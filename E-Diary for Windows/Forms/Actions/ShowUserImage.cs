using E_Diary_for_Windows.Entities;
using E_Diary_for_Windows.Utils;
using System.Drawing;
using System.Windows.Forms;

namespace E_Diary_for_Windows.Forms.Actions {
    public partial class ShowUserImage : Form {
        public ShowUserImage(User user) {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Text = user.Login;
            imageBox.Image = ImageUtils.LoadImage(user.Image);
            Size = new Size(imageBox.Image.Size.Width + 16, imageBox.Image.Size.Height + 39);
        }
    }
}
