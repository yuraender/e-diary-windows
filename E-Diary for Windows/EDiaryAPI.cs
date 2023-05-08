using E_Diary_for_Windows.Entities;
using E_Diary_for_Windows.Forms.Authorization;
using E_Diary_for_Windows.Properties;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Text;
using System.Windows.Forms;

namespace E_Diary_for_Windows {
    public class EDiaryAPI : RestClient {

        public static EDiaryAPI API {
            get; private set;
        }
        public User CurrentUser {
            get; private set;
        }

        public EDiaryAPI(string token)
            : base((string) Settings.Default["ApiAddress"]) {
            API = this;
            if (!string.IsNullOrEmpty(token)) {
                Login(token, true);
            }
            Encoding = Encoding.UTF8;
        }

        public T Request<T>(RestRequest request) {
            object response = null;
            try {
                string responseStr = Execute(request).Content;
                if (responseStr.Contains("Insufficient permissions")) {
                    MessageBox.Show("У вас нет прав.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (typeof(T) == typeof(JObject)) {
                    response = JObject.Parse(responseStr);
                } else if (typeof(T) == typeof(JArray)) {
                    response = JArray.Parse(responseStr);
                } else {
                    response = Convert.ChangeType(responseStr, typeof(T));
                }
            } catch {
                DialogResult result = MessageBox.Show(
                    "Не удалось получить ответ от сервера.", "",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry) {
                    response = Request<T>(request);
                } else {
                    ChangeApiAddress changeApiAddress = new ChangeApiAddress();
                    changeApiAddress.button.Click += (s, args) => {
                        changeApiAddress.Hide();
                        response = Request<T>(request);
                    };
                    changeApiAddress.ShowDialog();
                }
            }
            return (T) response;
        }

        public async void RequestAsync<T>(RestRequest request, Action<T> task) {
            object response = null;
            try {
                IRestResponse resp = await ExecuteAsync(request);
                string responseStr = resp.Content;
                if (responseStr.Contains("Insufficient permissions")) {
                    MessageBox.Show("У вас нет прав.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (typeof(T) == typeof(JObject)) {
                    response = JObject.Parse(responseStr);
                } else if (typeof(T) == typeof(JArray)) {
                    response = JArray.Parse(responseStr);
                } else {
                    response = Convert.ChangeType(responseStr, typeof(T));
                }
                if (task != null) {
                    task.Invoke((T) response);
                }
            } catch {
                DialogResult result = MessageBox.Show(
                    "Не удалось получить ответ от сервера.", "",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry) {
                    RequestAsync(request, task);
                } else {
                    ChangeApiAddress changeApiAddress = new ChangeApiAddress();
                    changeApiAddress.button.Click += (s, args) => {
                        changeApiAddress.Hide();
                        RequestAsync(request, task);
                    };
                    changeApiAddress.ShowDialog();
                }
            }
        }

        public void Login(string token, bool save) {
            JObject response;
            if ((response = IsTokenValid(token)) != null) {
                int id = (int) response.GetValue("user");
                if (save) {
                    Settings.Default["Token"] = token;
                    Settings.Default.Save();
                }
                Authenticator = token != null ? new JwtAuthenticator(token) : null;
                CurrentUser = Request<JObject>(
                    new RestRequest($"users/{id}", Method.GET)).ToObject<User>();
            }
        }

        public JObject IsTokenValid() {
            return IsTokenValid((string) Settings.Default["Token"]);
        }

        public JObject IsTokenValid(string token) {
            RestRequest request = new RestRequest("login", Method.GET);
            request.AddParameter("token", token);
            JObject response = Request<JObject>(request);
            return response.ContainsKey("message")
                && ((string) response.GetValue("message")).Contains("Token is valid")
                ? response : null;
        }

        public void Logout() {
            Settings.Default["Token"] = null;
            Settings.Default.Save();
        }
    }
}
