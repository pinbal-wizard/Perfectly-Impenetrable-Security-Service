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
    public partial class PasswordEntry : Form
    {
        private string websiteName;
        private string username;
        private string password;


        /// <summary>
        /// Get the website name as a field
        /// </summary>
        public string WebsiteName
        {
            get { return websiteName; }
        }

        /// <summary>
        /// Gets the Username as a field
        /// </summary>
        public string Username
        {
            get { return username; }
        }


        /// <summary>
        /// Gets the the Password as a field
        /// <br></br>***Not Very good Security is it***
        /// </summary>
        public string Password
        {
            get { return password; }
        }


        public PasswordEntry()
        {
            websiteName = string.Empty;
            username = string.Empty;
            password = string.Empty;

            InitializeComponent();
        }


        /// <summary>
        /// 0 Reference Gaming  ¯\_(ツ)_/¯
        /// <br></br>Idk
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


        /// <summary>
        /// 0 Reference Gaming (¬_¬ )
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
