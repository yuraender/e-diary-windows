using E_Diary_for_Windows.Entities;
using RestSharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using Type = E_Diary_for_Windows.Forms.Admin.AdminForm.Type;

namespace E_Diary_for_Windows.Forms.Admin.Control.Marks {
    public partial class ControlMark : Form {

        private readonly Mark mark;

        public ControlMark(Form owner, Mark mark) {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Owner = owner;
            this.mark = mark;
        }

        private void ControlGroup_Load(object sender, EventArgs e) {
            LoadElements();
        }

        private void createButton_Click(object sender, EventArgs e) {
            if (userBox.SelectedIndex == -1) {
                MessageBox.Show("Введены неверные данные.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RestRequest request = new RestRequest("marks/{id}", Method.PUT);
            request.AddUrlSegment("id", mark.ID);
            request.AddParameter("user_id",
                ((User) userBox.SelectedItem).ID, ParameterType.QueryString);
            request.AddJsonBody(new {
                mark = ((MarkTypeName) markBox.SelectedItem).ID.ToString()
            });
            EDiaryAPI.API.RequestAsync<object>(request, r => {
                ((AdminForm) Owner).LoadTab(Type.Marks);
            });

            Close();
        }

        private void LoadElements() {
            foreach (MarkType type in Enum.GetValues(typeof(MarkType))) {
                markBox.Items.Add(new MarkTypeName(type));
            }
            markBox.SelectedItem = new MarkTypeName(mark.MarK);
            userBox.Items.Add(mark.User);
            userBox.SelectedIndex = 0;
        }
    }
}
