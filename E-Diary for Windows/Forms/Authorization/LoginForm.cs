using E_Diary_for_Windows.Utils;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace E_Diary_for_Windows.Forms.Authorization {
    public partial class LoginForm : Form {

        private string captcha;

        public LoginForm() {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void LoginForm_Load(object sender, EventArgs e) {
            Captcha captcha = new Captcha();
            this.captcha = captcha.ProcessRequest(captchaBox);
        }

        private void loginButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(usernameTextBox.Text)
                || string.IsNullOrEmpty(passwordTextBox.Text)) {
                MessageBox.Show("Введите имя пользователя и пароль.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!captchaTextBox.Text.Equals(captcha)) {
                MessageBox.Show("Вы неправильно ввели капчу.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RestRequest request = new RestRequest("login", Method.POST);
            request.AddParameter("username", usernameTextBox.Text);
            request.AddParameter("password", passwordTextBox.Text);
            JObject response = EDiaryAPI.API.Request<JObject>(request);
            if (response.ContainsKey("access_token")) {
                string token = (string) response.GetValue("access_token");
                EDiaryAPI.API.Login(token.Split(' ')[1], rememberCheckBox.Checked);

                Hide();
                MainForm mainForm = new MainForm(rememberCheckBox.Checked);
                mainForm.Closed += (s, args) => Close();
                mainForm.Show();
            } else {
                MessageBox.Show("Неверное имя пользователя или пароль.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void forgotLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (string.IsNullOrEmpty(usernameTextBox.Text)) {
                MessageBox.Show("Введите имя пользователя или почту.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new ForgotPassword(usernameTextBox.Text).ShowDialog();
        }

        private void apiLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            new ChangeApiAddress().ShowDialog();
        }

        private void captchaBox_MouseClick(object sender, EventArgs e) {
            captchaBox.Image = null;
            Captcha captcha = new Captcha();
            this.captcha = captcha.ProcessRequest(captchaBox);
        }
    }
}
