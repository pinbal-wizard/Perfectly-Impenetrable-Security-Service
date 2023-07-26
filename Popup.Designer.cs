namespace WinFormsApp1
{
    partial class Popup
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
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(149, 101);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(100, 23);
            this.PasswordTextBox.TabIndex = 0;
            // 
            // EnterPassLabel
            // 
            this.EnterPassLabel.AutoSize = true;
            this.EnterPassLabel.Location = new System.Drawing.Point(149, 68);
            this.EnterPassLabel.Name = "EnterPassLabel";
            this.EnterPassLabel.Size = new System.Drawing.Size(87, 15);
            this.EnterPassLabel.TabIndex = 1;
            this.EnterPassLabel.Text = "Enter Password";
            this.EnterPassLabel.Click += new System.EventHandler(this.EnterPassLabel_Click);
            // 
            // SubmitPassBtn
            // 
            this.SubmitPassBtn.Location = new System.Drawing.Point(255, 100);
            this.SubmitPassBtn.Name = "SubmitPassBtn";
            this.SubmitPassBtn.Size = new System.Drawing.Size(75, 23);
            this.SubmitPassBtn.TabIndex = 2;
            this.SubmitPassBtn.Text = "Submit";
            this.SubmitPassBtn.UseVisualStyleBackColor = true;
            this.SubmitPassBtn.Click += new System.EventHandler(this.SubmitPassBtn_Click);
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 216);
            this.Controls.Add(this.SubmitPassBtn);
            this.Controls.Add(this.EnterPassLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Name = "Popup";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Popup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox PasswordTextBox;
        private Label EnterPassLabel;
        internal Button SubmitPassBtn;
    }
}