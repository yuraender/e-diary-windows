﻿namespace E_Diary_for_Windows.Forms.Admin.Control.Marks {
    partial class ControlMark {
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
            this.createButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.markBox = new System.Windows.Forms.ComboBox();
            this.userBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(66, 250);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(156, 51);
            this.createButton.TabIndex = 4;
            this.createButton.Text = "Добавить";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Оценка/статус";
            // 
            // markBox
            // 
            this.markBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.markBox.FormattingEnabled = true;
            this.markBox.Location = new System.Drawing.Point(48, 67);
            this.markBox.Name = "markBox";
            this.markBox.Size = new System.Drawing.Size(191, 21);
            this.markBox.TabIndex = 1;
            // 
            // userBox
            // 
            this.userBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userBox.Enabled = false;
            this.userBox.FormattingEnabled = true;
            this.userBox.Location = new System.Drawing.Point(48, 107);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(191, 21);
            this.userBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Обучающийся";
            // 
            // ControlMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 329);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.markBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlMark";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить";
            this.Load += new System.EventHandler(this.ControlGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox markBox;
        private System.Windows.Forms.ComboBox userBox;
        private System.Windows.Forms.Label label5;
    }
}