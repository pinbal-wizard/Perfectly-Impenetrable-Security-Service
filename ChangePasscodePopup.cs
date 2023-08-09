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
        private MainWindow form;
        private FlowLayoutPanel panel;
        private FlowLayoutPanel oldPasswordDiv;        
        private FlowLayoutPanel newPasswordDiv;
        private FlowLayoutPanel newPasswordConfirmDiv;

        private Label oldPasswordLabel;
        private TextBox oldPasswordTextBox;
        
        private Label newPasswordLabel;
        private TextBox newPasswordTextBox;

        private Label newPasswordConfirmLabel;
        private TextBox newPasswordConfirmTextBox;

        private Button Confirm;


        public ChangePasscodePopup(MainWindow form)
        {
            this.form = form;
            InitializeComponent();
        }
        private void ChangePasscodePopup_Load(object sender, EventArgs e)
        {
            oldPasswordDivInit();            
            newPasswordDivInit();
            newPasswordConfirmDivInit();
            panel = new FlowLayoutPanel();
            panel.AutoSize = true;
            panel.FlowDirection = FlowDirection.TopDown;
            panel.Padding = new Padding(50, 0, 0, 0);
            panel.Controls.Add(oldPasswordDiv);
            panel.Controls.Add(newPasswordDiv);
            panel.Controls.Add(newPasswordConfirmDiv);

            Confirm = new Button();
            Confirm.Text = "OK";
            Confirm.AutoSize = true;
            Confirm.Click += Confirm_Click;
            panel.Controls.Add(Confirm);
            this.AcceptButton = Confirm;

            Controls.Add(panel);
        }

        private void Confirm_Click(object? sender, EventArgs e)
        {
            //check old
            if (!ValidatePassword())
            {
                MessageBox.Show("Current password is wrong");
                return;
            }
            //check if they are the same
            if (newPasswordTextBox.Text != newPasswordConfirmTextBox.Text)
            {
                MessageBox.Show("New paswords do not match");
                return;
            }
            //confirmed they are same so only need to check one
            if(newPasswordTextBox.Text == String.Empty || newPasswordTextBox.Text == "\n")
            {
                MessageBox.Show("Can not have a blank password");
                return;
            }
            //change it
            using (HashAlgorithm hash = MD5.Create())
            {

                string riddle = File.ReadAllLines("../../../riddle.txt").First();
                byte[] hashpassword = form.hash;
                string decypted = Serializer.Decrypt(riddle, hashpassword);
                byte[] newhash = hash.ComputeHash(Encoding.UTF8.GetBytes(newPasswordConfirmTextBox.Text));
                string encryptedRiddle = Serializer.Encrypt(decypted, newhash);
                File.WriteAllText("../../../riddle.txt", encryptedRiddle);
            }
            this.Close();
        }

        private void oldPasswordDivInit()
        {
            oldPasswordLabel = new Label();
            oldPasswordLabel.Text = "Enter Current Password";
            oldPasswordLabel.Margin = new Padding(10, 2, 40, 0);
            oldPasswordLabel.AutoSize = true;            

            oldPasswordTextBox = new TextBox();
            oldPasswordTextBox.PasswordChar = '●';

            oldPasswordDiv = new FlowLayoutPanel();
            oldPasswordDiv.FlowDirection = FlowDirection.LeftToRight;
            oldPasswordDiv.Margin = new Padding(0, 20, 0, 20);
            oldPasswordDiv.AutoSize = true;        
            oldPasswordDiv.Controls.Add(oldPasswordLabel);
            oldPasswordDiv.Controls.Add(oldPasswordTextBox);
        }

        

        private void newPasswordDivInit()
        {
            newPasswordLabel = new Label();
            newPasswordLabel.Text = "Enter New Password";
            newPasswordLabel.AutoSize = true;
            newPasswordLabel.Margin = new Padding(10, 2, 60, 0);

            newPasswordTextBox = new TextBox();
            newPasswordTextBox.PasswordChar = '●';

            newPasswordDiv = new FlowLayoutPanel();
            newPasswordDiv.FlowDirection = FlowDirection.LeftToRight;
            newPasswordDiv.Margin = new Padding(0, 0, 0, 20);
            newPasswordDiv.AutoSize = true;
            newPasswordDiv.Controls.Add(newPasswordLabel);
            newPasswordDiv.Controls.Add(newPasswordTextBox);
        }

        private void newPasswordConfirmDivInit()
        {
            newPasswordConfirmLabel = new Label();
            newPasswordConfirmLabel.Text = "Confirm New Password";
            newPasswordConfirmLabel.Margin = new Padding(10,2, 42, 0);
            newPasswordConfirmLabel.AutoSize = true;
            
            newPasswordConfirmTextBox = new TextBox();
            newPasswordConfirmTextBox.PasswordChar = '●';

            newPasswordConfirmDiv = new FlowLayoutPanel();
            newPasswordConfirmDiv.FlowDirection = FlowDirection.LeftToRight;
            newPasswordConfirmDiv.Margin = new Padding(0, 0, 0, 20);
            newPasswordConfirmDiv.AutoSize = true;
            newPasswordConfirmDiv.Controls.Add(newPasswordConfirmLabel);
            newPasswordConfirmDiv.Controls.Add(newPasswordConfirmTextBox);
        }

        private bool ValidatePassword()
        {
            using (HashAlgorithm hash = MD5.Create())
            {
                string check = "riddle me this who is the real g";
                string test = File.ReadAllLines("../../../riddle.txt").First();
                byte[] hashpassword = hash.ComputeHash(Encoding.UTF8.GetBytes(oldPasswordTextBox.Text));
                string decypted = Serializer.Decrypt(test, hashpassword);
                form.hash = hashpassword;
                if (decypted == check)
                {
                    form.hash = hashpassword;
                    return true;
                }

            }
            return false;
        }
    }
}
