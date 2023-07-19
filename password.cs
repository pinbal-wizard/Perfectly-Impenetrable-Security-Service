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
        public Label SiteLabel { get; set; }
        public Label UsernameLabel { get; set; }

        public passwordInfo(string WebSite,string Username,string Password, Form1 form)
        {
            this.WebSite = WebSite;
            this.Username = Username;
            this.Password = Password;
            this.form = form;

            SiteLabel = new Label();
            SiteLabel.Text = WebSite;
            SiteLabel.Location = new Point(0,0);
            SiteLabel.Padding = new Padding(4);
            SiteLabel.Font = new Font("Arial", 8, FontStyle.Bold);

            UsernameLabel = new Label();
            UsernameLabel.Text = Username;
            UsernameLabel.Location = new Point(0,23);
            UsernameLabel.Padding = new Padding(4);

            this.Width = 200;
            this.Height = 75;
            this.Click += PasswordInfo_Click;
            this.Controls.Add(this.SiteLabel);
            this.Controls.Add(this.UsernameLabel);
            
        }

        private void PasswordInfo_Click(object? sender, EventArgs e)
        {
            form.infoDisplayItems[0].Text = WebSite;

            form.infoDisplayItems[1].Text = WebSite.Split("://").Last();
            form.infoDisplayItems[2].Text = Username;
            form.infoDisplayItems[3].Text = Password;
        }
    }
}
