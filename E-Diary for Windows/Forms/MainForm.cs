using E_Diary_for_Windows.Entities;
using E_Diary_for_Windows.Forms.Actions;
using E_Diary_for_Windows.Forms.Admin;
using E_Diary_for_Windows.Forms.Admin.Control;
using E_Diary_for_Windows.Utils;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static E_Diary_for_Windows.Forms.Admin.AdminForm;
using Application = System.Windows.Forms.Application;
using Label = System.Windows.Forms.Label;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace E_Diary_for_Windows.Forms {
    public partial class MainForm : Form {

        private User user = EDiaryAPI.API.CurrentUser;

        private readonly List<Control> profileTabControls = new List<Control>();
        private readonly List<DateTime> days = new List<DateTime>();

        public MainForm(bool runTimer) {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            timer.Enabled = runTimer;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            LoadTab(Type.Profile);
            LoadUserInfo(user);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl.SelectedIndex == 0) {
                LoadTab(Type.Profile);
            } else {
                educationTabControl_SelectedIndexChanged(null, null);
            }
        }

        private void educationTabControl_SelectedIndexChanged(object sender, EventArgs e) {
            if (educationTabControl.SelectedIndex == 0) {
                LoadTab(Type.Group);
            } else if (educationTabControl.SelectedIndex == 1) {
                LoadTab(Type.Marks);
            } else if (educationTabControl.SelectedIndex == 2) {
                LoadTab(Type.Homework);
            } else {
                LoadTab(Type.Schedules);
            }
        }

        private void adminButton_Click(object sender, EventArgs e) {
            adminButton.Enabled = false;
            AdminForm adminForm = new AdminForm();
            adminForm.Closed += (s, args) => adminButton.Enabled = true;
            adminForm.Show();
        }

        //Profile
        private void userImageBox_Click(object sender, EventArgs e) {
            new EditUserImage(user, new List<PictureBox>() { imageBox, userImageBox }).ShowDialog();
        }

        private void userEditButton_Click(object sender, EventArgs e) {
            new ControlUser(this, user, CuAction.Update, false).ShowDialog();
        }

        //Group
        private void groupGroupsBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (groupGroupsBox.SelectedIndex == -1) {
                return;
            }
            RestRequest request = new RestRequest("users", Method.GET);
            request.AddParameter("group_id", ((Group) groupGroupsBox.SelectedItem).ID);
            EDiaryAPI.API.RequestAsync<JArray>(request, r => {
                groupUsersList.Items.Clear();

                foreach (User user in r.ToObject<List<User>>()) {
                    groupUsersImageList.Images.Add(user.Login, ImageUtils.LoadImage(user.Image));
                    ListViewItem userItem = groupUsersList.Items.Add(user.Name);
                    userItem.ImageKey = user.Login;
                }
            });
        }

        //Marks
        private void marksGroupsBox_SelectedIndexChanged(object sender, EventArgs e) {
            RestRequest request = new RestRequest("groups/{id}", Method.GET);
            request.AddUrlSegment("id", ((Group) marksGroupsBox.SelectedItem).ID);
            EDiaryAPI.API.RequestAsync<JObject>(request, r => {
                marksTermsBox.Items.Clear();
                marksSubjectsBox.Items.Clear();
                marksGridView.DataSource = null;
                marksLateLabel.Text = "-";
                marksMissingsLabel.Text = "-";
                marksGoodMissingsLabel.Text = "-";
                marksAverageLabel.Text = "-";
                marksFinalLabel.Text = "-";

                Group group = r.ToObject<Group>();
                if (group.IsSchoolGrade()) {
                    marksTermsBox.Items.AddRange(new string[] {
                        "1 четверть", "2 четверть", "3 четверть", "4 четверть"
                    });
                } else {
                    marksTermsBox.Items.AddRange(new string[] {
                        "1 семестр", "2 семестр",
                    });
                }
                foreach (Subject subject in group.Subjects) {
                    marksSubjectsBox.Items.Add(subject);
                }
            });
        }

        private void marksTermsBox_SelectedIndexChanged(object sender, EventArgs e) {
            marksSubjectsBox.SelectedIndex = -1;
            marksGridView.DataSource = null;
            marksLateLabel.Text = "-";
            marksMissingsLabel.Text = "-";
            marksGoodMissingsLabel.Text = "-";
            marksAverageLabel.Text = "-";
            marksFinalLabel.Text = "-";
        }

        private void marksSubjectsBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (marksTermsBox.SelectedIndex == -1 || marksSubjectsBox.SelectedIndex == -1) {
                return;
            }
            int term = Convert.ToInt32(((string) marksTermsBox.SelectedItem).Split(' ')[0]);
            Group group = (Group) marksGroupsBox.SelectedItem;
            Subject subject = (Subject) marksSubjectsBox.SelectedItem;

            RestRequest request = new RestRequest("lessons", Method.GET);
            request.AddParameter("term", term);
            request.AddParameter("group_id", group.ID);
            request.AddParameter("subject_id", subject.ID);
            EDiaryAPI.API.RequestAsync<JArray>(request, r => {
                List<object> marks = new List<object>();
                List<Lesson> lessons = r.ToObject<List<Lesson>>();
                foreach (Lesson lesson in lessons) {
                    StringBuilder sb = new StringBuilder();
                    List<Mark> lMarks = lesson.Marks.FindAll(m => {
                        return m.User.ID == user.ID && m.IsMarkType();
                    });
                    foreach (Homework homework in lesson.Homework) {
                        lMarks.AddRange(homework.Marks.FindAll(m => {
                            return m.User.ID == user.ID && m.IsMarkType();
                        }));
                    }
                    lMarks.ForEach(m => {
                        sb.Append(sb.ToString().Equals("")
                            ? Mark.GetType(m.MarK)
                            : ", " + Mark.GetType(m.MarK));
                    });
                    marks.Add(new {
                        Урок = lesson,
                        Тип = Lesson.GetType(lesson.Type),
                        Оценка = sb.ToString()
                    });
                }
                marksLateLabel.Text = lessons.Count(l => l.Marks.Any(m => {
                    return m.MarK.Equals("LATE") && m.User.ID == user.ID;
                })).ToString();
                marksMissingsLabel.Text = lessons.Count(l => l.Marks.Any(m => {
                    return m.User.ID == user.ID
                        && (m.MarK.Equals("MISSING") || m.MarK.Equals("MISSING_BAD"));
                })).ToString();
                marksGoodMissingsLabel.Text = lessons.Count(l => l.Marks.Any(m => {
                    return m.MarK.Equals("MISSING_GOOD") && m.User.ID == user.ID;
                })).ToString();
                int marksAmount = 0;
                int marksSum = lessons
                    .FindAll(l => l.IsLessonType())
                    .Sum(l => {
                        List<Mark> lMarks = l.Marks.FindAll(m => m.User.ID == user.ID && m.IsMarkType());
                        foreach (Homework homework in l.Homework) {
                            lMarks.AddRange(homework.Marks.FindAll(m => {
                                return m.User.ID == user.ID && m.IsMarkType();
                            }));
                        }
                        return lMarks.Sum(m => {
                            marksAmount++;
                            return int.Parse(Mark.GetType(m.MarK));
                        });
                    });
                marksAverageLabel.Text = marksSum == 0 ? "-"
                    : ((double) marksSum / Math.Max(1, marksAmount)).ToString();
                Lesson finalLesson = lessons.Find(l => l.Type == LessonType.FINAL);
                if (finalLesson != null) {
                    Mark mark = finalLesson.Marks.Find(m => {
                        return m.User.ID == user.ID && m.IsMarkType();
                    });
                    marksFinalLabel.Text = mark != null ? Mark.GetType(mark.MarK) : "-";
                }
                marksGridView.DataSource = marks;
            });
        }

        private void marksExcelButton_Click(object sender, EventArgs e) {
            if (marksGridView.RowCount != 0) {
                Subject subject = (Subject) marksSubjectsBox.SelectedItem;
                RunExcel("Успеваемость " + subject.Name, Type.Marks);
            }
        }

        //Homework
        private void homeworkGroupsBox_SelectedIndexChanged(object sender, EventArgs e) {
            RestRequest request = new RestRequest("groups/{id}", Method.GET);
            request.AddUrlSegment("id", ((Group) homeworkGroupsBox.SelectedItem).ID);
            EDiaryAPI.API.RequestAsync<JObject>(request, r => {
                homeworkSubjectsBox.Items.Clear();
                homeworkGridView.DataSource = null;
                foreach (Subject subject in r.ToObject<Group>().Subjects) {
                    homeworkSubjectsBox.Items.Add(subject);
                }
            });
        }

        private void homeworkSubjectsBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (homeworkSubjectsBox.SelectedIndex == -1) {
                return;
            }
            RestRequest request = new RestRequest("lessons", Method.GET);
            request.AddParameter("start_date", homeworkStartDatePicker.Value.ToString("yyyy-MM-dd"));
            request.AddParameter("end_date", homeworkEndDatePicker.Value.ToString("yyyy-MM-dd"));
            request.AddParameter("subject_id", ((Subject) homeworkSubjectsBox.SelectedItem).ID);
            EDiaryAPI.API.RequestAsync<JArray>(request, r => {
                List<object> homework = new List<object>();
                foreach (Lesson lesson in r.ToObject<List<Lesson>>()) {
                    foreach (Homework h in lesson.Homework) {
                        StringBuilder sb = new StringBuilder();
                        h.Marks.FindAll(m => {
                            return m.User.ID == user.ID && m.IsMarkType();
                        }).ForEach(m => {
                            sb.Append(sb.ToString().Equals("")
                                ? Mark.GetType(m.MarK)
                                : ", " + Mark.GetType(m.MarK));
                        });
                        homework.Add(new {
                            Название = h.Name,
                            Описание = h.Description,
                            Срок = lesson,
                            Оценка = sb.ToString()
                        });
                    }
                }
                homeworkGridView.DataSource = homework;
            });
        }

        private void homeworkStartDatePicker_ValueChanged(object sender, EventArgs e) {
            homeworkSubjectsBox_SelectedIndexChanged(null, null);
        }

        private void homeworkEndDatePicker_ValueChanged(object sender, EventArgs e) {
            homeworkSubjectsBox_SelectedIndexChanged(null, null);
        }

        //Schedules
        private void schedulesGroupsBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (schedulesGroupsBox.SelectedIndex == -1) {
                return;
            }
            RestRequest request = new RestRequest("lessons", Method.GET);
            request.AddParameter("start_date", days[0].ToString("yyyy-MM-dd"));
            request.AddParameter("end_date", days[5].ToString("yyyy-MM-dd"));
            request.AddParameter("group_id", ((Group) schedulesGroupsBox.SelectedItem).ID);
            EDiaryAPI.API.RequestAsync<JArray>(request, r => {
                schedulesGridView.Rows.Clear();
                List<Lesson> lessons = r.ToObject<List<Lesson>>();
                for (int i = 0; i < 8; i++) {
                    Lesson monday = lessons.Find(l => l.Date == days[0] && l.LessoN == i + 1);
                    Lesson tuesday = lessons.Find(l => l.Date == days[1] && l.LessoN == i + 1);
                    Lesson wednesday = lessons.Find(l => l.Date == days[2] && l.LessoN == i + 1);
                    Lesson thursday = lessons.Find(l => l.Date == days[3] && l.LessoN == i + 1);
                    Lesson friday = lessons.Find(l => l.Date == days[4] && l.LessoN == i + 1);
                    Lesson saturday = lessons.Find(l => l.Date == days[5] && l.LessoN == i + 1);
                    schedulesGridView.Rows.Add(new object[]{ i + 1,
                        monday != null ? monday.Subject.Name : "",
                        tuesday != null ? tuesday.Subject.Name : "",
                        wednesday != null ? wednesday.Subject.Name : "",
                        thursday != null ? thursday.Subject.Name : "",
                        friday != null ? friday.Subject.Name : "",
                        saturday != null ? saturday.Subject.Name : "",
                    });
                }
            });
        }

        private void schedulesExcelButton_Click(object sender, EventArgs e) {
            if (schedulesGridView.RowCount != 0) {
                RunExcel("Расписание", Type.Schedules);
            }
        }

        private void helpLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            MessageBox.Show("В разработке.");
        }

        private void logoutLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            EDiaryAPI.API.Logout();
            Close();
        }

        private void adminMenuItem_Click(object sender, EventArgs e) {
            adminButton_Click(null, null);
        }

        private void logoutMenuItem_Click(object sender, EventArgs e) {
            logoutLabel_LinkClicked(null, null);
        }

        private void exitMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void helpMenuItem_Click(object sender, EventArgs e) {
            helpLabel_LinkClicked(null, null);
        }

        private void aboutMenuItem_Click(object sender, EventArgs e) {
            new About().ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e) {
            if (EDiaryAPI.API.IsTokenValid() == null) {
                MessageBox.Show("Сессия устарела. Необходимо заново авторизоваться.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                logoutLabel_LinkClicked(null, null);
            }
        }

        private void LoadTab(Type type) {
            RestRequest userRequest = new RestRequest($"users/{user.ID}", Method.GET);
            EDiaryAPI.API.RequestAsync<JObject>(userRequest, ur => {
                LoadUserInfo(user = ur.ToObject<User>());
                if (type == Type.Profile) {
                    foreach (Control control in profileTabControls) {
                        profileTab.Controls.Remove(control);
                    }
                    profileTabControls.Clear();

                    for (int i = 0; i < user.Groups.Count; i++) {
                        Label groupLabel = new Label();
                        groupLabel.Parent = profileTab;
                        groupLabel.AutoSize = false;
                        groupLabel.Location = new Point(200, 55 + 30 * i);
                        groupLabel.Size = new Size(60, 20);
                        groupLabel.Text = "Группа:";
                        profileTabControls.Add(groupLabel);

                        Label groupNameLabel = new Label();
                        groupNameLabel.Parent = profileTab;
                        groupNameLabel.AutoSize = false;
                        groupNameLabel.Location = new Point(200 + 100, 55 + 30 * i);
                        groupNameLabel.Size = new Size(400, 20);
                        groupNameLabel.Text
                            = $"{user.Groups[i].Name} ({user.Groups[i].FullName})";
                        profileTabControls.Add(groupNameLabel);
                    }
                } else if (type == Type.Group) {
                    groupGroupsBox.Items.Clear();
                    groupUsersList.Items.Clear();
                    groupUsersList.LargeImageList = groupUsersImageList;
                    foreach (Group group in user.Groups) {
                        groupGroupsBox.Items.Add(group);
                    }
                } else if (type == Type.Marks) {
                    marksGroupsBox.Items.Clear();
                    marksTermsBox.Items.Clear();
                    marksSubjectsBox.Items.Clear();
                    foreach (Group group in user.Groups) {
                        marksGroupsBox.Items.Add(group);
                    }
                    marksGridView.DataSource = null;
                    marksLateLabel.Text = "-";
                    marksMissingsLabel.Text = "-";
                    marksGoodMissingsLabel.Text = "-";
                    marksAverageLabel.Text = "-";
                    marksFinalLabel.Text = "-";
                } else if (type == Type.Homework) {
                    homeworkGroupsBox.Items.Clear();
                    homeworkSubjectsBox.Items.Clear();
                    foreach (Group group in user.Groups) {
                        homeworkGroupsBox.Items.Add(group);
                    }
                    homeworkGridView.DataSource = null;
                } else {
                    schedulesGroupsBox.Items.Clear();
                    foreach (Group group in user.Groups) {
                        schedulesGroupsBox.Items.Add(group);
                    }
                    schedulesGridView.Rows.Clear();
                    days.Clear();
                    for (int i = 0; i < 6; i++) {
                        days.Add(DateTime.Now.AddDays(DayOfWeek.Monday - DateTime.Now.DayOfWeek + i));
                        schedulesGridView.Columns[i + 1].HeaderText = days[i].ToString("ddd, dd MMM");
                    }
                }
            });
        }

        private void RunExcel(string name, Type type) {
            Microsoft.Office.Interop.Excel.Application excelApp
                = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Workbooks.Add();
            Worksheet workSheet = (Worksheet) excelApp.ActiveSheet;
            workSheet.Rows[1].Font.Bold = true;
            workSheet.Rows[3].Font.Bold = true;

            workSheet.Name = workSheet.Cells[1, 2] = name;
            workSheet.Cells[1, 2].HorizontalAlignment = XlHAlign.xlHAlignCenter;

            DataGridView gridView;
            if (type == Type.Marks) {
                gridView = marksGridView;
                workSheet.Cells[3, 6] = "Опоздания";
                workSheet.Cells[3, 7] = marksLateLabel.Text;
                workSheet.Cells[4, 6] = "Пропуски";
                workSheet.Cells[4, 7] = marksMissingsLabel.Text;
                workSheet.Cells[5, 6] = "Пропуски (бол.)";
                workSheet.Cells[5, 7] = marksGoodMissingsLabel.Text;
                workSheet.Cells[6, 6] = "Средний балл";
                workSheet.Cells[6, 7] = marksAverageLabel.Text;
                workSheet.Cells[7, 6] = "Итоговая оценка";
                workSheet.Cells[7, 7] = marksFinalLabel.Text;
                workSheet.Cells[3, 6].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                workSheet.Cells[4, 6].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                workSheet.Cells[5, 6].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                workSheet.Cells[6, 6].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                workSheet.Cells[7, 6].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            } else {
                gridView = schedulesGridView;
            }

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

        private void LoadUserInfo(User user) {
            loginLabel.Text = user.Login;
            nameLabel.Text = user.Name;
            bool isAdmin = !user.Roles.OrderBy(role => role.ID).Last().Name.Equals("USER");
            roleLabel.Text = !isAdmin ? "Обучающийся" : "Сотрудник";
            imageBox.Image = userImageBox.Image = ImageUtils.LoadImage(user.Image);
            adminButton.Visible = adminMenuItem.Visible = fileSeparator.Visible = isAdmin;
        }

        public enum Type {

            Profile, Group, Marks, Homework, Schedules
        }
    }
}
