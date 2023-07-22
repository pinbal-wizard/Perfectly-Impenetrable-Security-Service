using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
    public struct password
    {
        public string WebSite { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public password(string Website, string Username, string Password)
        {
            this.WebSite = Website;
            this.Username = Username;
            this.Password = Password;
        }
    }

    public class passwordInfo : FlowLayoutPanel
    {

        private Form1 form;
        public string WebSite { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Label SiteLabel { get; set; }
        public Label UsernameLabel { get; set; }

        public passwordInfo(password passwordbase, Form1 form)
        {
            //Set info from password struct
            this.WebSite = passwordbase.WebSite.Split("://").Last();
            this.Username = passwordbase.Username;
            this.Password = passwordbase.Password;
            this.form = form;


            //Label to display site name
            SiteLabel = new Label();
            SiteLabel.Text = WebSite;
            SiteLabel.Padding = new Padding(12,0,18,0);
            SiteLabel.Font = new Font("Arial",10);
            SiteLabel.AutoSize = true; 
            SiteLabel.Click += PasswordInfo_Click;
            //Label to display the username
            UsernameLabel = new Label();
            UsernameLabel.Text = Username;
            UsernameLabel.Padding = new Padding(12,0,18,0);
            UsernameLabel.Font = new Font("Arial",8);
            UsernameLabel.AutoSize = true;
            UsernameLabel.Click += PasswordInfo_Click;

            //Height and Width. Width should match the sidepanel width in Form1.cs, Height can be changed
            this.Width = 200;
            this.Height = 75;
            this.AutoSize = true;
            this.Padding = new Padding(0,10,0,10);
            this.FlowDirection = FlowDirection.TopDown;
            this.Click += PasswordInfo_Click;
            this.Controls.Add(this.SiteLabel);
            this.Controls.Add(this.UsernameLabel);

            //Debug to see Label sizes
            //foreach (Label label in this.Controls) label.BorderStyle = BorderStyle.FixedSingle;

        }

        private void PasswordInfo_Click(object? sender, EventArgs e)
        {
            //The panel and the labels call this function when clicked
            //This is so if you click the text it still updates the infoDisplay
            form.Selected.SiteLabel.Font = new Font(form.Selected.SiteLabel.Font.Name, form.Selected.SiteLabel.Font.Size);
            form.Selected = this;
            this.SiteLabel.Font = new Font(SiteLabel.Font.Name, SiteLabel.Font.Size, FontStyle.Bold);

            form.infoDisplay.websitename.Text = WebSite.Split("://").Last();
            form.infoDisplay.websiteLink.Text = WebSite;
            form.infoDisplay.username.Text = Username;
            form.infoDisplay.password.Text = "●●●●●●●●";
            form.infoDisplay.realpassword = Password;
        }
    }
}
