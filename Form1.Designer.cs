namespace UserData
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);

            // Create labels for "Website Name," "Username," and "Password"
            this.lblWebsiteName = new System.Windows.Forms.Label();
            this.lblWebsiteName.Text = "Website Name:";
            this.lblWebsiteName.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(this.lblWebsiteName);

            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUsername.Text = "Username:";
            this.lblUsername.Location = new System.Drawing.Point(20, 50);
            this.Controls.Add(this.lblUsername);

            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPassword.Text = "Password:";
            this.lblPassword.Location = new System.Drawing.Point(20, 80);
            this.Controls.Add(this.lblPassword);

            // Create text boxes for the user to fill in data
            this.txtWebsiteName = new System.Windows.Forms.TextBox();
            this.txtWebsiteName.Location = new System.Drawing.Point(120, 20);
            this.Controls.Add(this.txtWebsiteName);

            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtUsername.Location = new System.Drawing.Point(120, 50);
            this.Controls.Add(this.txtUsername);

            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPassword.Location = new System.Drawing.Point(120, 80);
            this.Controls.Add(this.txtPassword);

            // Create the "Add" button
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAdd.Text = "Add";
            this.btnAdd.Location = new System.Drawing.Point(20, 110);
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.Controls.Add(this.btnAdd);

            // Set the form's text
            this.Text = "Form1";


            #endregion
        }
    }
}