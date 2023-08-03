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
    public partial class ChangePasscodePopup : Form
    {
        private MasterPasswordPopup masterPasswordPopupInstance;
        private string newTypedPasscodeValue;

        public ChangePasscodePopup()
        {
        }

        public ChangePasscodePopup(MasterPasswordPopup masterPasswordPopupInstance)
        {
            InitializeComponent();
            this.masterPasswordPopupInstance = masterPasswordPopupInstance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string passcode = newTypedPasscodeValue;
            masterPasswordPopupInstance.password = passcode;


        }



        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            newTypedPasscodeValue = InputTextBox.Text;
        }
    }
}
