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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string passcode = newTypedPasscodeValue;
            //compute hash of new passcode
            //set form.hash to the new password

            using (HashAlgorithm hash = MD5.Create())
            {
                string riddle = File.ReadAllLines("../../../riddle.txt").First();
                byte[] hashpassword = form.hash;
                string decypted = Serializer.Decrypt(riddle, hashpassword);
                byte[] newhash = hash.ComputeHash(Encoding.UTF8.GetBytes(newTypedPasscodeValue));
                string encryptedRiddle = Serializer.Encrypt(decypted, newhash);
                File.WriteAllText("../../../riddle.txt", encryptedRiddle);

            }
            this.Close();
        }


        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            newTypedPasscodeValue = InputTextBox.Text;
        }


    }
}
