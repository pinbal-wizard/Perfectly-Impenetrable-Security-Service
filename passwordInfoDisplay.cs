using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace WinFormsApp1
{
    /// <summary>
    /// Main info display div
    /// just a lot of label inits
    /// </summary>
    public class PasswordInfoDisplay : FlowLayoutPanel
    {
        public TextBox Websitename { get; set; }
        public Label Divider { get; set; }
        public TextBox WebsiteLinkLabel { get; set; }
        public TextBox WebsiteLink { get; set; }
        public TextBox UsernameLabel { get; set; }
        public TextBox Username { get; set; }
        public FlowLayoutPanel UsernamePanel { get; set; }
        public TextBox PasswordLabel { get; set; }        
        public TextBox Password { get; set; }
        public FlowLayoutPanel PasswordPanel { get; set; }
        public Label Divider2 { get; set; }
        public Button HideButton { get; set; }

        Label Test;
        public Button EditButton;
        public Button saveButton;
        public Button cancelButton;
        public string RealPassword { get; set; }
        public bool IsHidden { get; set; }
        private MainWindow form;

        /// <summary>
        /// FlowLayoutPanel with flow direction of top to bottom
        ///No locations specified, instead distance between elements is controlled through padding and margin
        ///Padding and margin are differnt, dont know how though
        ///If an inline element like the button next to the password is needed
        ///Put both items in a normal panel and add that to the FlowLayoutPanel
        ///All elements have a margin added, even if it is zero for alignment reasons
        /// </summary>
        /// <param name="form"></param>
        public PasswordInfoDisplay(MainWindow form)
        {
            this.form = form;
            this.DoubleBuffered = true;
            //Password hidden or not
            IsHidden = true;
            //TestLabel for width
            Test = new Label();


            //Below is example default info so that it is not empty when you first open it
            RealPassword = "wake up";

            //Website top title
            Websitename = new TextBox();
            Websitename.Text = "example.com";
            Websitename.Font = new Font("Arial", 13, FontStyle.Bold);
            Websitename.Margin = new Padding(0, 30, 0, 15);
            TextLength(Websitename);

            //Cool divider, padding 40 to create space bettwen it and things below
            Divider = new Label();
            Divider.Text = string.Empty;
            Divider.BorderStyle = BorderStyle.Fixed3D;
            Divider.AutoSize = false;
            Divider.Height = 2;
            Divider.Width = 400;
            Divider.Margin = new Padding(0, 0, 0, 40);

            //Website link Label and actual link, link will actually work in future
            WebsiteLinkLabel = new TextBox();
            WebsiteLinkLabel.Text = "Website Address";
            WebsiteLinkLabel.Font = new Font("Arial", 7);
            WebsiteLinkLabel.Margin = new Padding(0);
            WebsiteLink = new TextBox();
            WebsiteLink.Text = "https://example.com";
            WebsiteLink.ForeColor = Color.Blue;
            WebsiteLink.Click += WebsiteLink_Click;
            WebsiteLink.Margin = new Padding(0, 0, 0, 40);

            //Username Stuff
            UsernameLabel = new TextBox();
            UsernameLabel.Text = "Username";
            UsernameLabel.Margin = new Padding(0);
            UsernameLabel.Font = new Font("Arial", 7);

            //Seperate panel (like a div) for username
            InitUsernamePanel();

            //Password Label
            PasswordLabel = new TextBox();
            PasswordLabel.Text = "Password";
            PasswordLabel.Font = new Font("Arial", 7);
            PasswordLabel.Margin = new Padding(0);

            //Seperate panel (like a div) for password and button so that they can be on the same y level
            InitPasswordPanel();

            //Cool bottom divider
            Divider2 = new Label();
            Divider2.Text = string.Empty;
            Divider2.BorderStyle = BorderStyle.Fixed3D;
            Divider2.AutoSize = false;
            Divider2.Height = 2;
            Divider2.Width = 100;
            Divider2.Margin = new Padding(0);
            InitEditButton();
            InitSaveButton();
            InitCancelButton();
           
            //Width is rest of the form.
            this.Width = form.ClientSize.Width - 200;
            this.Height = form.ClientSize.Height;
            this.Location = new Point(200, 0);
            this.Padding = new Padding(40, 0, 40, 0);
            this.FlowDirection = FlowDirection.TopDown;
            this.AutoScroll = true;
            this.WrapContents = false;

            //Add items to the infodisplay
            this.Controls.Add(Websitename);
            this.Controls.Add(Divider);
            this.Controls.Add(WebsiteLinkLabel);
            this.Controls.Add(WebsiteLink);
            this.Controls.Add(UsernameLabel);
            this.Controls.Add(UsernamePanel);
            this.Controls.Add(PasswordLabel);
            this.Controls.Add(PasswordPanel);
            this.Controls.Add(Divider2);
            this.Controls.Add(EditButton);
            this.Controls.Add(cancelButton);
            this.Controls.Add(saveButton);

                
            //Levels of optimisation you would never find in autogenerated code
            foreach(Control ctr in Controls)
            {
                if(ctr.GetType() == typeof(TextBox))
                {
                    TextBox txt = ((TextBox)ctr);
                    txt.AutoSize = false;
                    txt.BorderStyle = BorderStyle.None;
                    txt.BackColor = BackColor;
                    txt.ReadOnly = true;
                    TextLength(txt);


                }
            }
            
        }
        /// <summary>
        /// **Will open browser**
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebsiteLink_Click(object? sender, EventArgs e)
        {
            //If i wanted it to crash i would try to access the negitive index of an array
            //Must fail silently because its not failing okay i will comit hate crime if this crashes the form while testing
            //failing means something broke, nothing happening is not something breaking
        }

        /// <summary>
        /// Initializing the edit button
        /// </summary>
        private void InitEditButton()
        {
            EditButton = new Button();
            EditButton.Text = "Edit";
            EditButton.AutoSize = true;
            EditButton.Click += new EventHandler(EditButton_Click);
        }

        private void InitSaveButton()
        {
            saveButton = new Button();
            saveButton.Text = "Save";
            saveButton.AutoSize = true;
            saveButton.Visible = false;
            saveButton.Click += new EventHandler(saveButton_Click);
        }

        /// <summary>
        /// Initializing the cancel button, visibility is set to false until called upon
        /// </summary>
        private void InitCancelButton()
        {
            cancelButton = new Button();
            cancelButton.Text = "Cancel";
            cancelButton.AutoSize = true;
            cancelButton.Visible = false;
            cancelButton.Click += new EventHandler(cancelButton_Click);
        }

        /// <summary>
        /// Will initalise the username panel
        /// </summary>
        private void InitUsernamePanel()
        {
            Username = new TextBox();
            Username.Text = "Boe Jiden";
            Username.Font = new Font("Arial", 10);
            Username.Margin = new Padding(0, 0, 0, 40);
            Username.BorderStyle = BorderStyle.None;
            Username.BackColor = BackColor;
            Username.ReadOnly = true;
            TextLength(Username);

            UsernamePanel = new FlowLayoutPanel();
            UsernamePanel.Margin = new Padding(0, 0, 0,0);
            UsernamePanel.AutoSize = true;
            UsernamePanel.Controls.Add(Username);

        }

        /// <summary>
        /// Will initalise the password panel
        /// </summary>
        private void InitPasswordPanel()
        {
            //Actuall password, hidden initially
            Password = new TextBox();
            Password.Text = "●●●●●●●●";
            Password.Font = new Font("Arial", 9);
            Password.TextChanged += PasswordHideToggled;
            Password.Margin = new Padding(0, 2, 0, 0);
            Password.AutoSize = true;
            Password.MaximumSize = new Size(400, 400000);
            Password.BorderStyle = BorderStyle.None;
            Password.BackColor = BackColor;
            Password.ReadOnly = true;
            TextLength(Password);

            //Button to hide and unhide password
            HideButton = new Button();
            HideButton.Size = new Size(23, 23);
            HideButton.Margin = new Padding(10, 0, 0, 0);
            HideButton.Click += Hide_Click;
            HideButton.Image = Image.FromFile("..\\..\\..\\assets\\passwordHide.png");
            HideButton.ImageAlign = ContentAlignment.TopCenter;
            HideButton.FlatStyle = FlatStyle.Flat;
            HideButton.FlatAppearance.BorderSize = 0;
            HideButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HideButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            HideButton.AutoSize = true;
            //Container Panel
            PasswordPanel = new FlowLayoutPanel();
            PasswordPanel.Margin = new Padding(0, 0, 0, 40);
            PasswordPanel.AutoSize = true;
            PasswordPanel.Controls.Add(Password);
            PasswordPanel.Controls.Add(HideButton);
        }

        /// <summary>
        /// Resest the read-only and the backcolor of the username and password textboxes to make it editable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            // Changing username textbox to be editable
            Username.ReadOnly = false;
            Username.BackColor = Color.White;
            Username.AutoSize = true;

            // Do the same thing to the password textbox
            Password.ReadOnly = false;
            Password.BackColor = Color.White;
            Password.AutoSize = true;

            // Update the position of the "Cancel" and "Save" buttons
            saveButton.Location = new Point(EditButton.Right, EditButton.Top);
            cancelButton.Location = new Point(saveButton.Left, saveButton.Bottom + 10);

            // Show both buttons 
            saveButton.Visible = true;
            cancelButton.Visible = true;
            EditButton.Visible = false;
        }

        /// <summary>
        /// Reset the textboxes property to read-only on clicking the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(Object sender, EventArgs e) 
        {
            //Revert the username textbox to read-only
            Username.ReadOnly = true;
            Username.BackColor = BackColor;
            Username.AutoSize = true;

            //Revert the password textbox to read-only and set it to the original size
            Password.ReadOnly = true;
            Password.BackColor = BackColor;
            Password.AutoSize = false;
            Password.Size = Password.GetPreferredSize(new Size(Password.Width, 0));

            //Change the visibility of the edit button and the cancel button
            EditButton.Visible = true;
            cancelButton.Visible = false;
            saveButton.Visible = false;
        }

        /// <summary>
        /// Saves the updated ìnfo into 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(Object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// updates position of hide button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordHideToggled(object? sender, EventArgs e)
        {
            TextLength(Password);
            HideButton.Location = new Point(Password.Size.Width, 0);
        }

        /// <summary>
        /// Will either show or or hide the real password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hide_Click(object? sender, EventArgs e)
        {
            //simple hide unhide code
            IsHidden = !IsHidden;
            if (IsHidden == true)
            {
                Password.Text = "●●●●●●●●";
            }
            else
            {
                Password.Text = RealPassword;
            }
        }
        /// <summary>
        /// Set text box length to correct ammout.
        /// Little bit of a hack
        /// </summary>
        /// <param name="WhatLengthAmI"></param>
        public void TextLength(TextBox WhatLengthAmI)
        {
            Test.Text = WhatLengthAmI.Text;
            Test.Font = WhatLengthAmI.Font;
            Test.AutoSize = true;
            this.Controls.Add(Test);
            WhatLengthAmI.Width = Test.Width;
            this.Controls.Remove(Test);
           
        }
    }
}