namespace WinFormsApp1
{
    partial class NewPasswordEntry
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
            this.WebsiteNameLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this._hidePassword = new Button();
            this.WebsiteNameTextbox = new System.Windows.Forms.TextBox();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.AddEntryButton = new System.Windows.Forms.Button();
            this.CancelEntryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WebsiteNameLabel
            // 
            this.WebsiteNameLabel.AutoSize = true;
            this.WebsiteNameLabel.Location = new System.Drawing.Point(61, 61);
            this.WebsiteNameLabel.Name = "WebsiteNameLabel";
            this.WebsiteNameLabel.Size = new System.Drawing.Size(124, 25);
            this.WebsiteNameLabel.Text = "Website name";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(61, 111);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(91, 25);
            this.UsernameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(61, 158);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(87, 25);
            this.PasswordLabel.Text = "Password";
            // 
            // WebsiteNameTextbox
            // 
            this.WebsiteNameTextbox.Location = new System.Drawing.Point(191, 57);
            this.WebsiteNameTextbox.Name = "WebsiteNameTextbox";
            this.WebsiteNameTextbox.Size = new System.Drawing.Size(244, 31);
            this.WebsiteNameTextbox.TabIndex = 0;
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(191, 107);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(244, 31);
            this.UsernameTextbox.TabIndex = 1;
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(191, 158);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '●';
            this.PasswordTextbox.Size = new System.Drawing.Size(244, 31);
            this.PasswordTextbox.TabIndex = 2;
            //
            // Hide Password Button
            //
            this._hidePassword.Location = new Point(191+PasswordTextbox.Width+50, 158);
            this._hidePassword.Text = "Show";
            this._hidePassword.Size = new Size(100, 31);
            this._hidePassword.TabIndex = 3;
            this._hidePassword.UseVisualStyleBackColor = true;
            this._hidePassword.Click += _hidePassword_Click;
            // 
            // AddEntryButton
            // 
            this.AddEntryButton.Location = new System.Drawing.Point(191, 230);
            this.AddEntryButton.Name = "AddEntryButton";
            this.AddEntryButton.Size = new System.Drawing.Size(112, 34);
            this.AddEntryButton.TabIndex = 4;
            this.AddEntryButton.Text = "Add";
            this.AddEntryButton.UseVisualStyleBackColor = true;
            this.AddEntryButton.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // CancelEntryButton
            // 
            this.CancelEntryButton.Location = new System.Drawing.Point(352, 229);
            this.CancelEntryButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelEntryButton.Name = "CancelEntryButton";
            this.CancelEntryButton.Size = new System.Drawing.Size(111, 35);
            this.CancelEntryButton.TabIndex = 5;
            this.CancelEntryButton.Text = "Cancel";
            this.CancelEntryButton.UseVisualStyleBackColor = true;
            this.CancelEntryButton.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // PasswordEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CancelEntryButton);
            this.Controls.Add(this.AddEntryButton);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this._hidePassword);
            this.Controls.Add(this.UsernameTextbox);
            this.Controls.Add(this.WebsiteNameTextbox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.WebsiteNameLabel);
            this.Name = "PasswordEntry";
            this.Text = "PasswordEntry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Label WebsiteNameLabel;
        private Label UsernameLabel;
        private Label PasswordLabel;
        private Button _hidePassword;
        private TextBox WebsiteNameTextbox;
        private TextBox UsernameTextbox;
        private TextBox PasswordTextbox;
        private Button AddEntryButton;
        private Button CancelEntryButton;
    }
}