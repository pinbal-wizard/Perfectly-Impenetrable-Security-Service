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
    /// Form for the Password Popup form
    /// </summary>
    public partial class MasterPasswordPopup : Form
    {
        private string password = "123";
        private bool showPassword = false; // flag to indicate whether the password is visible

        public MasterPasswordPopup()
        {
            InitializeComponent();
            PasswordTextBox.PasswordChar = '*'; // Censor the password by default

            this.AcceptButton = SubmitPassBtn;
        }

        private void ShowPasswordButton_Click(object sender, EventArgs e)
        {
            showPassword = !showPassword;

            if (showPassword)
            {
                ShowPassword();
                ShowPasswordButton.Text = "Hide Password";
            }
            else
            {
                HidePassword();
                ShowPasswordButton.Text = "Show Password";
            }
        }

        private void ShowPassword()
        {
            // Show the password in letters
            PasswordTextBox.PasswordChar = '\0'; // Set to '\0' (null character) to show letters
        }

        private void HidePassword()
        {
            // Censor the password with asterisks
            PasswordTextBox.PasswordChar = '*';
        }

        private void SubmitPassBtn_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == password)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Password is incorrect");
            }
        }
    }
}