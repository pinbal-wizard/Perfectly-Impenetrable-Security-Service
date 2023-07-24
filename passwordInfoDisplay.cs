﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
    public class passwordInfoDisplay: FlowLayoutPanel
    {
        private Form1 form;
        public Label websitename { get; set; }
        public Label divider { get; set; }
        public Label websiteLinkLabel { get; set; }
        public Label websiteLink { get; set; }
        public Label usernameLabel { get; set; }
        public Label username { get; set; }
        public Label passwordLabel { get; set; }
        public Panel passwordPanel { get; set; }
        public Label password { get; set; }
        public Button hide { get; set; }
        public Label divider2 { get; set; }
        public string realpassword { get; set; }
        public bool hidden { get; set; }
        
        public passwordInfoDisplay(Form1 form)
        {

            //FlowLayoutPanel with flow direction of top to bottom
            //No locations specified, instead distance between elements is controlled through padding and margin
            //Padding and margin are differnt, dont know how though
            //If an inline element like the button next to the password is needed
            //Put both items in a normal panel and add that to the FlowLayoutPanel

            //All elements have a margin added, even if it is zero for alignment reasons

            //form passed to get access to ClientSize
            this.form = form;
            this.DoubleBuffered = true;
            
            //Password hidden or not
            hidden = true;

            //Below is example default info so that it is not empty when you first open it
            realpassword = "wake up";

            //Website top title
            websitename = new Label();
            websitename.Text = "example.com";
            websitename.Font = new Font("Arial", 13, FontStyle.Bold);
            websitename.Padding = new Padding(0, 30, 0, 15);
            websitename.AutoSize = true;

            //Cool divider, padding 40 to create space bettwen it and things below
            divider = new Label();
            divider.Text = string.Empty;
            divider.BorderStyle = BorderStyle.Fixed3D;
            divider.AutoSize = false;
            divider.Height = 2;
            divider.Width = 400;
            divider.Margin = new Padding(0, 0, 0, 40);


            //Website link Label and actual link, link will actually work in future
            websiteLinkLabel = new Label();
            websiteLinkLabel.Text = "Website Address";
            websiteLinkLabel.Font = new Font("Arial", 7);
            websiteLinkLabel.Margin = new Padding(0);
            websiteLinkLabel.AutoSize = true;
            websiteLink = new Label();
            websiteLink.Text = "https://example.com";
            websiteLink.ForeColor = Color.Blue;
            websiteLink.Click += WebsiteLink_Click;
            websiteLink.Margin = new Padding(0, 0, 0, 40);
            websiteLink.AutoSize = true;


            //Username Stuff
            usernameLabel = new Label();
            usernameLabel.Text = "Username";
            usernameLabel.Margin = new Padding(0);
            usernameLabel.Font = new Font("Arial", 7);
            usernameLabel.AutoSize = true;
            username = new Label();
            username.Text = "Boe Jiden";
            username.Font = new Font("Arial", 10);
            username.Margin = new Padding(0, 0, 0, 40);
            username.AutoSize = true;

            
            //Password Label
            passwordLabel = new Label();
            passwordLabel.Text = "Password";
            passwordLabel.Font = new Font("Arial", 7);
            passwordLabel.Margin = new Padding(0);
            passwordLabel.AutoSize = true;

            //Seperate panel (like a div) for password and button so that they can be on the same y level
            InitPasswordPanel();

            //Cool bottom divider
            divider2 = new Label();
            divider2.Text = string.Empty;
            divider2.BorderStyle = BorderStyle.Fixed3D;
            divider2.AutoSize = false;
            divider2.Height = 2;
            divider2.Width = 100;
            divider2.Margin = new Padding(0,0,0,10);


            //Width is rest of the form.
            this.Width = form.ClientSize.Width - 200;
            this.Height = form.ClientSize.Height;
            this.Location = new Point(200, 0);
            this.Padding = new Padding(40,0,40,0);
            this.FlowDirection = FlowDirection.TopDown;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.AutoScroll = true;
            this.WrapContents = false;
            //Add items to the infodisplay
            this.Controls.Add(websitename);
            this.Controls.Add(divider);
            this.Controls.Add(websiteLinkLabel);
            this.Controls.Add(websiteLink);
            this.Controls.Add(usernameLabel);
            this.Controls.Add(username);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(passwordPanel);
            this.Controls.Add(divider2);
        }

        private void WebsiteLink_Click(object? sender, EventArgs e)
        {
            //Will open browser
        }

        private void InitPasswordPanel()
        {
            //Actuall password, hidden initially
            password = new Label();
            password.Text = "●●●●●●●●";
            password.Font = new Font("Arial", 9);
            password.Location = new Point(0, 1);
            password.SizeChanged += PasswordHideToggled;
            password.AutoSize = true;

            //Button to hide and unhide password
            hide = new Button();
            hide.Size = new Size(23, 23);
            //Xpos is always offsett by the password width, means that it will never overlap
            hide.Location = new Point(password.Size.Width, 0);
            hide.Click += Hide_Click;
            hide.Image = Image.FromFile("..\\..\\..\\assets\\passwordHide.png");
            hide.ImageAlign = ContentAlignment.TopCenter;
            hide.FlatStyle = FlatStyle.Flat;
            hide.FlatAppearance.BorderSize = 0;
            hide.FlatAppearance.MouseOverBackColor = Color.Transparent;
            hide.FlatAppearance.MouseDownBackColor = Color.Transparent;
            hide.AutoSize = true;
            //Container Panel
            passwordPanel = new Panel();
            passwordPanel.Margin = new Padding(0,0,0,40);
            passwordPanel.AutoSize = true;
            passwordPanel.Controls.Add(password);
            passwordPanel.Controls.Add(hide);
        }

        private void PasswordHideToggled(object? sender, EventArgs e)
        {
            hide.Location = new Point(password.Size.Width, 0);
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
