using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
    /// <summary>
    /// Struct for how we will store any passwords
    /// </summary>
    public struct PasswordStruct
    {
        public string WebSite { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public PasswordStruct(string Website, string Username, string Password)
        {
            this.WebSite = Website;
            this.Username = Username;
            this.Password = Password;
        }
    }

    public class passwordInfo : FlowLayoutPanel
    {

        private MainWindow form;
        public string WebSite { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Label SiteLabel { get; set; }
        public Label UsernameLabel { get; set; }

        public passwordInfo(PasswordStruct passwordbase, MainWindow form)
        {
            //Set info from password struct
            this.WebSite = passwordbase.WebSite;
            this.Username = passwordbase.Username;
            this.Password = passwordbase.Password;
            this.form = form;


            //Label to display site name
            SiteLabel = new Label();
            SiteLabel.Text = WebSite.Split("://").Last(); ;
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

            //Height and Width. Width should match the sidepanel width in MainWindow.cs, Height can be changed
            
            
            this.Padding = new Padding(0,10,0,10);
            this.FlowDirection = FlowDirection.TopDown;
            this.Click += PasswordInfo_Click;
            this.Controls.Add(this.SiteLabel);
            this.Controls.Add(this.UsernameLabel);
            
            this.MinimumSize= new Size(200,0);
            this.AutoSize = true;
        }

        private void PasswordInfo_Click(object? sender, EventArgs e)
        {
            //The panel and the labels both have this function when clicked
            //This is so if you click the text it still updates the infoDisplay

            //Selected variable to bold url in side bar
            form.Selected = this;
            form.Selected.SiteLabel.Font = new Font(form.Selected.SiteLabel.Font.Name, form.Selected.SiteLabel.Font.Size);
            this.SiteLabel.Font = new Font(SiteLabel.Font.Name, SiteLabel.Font.Size, FontStyle.Bold);

            //Setting info
            form.InfoDisplay.websitename.Text = WebSite.Split("://").Last();
            form.InfoDisplay.websiteLink.Text = WebSite;
            form.InfoDisplay.username.Text = Username;
            form.InfoDisplay.password.Text = "●●●●●●●●";
            form.InfoDisplay.realpassword = Password;
        }
    }
}
