﻿using System;
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
        private bool _isPasswordShown = false; // flag to indicate whether the password is visible
        public byte[] Password;
        private MainWindow _form;

        public MasterPasswordPopup(MainWindow form)
        {
            this._form = form;

            InitializeComponent();
            MasterPasswordPopup_SizeChanged(this, EventArgs.Empty);
            _passwordTextBox.PasswordChar = '●'; // Censor the password by default

            this.AcceptButton = _submitPassBtn;
            this.Load += OnLoad;
        }


        private void OnLoad(object sender, EventArgs e)
        {
            if (Serializer.ValidatePassword("") == 2)
            {
                this.DialogResult = DialogResult.Yes;
            }
        }

        /// <summary>
        /// Set password textbox char to null char so it is shown
        /// </summary>
        private void ShowPassword()
        {
            // Show the password in letters
            _passwordTextBox.PasswordChar = '\0'; // Set to '\0' (null character) to show letters
        }

        /// <summary>
        /// Set password textbox char to ● to hide it
        /// </summary>
        private void HidePassword()
        {
            // Censor the password with asterisks
            _passwordTextBox.PasswordChar = '●';
        }

        private void MasterPasswordPopup_SizeChanged(object sender, EventArgs e)
        {
            int halfWidth = ClientSize.Width / 2;
            int halfHeight = ClientSize.Height / 2;
            this._passwordTextBox.Location = new Point(halfWidth - this._passwordTextBox.Width, halfHeight);
            this._enterPassLabel.Location = new Point(halfWidth - this._enterPassLabel.Width / 2, halfHeight - (this._enterPassLabel.Height));
            this._submitPassBtn.Location = new Point(this._passwordTextBox.Location.X + this._passwordTextBox.Width + this._passwordTextBox.Margin.Right + this._showPasswordButton.Width + this._showPasswordButton.Margin.Right, halfHeight);
            this._showPasswordButton.Location = new Point(this._passwordTextBox.Location.X + this._passwordTextBox.Width + this._passwordTextBox.Margin.Right, halfHeight);
        }

        /// <summary>
        /// Button for Hiding and Showing password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPasswordButton_Click(object sender, EventArgs e)
        {
            _isPasswordShown = !_isPasswordShown;

            if (_isPasswordShown)
            {
                ShowPassword();
                _showPasswordButton.Text = "Hide Password";
            }
            else
            {
                HidePassword();
                _showPasswordButton.Text = "Show Password";
            }
        }

        /// <summary>
        /// Runs on button click and enter press.
        /// Handels password validation at a high level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitPassBtn_Click(object sender, EventArgs e)
        {
            int result = Serializer.ValidatePassword(_passwordTextBox.Text, out byte[] hashPassword);
            if (result == 0 & hashPassword != null)
            {
                _form._hash = hashPassword;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Password is incorrect");
                _passwordTextBox.Text = string.Empty;
            }
        }
    }
}