namespace E_Diary_for_Windows.Forms {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.adminButton = new System.Windows.Forms.Button();
            this.helpLabel = new System.Windows.Forms.LinkLabel();
            this.logoutLabel = new System.Windows.Forms.LinkLabel();
            this.loginLabel = new System.Windows.Forms.Label();
            this.roleLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.educationTab = new System.Windows.Forms.TabPage();
            this.educationTabControl = new System.Windows.Forms.TabControl();
            this.groupTab = new System.Windows.Forms.TabPage();
            this.groupGroupsBox = new System.Windows.Forms.ListBox();
            this.groupUsersList = new System.Windows.Forms.ListView();
            this.marksTab = new System.Windows.Forms.TabPage();
            this.marksExcelButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.marksFinalLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.marksAverageLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.marksGoodMissingsLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.marksMissingsLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.marksLateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.marksSubjectsBox = new System.Windows.Forms.ComboBox();
            this.marksGroupsBox = new System.Windows.Forms.ComboBox();
            this.marksGridView = new System.Windows.Forms.DataGridView();
            this.marksTermsBox = new System.Windows.Forms.ComboBox();
            this.homeworkTab = new System.Windows.Forms.TabPage();
            this.homeworkEndDateLabel = new System.Windows.Forms.Label();
            this.homeworkStartDateLabel = new System.Windows.Forms.Label();
            this.homeworkEndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.homeworkStartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.homeworkGroupsBox = new System.Windows.Forms.ComboBox();
            this.homeworkGridView = new System.Windows.Forms.DataGridView();
            this.homeworkSubjectsBox = new System.Windows.Forms.ComboBox();
            this.schedulesTab = new System.Windows.Forms.TabPage();
            this.schedulesExcelButton = new System.Windows.Forms.Button();
            this.schedulesGroupsBox = new System.Windows.Forms.ListBox();
            this.schedulesGridView = new System.Windows.Forms.DataGridView();
            this.LessonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profileTab = new System.Windows.Forms.TabPage();
            this.userImageBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.userEditButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.fileMenu = new System.Windows.Forms.MenuItem();
            this.adminMenuItem = new System.Windows.Forms.MenuItem();
            this.fileSeparator = new System.Windows.Forms.MenuItem();
            this.logoutMenuItem = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.helpMenu = new System.Windows.Forms.MenuItem();
            this.helpMenuItem = new System.Windows.Forms.MenuItem();
            this.helpSeparator = new System.Windows.Forms.MenuItem();
            this.aboutMenuItem = new System.Windows.Forms.MenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupUsersImageList = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.educationTab.SuspendLayout();
            this.educationTabControl.SuspendLayout();
            this.groupTab.SuspendLayout();
            this.marksTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marksGridView)).BeginInit();
            this.homeworkTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homeworkGridView)).BeginInit();
            this.schedulesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schedulesGridView)).BeginInit();
            this.profileTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userImageBox)).BeginInit();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // adminButton
            // 
            this.adminButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adminButton.Location = new System.Drawing.Point(447, 23);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(100, 40);
            this.adminButton.TabIndex = 1;
            this.adminButton.Text = "Панель учителя";
            this.adminButton.UseVisualStyleBackColor = true;
            this.adminButton.Click += new System.EventHandler(this.adminButton_Click);
            // 
            // helpLabel
            // 
            this.helpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpLabel.AutoSize = true;
            this.helpLabel.Location = new System.Drawing.Point(722, 29);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(50, 13);
            this.helpLabel.TabIndex = 3;
            this.helpLabel.TabStop = true;
            this.helpLabel.Text = "Помощь";
            this.helpLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.helpLabel_LinkClicked);
            // 
            // logoutLabel
            // 
            this.logoutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutLabel.AutoSize = true;
            this.logoutLabel.Location = new System.Drawing.Point(722, 42);
            this.logoutLabel.Name = "logoutLabel";
            this.logoutLabel.Size = new System.Drawing.Size(39, 13);
            this.logoutLabel.TabIndex = 4;
            this.logoutLabel.TabStop = true;
            this.logoutLabel.Text = "Выход";
            this.logoutLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logoutLabel_LinkClicked);
            // 
            // loginLabel
            // 
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginLabel.Location = new System.Drawing.Point(52, 16);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(105, 13);
            this.loginLabel.TabIndex = 0;
            this.loginLabel.Text = "loginLabel";
            // 
            // roleLabel
            // 
            this.roleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roleLabel.Location = new System.Drawing.Point(52, 29);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(105, 13);
            this.roleLabel.TabIndex = 1;
            this.roleLabel.Text = "roleLabel";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.imageBox);
            this.groupBox1.Controls.Add(this.roleLabel);
            this.groupBox1.Controls.Add(this.loginLabel);
            this.groupBox1.Location = new System.Drawing.Point(553, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(6, 9);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(40, 40);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox.TabIndex = 3;
            this.imageBox.TabStop = false;
            // 
            // educationTab
            // 
            this.educationTab.Controls.Add(this.educationTabControl);
            this.educationTab.Location = new System.Drawing.Point(4, 25);
            this.educationTab.Name = "educationTab";
            this.educationTab.Padding = new System.Windows.Forms.Padding(3);
            this.educationTab.Size = new System.Drawing.Size(752, 345);
            this.educationTab.TabIndex = 0;
            this.educationTab.Text = "Образование";
            this.educationTab.UseVisualStyleBackColor = true;
            // 
            // educationTabControl
            // 
            this.educationTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.educationTabControl.Controls.Add(this.groupTab);
            this.educationTabControl.Controls.Add(this.marksTab);
            this.educationTabControl.Controls.Add(this.homeworkTab);
            this.educationTabControl.Controls.Add(this.schedulesTab);
            this.educationTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.educationTabControl.Location = new System.Drawing.Point(-4, 0);
            this.educationTabControl.Name = "educationTabControl";
            this.educationTabControl.SelectedIndex = 0;
            this.educationTabControl.Size = new System.Drawing.Size(760, 349);
            this.educationTabControl.TabIndex = 0;
            this.educationTabControl.SelectedIndexChanged += new System.EventHandler(this.educationTabControl_SelectedIndexChanged);
            // 
            // groupTab
            // 
            this.groupTab.Controls.Add(this.groupGroupsBox);
            this.groupTab.Controls.Add(this.groupUsersList);
            this.groupTab.Location = new System.Drawing.Point(4, 25);
            this.groupTab.Name = "groupTab";
            this.groupTab.Padding = new System.Windows.Forms.Padding(3);
            this.groupTab.Size = new System.Drawing.Size(752, 320);
            this.groupTab.TabIndex = 0;
            this.groupTab.Text = "Мой класс";
            this.groupTab.UseVisualStyleBackColor = true;
            // 
            // groupGroupsBox
            // 
            this.groupGroupsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupGroupsBox.FormattingEnabled = true;
            this.groupGroupsBox.ItemHeight = 16;
            this.groupGroupsBox.Location = new System.Drawing.Point(3, 3);
            this.groupGroupsBox.Name = "groupGroupsBox";
            this.groupGroupsBox.Size = new System.Drawing.Size(100, 308);
            this.groupGroupsBox.TabIndex = 0;
            this.groupGroupsBox.SelectedIndexChanged += new System.EventHandler(this.groupGroupsBox_SelectedIndexChanged);
            // 
            // groupUsersList
            // 
            this.groupUsersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupUsersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupUsersList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(105)))), ((int)(((byte)(161)))));
            this.groupUsersList.HideSelection = false;
            this.groupUsersList.Location = new System.Drawing.Point(109, 3);
            this.groupUsersList.Name = "groupUsersList";
            this.groupUsersList.Size = new System.Drawing.Size(640, 308);
            this.groupUsersList.TabIndex = 1;
            this.groupUsersList.UseCompatibleStateImageBehavior = false;
            // 
            // marksTab
            // 
            this.marksTab.Controls.Add(this.marksExcelButton);
            this.marksTab.Controls.Add(this.groupBox2);
            this.marksTab.Controls.Add(this.marksSubjectsBox);
            this.marksTab.Controls.Add(this.marksGroupsBox);
            this.marksTab.Controls.Add(this.marksGridView);
            this.marksTab.Controls.Add(this.marksTermsBox);
            this.marksTab.Location = new System.Drawing.Point(4, 25);
            this.marksTab.Name = "marksTab";
            this.marksTab.Padding = new System.Windows.Forms.Padding(3);
            this.marksTab.Size = new System.Drawing.Size(752, 320);
            this.marksTab.TabIndex = 1;
            this.marksTab.Text = "Успеваемость";
            this.marksTab.UseVisualStyleBackColor = true;
            // 
            // marksExcelButton
            // 
            this.marksExcelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.marksExcelButton.Image = global::E_Diary_for_Windows.Properties.Resources.excel;
            this.marksExcelButton.Location = new System.Drawing.Point(727, 166);
            this.marksExcelButton.Name = "marksExcelButton";
            this.marksExcelButton.Size = new System.Drawing.Size(23, 23);
            this.marksExcelButton.TabIndex = 5;
            this.marksExcelButton.UseVisualStyleBackColor = true;
            this.marksExcelButton.Click += new System.EventHandler(this.marksExcelButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.marksFinalLabel);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.marksAverageLabel);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.marksGoodMissingsLabel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.marksMissingsLabel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.marksLateLabel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(609, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 131);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Статистика";
            // 
            // marksFinalLabel
            // 
            this.marksFinalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.marksFinalLabel.Location = new System.Drawing.Point(97, 107);
            this.marksFinalLabel.Name = "marksFinalLabel";
            this.marksFinalLabel.Size = new System.Drawing.Size(37, 15);
            this.marksFinalLabel.TabIndex = 9;
            this.marksFinalLabel.Text = "-";
            this.marksFinalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(6, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Итог. оценка";
            // 
            // marksAverageLabel
            // 
            this.marksAverageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.marksAverageLabel.Location = new System.Drawing.Point(97, 92);
            this.marksAverageLabel.Name = "marksAverageLabel";
            this.marksAverageLabel.Size = new System.Drawing.Size(37, 15);
            this.marksAverageLabel.TabIndex = 7;
            this.marksAverageLabel.Text = "-";
            this.marksAverageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Средний балл";
            // 
            // marksGoodMissingsLabel
            // 
            this.marksGoodMissingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.marksGoodMissingsLabel.Location = new System.Drawing.Point(97, 62);
            this.marksGoodMissingsLabel.Name = "marksGoodMissingsLabel";
            this.marksGoodMissingsLabel.Size = new System.Drawing.Size(37, 15);
            this.marksGoodMissingsLabel.TabIndex = 5;
            this.marksGoodMissingsLabel.Text = "-";
            this.marksGoodMissingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Пропуски (бол.)";
            // 
            // marksMissingsLabel
            // 
            this.marksMissingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.marksMissingsLabel.Location = new System.Drawing.Point(97, 47);
            this.marksMissingsLabel.Name = "marksMissingsLabel";
            this.marksMissingsLabel.Size = new System.Drawing.Size(37, 15);
            this.marksMissingsLabel.TabIndex = 3;
            this.marksMissingsLabel.Text = "-";
            this.marksMissingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пропуски";
            // 
            // marksLateLabel
            // 
            this.marksLateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.marksLateLabel.Location = new System.Drawing.Point(97, 19);
            this.marksLateLabel.Name = "marksLateLabel";
            this.marksLateLabel.Size = new System.Drawing.Size(37, 15);
            this.marksLateLabel.TabIndex = 1;
            this.marksLateLabel.Text = "-";
            this.marksLateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Опоздания";
            // 
            // marksSubjectsBox
            // 
            this.marksSubjectsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.marksSubjectsBox.FormattingEnabled = true;
            this.marksSubjectsBox.Location = new System.Drawing.Point(504, 3);
            this.marksSubjectsBox.Name = "marksSubjectsBox";
            this.marksSubjectsBox.Size = new System.Drawing.Size(245, 24);
            this.marksSubjectsBox.TabIndex = 2;
            this.marksSubjectsBox.SelectedIndexChanged += new System.EventHandler(this.marksSubjectsBox_SelectedIndexChanged);
            // 
            // marksGroupsBox
            // 
            this.marksGroupsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.marksGroupsBox.FormattingEnabled = true;
            this.marksGroupsBox.Location = new System.Drawing.Point(3, 3);
            this.marksGroupsBox.Name = "marksGroupsBox";
            this.marksGroupsBox.Size = new System.Drawing.Size(245, 24);
            this.marksGroupsBox.TabIndex = 0;
            this.marksGroupsBox.SelectedIndexChanged += new System.EventHandler(this.marksGroupsBox_SelectedIndexChanged);
            // 
            // marksGridView
            // 
            this.marksGridView.AllowUserToAddRows = false;
            this.marksGridView.AllowUserToDeleteRows = false;
            this.marksGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.marksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.marksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.marksGridView.Location = new System.Drawing.Point(3, 33);
            this.marksGridView.Name = "marksGridView";
            this.marksGridView.ReadOnly = true;
            this.marksGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.marksGridView.RowHeadersVisible = false;
            this.marksGridView.Size = new System.Drawing.Size(600, 284);
            this.marksGridView.TabIndex = 3;
            // 
            // marksTermsBox
            // 
            this.marksTermsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.marksTermsBox.FormattingEnabled = true;
            this.marksTermsBox.Location = new System.Drawing.Point(254, 3);
            this.marksTermsBox.Name = "marksTermsBox";
            this.marksTermsBox.Size = new System.Drawing.Size(245, 24);
            this.marksTermsBox.TabIndex = 1;
            this.marksTermsBox.SelectedIndexChanged += new System.EventHandler(this.marksTermsBox_SelectedIndexChanged);
            // 
            // homeworkTab
            // 
            this.homeworkTab.Controls.Add(this.homeworkEndDateLabel);
            this.homeworkTab.Controls.Add(this.homeworkStartDateLabel);
            this.homeworkTab.Controls.Add(this.homeworkEndDatePicker);
            this.homeworkTab.Controls.Add(this.homeworkStartDatePicker);
            this.homeworkTab.Controls.Add(this.homeworkGroupsBox);
            this.homeworkTab.Controls.Add(this.homeworkGridView);
            this.homeworkTab.Controls.Add(this.homeworkSubjectsBox);
            this.homeworkTab.Location = new System.Drawing.Point(4, 25);
            this.homeworkTab.Name = "homeworkTab";
            this.homeworkTab.Size = new System.Drawing.Size(752, 320);
            this.homeworkTab.TabIndex = 2;
            this.homeworkTab.Text = "Домашние задания";
            this.homeworkTab.UseVisualStyleBackColor = true;
            // 
            // homeworkEndDateLabel
            // 
            this.homeworkEndDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.homeworkEndDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.homeworkEndDateLabel.Location = new System.Drawing.Point(584, 6);
            this.homeworkEndDateLabel.Name = "homeworkEndDateLabel";
            this.homeworkEndDateLabel.Size = new System.Drawing.Size(22, 17);
            this.homeworkEndDateLabel.TabIndex = 5;
            this.homeworkEndDateLabel.Text = "до";
            // 
            // homeworkStartDateLabel
            // 
            this.homeworkStartDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.homeworkStartDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.homeworkStartDateLabel.Location = new System.Drawing.Point(415, 6);
            this.homeworkStartDateLabel.Name = "homeworkStartDateLabel";
            this.homeworkStartDateLabel.Size = new System.Drawing.Size(22, 17);
            this.homeworkStartDateLabel.TabIndex = 3;
            this.homeworkStartDateLabel.Text = "от";
            // 
            // homeworkEndDatePicker
            // 
            this.homeworkEndDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.homeworkEndDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.homeworkEndDatePicker.Location = new System.Drawing.Point(614, 4);
            this.homeworkEndDatePicker.Name = "homeworkEndDatePicker";
            this.homeworkEndDatePicker.Size = new System.Drawing.Size(135, 21);
            this.homeworkEndDatePicker.TabIndex = 6;
            this.homeworkEndDatePicker.ValueChanged += new System.EventHandler(this.homeworkEndDatePicker_ValueChanged);
            // 
            // homeworkStartDatePicker
            // 
            this.homeworkStartDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.homeworkStartDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.homeworkStartDatePicker.Location = new System.Drawing.Point(443, 4);
            this.homeworkStartDatePicker.Name = "homeworkStartDatePicker";
            this.homeworkStartDatePicker.Size = new System.Drawing.Size(135, 21);
            this.homeworkStartDatePicker.TabIndex = 4;
            this.homeworkStartDatePicker.Value = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.homeworkStartDatePicker.ValueChanged += new System.EventHandler(this.homeworkStartDatePicker_ValueChanged);
            // 
            // homeworkGroupsBox
            // 
            this.homeworkGroupsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.homeworkGroupsBox.FormattingEnabled = true;
            this.homeworkGroupsBox.Location = new System.Drawing.Point(3, 3);
            this.homeworkGroupsBox.Name = "homeworkGroupsBox";
            this.homeworkGroupsBox.Size = new System.Drawing.Size(200, 24);
            this.homeworkGroupsBox.TabIndex = 0;
            this.homeworkGroupsBox.SelectedIndexChanged += new System.EventHandler(this.homeworkGroupsBox_SelectedIndexChanged);
            // 
            // homeworkGridView
            // 
            this.homeworkGridView.AllowUserToAddRows = false;
            this.homeworkGridView.AllowUserToDeleteRows = false;
            this.homeworkGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.homeworkGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.homeworkGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.homeworkGridView.Location = new System.Drawing.Point(3, 33);
            this.homeworkGridView.Name = "homeworkGridView";
            this.homeworkGridView.ReadOnly = true;
            this.homeworkGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.homeworkGridView.RowHeadersVisible = false;
            this.homeworkGridView.Size = new System.Drawing.Size(746, 284);
            this.homeworkGridView.TabIndex = 7;
            // 
            // homeworkSubjectsBox
            // 
            this.homeworkSubjectsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.homeworkSubjectsBox.FormattingEnabled = true;
            this.homeworkSubjectsBox.Location = new System.Drawing.Point(209, 3);
            this.homeworkSubjectsBox.Name = "homeworkSubjectsBox";
            this.homeworkSubjectsBox.Size = new System.Drawing.Size(200, 24);
            this.homeworkSubjectsBox.TabIndex = 1;
            this.homeworkSubjectsBox.SelectedIndexChanged += new System.EventHandler(this.homeworkSubjectsBox_SelectedIndexChanged);
            // 
            // schedulesTab
            // 
            this.schedulesTab.Controls.Add(this.schedulesExcelButton);
            this.schedulesTab.Controls.Add(this.schedulesGroupsBox);
            this.schedulesTab.Controls.Add(this.schedulesGridView);
            this.schedulesTab.Location = new System.Drawing.Point(4, 25);
            this.schedulesTab.Name = "schedulesTab";
            this.schedulesTab.Size = new System.Drawing.Size(752, 320);
            this.schedulesTab.TabIndex = 3;
            this.schedulesTab.Text = "Расписание";
            this.schedulesTab.UseVisualStyleBackColor = true;
            // 
            // schedulesExcelButton
            // 
            this.schedulesExcelButton.Image = global::E_Diary_for_Windows.Properties.Resources.excel;
            this.schedulesExcelButton.Location = new System.Drawing.Point(79, 4);
            this.schedulesExcelButton.Name = "schedulesExcelButton";
            this.schedulesExcelButton.Size = new System.Drawing.Size(23, 23);
            this.schedulesExcelButton.TabIndex = 2;
            this.schedulesExcelButton.UseVisualStyleBackColor = true;
            this.schedulesExcelButton.Click += new System.EventHandler(this.schedulesExcelButton_Click);
            // 
            // schedulesGroupsBox
            // 
            this.schedulesGroupsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.schedulesGroupsBox.FormattingEnabled = true;
            this.schedulesGroupsBox.ItemHeight = 16;
            this.schedulesGroupsBox.Location = new System.Drawing.Point(3, 3);
            this.schedulesGroupsBox.Name = "schedulesGroupsBox";
            this.schedulesGroupsBox.Size = new System.Drawing.Size(100, 308);
            this.schedulesGroupsBox.TabIndex = 0;
            this.schedulesGroupsBox.SelectedIndexChanged += new System.EventHandler(this.schedulesGroupsBox_SelectedIndexChanged);
            // 
            // schedulesGridView
            // 
            this.schedulesGridView.AllowUserToAddRows = false;
            this.schedulesGridView.AllowUserToDeleteRows = false;
            this.schedulesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.schedulesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.schedulesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.schedulesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LessonColumn,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.schedulesGridView.Location = new System.Drawing.Point(109, 3);
            this.schedulesGridView.Name = "schedulesGridView";
            this.schedulesGridView.ReadOnly = true;
            this.schedulesGridView.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.schedulesGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.schedulesGridView.Size = new System.Drawing.Size(640, 308);
            this.schedulesGridView.TabIndex = 1;
            // 
            // LessonColumn
            // 
            this.LessonColumn.HeaderText = "Урок";
            this.LessonColumn.Name = "LessonColumn";
            this.LessonColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Day 1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Day 2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Day 3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Day 4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Day 5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Day 6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // profileTab
            // 
            this.profileTab.AutoScroll = true;
            this.profileTab.Controls.Add(this.userImageBox);
            this.profileTab.Controls.Add(this.nameLabel);
            this.profileTab.Controls.Add(this.userEditButton);
            this.profileTab.Location = new System.Drawing.Point(4, 25);
            this.profileTab.Name = "profileTab";
            this.profileTab.Padding = new System.Windows.Forms.Padding(3);
            this.profileTab.Size = new System.Drawing.Size(752, 345);
            this.profileTab.TabIndex = 1;
            this.profileTab.Text = "Профиль";
            this.profileTab.UseVisualStyleBackColor = true;
            // 
            // userImageBox
            // 
            this.userImageBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.userImageBox.Location = new System.Drawing.Point(6, 6);
            this.userImageBox.Name = "userImageBox";
            this.userImageBox.Size = new System.Drawing.Size(150, 150);
            this.userImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userImageBox.TabIndex = 0;
            this.userImageBox.TabStop = false;
            this.userImageBox.Click += new System.EventHandler(this.userImageBox_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(105)))), ((int)(((byte)(161)))));
            this.nameLabel.Location = new System.Drawing.Point(162, 6);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(543, 35);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "nameLabel";
            // 
            // userEditButton
            // 
            this.userEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userEditButton.FlatAppearance.BorderSize = 0;
            this.userEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userEditButton.Image = global::E_Diary_for_Windows.Properties.Resources.edit;
            this.userEditButton.Location = new System.Drawing.Point(711, 5);
            this.userEditButton.Name = "userEditButton";
            this.userEditButton.Size = new System.Drawing.Size(35, 35);
            this.userEditButton.TabIndex = 1;
            this.userEditButton.UseVisualStyleBackColor = true;
            this.userEditButton.Click += new System.EventHandler(this.userEditButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.profileTab);
            this.tabControl.Controls.Add(this.educationTab);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.Location = new System.Drawing.Point(12, 75);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 374);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileMenu,
            this.helpMenu});
            // 
            // fileMenu
            // 
            this.fileMenu.Index = 0;
            this.fileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.adminMenuItem,
            this.fileSeparator,
            this.logoutMenuItem,
            this.exitMenuItem});
            this.fileMenu.Text = "Файл";
            // 
            // adminMenuItem
            // 
            this.adminMenuItem.Index = 0;
            this.adminMenuItem.Text = "Панель учителя";
            this.adminMenuItem.Click += new System.EventHandler(this.adminMenuItem_Click);
            // 
            // fileSeparator
            // 
            this.fileSeparator.Index = 1;
            this.fileSeparator.Text = "-";
            // 
            // logoutMenuItem
            // 
            this.logoutMenuItem.Index = 2;
            this.logoutMenuItem.Text = "Выйти из аккаунта";
            this.logoutMenuItem.Click += new System.EventHandler(this.logoutMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Index = 3;
            this.exitMenuItem.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.exitMenuItem.Text = "Выход";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.Index = 1;
            this.helpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.helpMenuItem,
            this.helpSeparator,
            this.aboutMenuItem});
            this.helpMenu.Text = "Справка";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Index = 0;
            this.helpMenuItem.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.helpMenuItem.Text = "Просмотр справки";
            this.helpMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // helpSeparator
            // 
            this.helpSeparator.Index = 1;
            this.helpSeparator.Text = "-";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Index = 2;
            this.aboutMenuItem.Text = "О программе E-Diary for Windows";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 30000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // groupUsersImageList
            // 
            this.groupUsersImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.groupUsersImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.groupUsersImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::E_Diary_for_Windows.Properties.Resources.E_Diary_header;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.logoutLabel);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.adminButton);
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Diary for Windows";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.educationTab.ResumeLayout(false);
            this.educationTabControl.ResumeLayout(false);
            this.groupTab.ResumeLayout(false);
            this.marksTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marksGridView)).EndInit();
            this.homeworkTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.homeworkGridView)).EndInit();
            this.schedulesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schedulesGridView)).EndInit();
            this.profileTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userImageBox)).EndInit();
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button adminButton;
        private System.Windows.Forms.LinkLabel helpLabel;
        private System.Windows.Forms.LinkLabel logoutLabel;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label roleLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage educationTab;
        private System.Windows.Forms.TabControl educationTabControl;
        private System.Windows.Forms.TabPage groupTab;
        private System.Windows.Forms.TabPage marksTab;
        private System.Windows.Forms.TabPage homeworkTab;
        private System.Windows.Forms.TabPage schedulesTab;
        private System.Windows.Forms.TabPage profileTab;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem fileMenu;
        private System.Windows.Forms.MenuItem logoutMenuItem;
        private System.Windows.Forms.MenuItem exitMenuItem;
        private System.Windows.Forms.PictureBox userImageBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button userEditButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.MenuItem helpMenu;
        private System.Windows.Forms.MenuItem helpMenuItem;
        private System.Windows.Forms.MenuItem helpSeparator;
        private System.Windows.Forms.MenuItem aboutMenuItem;
        private System.Windows.Forms.MenuItem adminMenuItem;
        private System.Windows.Forms.MenuItem fileSeparator;
        private System.Windows.Forms.ImageList groupUsersImageList;
        private System.Windows.Forms.ListView groupUsersList;
        private System.Windows.Forms.ListBox groupGroupsBox;
        private System.Windows.Forms.ComboBox marksTermsBox;
        private System.Windows.Forms.DataGridView marksGridView;
        private System.Windows.Forms.ComboBox marksGroupsBox;
        private System.Windows.Forms.ComboBox marksSubjectsBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label marksLateLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label marksAverageLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label marksGoodMissingsLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label marksMissingsLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label marksFinalLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox homeworkGroupsBox;
        private System.Windows.Forms.DataGridView homeworkGridView;
        private System.Windows.Forms.ComboBox homeworkSubjectsBox;
        private System.Windows.Forms.Label homeworkEndDateLabel;
        private System.Windows.Forms.Label homeworkStartDateLabel;
        private System.Windows.Forms.DateTimePicker homeworkEndDatePicker;
        private System.Windows.Forms.DateTimePicker homeworkStartDatePicker;
        private System.Windows.Forms.DataGridView schedulesGridView;
        private System.Windows.Forms.ListBox schedulesGroupsBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn LessonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button marksExcelButton;
        private System.Windows.Forms.Button schedulesExcelButton;
    }
}

