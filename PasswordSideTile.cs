﻿using System;
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


    /// <summary>
    /// Class for how the Password Tiles are shown in the list of tiles as well as an extention of the PasswordStuct
    /// </summary>
    public class PasswordSideTile : FlowLayoutPanel
    {
        private MainWindow form;
        public string WebSite { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Label SiteLabel { get; set; }
        public Label UsernameLabel { get; }
        public PasswordStruct passwordbase { get; set; }
        public int index { get;set; }

        /// <summary>
        /// The Constructor for the Siderbar class uses a PasswordsStruct as a base 
        /// </summary>
        /// <param name="passwordbase"></param>
        /// <param name="form"></param>
        public PasswordSideTile(PasswordStruct passwordbase, int index,MainWindow form)
        {
            //Set info from password struct
            this.WebSite = passwordbase.WebSite;
            this.Username = passwordbase.Username;
            this.Password = passwordbase.Password;
            this.form = form;
            this.index = index;

            //Label to display site name
            SiteLabel = new Label();
            SiteLabel.Text = WebSite.Split("://").Last();
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
            
            this.MinimumSize= new Size(form.ClientSize.Width/5, 0);
            this.AutoSize = true;

        }
        /// <summary>
        /// SideTile displays the website link without the :// part, so on update set it to the bit after that
        /// </summary>
        public void UpdateDisplay()
        {
            //split, then last gets actual website name, then update Label
            SiteLabel.Text = WebSite.Split("://").Last();
            UsernameLabel.Text = Username;
        }


        /// <summary>
        /// Loads info into the main Display
        /// <br></br>***This is where the password popup should also be used as not to keep the master password or regular password stored in memory***
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PasswordInfo_Click(object? sender, EventArgs e)
        {
            //The panel and the labels both have this function when clicked
            //This is so if you click the text it still updates the infoDisplay

            //Selected variable to bold url in side bar
            if (form.Selected != null)
            {
                form.Selected.SiteLabel.Font = new Font(form.Selected.SiteLabel.Font.Name, form.Selected.SiteLabel.Font.Size);
                this.SiteLabel.Font = new Font(SiteLabel.Font.Name, SiteLabel.Font.Size, FontStyle.Bold);
            }
            form.Selected = this;
            //Update lengths
            foreach (Control ctr in form.InfoDisplay.Controls)
            {
                if (ctr.GetType() == typeof(TextBox))
                {
                    TextBox txt = (TextBox)ctr;
                    form.InfoDisplay.TextLength(txt);
                }
            }

                    //Setting info
            form.InfoDisplay.Websitename.Text = WebSite.Split("://").Last();
            form.InfoDisplay.WebsiteLink.Text = WebSite;
            form.InfoDisplay.Username.Text = Username;
            form.InfoDisplay.Password.Text = Password;
            form.InfoDisplay.Password.PasswordChar = '●';
            form.InfoDisplay.TextLength(form.InfoDisplay.WebsiteLink);
            form.InfoDisplay.TextLength(form.InfoDisplay.Websitename);
            form.InfoDisplay.TextLength(form.InfoDisplay.Username);
            form.InfoDisplay.TextLength(form.InfoDisplay.Password);
        }
    }
}
