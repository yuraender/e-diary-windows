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
    public partial class ControlSubject : Form {

        private readonly Subject subject;
        private readonly CuAction action;

        public ControlSubject(Form owner, Subject subject, CuAction action) {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Owner = owner;
            this.subject = subject;
            this.action = action;
        }

        private void ControlSubject_Load(object sender, EventArgs e) {
            LoadElements();

            if (action == CuAction.Create) {
                Text = "Добавление";
                createUpdateButton.Text = "Добавить";
                teacherBox.SelectedIndex = 0;
            } else {
                Text = "Обновление";
                createUpdateButton.Text = "Обновить";
                nameBox.Text = subject.Name;
            }
        }

        private void createUpdateButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(nameBox.Text)) {
                MessageBox.Show("Введены неверные данные.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RestRequest request;
            if (action == CuAction.Create) {
                request = new RestRequest("subjects", Method.POST);
            } else {
                request = new RestRequest("subjects/{id}", Method.PUT);
                request.AddUrlSegment("id", subject.ID);
            }
            request.AddJsonBody(new {
                name = nameBox.Text
            });
            EDiaryAPI.API.RequestAsync<JObject>(request, r => {
                Subject subject = r.ToObject<Subject>();
                RestRequest teacherRequest = new RestRequest("subjects/{id}/setTeacher", Method.POST);
                teacherRequest.AddUrlSegment("id", subject.ID);
                if (teacherBox.SelectedIndex != 0) {
                    teacherRequest.AddParameter("id", ((User) teacherBox.SelectedItem).ID);
                }
                EDiaryAPI.API.RequestAsync<object>(teacherRequest, null);
                ((AdminForm) Owner).LoadTab(Type.Subjects);
            });

            Close();
        }

        private void LoadElements() {
            EDiaryAPI.API
                .RequestAsync<JArray>(new RestRequest("users", Method.GET), r => {
                    r.ToObject<List<User>>().ForEach(user => {
                        teacherBox.Items.Add(user);
                    });
                    if (subject != null) {
                        teacherBox.SelectedItem = subject.Teacher != null
                            ? subject.Teacher : teacherBox.Items[0];
                    }
                });
        }
    }
}
