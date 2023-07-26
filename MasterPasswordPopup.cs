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

        public MasterPasswordPopup()
        {
            InitializeComponent();
        }

        private void SubmitPassBtn_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == password)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Password is incorrect");

            }


        }
    }
}
