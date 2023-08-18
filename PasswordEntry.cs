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
    /// <summary>
    /// Form for adding new PasswordStruct and or PasswordSideBar Tiles
    /// </summary>
    public partial class NewPasswordEntry : Form
    {
        private string websiteName;
        private string username;
        private string password;


        /// <summary>
        /// Get the website name as a field
        /// Added the setter to access values, but this will remove the read-only property
        /// </summary>
        public string WebsiteName
        {
            get { return websiteName; }
            set { websiteName = value; }
        }

        /// <summary>
        /// Gets the Username as a field
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }


        /// <summary>
        /// Gets the the Password as a field
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public NewPasswordEntry()
        {
            websiteName = string.Empty;
            username = string.Empty;
            password = string.Empty;

            InitializeComponent();
        }
        /// <summary>
        /// Hides and unhides the password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _hidePassword_Click(object sender, EventArgs e)
        {
            if(_hidePassword.Text == "Show")
            {
                PasswordTextbox.PasswordChar = '\0';
                _hidePassword.Text = "Hide";
                return;
            }
            PasswordTextbox.PasswordChar = '●';
            _hidePassword.Text = "Show";
        }



        /// <summary>
        /// Check if inputed data is valid and save it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            websiteName = WebsiteNameTextbox.Text.Trim();
            username = UsernameTextbox.Text.Trim();    
            password = PasswordTextbox.Text.Trim();   

            if (new[] {WebsiteName, Username, Password}.Any(string.IsNullOrEmpty))
            {
                MessageBox.Show("Please fill in all fields to save!");
            }
            else if (WebsiteName.Contains(" "))
            {
                MessageBox.Show("Space characters in url not accepted");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        /// <summary>
        /// Send cancel event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
