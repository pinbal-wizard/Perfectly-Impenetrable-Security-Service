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
            this._passwordTextBox = new System.Windows.Forms.TextBox();
            this._enterPassLabel = new System.Windows.Forms.Label();
            this._submitPassBtn = new System.Windows.Forms.Button();
            this._showPasswordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            this._passwordTextBox.Location = new System.Drawing.Point(213, 168);
            this._passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._passwordTextBox.Name = "PasswordTextBox";
            this._passwordTextBox.Size = new System.Drawing.Size(141, 31);
            this._passwordTextBox.TabIndex = 0;
            // 
            // EnterPassLabel
            // 
            this._enterPassLabel.AutoSize = true;
            this._enterPassLabel.Location = new System.Drawing.Point(213, 113);
            this._enterPassLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._enterPassLabel.Name = "EnterPassLabel";
            this._enterPassLabel.Size = new System.Drawing.Size(132, 25);
            this._enterPassLabel.TabIndex = 1;
            this._enterPassLabel.Text = "Enter Password";
            // 
            // SubmitPassBtn
            // 
            this._submitPassBtn.Location = new System.Drawing.Point(437, 167);
            this._submitPassBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._submitPassBtn.Name = "SubmitPassBtn";
            this._submitPassBtn.Size = new System.Drawing.Size(107, 38);
            this._submitPassBtn.TabIndex = 2;
            this._submitPassBtn.Text = "Submit";
            this._submitPassBtn.UseVisualStyleBackColor = true;
            this._submitPassBtn.Click += new System.EventHandler(this.SubmitPassBtn_Click);
            // 
            // ShowPasswordButton
            // 
            this._showPasswordButton.Location = new System.Drawing.Point(364, 167);
            this._showPasswordButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._showPasswordButton.Name = "ShowPasswordButton";
            this._showPasswordButton.Size = new System.Drawing.Size(66, 38);
            this._showPasswordButton.TabIndex = 3;
            this._showPasswordButton.Text = "Show";
            this._showPasswordButton.UseVisualStyleBackColor = true;
            this._showPasswordButton.Click += new System.EventHandler(this.ShowPasswordButton_Click);
            // 
            // MasterPasswordPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 360);
            this.Controls.Add(this._showPasswordButton);
            this.Controls.Add(this._submitPassBtn);
            this.Controls.Add(this._enterPassLabel);
            this.Controls.Add(this._passwordTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MasterPasswordPopup";
            this.Text = "Form2";
            this.Resize += new System.EventHandler(this.MasterPasswordPopup_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox _passwordTextBox;
        private Label _enterPassLabel;
        private Button _submitPassBtn;
        private Button _showPasswordButton;
    }
}