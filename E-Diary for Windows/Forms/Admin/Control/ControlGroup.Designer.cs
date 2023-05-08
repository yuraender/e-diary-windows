namespace E_Diary_for_Windows.Forms.Admin.Control {
    partial class ControlGroup {
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
            this.fullNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.removeSubjectButton = new System.Windows.Forms.Button();
            this.requiredSubjectList = new System.Windows.Forms.ListBox();
            this.addSubjectButton = new System.Windows.Forms.Button();
            this.fullSubjectList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gradeBox = new System.Windows.Forms.ComboBox();
            this.teacherBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createUpdateButton
            // 
            this.createUpdateButton.Location = new System.Drawing.Point(66, 250);
            this.createUpdateButton.Name = "createUpdateButton";
            this.createUpdateButton.Size = new System.Drawing.Size(156, 51);
            this.createUpdateButton.TabIndex = 9;
            this.createUpdateButton.Text = "CreateUpdate";
            this.createUpdateButton.UseVisualStyleBackColor = true;
            this.createUpdateButton.Click += new System.EventHandler(this.createUpdateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(48, 67);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(191, 20);
            this.nameBox.TabIndex = 1;
            // 
            // fullNameBox
            // 
            this.fullNameBox.Location = new System.Drawing.Point(48, 106);
            this.fullNameBox.Name = "fullNameBox";
            this.fullNameBox.Size = new System.Drawing.Size(191, 20);
            this.fullNameBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Расшифровка";
            // 
            // removeSubjectButton
            // 
            this.removeSubjectButton.Location = new System.Drawing.Point(172, 84);
            this.removeSubjectButton.Name = "removeSubjectButton";
            this.removeSubjectButton.Size = new System.Drawing.Size(78, 23);
            this.removeSubjectButton.TabIndex = 3;
            this.removeSubjectButton.Text = "<<";
            this.removeSubjectButton.UseVisualStyleBackColor = true;
            this.removeSubjectButton.Click += new System.EventHandler(this.removeRoleButton_Click);
            // 
            // requiredSubjectList
            // 
            this.requiredSubjectList.FormattingEnabled = true;
            this.requiredSubjectList.Location = new System.Drawing.Point(255, 19);
            this.requiredSubjectList.Name = "requiredSubjectList";
            this.requiredSubjectList.Size = new System.Drawing.Size(160, 121);
            this.requiredSubjectList.TabIndex = 1;
            // 
            // addSubjectButton
            // 
            this.addSubjectButton.Location = new System.Drawing.Point(172, 55);
            this.addSubjectButton.Name = "addSubjectButton";
            this.addSubjectButton.Size = new System.Drawing.Size(78, 23);
            this.addSubjectButton.TabIndex = 2;
            this.addSubjectButton.Text = ">>";
            this.addSubjectButton.UseVisualStyleBackColor = true;
            this.addSubjectButton.Click += new System.EventHandler(this.addRoleButton_Click);
            // 
            // fullSubjectList
            // 
            this.fullSubjectList.FormattingEnabled = true;
            this.fullSubjectList.Location = new System.Drawing.Point(6, 19);
            this.fullSubjectList.Name = "fullSubjectList";
            this.fullSubjectList.Size = new System.Drawing.Size(160, 121);
            this.fullSubjectList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fullSubjectList);
            this.groupBox1.Controls.Add(this.addSubjectButton);
            this.groupBox1.Controls.Add(this.requiredSubjectList);
            this.groupBox1.Controls.Add(this.removeSubjectButton);
            this.groupBox1.Location = new System.Drawing.Point(283, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 151);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дисциплины";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Класс";
            // 
            // gradeBox
            // 
            this.gradeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradeBox.FormattingEnabled = true;
            this.gradeBox.Location = new System.Drawing.Point(48, 145);
            this.gradeBox.Name = "gradeBox";
            this.gradeBox.Size = new System.Drawing.Size(191, 21);
            this.gradeBox.TabIndex = 5;
            // 
            // teacherBox
            // 
            this.teacherBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teacherBox.FormattingEnabled = true;
            this.teacherBox.Items.AddRange(new object[] {
            "(не выбрано)"});
            this.teacherBox.Location = new System.Drawing.Point(48, 185);
            this.teacherBox.Name = "teacherBox";
            this.teacherBox.Size = new System.Drawing.Size(191, 21);
            this.teacherBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Руководитель";
            // 
            // ControlGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 329);
            this.Controls.Add(this.teacherBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gradeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fullNameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createUpdateButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ControlGroup";
            this.Load += new System.EventHandler(this.ControlGroup_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createUpdateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox fullNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removeSubjectButton;
        private System.Windows.Forms.ListBox requiredSubjectList;
        private System.Windows.Forms.Button addSubjectButton;
        private System.Windows.Forms.ListBox fullSubjectList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox gradeBox;
        private System.Windows.Forms.ComboBox teacherBox;
        private System.Windows.Forms.Label label4;
    }
}