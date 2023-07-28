namespace WinFormsApp1
{
    partial class MasterPasswordPopup
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
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.EnterPassLabel = new System.Windows.Forms.Label();
            this.SubmitPassBtn = new System.Windows.Forms.Button();
            this.ShowPasswordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(213, 168);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(141, 31);
            this.PasswordTextBox.TabIndex = 0;
            // 
            // EnterPassLabel
            // 
            this.EnterPassLabel.AutoSize = true;
            this.EnterPassLabel.Location = new System.Drawing.Point(213, 113);
            this.EnterPassLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EnterPassLabel.Name = "EnterPassLabel";
            this.EnterPassLabel.Size = new System.Drawing.Size(132, 25);
            this.EnterPassLabel.TabIndex = 1;
            this.EnterPassLabel.Text = "Enter Password";
            // 
            // SubmitPassBtn
            // 
            this.SubmitPassBtn.Location = new System.Drawing.Point(437, 167);
            this.SubmitPassBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SubmitPassBtn.Name = "SubmitPassBtn";
            this.SubmitPassBtn.Size = new System.Drawing.Size(107, 38);
            this.SubmitPassBtn.TabIndex = 2;
            this.SubmitPassBtn.Text = "Submit";
            this.SubmitPassBtn.UseVisualStyleBackColor = true;
            this.SubmitPassBtn.Click += new System.EventHandler(this.SubmitPassBtn_Click);
            // 
            // ShowPasswordButton
            // 
            this.ShowPasswordButton.Location = new System.Drawing.Point(364, 167);
            this.ShowPasswordButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ShowPasswordButton.Name = "ShowPasswordButton";
            this.ShowPasswordButton.Size = new System.Drawing.Size(66, 38);
            this.ShowPasswordButton.TabIndex = 3;
            this.ShowPasswordButton.Text = "Show";
            this.ShowPasswordButton.UseVisualStyleBackColor = true;
            this.ShowPasswordButton.Click += new System.EventHandler(this.ShowPasswordButton_Click);
            // 
            // MasterPasswordPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 360);
            this.Controls.Add(this.ShowPasswordButton);
            this.Controls.Add(this.SubmitPassBtn);
            this.Controls.Add(this.EnterPassLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MasterPasswordPopup";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox PasswordTextBox;
        private Label EnterPassLabel;
        internal Button SubmitPassBtn;
        private Button ShowPasswordButton;
    }
}