using E_Diary_for_Windows.Entities;
using E_Diary_for_Windows.Forms.Actions;
using E_Diary_for_Windows.Forms.Admin.Control;
using E_Diary_for_Windows.Forms.Admin.Control.Marks;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Diary_for_Windows.Forms.Admin {
    public partial class AdminForm : Form {
        public AdminForm() {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(
                System.Windows.Forms.Application.ExecutablePath);
        }

        private void AdminForm_Load(object sender, EventArgs e) {
            LoadTab(Type.Users);
            LoadElements();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl.SelectedIndex == 0) {
                LoadTab(Type.Users);
            } else if (tabControl.SelectedIndex == 1) {
                LoadTab(Type.Groups);
            } else if (tabControl.SelectedIndex == 2) {
                LoadTab(Type.Subjects);
            } else if (tabControl.SelectedIndex == 3) {
                LoadTab(Type.Lessons);
            } else {
                LoadTab(Type.Marks);
            }
        }

        //Users
        private void userGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
            User user = (User) userGridView.CurrentRow.DataBoundItem;
            userRolesGridView.DataSource = user.Roles;
            userRolesGridView.Columns["Name"].HeaderText = "Название";
            userGroupsGridView.Columns.Clear();
            userGroupsGridView.DataSource = user.Groups;
            userGroupsGridView.Columns["Name"].HeaderText = "Название";
            userGroupsGridView.Columns["FullName"].Visible = false;
            userGroupsGridView.Columns.RemoveAt(3);
            userGroupsGridView.Columns.Insert(3, new DataGridViewTextBoxColumn());
            userGroupsGridView.Columns[3].HeaderText = "Класс";
            foreach (DataGridViewRow row in userGroupsGridView.Rows) {
                row.Cells[3].Value = new GroupGradeName(user.Groups[row.Index].Grade).Name;
            }
            userGroupsGridView.Columns["Teacher"].Visible = false;
        }

        private void userSearchButton_Click(object sender, EventArgs e) {
            LoadTab(Type.Users);
        }


        private void userExcelButton_Click(object sender, EventArgs e) {
            RunExcel(Type.Users);
        }

        private void userImageButton_Click(object sender, EventArgs e) {
            if (userGridView.CurrentRow != null) {
                User user = (User) userGridView.CurrentRow.DataBoundItem;
                new ShowUserImage(user).ShowDialog();
            }
        }

        private void userEditImageButton_Click(object sender, EventArgs e) {
            if (userGridView.CurrentRow != null) {
                User user = (User) userGridView.CurrentRow.DataBoundItem;
                new EditUserImage(user, new List<PictureBox>()).ShowDialog();
            }
        }

        private void userCreateButton_Click(object sender, EventArgs e) {
            new ControlUser(this, null, CuAction.Create, true).ShowDialog();
        }

        private void userUpdateButton_Click(object sender, EventArgs e) {
            if (userGridView.CurrentRow != null) {
                User user = (User) userGridView.CurrentRow.DataBoundItem;
                new ControlUser(this, user, CuAction.Update, true).ShowDialog();
            }
        }

        private void userDeleteButton_Click(object sender, EventArgs e) {
            DeleteItem(Type.Users);
        }

        //Groups
        private void groupGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
            groupSubjectsGridView.DataSource = ((Group) groupGridView.CurrentRow.DataBoundItem).Subjects;
            groupSubjectsGridView.Columns["Name"].HeaderText = "Название";
            groupSubjectsGridView.Columns["Teacher"].Visible = false;
            groupLessonGridView.Columns.Clear();
            groupLessonGridView.DataSource = null;
        }

        private void groupSubjectsGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
            RestRequest request = new RestRequest("lessons", Method.GET);
            request.AddParameter("group_id", ((Group) groupGridView.CurrentRow.DataBoundItem).ID);
            request.AddParameter("subject_id", ((Subject) groupSubjectsGridView.CurrentRow.DataBoundItem).ID);
            EDiaryAPI.API.RequestAsync<JArray>(request, r => {
                List<Lesson> lessons = r.ToObject<List<Lesson>>();
                groupLessonGridView.Columns.Clear();
                groupLessonGridView.DataSource = lessons;
                groupLessonGridView.Columns.RemoveAt(1);
                groupLessonGridView.Columns.Insert(1, new DataGridViewTextBoxColumn());
                groupLessonGridView.Columns[1].HeaderText = "Тип";
                foreach (DataGridViewRow row in groupLessonGridView.Rows) {
                    row.Cells[1].Value = Lesson.GetType(lessons[row.Index].Type);
                }
                groupLessonGridView.Columns["Term"].HeaderText = "Четверть/семестр";
                groupLessonGridView.Columns["Date"].HeaderText = "Дата";
                groupLessonGridView.Columns["LessoN"].HeaderText = "Урок";
                groupLessonGridView.Columns["Group"].Visible = false;
                groupLessonGridView.Columns["Subject"].Visible = false;
            });
        }

        private void groupSearchButton_Click(object sender, EventArgs e) {
            LoadTab(Type.Groups);
        }

        private void groupExcelButton_Click(object sender, EventArgs e) {
            RunExcel(Type.Groups);
        }

        private void groupAddLesson_Click(object sender, EventArgs e) {
            Group group = groupGridView.CurrentRow != null
                ? (Group) groupGridView.CurrentRow.DataBoundItem : null;
            Subject subject = groupSubjectsGridView.CurrentRow != null
                ? (Subject) groupSubjectsGridView.CurrentRow.DataBoundItem : null;
            new ControlLesson(this, null, group, subject, CuAction.Create).ShowDialog();
        }

        private void groupCreateButton_Click(object sender, EventArgs e) {
            new ControlGroup(this, null, CuAction.Create).ShowDialog();
        }

        private void groupUpdateButton_Click(object sender, EventArgs e) {
            if (groupGridView.CurrentRow != null) {
                Group group = (Group) groupGridView.CurrentRow.DataBoundItem;
                new ControlGroup(this, group, CuAction.Update).ShowDialog();
            }
        }

        private void groupDeleteButton_Click(object sender, EventArgs e) {
            DeleteItem(Type.Groups);
        }

        //Subjects
        private void subjectSearchButton_Click(object sender, EventArgs e) {
            LoadTab(Type.Subjects);
        }

        private void subjectExcelButton_Click(object sender, EventArgs e) {
            RunExcel(Type.Subjects);
        }

        private void subjectCreateButton_Click(object sender, EventArgs e) {
            new ControlSubject(this, null, CuAction.Create).ShowDialog();
        }

        private void subjectUpdateButton_Click(object sender, EventArgs e) {
            if (subjectGridView.CurrentRow != null) {
                Subject subject = (Subject) subjectGridView.CurrentRow.DataBoundItem;
                new ControlSubject(this, subject, CuAction.Update).ShowDialog();
            }
        }

        private void subjectDeleteButton_Click(object sender, EventArgs e) {
            DeleteItem(Type.Subjects);
        }

        //Lessons
        private void lessonSearchButton_Click(object sender, EventArgs e) {
            LoadTab(Type.Lessons);
        }

        private void lessonExcelButton_Click(object sender, EventArgs e) {
            RunExcel(Type.Lessons);
        }

        private void lessonLessonMarkButton_Click(object sender, EventArgs e) {
            if (lessonGridView.CurrentRow != null) {
                Lesson lesson = (Lesson) lessonGridView.CurrentRow.DataBoundItem;
                new ControlLessonMark(this, lesson).ShowDialog();
            }
        }

        private void lessonHomeworkMarkButton_Click(object sender, EventArgs e) {
            if (lessonGridView.CurrentRow != null) {
                Lesson lesson = (Lesson) lessonGridView.CurrentRow.DataBoundItem;
                new ControlHomeworkMark(this, lesson).ShowDialog();
            }
        }

        private void lessonCreateButton_Click(object sender, EventArgs e) {
            new ControlLesson(this, null, null, null, CuAction.Create).ShowDialog();
        }

        private void lessonUpdateButton_Click(object sender, EventArgs e) {
            if (lessonGridView.CurrentRow != null) {
                Lesson lesson = (Lesson) lessonGridView.CurrentRow.DataBoundItem;
                new ControlLesson(this,
                    lesson, lesson.Group, lesson.Subject, CuAction.Update).ShowDialog();
            }
        }

        private void lessonDeleteButton_Click(object sender, EventArgs e) {
            DeleteItem(Type.Lessons);
        }

        //Marks
        private void markSearchButton_Click(object sender, EventArgs e) {
            LoadTab(Type.Marks);
        }

        private void markExcelButton_Click(object sender, EventArgs e) {
            RunExcel(Type.Marks);
        }

        private void markUpdateButton_Click(object sender, EventArgs e) {
            if (markGridView.CurrentRow != null) {
                Mark mark = (Mark) markGridView.CurrentRow.DataBoundItem;
                new ControlMark(this, mark).ShowDialog();
            }
        }

        private void markDeleteButton_Click(object sender, EventArgs e) {
            DeleteItem(Type.Marks);
        }

        private void exitMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        public void LoadTab(Type type) {
            Task.Run(() => {
                if (type == Type.Users) {
                    List<User> users = new List<User>();
                    if (!string.IsNullOrEmpty(userSearchBox.Text)) {
                        RestRequest request;
                        if (userIdCheck.Checked && int.TryParse(userSearchBox.Text, out int id)) {
                            request = new RestRequest("users/{id}", Method.GET);
                            request.AddUrlSegment("id", id);
                            users.Add(EDiaryAPI.API.Request<JObject>(request).ToObject<User>());
                        } else if (userNameCheck.Checked) {
                            request = new RestRequest("users", Method.GET);
                            request.AddParameter("name", userSearchBox.Text);
                            if (userGroupCheck.SelectedIndex > 0) {
                                request.AddParameter("group_id", ((Group) userGroupCheck.SelectedItem).ID);
                            }
                            users = EDiaryAPI.API.Request<JArray>(request).ToObject<List<User>>();
                        } else {
                            request = new RestRequest("users/{id}", Method.GET);
                            request.AddUrlSegment("id", userSearchBox.Text);
                            request.AddParameter("is_login", true);
                            users.Add(EDiaryAPI.API.Request<JObject>(request).ToObject<User>());
                        }
                    } else {
                        RestRequest request = new RestRequest("users", Method.GET);
                        if (userGroupCheck.SelectedIndex > 0) {
                            request.AddParameter("group_id", ((Group) userGroupCheck.SelectedItem).ID);
                        }
                        users = EDiaryAPI.API.Request<JArray>(request).ToObject<List<User>>();
                    }
                    Invoke(new System.Action(() => {
                        userGridView.DataSource = users.Where(u => {
                            if (userGroupCheck.SelectedIndex < 1) {
                                return true;
                            }
                            return u.Groups.Any(g => {
                                return g.ID == ((Group) userGroupCheck.SelectedItem).ID;
                            });
                        }).ToList();
                        userGridView.Columns["Name"].HeaderText = "ФИО";
                        userGridView.Columns["BirthDate"].HeaderText = "Дата рождения";
                        userGridView.Columns["Login"].HeaderText = "Логин";
                        userGridView.Columns["Image"].Visible = false;
                        userRolesGridView.DataSource = null;
                        userGroupsGridView.Columns.Clear();
                        userGroupsGridView.DataSource = null;
                    }));
                } else if (type == Type.Groups) {
                    List<Group> groups = new List<Group>();
                    if (!string.IsNullOrEmpty(groupSearchBox.Text)) {
                        RestRequest request;
                        if (groupIdCheck.Checked && int.TryParse(groupSearchBox.Text, out int id)) {
                            request = new RestRequest("groups/{id}", Method.GET);
                            request.AddUrlSegment("id", id);
                            groups.Add(EDiaryAPI.API.Request<JObject>(request).ToObject<Group>());
                        } else if (groupNameCheck.Checked) {
                            request = new RestRequest("groups/{id}", Method.GET);
                            request.AddUrlSegment("id", groupSearchBox.Text);
                            request.AddParameter("is_name", true);
                            groups.Add(EDiaryAPI.API.Request<JObject>(request).ToObject<Group>());
                        } else {
                            request = new RestRequest("groups", Method.GET);
                            request.AddParameter("full_name", groupSearchBox.Text);
                            if (groupUserCheck.SelectedIndex > 0) {
                                request.AddParameter("teacher_id", ((User) groupUserCheck.SelectedItem).ID);
                            }
                            groups = EDiaryAPI.API.Request<JArray>(request).ToObject<List<Group>>();
                        }
                    } else {
                        RestRequest request = new RestRequest("groups", Method.GET);
                        if (groupUserCheck.SelectedIndex > 0) {
                            request.AddParameter("teacher_id", ((User) groupUserCheck.SelectedItem).ID);
                        }
                        groups = EDiaryAPI.API.Request<JArray>(request).ToObject<List<Group>>();
                    }
                    Invoke(new System.Action(() => {
                        groupGridView.Columns.Clear();
                        groupGridView.DataSource = groups.Where(g => {
                            if (groupUserCheck.SelectedIndex < 1) {
                                return true;
                            }
                            return g.Teacher != null
                                && g.Teacher.ID == ((User) groupUserCheck.SelectedItem).ID;
                        }).ToList();
                        groupGridView.Columns["Name"].HeaderText = "Название";
                        groupGridView.Columns["FullName"].HeaderText = "Расшифровка";
                        groupGridView.Columns.RemoveAt(3);
                        groupGridView.Columns.Insert(3, new DataGridViewTextBoxColumn());
                        groupGridView.Columns[3].HeaderText = "Класс";
                        foreach (DataGridViewRow row in groupGridView.Rows) {
                            row.Cells[3].Value = new GroupGradeName(
                                ((List<Group>) groupGridView.DataSource)[row.Index].Grade).Name;
                        }
                        groupGridView.Columns["Teacher"].HeaderText = "Руководитель";
                        groupSubjectsGridView.DataSource = null;
                        groupLessonGridView.DataSource = null;
                        groupLessonGridView.Columns.Clear();
                    }));
                } else if (type == Type.Subjects) {
                    List<Subject> subjects = new List<Subject>();
                    if (!string.IsNullOrEmpty(subjectSearchBox.Text)) {
                        RestRequest request;
                        if (subjectIdCheck.Checked && int.TryParse(subjectSearchBox.Text, out int id)) {
                            request = new RestRequest("subjects/{id}", Method.GET);
                            request.AddUrlSegment("id", id);
                            subjects.Add(EDiaryAPI.API.Request<JObject>(request).ToObject<Subject>());
                        } else {
                            request = new RestRequest("subjects", Method.GET);
                            request.AddParameter("name", subjectSearchBox.Text);
                            if (subjectUserCheck.SelectedIndex > 0) {
                                request.AddParameter("teacher_id", ((User) subjectUserCheck.SelectedItem).ID);
                            }
                            subjects = EDiaryAPI.API.Request<JArray>(request).ToObject<List<Subject>>();
                        }
                    } else {
                        RestRequest request = new RestRequest("subjects", Method.GET);
                        if (subjectUserCheck.SelectedIndex > 0) {
                            request.AddParameter("teacher_id", ((User) subjectUserCheck.SelectedItem).ID);
                        }
                        subjects = EDiaryAPI.API.Request<JArray>(request).ToObject<List<Subject>>();
                    }
                    Invoke(new System.Action(() => {
                        subjectGridView.DataSource = subjects.Where(s => {
                            if (subjectUserCheck.SelectedIndex < 1) {
                                return true;
                            }
                            return s.Teacher != null
                                && s.Teacher.ID == ((User) groupUserCheck.SelectedItem).ID;
                        }).ToList();
                        subjectGridView.Columns["Name"].HeaderText = "Название";
                        subjectGridView.Columns["Teacher"].HeaderText = "Руководитель";
                    }));
                } else if (type == Type.Lessons) {
                    List<Lesson> lessons = new List<Lesson>();
                    RestRequest request = new RestRequest("lessons", Method.GET);
                    if (lessonTypeCheck.SelectedIndex > 0) {
                        request.AddParameter("type",
                            ((LessonTypeName) lessonTypeCheck.SelectedItem).ID.ToString());
                    }
                    request.AddParameter("start_date", lessonStartDatePicker.Value.ToString("yyyy-MM-dd"));
                    request.AddParameter("end_date", lessonEndDatePicker.Value.ToString("yyyy-MM-dd"));
                    if (lessonGroupCheck.SelectedIndex > 0) {
                        request.AddParameter("group_id", ((Group) lessonGroupCheck.SelectedItem).ID);
                    }
                    if (lessonSubjectCheck.SelectedIndex > 0) {
                        request.AddParameter("subject_id", ((Subject) lessonSubjectCheck.SelectedItem).ID);
                    }
                    lessons = EDiaryAPI.API.Request<JArray>(request).ToObject<List<Lesson>>();
                    Invoke(new System.Action(() => {
                        lessonGridView.Columns.Clear();
                        lessonGridView.DataSource = lessons;
                        lessonGridView.Columns.RemoveAt(1);
                        lessonGridView.Columns.Insert(1, new DataGridViewTextBoxColumn());
                        lessonGridView.Columns[1].HeaderText = "Тип";
                        foreach (DataGridViewRow row in lessonGridView.Rows) {
                            row.Cells[1].Value = Lesson.GetType(lessons[row.Index].Type);
                        }
                        lessonGridView.Columns["Term"].HeaderText = "Четверть/семестр";
                        lessonGridView.Columns["Date"].HeaderText = "Дата";
                        lessonGridView.Columns["LessoN"].HeaderText = "Урок";
                        lessonGridView.Columns["Group"].HeaderText = "Группа";
                        lessonGridView.Columns["Subject"].HeaderText = "Дисциплина";
                    }));
                } else {
                    List<Mark> marks = new List<Mark>();
                    RestRequest request = new RestRequest("marks", Method.GET);
                    if (markTypeCheck.SelectedIndex > 0) {
                        request.AddParameter("type",
                            ((MarkTypeName) markTypeCheck.SelectedItem).ID.ToString());
                    }
                    if (markUserCheck.SelectedIndex > 0) {
                        request.AddParameter("user_id", ((User) markUserCheck.SelectedItem).ID);
                    }
                    marks = EDiaryAPI.API.Request<JArray>(request).ToObject<List<Mark>>();
                    Invoke(new System.Action(() => {
                        markGridView.Columns.Clear();
                        markGridView.DataSource = marks;
                        markGridView.Columns.RemoveAt(1);
                        markGridView.Columns.Insert(1, new DataGridViewTextBoxColumn());
                        markGridView.Columns[1].HeaderText = "Оценка";
                        foreach (DataGridViewRow row in markGridView.Rows) {
                            row.Cells[1].Value = Mark.GetType(marks[row.Index].MarK);
                        }
                        markGridView.Columns["User"].HeaderText = "Обучающийся";
                    }));
                }
            });
        }

        private void RunExcel(Type type) {
            Microsoft.Office.Interop.Excel.Application excelApp
                = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Workbooks.Add();
            Worksheet workSheet = (Worksheet) excelApp.ActiveSheet;
            workSheet.Rows[1].Font.Bold = true;
            workSheet.Rows[3].Font.Bold = true;

            DataGridView gridView;
            if (type == Type.Users) {
                workSheet.Name = workSheet.Cells[1, 2] = "Пользователи";
                gridView = userGridView;
            } else if (type == Type.Groups) {
                workSheet.Name = workSheet.Cells[1, 2] = "Группы";
                gridView = groupGridView;
            } else if (type == Type.Subjects) {
                workSheet.Name = workSheet.Cells[1, 2] = "Дисциплины";
                gridView = subjectGridView;
            } else if (type == Type.Lessons) {
                workSheet.Name = workSheet.Cells[1, 2] = "Уроки";
                gridView = lessonGridView;
            } else {
                workSheet.Name = workSheet.Cells[1, 2] = "Оценки";
                gridView = markGridView;
            }
            workSheet.Cells[1, 2].HorizontalAlignment = XlHAlign.xlHAlignCenter;

            for (int i = 1; i < gridView.DisplayedColumnCount(false) + 1; i++) {
                workSheet.Cells[3, i] = gridView.Columns[i - 1].HeaderText;
                workSheet.Cells[3, i].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                workSheet.Cells[3, i].Borders.LineStyle = 1;
            }
            for (int i = 0; i < gridView.RowCount; i++) {
                for (int j = 0; j < gridView.DisplayedColumnCount(false); j++) {
                    if (gridView[j, i].Value != null) {
                        workSheet.Cells[i + 4, j + 1] = gridView[j, i].Value.ToString();
                    } else {
                        workSheet.Cells[i + 4, j + 1] = "";
                    }
                    workSheet.Cells[i + 4, j + 1].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    workSheet.Cells[i + 4, j + 1].Borders.LineStyle = 1;
                    workSheet.Columns[j + 1].AutoFit();
                }
            }

            workSheet.Cells[gridView.RowCount + 5,
                gridView.DisplayedColumnCount(false)] = DateTime.Now.ToString("dd.MM.yyyy");
            workSheet.Cells[gridView.RowCount + 5,
                gridView.DisplayedColumnCount(false)].HorizontalAlignment = XlHAlign.xlHAlignRight;
            excelApp.Visible = true;
        }

        private void DeleteItem(Type type) {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) {
                RestRequest request;
                if (type == Type.Users) {
                    request = new RestRequest("users/{id}", Method.DELETE);
                    request.AddUrlSegment("id", (int) userGridView.CurrentRow.Cells[0].Value);
                } else if (type == Type.Groups) {
                    request = new RestRequest("groups/{id}", Method.DELETE);
                    request.AddUrlSegment("id", (int) groupGridView.CurrentRow.Cells[0].Value);
                } else if (type == Type.Subjects) {
                    request = new RestRequest("subjects/{id}", Method.DELETE);
                    request.AddUrlSegment("id", (int) subjectGridView.CurrentRow.Cells[0].Value);
                } else if (type == Type.Lessons) {
                    request = new RestRequest("lessons/{id}", Method.DELETE);
                    request.AddUrlSegment("id", (int) lessonGridView.CurrentRow.Cells[0].Value);
                } else {
                    request = new RestRequest("marks/{id}", Method.DELETE);
                    request.AddUrlSegment("id", (int) markGridView.CurrentRow.Cells[0].Value);
                }
                EDiaryAPI.API.RequestAsync<object>(request, r => LoadTab(type));
            }
        }

        private void LoadElements() {
            userGroupCheck.SelectedIndex = 0;
            groupUserCheck.SelectedIndex = 0;
            subjectUserCheck.SelectedIndex = 0;
            lessonTypeCheck.SelectedIndex = 0;
            lessonGroupCheck.SelectedIndex = 0;
            lessonSubjectCheck.SelectedIndex = 0;
            markTypeCheck.SelectedIndex = 0;
            markUserCheck.SelectedIndex = 0;
            EDiaryAPI.API.RequestAsync<JArray>(
                new RestRequest("users", Method.GET), r => {
                    foreach (User user in r.ToObject<List<User>>()) {
                        groupUserCheck.Items.Add(user);
                        subjectUserCheck.Items.Add(user);
                        markUserCheck.Items.Add(user);
                    }
                });
            EDiaryAPI.API.RequestAsync<JArray>(
                new RestRequest("groups", Method.GET), r => {
                    foreach (Group group in r.ToObject<List<Group>>()) {
                        userGroupCheck.Items.Add(group);
                        lessonGroupCheck.Items.Add(group);
                    }
                });
            EDiaryAPI.API.RequestAsync<JArray>(
                new RestRequest("subjects", Method.GET), r => {
                    foreach (Subject subject in r.ToObject<List<Subject>>()) {
                        lessonSubjectCheck.Items.Add(subject);
                    }
                });
            foreach (LessonType type in Enum.GetValues(typeof(LessonType))) {
                lessonTypeCheck.Items.Add(new LessonTypeName(type));
            }
            foreach (MarkType type in Enum.GetValues(typeof(MarkType))) {
                markTypeCheck.Items.Add(new MarkTypeName(type));
            }
        }

        public enum CuAction {

            Create, Update
        }

        public enum Type {

            Users, Groups, Subjects, Lessons, Marks
        }
    }
}
