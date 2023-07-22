namespace WinFormsApp1
{
    partial class PasswordEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textWebsiteName = new TextBox();
            textUsername = new TextBox();
            textPassword = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 100);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(207, 41);
            label1.TabIndex = 0;
            label1.Text = "Website name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(104, 182);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(152, 41);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(104, 259);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(143, 41);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // textWebsiteName
            // 
            textWebsiteName.Location = new Point(325, 94);
            textWebsiteName.Margin = new Padding(5);
            textWebsiteName.Name = "textWebsiteName";
            textWebsiteName.Size = new Size(412, 47);
            textWebsiteName.TabIndex = 3;
            // 
            // textUsername
            // 
            textUsername.Location = new Point(325, 259);
            textUsername.Margin = new Padding(5);
            textUsername.Name = "textUsername";
            textUsername.Size = new Size(412, 47);
            textUsername.TabIndex = 4;
            // 
            // textPassword
            // 
            textPassword.Location = new Point(325, 176);
            textPassword.Margin = new Padding(5);
            textPassword.Name = "textPassword";
            textPassword.Size = new Size(412, 47);
            textPassword.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(325, 378);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(190, 56);
            button1.TabIndex = 6;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonSave_Click;
            // 
            // button2
            // 
            button2.Location = new Point(599, 376);
            button2.Name = "button2";
            button2.Size = new Size(188, 58);
            button2.TabIndex = 7;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonCancel_Click;
            // 
            // PasswordEntry
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1360, 738);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textPassword);
            Controls.Add(textUsername);
            Controls.Add(textWebsiteName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(5);
            Name = "PasswordEntry";
            Text = "PasswordEntry";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textWebsiteName;
        private TextBox textUsername;
        private TextBox textPassword;
        private Button button1;
        private Button button2;
    }
}