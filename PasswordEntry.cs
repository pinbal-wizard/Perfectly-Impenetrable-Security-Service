using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class PasswordEntry : Form
    {
        public string WebsiteName;
        public string Username;
        public string Password;

        public PasswordEntry()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            WebsiteName = textWebsiteName.Text.Trim();
            Username = textUsername.Text.Trim();    
            Password = textPassword.Text.Trim();   

            if (new[] {WebsiteName, Username, Password}.Any(string.IsNullOrEmpty))
            {
                MessageBox.Show("Please fill in all fields to save!");
            }
            else if (WebsiteName.Contains(" ") || Username.Contains(" ") || Password.Contains(" "))
            {
                MessageBox.Show("Space characters not accepted");
            }

            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
