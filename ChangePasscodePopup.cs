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
    public partial class ChangePasscodePopup : Form
    {
        private MasterPasswordPopup masterPasswordPopupInstance;
        private string newTypedPasscodeValue;
        private MainWindow form;

        public ChangePasscodePopup(MainWindow form)
        {
            this.form = form;
            InitializeComponent();
        }

        public ChangePasscodePopup(MasterPasswordPopup masterPasswordPopupInstance)
        {
            InitializeComponent();
            this.masterPasswordPopupInstance = masterPasswordPopupInstance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string passcode = newTypedPasscodeValue;
            //compute hash of new passcode
            //set form.hash to the new password

            using (HashAlgorithm hash = MD5.Create())
            {
                byte[] key = hash.ComputeHash(Encoding.UTF8.GetBytes(newTypedPasscodeValue));
                form.hash = key;
                 
            }



        }



        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            newTypedPasscodeValue = InputTextBox.Text;
        }
    }
}
