using E_Diary_for_Windows.Entities;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CuAction = E_Diary_for_Windows.Forms.Admin.AdminForm.CuAction;
using Group = E_Diary_for_Windows.Entities.Group;
using Type = E_Diary_for_Windows.Forms.Admin.AdminForm.Type;

namespace E_Diary_for_Windows.Forms.Admin.Control {
    public partial class ControlUser : Form {

        private readonly User user;
        private readonly CuAction action;
        private readonly bool isAdmin;

        private readonly List<Role> toAddRoles = new List<Role>();
        private readonly List<Role> toRemoveRoles = new List<Role>();
        private readonly List<Group> toAddGroups = new List<Group>();
        private readonly List<Group> toRemoveGroups = new List<Group>();

        public ControlUser(Form owner, User user, CuAction action, bool isAdmin) {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Owner = owner;
            this.user = user;
            this.action = action;
            this.isAdmin = isAdmin;
        }

        private void ControlUser_Load(object sender, EventArgs e) {
            if (action == CuAction.Create) {
                Text = "Добавление";
                createUpdateButton.Text = "Добавить";
            } else {
                Text = "Обновление";
                createUpdateButton.Text = "Обновить";

                nameBox.Text = user.Name;
                datePicker.Value = user.BirthDate;
                loginBox.Text = user.Login;
                emailBox.Text = user.Email;
            }

            if (!isAdmin) {
                nameBox.Enabled = false;
                datePicker.Enabled = false;
                loginBox.Enabled = false;
                emailBox.Enabled = false;
                rolesGroupBox.Visible = false;
                groupsGroupBox.Visible = false;
                Size = new Size(300, 400);
            } else {
                LoadElements();
            }
        }

        private void createUpdateButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(nameBox.Text)
                || string.IsNullOrEmpty(loginBox.Text)
                || string.IsNullOrEmpty(emailBox.Text)) {
                MessageBox.Show("Введены неверные данные.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(emailBox.Text,
                "^[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,6}$", RegexOptions.IgnoreCase)) {
                MessageBox.Show("Введен неверный адрес электронной почты.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (requiredRoleList.Items.Count == 0) {
                MessageBox.Show("Пользователь должен иметь хотя бы одну роль.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RestRequest request;
            if (action == CuAction.Create) {
                request = new RestRequest("users", Method.POST);
            } else {
                request = new RestRequest("users/{id}", Method.PUT);
                request.AddUrlSegment("id", user.ID);
            }
            request.AddJsonBody(new {
                name = nameBox.Text,
                birthDate = datePicker.Value.ToString("yyyy-MM-dd"),
                login = loginBox.Text, password = passwordBox.Text,
                email = emailBox.Text
            });
            EDiaryAPI.API.RequestAsync<JObject>(request, r => {
                User user = r.ToObject<User>();
                foreach (Role role in toAddRoles) {
                    RestRequest roleRequest = new RestRequest("users/{id}/addRole", Method.POST);
                    roleRequest.AddUrlSegment("id", user.ID);
                    roleRequest.AddParameter("role", role.Name);
                    EDiaryAPI.API.RequestAsync<object>(roleRequest, null);
                }
                foreach (Role role in toRemoveRoles) {
                    RestRequest roleRequest = new RestRequest("users/{id}/removeRole", Method.POST);
                    roleRequest.AddUrlSegment("id", user.ID);
                    roleRequest.AddParameter("role", role.Name);
                    EDiaryAPI.API.RequestAsync<object>(roleRequest, null);
                }
                foreach (Group group in toAddGroups) {
                    RestRequest groupRequest = new RestRequest("users/{id}/addGroup", Method.POST);
                    groupRequest.AddUrlSegment("id", user.ID);
                    groupRequest.AddParameter("id", group.ID);
                    EDiaryAPI.API.RequestAsync<object>(groupRequest, null);
                }
                foreach (Group group in toRemoveGroups) {
                    RestRequest groupRequest = new RestRequest("users/{id}/removeGroup", Method.POST);
                    groupRequest.AddUrlSegment("id", user.ID);
                    groupRequest.AddParameter("id", group.ID);
                    EDiaryAPI.API.RequestAsync<object>(groupRequest, null);
                }
                if (Owner is AdminForm) {
                    ((AdminForm) Owner).LoadTab(Type.Users);
                }
            });

            Close();
        }

        private void addRoleButton_Click(object sender, EventArgs e) {
            foreach (int index in fullRoleList.SelectedIndices) {
                requiredRoleList.Items.Add(fullRoleList.Items[index]);
                toAddRoles.Add((Role) fullRoleList.Items[index]);
                toRemoveRoles.Remove((Role) fullRoleList.Items[index]);
                fullRoleList.Items.RemoveAt(index);
            }
        }

        private void removeRoleButton_Click(object sender, EventArgs e) {
            foreach (int index in requiredRoleList.SelectedIndices) {
                fullRoleList.Items.Add(requiredRoleList.Items[index]);
                toAddRoles.Remove((Role) requiredRoleList.Items[index]);
                toRemoveRoles.Add((Role) requiredRoleList.Items[index]);
                requiredRoleList.Items.RemoveAt(index);
            }
        }

        private void addGroupButton_Click(object sender, EventArgs e) {
            foreach (int index in fullGroupList.SelectedIndices) {
                requiredGroupList.Items.Add(fullGroupList.Items[index]);
                toAddGroups.Add((Group) fullGroupList.Items[index]);
                toRemoveGroups.Remove((Group) fullGroupList.Items[index]);
                fullGroupList.Items.RemoveAt(index);
            }
        }

        private void removeGroupButton_Click(object sender, EventArgs e) {
            foreach (int index in requiredGroupList.SelectedIndices) {
                fullGroupList.Items.Add(requiredGroupList.Items[index]);
                toAddGroups.Remove((Group) requiredGroupList.Items[index]);
                toRemoveGroups.Add((Group) requiredGroupList.Items[index]);
                requiredGroupList.Items.RemoveAt(index);
            }
        }

        private void LoadElements() {
            EDiaryAPI.API
                .RequestAsync<JArray>(new RestRequest("users/roles", Method.OPTIONS), r => {
                    r.ToObject<List<Role>>().ForEach(role => {
                        if (action == CuAction.Create || !user.Roles.Contains(role)) {
                            fullRoleList.Items.Add(role);
                        } else {
                            requiredRoleList.Items.Add(role);
                        }
                    });
                });
            EDiaryAPI.API
                .RequestAsync<JArray>(new RestRequest("groups", Method.GET), r => {
                    r.ToObject<List<Group>>().ForEach(group => {
                        if (action == CuAction.Create || !user.Groups.Contains(group)) {
                            fullGroupList.Items.Add(group);
                        } else {
                            requiredGroupList.Items.Add(group);
                        }
                    });
                });
        }
    }
}
