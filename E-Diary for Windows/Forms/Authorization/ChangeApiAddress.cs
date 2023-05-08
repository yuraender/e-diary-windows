using E_Diary_for_Windows.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace E_Diary_for_Windows.Forms.Authorization {
    public partial class ChangeApiAddress : Form {

        public Button button;

        public ChangeApiAddress() {
            InitializeComponent();
            button = changeButton;
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            apiBox.Text = Settings.Default["ApiAddress"].ToString();
        }

        private void changeButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(apiBox.Text)) {
                MessageBox.Show("Сервер не может быть таким.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Settings.Default["ApiAddress"] = apiBox.Text;
            Settings.Default.Save();
            Close();
        }
    }
}
