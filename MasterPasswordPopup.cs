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
            MasterPasswordPopup_SizeChanged(this, null);
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
        /// Validate if the entered password is correct by decrypting some text using entered password
        /// </summary>
        /// <returns>True or False</returns>
        private bool ValidatePassword()
        {
            using (HashAlgorithm hash = MD5.Create())
            {
                string check = "riddle me this who is the real g";
                string test = File.ReadAllLines("../../../riddle.txt").First();
                byte[] hashpassword = hash.ComputeHash(Encoding.UTF8.GetBytes(PasswordTextBox.Text));
                string decypted = Serializer.Decrypt(test, hashpassword);
                if (decypted == check)
                {
                    form.hash = hashpassword;
                    return true;
                }
               
            }
            return false;
        }

        private void MasterPasswordPopup_SizeChanged(object sender, EventArgs e)
        {
            this.PasswordTextBox.Location = new Point((ClientSize.Width / 2) - this.PasswordTextBox.Width, ClientSize.Height / 2);
            this.EnterPassLabel.Location = new Point((ClientSize.Width / 2) - this.EnterPassLabel.Width / 2, (ClientSize.Height / 2) - (this.EnterPassLabel.Height));
            this.SubmitPassBtn.Location = new Point(this.PasswordTextBox.Location.X + this.PasswordTextBox.Width + this.PasswordTextBox.Margin.Right + this.ShowPasswordButton.Width + this.ShowPasswordButton.Margin.Right, ClientSize.Height / 2);
            this.ShowPasswordButton.Location = new Point(this.PasswordTextBox.Location.X + this.PasswordTextBox.Width + this.PasswordTextBox.Margin.Right, ClientSize.Height / 2);
        }

    }
}