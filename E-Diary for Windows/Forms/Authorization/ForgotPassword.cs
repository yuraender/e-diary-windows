using RestSharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace E_Diary_for_Windows.Forms.Authorization {
    public partial class ForgotPassword : Form {

        private readonly string username;

        public ForgotPassword(string username) {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.username = username;
        }

        private void sendButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(codeBox.Text)) {
                MessageBox.Show("Вы не ввели код подтверждения.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RestRequest request = new RestRequest("login/forgot", Method.POST);
            request.AddParameter("username", username);
            request.AddParameter("code", codeBox.Text);
            EDiaryAPI.API.RequestAsync<string>(request, r => {
                if (!r.Contains("Incorrect code")) {
                    MessageBox.Show(
                        "На почту отправлен новый пароль от аккаунта.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                } else {
                    MessageBox.Show("Вы ввели неверный код подтверждения.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
        }

        private void ForgotPassword_Load(object sender, EventArgs e) {
            RestRequest request = new RestRequest("login/forgot", Method.POST);
            request.AddParameter("username", username);
            EDiaryAPI.API.RequestAsync<object>(request, r => {
                MessageBox.Show(
                    "На почту отправлен код для восстановления пароля.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }
    }
}
