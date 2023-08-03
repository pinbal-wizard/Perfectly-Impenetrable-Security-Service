using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WinFormsApp1
{
    /// <summary>
    /// Form for the Password Popup form
    /// </summary>
    public partial class MasterPasswordPopup : Form
    {
        private bool showPassword = false; // flag to indicate whether the password is visible
        private MainWindow form;
        public MasterPasswordPopup(MainWindow form)
        {
            InitializeComponent();
            PasswordTextBox.PasswordChar = '*'; // Censor the password by default
            this.form = form;
            this.AcceptButton = SubmitPassBtn;
        }

        /// <summary>
        /// Button for Hiding and Showing password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Set password textbox char to null char so it is shown
        /// </summary>
        private void ShowPassword()
        {
            // Show the password in letters
            PasswordTextBox.PasswordChar = '\0'; // Set to '\0' (null character) to show letters
        }
        /// <summary>
        /// Set password textbox char to ● to hide it
        /// </summary>
        private void HidePassword()
        {
            // Censor the password with asterisks
            PasswordTextBox.PasswordChar = '*';
        }
        /// <summary>
        /// Runs on button click and enter press.
        /// Handels password validation at a high level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitPassBtn_Click(object sender, EventArgs e)
        {
            if (ValidatePassword())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Password is incorrect");
            }
        }
        /// <summary>
        /// Validate if the entered password is correct
        /// </summary>
        /// <returns>True or False</returns>
        private bool ValidatePassword()
        {
            using (HashAlgorithm hash = MD5.Create())
            {
                string check = "";
                byte[] key = hash.ComputeHash(Encoding.UTF8.GetBytes(PasswordTextBox.Text));           
                if (CheckArraySame(key,form.hash))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Check of 2 byte arrays are the same, needed because a simple == check on arrays only checks if the refrence(pointer) is the same(which it will not be)
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns>True or False</returns>
        private bool CheckArraySame(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length) return false;
            for(int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i]) return false;
            }
            return true;
        }
    }
}