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
    public partial class ChangeMasterPasswordPopup : Form
    {     
        private MainWindow _form;

        private FlowLayoutPanel _panel;
        private FlowLayoutPanel _oldPasswordDiv;        
        private FlowLayoutPanel _newPasswordDiv;
        private FlowLayoutPanel _newPasswordConfirmDiv;

        private Label _oldPasswordLabel;
        private TextBox _oldPasswordTextBox;
        
        private Label _newPasswordLabel;
        private TextBox _newPasswordTextBox;

        private Label _newPasswordConfirmLabel;
        private TextBox _newPasswordConfirmTextBox;

        private Button _confirm;


        public ChangeMasterPasswordPopup(MainWindow form)
        {
            this._form = form;
            InitializeComponent();

            PasswordDivInit();

            _panel = new FlowLayoutPanel();
            _panel.AutoSize = true;
            _panel.FlowDirection = FlowDirection.TopDown;
            _panel.Padding = new Padding(50, 0, 0, 0);
            _panel.Controls.Add(_oldPasswordDiv);
            _panel.Controls.Add(_newPasswordDiv);
            _panel.Controls.Add(_newPasswordConfirmDiv);

            _confirm = new Button();
            _confirm.Text = "OK";
            _confirm.AutoSize = true;
            _confirm.Click += Confirm_Click;
            _panel.Controls.Add(_confirm);
            this.AcceptButton = _confirm;

            Controls.Add(_panel);
        }

        private void Confirm_Click(object? sender, EventArgs e)
        {
            //check old
            if (Serializer.ValidatePassword(_oldPasswordTextBox.Text) == 1)
            {
                MessageBox.Show("Current password is wrong");
                return;
            }
            //check if they are the same
            if (_newPasswordTextBox.Text != _newPasswordConfirmTextBox.Text)
            {
                MessageBox.Show("New paswords do not match");
                return;
            }
            //confirmed they are same so only need to check one
            if(_newPasswordTextBox.Text == String.Empty || _newPasswordTextBox.Text == "\n")
            {
                MessageBox.Show("Can not have a blank password");
                return;
            }
            //change it
            Serializer.ChangeMasterPassword(_form.hash,_newPasswordTextBox.Text);
            this.Close();
        }

        private void PasswordDivInit()
        {
            _oldPasswordLabel = new Label();
            _oldPasswordLabel.Text = "Enter Current Password";
            _oldPasswordLabel.Margin = new Padding(10, 2, 40, 0);
            _oldPasswordLabel.AutoSize = true;            

            _oldPasswordTextBox = new TextBox();
            _oldPasswordTextBox.PasswordChar = '●';

            _oldPasswordDiv = new FlowLayoutPanel();
            _oldPasswordDiv.FlowDirection = FlowDirection.LeftToRight;
            _oldPasswordDiv.Margin = new Padding(0, 20, 0, 20);
            _oldPasswordDiv.AutoSize = true;        
            _oldPasswordDiv.Controls.Add(_oldPasswordLabel);
            _oldPasswordDiv.Controls.Add(_oldPasswordTextBox);

            _newPasswordLabel = new Label();
            _newPasswordLabel.Text = "Enter New Password";
            _newPasswordLabel.AutoSize = true;
            _newPasswordLabel.Margin = new Padding(10, 2, 60, 0);

            _newPasswordTextBox = new TextBox();
            _newPasswordTextBox.PasswordChar = '●';

            _newPasswordDiv = new FlowLayoutPanel();
            _newPasswordDiv.FlowDirection = FlowDirection.LeftToRight;
            _newPasswordDiv.Margin = new Padding(0, 0, 0, 20);
            _newPasswordDiv.AutoSize = true;
            _newPasswordDiv.Controls.Add(_newPasswordLabel);
            _newPasswordDiv.Controls.Add(_newPasswordTextBox);

            _newPasswordConfirmLabel = new Label();
            _newPasswordConfirmLabel.Text = "Confirm New Password";
            _newPasswordConfirmLabel.Margin = new Padding(10, 2, 42, 0);
            _newPasswordConfirmLabel.AutoSize = true;

            _newPasswordConfirmTextBox = new TextBox();
            _newPasswordConfirmTextBox.PasswordChar = '●';

            _newPasswordConfirmDiv = new FlowLayoutPanel();
            _newPasswordConfirmDiv.FlowDirection = FlowDirection.LeftToRight;
            _newPasswordConfirmDiv.Margin = new Padding(0, 0, 0, 20);
            _newPasswordConfirmDiv.AutoSize = true;
            _newPasswordConfirmDiv.Controls.Add(_newPasswordConfirmLabel);
            _newPasswordConfirmDiv.Controls.Add(_newPasswordConfirmTextBox);
        }
    }
}
