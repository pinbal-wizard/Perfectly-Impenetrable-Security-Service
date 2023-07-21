using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class passwordInfo:Panel
    {
        private Form1 form;
        public string WebSite { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public TransparentLabel SiteLabel { get; set; }
        public TransparentLabel UsernameLabel { get; set; }

        public passwordInfo(string WebSite,string Username,string Password, Form1 form)
        {
            this.WebSite = WebSite;
            this.Username = Username;
            this.Password = Password;
            this.form = form;

            SiteLabel = new TransparentLabel();
            SiteLabel.Text = WebSite;
            SiteLabel.Location = new Point(0,0);
            SiteLabel.Margin = new Padding(4);
            SiteLabel.Font = new Font("Arial", 8, FontStyle.Bold);
            SiteLabel.Click += PasswordInfo_Click;

            UsernameLabel = new TransparentLabel();
            UsernameLabel.Text = Username;
            UsernameLabel.Location = new Point(0,23);
            UsernameLabel.Margin = new Padding(4);
            UsernameLabel.Click += PasswordInfo_Click;

            this.Width = 200;
            this.Height = 75;
            this.Click += PasswordInfo_Click;
            this.Controls.Add(this.SiteLabel);
            this.Controls.Add(this.UsernameLabel);
            
        }

        private void PasswordInfo_Click(object? sender, EventArgs e)
        {
            form.infoDisplay.websitename.Text = WebSite.Split("://").Last();
            form.infoDisplay.websiteLink.Text = WebSite;
            form.infoDisplay.username.Text = Username;
            form.infoDisplay.password.Text = "●●●●●●●●";
            form.infoDisplay.realpassword = Password;
        }
    }
}
