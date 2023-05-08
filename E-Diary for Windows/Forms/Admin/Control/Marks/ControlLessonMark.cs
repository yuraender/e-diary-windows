using E_Diary_for_Windows.Entities;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace E_Diary_for_Windows.Forms.Admin.Control.Marks {
    public partial class ControlLessonMark : Form {

        private readonly Lesson lesson;

        public ControlLessonMark(Form owner, Lesson lesson) {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Owner = owner;
            this.lesson = lesson;
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

            RestRequest request = new RestRequest("marks", Method.POST);
            request.AddParameter("user_id",
                ((User) userBox.SelectedItem).ID, ParameterType.QueryString);
            request.AddJsonBody(new {
                mark = ((MarkTypeName) markBox.SelectedItem).ID.ToString()
            });
            EDiaryAPI.API.RequestAsync<JObject>(request, r => {
                Mark mark = r.ToObject<Mark>();
                RestRequest markRequest = new RestRequest("lessons/{id}/addMark", Method.POST);
                markRequest.AddUrlSegment("id", lesson.ID);
                markRequest.AddParameter("id", mark.ID);
                EDiaryAPI.API.RequestAsync<object>(markRequest, null);
            });

            Close();
        }

        private void LoadElements() {
            foreach (MarkType type in Enum.GetValues(typeof(MarkType))) {
                markBox.Items.Add(new MarkTypeName(type));
            }
            markBox.SelectedIndex = 0;
            lessonBox.Items.Add(lesson);
            lessonBox.SelectedIndex = 0;
            RestRequest request = new RestRequest("users", Method.GET);
            request.AddParameter("group_id", lesson.Group.ID);
            EDiaryAPI.API.RequestAsync<JArray>(request, r => {
                r.ToObject<List<User>>().ForEach(user => {
                    userBox.Items.Add(user);
                });
            });
        }

        private void lessonBox_SelectedIndexChanged(object sender, EventArgs e) {
            Lesson lesson = (Lesson) lessonBox.SelectedItem;
            lessonLabel.Text = $"{lesson.Group.Name}, {lesson.Subject.Name},"
                + $" {Lesson.GetType(lesson.Type)} {lesson.ToString()}";
            new ToolTip().SetToolTip(lessonLabel, lessonLabel.Text);
        }
    }
}
