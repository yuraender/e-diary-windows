namespace E_Diary_for_Windows.Forms.Admin.Control {
    partial class ControlUser {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.createUpdateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.removeRoleButton = new System.Windows.Forms.Button();
            this.addRoleButton = new System.Windows.Forms.Button();
            this.requiredRoleList = new System.Windows.Forms.ListBox();
            this.fullRoleList = new System.Windows.Forms.ListBox();
            this.removeGroupButton = new System.Windows.Forms.Button();
            this.addGroupButton = new System.Windows.Forms.Button();
            this.requiredGroupList = new System.Windows.Forms.ListBox();
            this.fullGroupList = new System.Windows.Forms.ListBox();
            this.rolesGroupBox = new System.Windows.Forms.GroupBox();
            this.groupsGroupBox = new System.Windows.Forms.GroupBox();
            this.rolesGroupBox.SuspendLayout();
            this.groupsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // createUpdateButton
            // 
            this.createUpdateButton.Location = new System.Drawing.Point(66, 287);
            this.createUpdateButton.Name = "createUpdateButton";
            this.createUpdateButton.Size = new System.Drawing.Size(156, 51);
            this.createUpdateButton.TabIndex = 12;
            this.createUpdateButton.Text = "CreateUpdate";
            this.createUpdateButton.UseVisualStyleBackColor = true;
            this.createUpdateButton.Click += new System.EventHandler(this.createUpdateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(48, 67);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(191, 20);
            this.nameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата рождения";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(48, 106);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(191, 20);
            this.datePicker.TabIndex = 3;
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(48, 145);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(191, 20);
            this.loginBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Логин";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(48, 184);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(191, 20);
            this.passwordBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Пароль";
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(48, 223);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(191, 20);
            this.emailBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Email";
            // 
            // removeRoleButton
            // 
            this.removeRoleButton.Location = new System.Drawing.Point(172, 84);
            this.removeRoleButton.Name = "removeRoleButton";
            this.removeRoleButton.Size = new System.Drawing.Size(78, 23);
            this.removeRoleButton.TabIndex = 3;
            this.removeRoleButton.Text = "<<";
            this.removeRoleButton.UseVisualStyleBackColor = true;
            this.removeRoleButton.Click += new System.EventHandler(this.removeRoleButton_Click);
            // 
            // addRoleButton
            // 
            this.addRoleButton.Location = new System.Drawing.Point(172, 55);
            this.addRoleButton.Name = "addRoleButton";
            this.addRoleButton.Size = new System.Drawing.Size(78, 23);
            this.addRoleButton.TabIndex = 2;
            this.addRoleButton.Text = ">>";
            this.addRoleButton.UseVisualStyleBackColor = true;
            this.addRoleButton.Click += new System.EventHandler(this.addRoleButton_Click);
            // 
            // requiredRoleList
            // 
            this.requiredRoleList.FormattingEnabled = true;
            this.requiredRoleList.Location = new System.Drawing.Point(255, 19);
            this.requiredRoleList.Name = "requiredRoleList";
            this.requiredRoleList.Size = new System.Drawing.Size(160, 121);
            this.requiredRoleList.TabIndex = 1;
            // 
            // fullRoleList
            // 
            this.fullRoleList.FormattingEnabled = true;
            this.fullRoleList.Location = new System.Drawing.Point(6, 19);
            this.fullRoleList.Name = "fullRoleList";
            this.fullRoleList.Size = new System.Drawing.Size(160, 121);
            this.fullRoleList.TabIndex = 0;
            // 
            // removeGroupButton
            // 
            this.removeGroupButton.Location = new System.Drawing.Point(172, 80);
            this.removeGroupButton.Name = "removeGroupButton";
            this.removeGroupButton.Size = new System.Drawing.Size(78, 23);
            this.removeGroupButton.TabIndex = 3;
            this.removeGroupButton.Text = "<<";
            this.removeGroupButton.UseVisualStyleBackColor = true;
            this.removeGroupButton.Click += new System.EventHandler(this.removeGroupButton_Click);
            // 
            // addGroupButton
            // 
            this.addGroupButton.Location = new System.Drawing.Point(172, 51);
            this.addGroupButton.Name = "addGroupButton";
            this.addGroupButton.Size = new System.Drawing.Size(78, 23);
            this.addGroupButton.TabIndex = 2;
            this.addGroupButton.Text = ">>";
            this.addGroupButton.UseVisualStyleBackColor = true;
            this.addGroupButton.Click += new System.EventHandler(this.addGroupButton_Click);
            // 
            // requiredGroupList
            // 
            this.requiredGroupList.FormattingEnabled = true;
            this.requiredGroupList.Location = new System.Drawing.Point(256, 17);
            this.requiredGroupList.Name = "requiredGroupList";
            this.requiredGroupList.Size = new System.Drawing.Size(160, 121);
            this.requiredGroupList.TabIndex = 1;
            // 
            // fullGroupList
            // 
            this.fullGroupList.FormattingEnabled = true;
            this.fullGroupList.Location = new System.Drawing.Point(6, 17);
            this.fullGroupList.Name = "fullGroupList";
            this.fullGroupList.Size = new System.Drawing.Size(160, 121);
            this.fullGroupList.TabIndex = 0;
            // 
            // rolesGroupBox
            // 
            this.rolesGroupBox.Controls.Add(this.fullRoleList);
            this.rolesGroupBox.Controls.Add(this.addRoleButton);
            this.rolesGroupBox.Controls.Add(this.requiredRoleList);
            this.rolesGroupBox.Controls.Add(this.removeRoleButton);
            this.rolesGroupBox.Location = new System.Drawing.Point(281, 30);
            this.rolesGroupBox.Name = "rolesGroupBox";
            this.rolesGroupBox.Size = new System.Drawing.Size(421, 151);
            this.rolesGroupBox.TabIndex = 10;
            this.rolesGroupBox.TabStop = false;
            this.rolesGroupBox.Text = "Роли";
            // 
            // groupsGroupBox
            // 
            this.groupsGroupBox.Controls.Add(this.fullGroupList);
            this.groupsGroupBox.Controls.Add(this.requiredGroupList);
            this.groupsGroupBox.Controls.Add(this.removeGroupButton);
            this.groupsGroupBox.Controls.Add(this.addGroupButton);
            this.groupsGroupBox.Location = new System.Drawing.Point(281, 187);
            this.groupsGroupBox.Name = "groupsGroupBox";
            this.groupsGroupBox.Size = new System.Drawing.Size(421, 151);
            this.groupsGroupBox.TabIndex = 11;
            this.groupsGroupBox.TabStop = false;
            this.groupsGroupBox.Text = "Группы";
            // 
            // ControlUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 361);
            this.Controls.Add(this.groupsGroupBox);
            this.Controls.Add(this.rolesGroupBox);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createUpdateButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ControlUser";
            this.Load += new System.EventHandler(this.ControlUser_Load);
            this.rolesGroupBox.ResumeLayout(false);
            this.groupsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createUpdateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button removeRoleButton;
        private System.Windows.Forms.Button addRoleButton;
        private System.Windows.Forms.ListBox requiredRoleList;
        private System.Windows.Forms.ListBox fullRoleList;
        private System.Windows.Forms.Button removeGroupButton;
        private System.Windows.Forms.Button addGroupButton;
        private System.Windows.Forms.ListBox requiredGroupList;
        private System.Windows.Forms.ListBox fullGroupList;
        private System.Windows.Forms.GroupBox rolesGroupBox;
        private System.Windows.Forms.GroupBox groupsGroupBox;
    }
}