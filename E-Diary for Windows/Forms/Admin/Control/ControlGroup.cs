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
    public partial class ControlGroup : Form {

        private readonly Group group;
        private readonly CuAction action;

        private readonly List<Subject> toAddSubjects = new List<Subject>();
        private readonly List<Subject> toRemoveSubjects = new List<Subject>();

        public ControlGroup(Form owner, Group group, CuAction action) {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Owner = owner;
            this.group = group;
            this.action = action;
        }

        private void ControlGroup_Load(object sender, EventArgs e) {
            LoadElements();

            if (action == CuAction.Create) {
                Text = "Добавление";
                createUpdateButton.Text = "Добавить";
                gradeBox.SelectedIndex = 0;
                teacherBox.SelectedIndex = 0;
            } else {
                Text = "Обновление";
                createUpdateButton.Text = "Обновить";
                nameBox.Text = group.Name;
                fullNameBox.Text = group.FullName;
                gradeBox.SelectedItem = new GroupGradeName(group.Grade);
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
                request = new RestRequest("groups", Method.POST);
            } else {
                request = new RestRequest("groups/{id}", Method.PUT);
                request.AddUrlSegment("id", group.ID);
            }
            request.AddJsonBody(new {
                name = nameBox.Text,
                fullName = fullNameBox.Text,
                grade = ((GroupGradeName) gradeBox.SelectedItem).ID.ToString()
            });
            EDiaryAPI.API.RequestAsync<JObject>(request, r => {
                Group group = r.ToObject<Group>();
                RestRequest teacherRequest = new RestRequest("groups/{id}/setTeacher", Method.POST);
                teacherRequest.AddUrlSegment("id", group.ID);
                if (teacherBox.SelectedIndex != 0) {
                    teacherRequest.AddParameter("id", ((User) teacherBox.SelectedItem).ID);
                }
                EDiaryAPI.API.RequestAsync<object>(teacherRequest, null);

                foreach (Subject subject in toAddSubjects) {
                    RestRequest subjectRequest = new RestRequest("groups/{id}/addSubject", Method.POST);
                    subjectRequest.AddUrlSegment("id", group.ID);
                    subjectRequest.AddParameter("id", subject.ID);
                    EDiaryAPI.API.RequestAsync<object>(subjectRequest, null);
                }
                foreach (Subject subject in toRemoveSubjects) {
                    RestRequest subjectRequest = new RestRequest("groups/{id}/removeSubject", Method.POST);
                    subjectRequest.AddUrlSegment("id", group.ID);
                    subjectRequest.AddParameter("id", subject.ID);
                    EDiaryAPI.API.RequestAsync<object>(subjectRequest, null);
                }
                ((AdminForm) Owner).LoadTab(Type.Groups);
            });

            Close();
        }

        private void addRoleButton_Click(object sender, EventArgs e) {
            foreach (int index in fullSubjectList.SelectedIndices) {
                requiredSubjectList.Items.Add(fullSubjectList.Items[index]);
                toAddSubjects.Add((Subject) fullSubjectList.Items[index]);
                toRemoveSubjects.Remove((Subject) fullSubjectList.Items[index]);
                fullSubjectList.Items.RemoveAt(index);
            }
        }

        private void removeRoleButton_Click(object sender, EventArgs e) {
            foreach (int index in requiredSubjectList.SelectedIndices) {
                fullSubjectList.Items.Add(requiredSubjectList.Items[index]);
                toAddSubjects.Remove((Subject) requiredSubjectList.Items[index]);
                toRemoveSubjects.Add((Subject) requiredSubjectList.Items[index]);
                requiredSubjectList.Items.RemoveAt(index);
            }
        }

        private void LoadElements() {
            foreach (GroupGrade grade in Enum.GetValues(typeof(GroupGrade))) {
                gradeBox.Items.Add(new GroupGradeName(grade));
            }
            EDiaryAPI.API
                .RequestAsync<JArray>(new RestRequest("users", Method.GET), r => {
                    r.ToObject<List<User>>().ForEach(user => {
                        teacherBox.Items.Add(user);
                    });
                    if (group != null) {
                        teacherBox.SelectedItem = group.Teacher != null
                            ? group.Teacher : teacherBox.Items[0];
                    }
                });
            EDiaryAPI.API
                .RequestAsync<JArray>(new RestRequest("subjects", Method.GET), r => {
                    r.ToObject<List<Subject>>().ForEach(subject => {
                        if (action == CuAction.Create || !group.Subjects.Contains(subject)) {
                            fullSubjectList.Items.Add(subject);
                        } else {
                            requiredSubjectList.Items.Add(subject);
                        }
                    });
                });
        }
    }
}
