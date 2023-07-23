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
    public partial class Popup : Form
    {
        private string password = "123";
        public Popup()
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

        private void EnterPassLabel_Click(object sender, EventArgs e)
        {


        }

        private void Popup_Load(object sender, EventArgs e)
        {

        }





        //Test Save
    }
}
