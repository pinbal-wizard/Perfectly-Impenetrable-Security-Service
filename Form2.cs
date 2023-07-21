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
    public partial class Form2 : Form
    {
        TransparentLabel Prompt { get; set; }
        TextBox Input { get; set; }
        Form1 form { get; set; }
        public Form2(Form1 form)
        {
            this.form = form;
            InitializeComponent();
            this.Width = 300;
            this.Height = 120;
            this.Location = new Point(800, 400);

            Prompt = new TransparentLabel();
            Prompt.Text = "Please enter your Master Password";
            Prompt.Location = new Point(20, 0);
            Prompt.TextAlign = ContentAlignment.MiddleCenter;
            Prompt.Width = this.Width-50;

            Input = new TextBox();
            Input.Location = new Point(20, 30);
            Input.Width = this.Width-50;

            this.Controls.Add(Prompt);
            this.Controls.Add(Input);

        }
    }
}
