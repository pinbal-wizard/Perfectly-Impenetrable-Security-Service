using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class passwordInfoDisplay: Panel
    {
        private Form1 form;
        public TransparentLabel websitename { get; set; }
        public TransparentLabel divider { get; set; }
        public TransparentLabel websiteLinkLabel { get; set; }
        public TransparentLabel websiteLink { get; set; }
        public TransparentLabel usernameLabel { get; set; }
        public TransparentLabel username { get; set; }
        public TransparentLabel passwordLabel { get; set; }
        public TransparentLabel password { get; set; }
        public Button hide { get; set; }
        public string realpassword { get; set; }
        public bool hidden { get; set; }
        
        public passwordInfoDisplay(Form1 form)
        {
            this.form = form;
            this.DoubleBuffered = true;
            hidden = true;
            realpassword = "wake up";
            websitename = new TransparentLabel();
            websitename.Text = "example.com";
            websitename.Location = new Point(0, 0);
            websitename.AutoSize = true;

            divider = new TransparentLabel();
            divider.Text = string.Empty;
            divider.BorderStyle = BorderStyle.Fixed3D;
            divider.AutoSize = false;
            divider.Height = 2;
            divider.Width = 400;
            divider.Location = new Point(0, 30);

            websiteLinkLabel = new TransparentLabel();
            websiteLinkLabel.Text = "Website Address";
            websiteLinkLabel.Location = new Point(0, 40);
            websiteLinkLabel.AutoSize = true;
            websiteLink = new TransparentLabel();
            websiteLink.Text = "https://example.com";
            websiteLink.Location = new Point(0, 60);
            websiteLink.AutoSize = true;

            usernameLabel = new TransparentLabel();
            usernameLabel.Text = "Username";
            usernameLabel.Location = new Point(0, 90);
            usernameLabel.AutoSize = true;
            username = new TransparentLabel();
            username.Text = "Boe Jiden";
            username.Location = new Point(0, 110);
            username.AutoSize = true;

            passwordLabel = new TransparentLabel();
            passwordLabel.Text = "Password";
            passwordLabel.Location = new Point(0, 140);
            passwordLabel.AutoSize = true;
            password = new TransparentLabel();
            password.Text = "●●●●●●●●";
            password.Location = new Point(0, 160);
            password.AutoSize = true;

            hide = new Button();
            hide.Size = new Size(20, 20);
            hide.Location = new Point(110, 160);
            hide.Click += Hide_Click;


            this.Width = form.ClientSize.Width - 200;
            this.Height = form.ClientSize.Height;
            this.Location = new Point(220, 10);
            //add to the infodisplay
            this.Controls.Add(websitename);
            this.Controls.Add(divider);
            this.Controls.Add(websiteLinkLabel);
            this.Controls.Add(websiteLink);
            this.Controls.Add(usernameLabel);
            this.Controls.Add(username);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(password);
            this.Controls.Add(hide);

        }

        private void Hide_Click(object? sender, EventArgs e)
        {
            hidden = !hidden;
            if (hidden == true)
            {
                password.Text = "●●●●●●●●";
            }
            else
            {
                password.Text = realpassword;
            }
        }
    }
}
