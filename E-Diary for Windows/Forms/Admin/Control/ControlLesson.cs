using E_Diary_for_Windows.Entities;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CuAction = E_Diary_for_Windows.Forms.Admin.AdminForm.CuAction;
using Type = E_Diary_for_Windows.Forms.Admin.AdminForm.Type;

namespace E_Diary_for_Windows.Forms.Admin.Control {
    public partial class ControlLesson : Form {

        private readonly Lesson lesson;
        private readonly Group group;
        private readonly Subject subject;
        private readonly CuAction action;

        public ControlLesson(Form owner,
            Lesson lesson, Group group, Subject subject, CuAction action) {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Owner = owner;
            this.lesson = lesson;
            this.group = group;
            this.subject = subject;
            this.action = action;
        }

        private void ControlGroup_Load(object sender, EventArgs e) {
            LoadElements();

            if (action == CuAction.Create) {
                Text = "Добавление";
                createUpdateButton.Text = "Добавить";
                typeBox.SelectedIndex = 0;
            } else {
                Text = "Обновление";
                createUpdateButton.Text = "Обновить";
                typeBox.SelectedItem = new LessonTypeName(lesson.Type);
                termBox.Text = lesson.Term.ToString();
                dateTimePicker.Value = lesson.Date;
                lessonBox.Text = lesson.LessoN.ToString();
                groupBox.Enabled = subjectBox.Enabled = false;
            }
        }

        private void groupBox_SelectedIndexChanged(object sender, EventArgs e) {
            subjectBox.Items.Clear();
            foreach (Subject subject in ((Group) groupBox.SelectedItem).Subjects) {
                subjectBox.Items.Add(subject);
            }
            if (subject != null) {
                subjectBox.SelectedItem = subject;
            }
        }

        private void createUpdateButton_Click(object sender, EventArgs e) {
            if (!int.TryParse(termBox.Text, out int t)
                || !int.TryParse(lessonBox.Text, out int l)
                || groupBox.SelectedIndex == -1 || subjectBox.SelectedIndex == -1) {
                MessageBox.Show("Введены неверные данные.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RestRequest request;
            if (action == CuAction.Create) {
                request = new RestRequest("lessons", Method.POST);
                request.AddParameter("group_id",
                    ((Group) groupBox.SelectedItem).ID, ParameterType.QueryString);
                request.AddParameter("subject_id",
                    ((Subject) subjectBox.SelectedItem).ID, ParameterType.QueryString);
            } else {
                request = new RestRequest("lessons/{id}", Method.PUT);
                request.AddUrlSegment("id", lesson.ID);
            }
            request.AddJsonBody(new {
                type = ((LessonTypeName) typeBox.SelectedItem).ID.ToString(),
                term = t,
                date = dateTimePicker.Value.ToString("yyyy-MM-dd"),
                lesson = l
            });
            EDiaryAPI.API.RequestAsync<object>(request, r => {
                ((AdminForm) Owner).LoadTab(Type.Groups);
                ((AdminForm) Owner).LoadTab(Type.Lessons);
            });

            Close();
        }

        private void LoadElements() {
            foreach (LessonType type in Enum.GetValues(typeof(LessonType))) {
                typeBox.Items.Add(new LessonTypeName(type));
            }
            EDiaryAPI.API
                .RequestAsync<JArray>(new RestRequest("groups", Method.GET), r => {
                    r.ToObject<List<Group>>().ForEach(group => {
                        groupBox.Items.Add(group);
                    });
                    if (group != null) {
                        groupBox.SelectedItem = group;
                    }
                });
        }
    }
}
