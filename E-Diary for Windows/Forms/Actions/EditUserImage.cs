using E_Diary_for_Windows.Entities;
using E_Diary_for_Windows.Utils;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace E_Diary_for_Windows.Forms.Actions {
    public partial class EditUserImage : Form {

        private readonly User user;
        private readonly List<PictureBox> pictureBoxes;
        private string imagePath;

        public EditUserImage(User user, List<PictureBox> pictureBoxes) {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.user = user;
            this.pictureBoxes = pictureBoxes;
        }

        private void EditUserImage_Load(object sender, EventArgs e) {
            Text = user.Login;
            imageBox.Image = ImageUtils.LoadImage(user.Image);
        }

        private void imageBox_Click(object sender, EventArgs e) {
            new ShowUserImage(user).ShowDialog();
        }

        private void browseButton_Click(object sender, EventArgs e) {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) {
                imagePath = openFileDialog.FileName;
                imageNameBox.Text = Path.GetFileName(openFileDialog.FileName);
                imageBox.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void updateImageButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(imagePath)) {
                return;
            }
            RestRequest request = new RestRequest("users/{id}/setImage", Method.POST);
            request.AddUrlSegment("id", user.ID);
            request.AddFile("image", imagePath);
            EDiaryAPI.API.RequestAsync<JObject>(request, r => {
                User user = r.ToObject<User>();
                foreach (PictureBox pictureBox in pictureBoxes) {
                    pictureBox.Image = ImageUtils.LoadImage(user.Image);
                }
                Close();
            });
        }

        private void deleteImageButton_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить аватар?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) {
                RestRequest request = new RestRequest("users/{id}/setImage", Method.POST);
                request.AddUrlSegment("id", user.ID);
                EDiaryAPI.API.RequestAsync<JObject>(request, r => {
                    User user = r.ToObject<User>();
                    foreach (PictureBox pictureBox in pictureBoxes) {
                        pictureBox.Image = ImageUtils.LoadImage(user.Image);
                    }
                    Close();
                });
            }
        }
    }
}
