namespace E_Diary_for_Windows.Forms.Actions {
    partial class EditUserImage {
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
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.deleteImageButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.imageNameBox = new System.Windows.Forms.TextBox();
            this.updateImageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(12, 12);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(237, 237);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox.TabIndex = 0;
            this.imageBox.TabStop = false;
            this.imageBox.Click += new System.EventHandler(this.imageBox_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(281, 73);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "Выбрать";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // deleteImageButton
            // 
            this.deleteImageButton.Location = new System.Drawing.Point(281, 226);
            this.deleteImageButton.Name = "deleteImageButton";
            this.deleteImageButton.Size = new System.Drawing.Size(75, 23);
            this.deleteImageButton.TabIndex = 1;
            this.deleteImageButton.Text = "Удалить";
            this.deleteImageButton.UseVisualStyleBackColor = true;
            this.deleteImageButton.Click += new System.EventHandler(this.deleteImageButton_Click);
            // 
            // imageNameBox
            // 
            this.imageNameBox.Enabled = false;
            this.imageNameBox.Location = new System.Drawing.Point(263, 47);
            this.imageNameBox.Name = "imageNameBox";
            this.imageNameBox.Size = new System.Drawing.Size(109, 20);
            this.imageNameBox.TabIndex = 2;
            // 
            // updateImageButton
            // 
            this.updateImageButton.Location = new System.Drawing.Point(281, 102);
            this.updateImageButton.Name = "updateImageButton";
            this.updateImageButton.Size = new System.Drawing.Size(75, 23);
            this.updateImageButton.TabIndex = 3;
            this.updateImageButton.Text = "Обновить";
            this.updateImageButton.UseVisualStyleBackColor = true;
            this.updateImageButton.Click += new System.EventHandler(this.updateImageButton_Click);
            // 
            // EditUserImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.updateImageButton);
            this.Controls.Add(this.imageNameBox);
            this.Controls.Add(this.deleteImageButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imageBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditUserImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditUserImage";
            this.Load += new System.EventHandler(this.EditUserImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button deleteImageButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox imageNameBox;
        private System.Windows.Forms.Button updateImageButton;
    }
}