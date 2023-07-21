using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
    public class passwordInfoDisplay: Panel
    {
        private Form1 form;
        public Label websitename { get; set; }
        public Label divider { get; set; }
        public Label websiteLinkLabel { get; set; }
        public Label websiteLink { get; set; }
        public Label usernameLabel { get; set; }
        public Label username { get; set; }
        public Label passwordLabel { get; set; }
        public Label password { get; set; }
        public Button hide { get; set; }
        public string realpassword { get; set; }
        public bool hidden { get; set; }
        
        public passwordInfoDisplay(Form1 form)
        {
            //form passed to get access to ClientSize
            this.form = form;
            this.DoubleBuffered = true;
            //Password hidden or not
            hidden = true;

            //Below is example default info so that it is not empty when you first open it
            realpassword = "wake up";
            websitename = new Label();
            websitename.Text = "example.com";
            websitename.Location = new Point(0, 0);
            websitename.AutoSize = true;

            divider = new Label();
            divider.Text = string.Empty;
            divider.BorderStyle = BorderStyle.Fixed3D;
            divider.AutoSize = false;
            divider.Height = 2;
            divider.Width = 400;
            divider.Location = new Point(0, 30);

            websiteLinkLabel = new Label();
            websiteLinkLabel.Text = "Website Address";
            websiteLinkLabel.Location = new Point(0, 40);
            websiteLinkLabel.AutoSize = true;
            websiteLink = new Label();
            websiteLink.Text = "https://example.com";
            websiteLink.Location = new Point(0, 60);
            websiteLink.AutoSize = true;

            usernameLabel = new Label();
            usernameLabel.Text = "Username";
            usernameLabel.Location = new Point(0, 90);
            usernameLabel.AutoSize = true;
            username = new Label();
            username.Text = "Boe Jiden";
            username.Location = new Point(0, 110);
            username.AutoSize = true;

            passwordLabel = new Label();
            passwordLabel.Text = "Password";
            passwordLabel.Location = new Point(0, 140);
            passwordLabel.AutoSize = true;
            password = new Label();
            password.Text = "●●●●●●●●";
            password.Location = new Point(0, 160);
            password.AutoSize = true;

            //Button to hide and unhide password
            hide = new Button();
            hide.Size = new Size(20, 20);
            hide.Location = new Point(110, 160);
            hide.Click += Hide_Click;

            //Width is rest of the form. the Location is offsett 20 from the side panel
            this.Width = form.ClientSize.Width - 220;
            this.Height = form.ClientSize.Height;
            this.Location = new Point(220, 10);
            //Add items to the infodisplay
            this.Controls.Add(websitename);
            this.Controls.Add(divider);
            this.Controls.Add(websiteLinkLabel);
            this.Controls.Add(websiteLink);
            this.Controls.Add(usernameLabel);
            this.Controls.Add(username);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(password);
            

            //Debug to see Label sizes
            //foreach (Label label in this.Controls) label.BorderStyle = BorderStyle.FixedSingle;

            //Button added after so that debug works
            this.Controls.Add(hide);

        }

        private void Hide_Click(object? sender, EventArgs e)
        {
            //simple hide unhide code
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
