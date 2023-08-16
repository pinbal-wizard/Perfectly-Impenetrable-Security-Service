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


        //This section defines the layout of username and password info, as well as the alignment of the copy buttons
        //Div here is in refrence to the divs used in html as a way of sectioning content and seperateing them
        //It is also in refrence to the flowlayout property resembling the nature of htmls divs
        //UsernamePasswordCopyDiv is the over all container div for everything
        //The section is then split into the usernamepassword and the copy button
        //This section into 2 seperate areas means that the copy buttons will always be aligned with each other
        //The username password div is then split into 2 divs for each section
        //Diagram:
        //usernamepasswordcopy div
        //------------------------------------
        //|---usernamepassword div--|copy div|
        //|| Label                  |        |
        //||------username div------|        |
        //|||                       |        |
        //|||  username             |  COPY  |
        //||------------------------|        |
        //||  Label                 |        |
        //||------password div------|        |
        //|||                       |        |
        //|||  password  hideButton |  COPY  |
        //||------------------------|        |
        //|-------------------------|--------|
        //------------------------------------
        public FlowLayoutPanel UsernamePasswordCopyDiv { get; set; }
        public FlowLayoutPanel UsernamePasswordDiv { get; set; }
        public FlowLayoutPanel CopyDiv { get; set; }
        public FlowLayoutPanel UsernameDiv { get; set; }
        public FlowLayoutPanel PasswordDiv { get; set; }
        int MagicTextboxMargin { get; set; }

        public TextBox UsernameLabel { get; set; }
        public TextBox Username { get; set; }
        public FlowLayoutPanel UsernamePanel { get; set; }
        public TextBox PasswordLabel { get; set; }        
        public TextBox Password { get; set; }
        public FlowLayoutPanel PasswordPanel { get; set; }
        public Label Divider2 { get; set; }
        public Button HideButton { get; set; }
        public Button CopyUserButton { get; set; }
        public Button CopyPassButton { get; set; }        
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

            //UsernamePassword Copy Button Conatiner Div(also a very cool div btw)
            //Purpose is to allow for alignment of the copybuttons in both directions
            InitUsernamePasswordCopyDiv();

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
            this.Width = form.ClientSize.Width - form.ClientSize.Width/5;
            this.Height = form.ClientSize.Height;
            this.Location = new Point(form.ClientSize.Width/5, 0);
            this.Padding = new Padding(40, 0, 40, 0);
            this.FlowDirection = FlowDirection.TopDown;
            this.AutoScroll = true;
            this.WrapContents = false;

            //Add items to the infodisplay
            this.Controls.Add(Websitename);
            this.Controls.Add(Divider);
            this.Controls.Add(WebsiteLinkLabel);
            this.Controls.Add(WebsiteLink);
            this.Controls.Add(UsernamePasswordCopyDiv);
            this.Controls.Add(Divider2);            
            this.Controls.Add(EditButton);
            this.Controls.Add(saveButton);
            this.Controls.Add(cancelButton);

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
                }
            }
            TextLenghAll();            
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
        /// Initialises the div storing the username password and copybuttons
        /// </summary>
        private void InitUsernamePasswordCopyDiv()
        {
            //Init sub divs
            InitUsernamePasswordDiv();
            InitCopyDiv();

            //Make the overall container div for this entire section
            UsernamePasswordCopyDiv = new FlowLayoutPanel();
            UsernamePasswordCopyDiv.FlowDirection = FlowDirection.LeftToRight;
            UsernamePasswordCopyDiv.AutoSize = true;
            UsernamePasswordCopyDiv.Controls.Add(UsernamePasswordDiv);
            UsernamePasswordCopyDiv.Controls.Add(CopyDiv);
        }
        /// <summary>
        /// Initialises the div storing the username and password divs
        /// </summary>
        private void InitUsernamePasswordDiv()
        {
            //Make the username Label
            UsernameLabel = new TextBox();
            UsernameLabel.Text = "Username";
            UsernameLabel.Margin = new Padding(0);
            UsernameLabel.Font = new Font("Arial", 7);
            UsernameLabel.BorderStyle = BorderStyle.None;
            UsernameLabel.BackColor = BackColor;
            UsernameLabel.ReadOnly = true;

            //Make the password Label
            PasswordLabel = new TextBox();
            PasswordLabel.Text = "Password";
            PasswordLabel.Font = new Font("Arial", 7);
            PasswordLabel.Margin = new Padding(0);
            PasswordLabel.BorderStyle = BorderStyle.None;
            PasswordLabel.BackColor = BackColor;
            PasswordLabel.ReadOnly = true; 

            //Run subdiv init functions
            InitUsernameDiv();
            InitPasswordDiv();

            //Make the username password container div
            //Items added in the order of Label then div
            UsernamePasswordDiv = new FlowLayoutPanel();
            UsernamePasswordDiv.FlowDirection = FlowDirection.TopDown;
            UsernamePasswordDiv.AutoSize = true;
            UsernamePasswordDiv.Controls.Add(UsernameLabel);
            UsernamePasswordDiv.Controls.Add(UsernameDiv);     
            UsernamePasswordDiv.Controls.Add(PasswordLabel);
            UsernamePasswordDiv.Controls.Add(PasswordDiv);
        }
        /// <summary>
        /// Initialises the div storing the username
        /// </summary>
        private void InitUsernameDiv()
        {          
            //Make a username, has a margin bottom of 40 to space it and the password div below it
            Username = new TextBox();
            Username.Text = "Boe Jiden";
            Username.Font = new Font("Arial", 10);
            Username.Margin = new Padding(0, 0, 0, 40);
            Username.BorderStyle = BorderStyle.None;
            Username.BackColor = BackColor;
            Username.ReadOnly = true;

            //Make a div to store the Username
            UsernameDiv = new FlowLayoutPanel();
            UsernameDiv.Margin = new Padding(0);
            UsernameDiv.FlowDirection = FlowDirection.LeftToRight;
            UsernameDiv.AutoSize = true;
            UsernameDiv.Controls.Add(Username);
        }

        /// <summary>
        /// Initialises the div storing the password and Hide Button
        /// </summary>
        private void InitPasswordDiv()
        {            
            //Make a Password textbox, set the chars to ● for security
            Password = new TextBox();
            Password.Text = RealPassword;
            Password.PasswordChar = '●';
            Password.Font = new Font("Arial", 9);
            Password.TextChanged += PasswordHideToggled;
            Password.Margin = new Padding(0);
            Password.BorderStyle = BorderStyle.None;
            Password.BackColor = BackColor;
            Password.ReadOnly = true;

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

            //Password Div
            PasswordDiv = new FlowLayoutPanel();
            PasswordDiv.FlowDirection = FlowDirection.LeftToRight;
            PasswordDiv.Margin = new Padding(0);
            PasswordDiv.AutoSize = true;
            PasswordDiv.Controls.Add(Password);
            PasswordDiv.Controls.Add(HideButton);
        }
        /// <summary>
        /// Initialises the div storing the copyButtons
        /// </summary>
        private void InitCopyDiv()
        {
            //Make a button to copy username
            CopyUserButton = new Button();
            CopyUserButton.Text = "Copy Username";
            CopyUserButton.Margin = new Padding(0, UsernameLabel.Height+MagicTextboxMargin, 0, 0);
            CopyUserButton.AutoSize = true;
            CopyUserButton.Click += CopyUserButton_Click;

            //Make a button to copy password
            CopyPassButton = new Button();
            CopyPassButton.Text = "Copy Password";
            CopyPassButton.Margin = new Padding(0,PasswordLabel.Height+ MagicTextboxMargin, 0, 0);
            CopyPassButton.AutoSize = true;
            CopyPassButton.Click += CopyPassButton_Click;

            //Make the div to store both of the above copybuttons
            CopyDiv = new FlowLayoutPanel();
            CopyDiv.FlowDirection = FlowDirection.TopDown;
            CopyDiv.Margin = new Padding(0);
            CopyDiv.AutoSize = true;
            CopyDiv.Controls.Add(CopyUserButton);
            CopyDiv.Controls.Add(CopyPassButton);
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
        /// Resest the read-only and the backcolor of the username and password textboxes to make it editable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, EventArgs e)
        {    
            //You get 20% screen and thats it
            int Percent20 = form.ClientSize.Width / 5;
            // Change websitename textbox to be editable
            WebsiteLink.ReadOnly = false;
            WebsiteLink.BackColor = Color.White;
            WebsiteLink.Width = Percent20;

            // Changing username textbox to be editable
            Username.ReadOnly = false;
            Username.BackColor = Color.White;
            Username.Width = Percent20;

            // Do the same thing to the password textbox
            Password.ReadOnly = false;
            Password.BackColor = Color.White;
            Password.Width = Percent20;
            
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
            //Revert website link textbox to read-only
            WebsiteLink.ReadOnly = true;
            WebsiteLink.BackColor = BackColor;
            TextLength(WebsiteLink);

            //Revert the username textbox to read-only
            Username.ReadOnly = true;
            Username.BackColor = BackColor;
            TextLength(Username);

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
        /// Saves the updated ìnfo into new password struct 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(Object sender, EventArgs e)
        {
            // Current logic looks kinda wonky
            // Basically it will take these fields and return it as string and check if null or not
            if (string.IsNullOrEmpty(Websitename.Text) || string.IsNullOrEmpty(Username.Text) || string.IsNullOrEmpty(Password.Text))
            {
                MessageBox.Show("Please fill in all fields to finalize edit");
                return; 
            }

            // If not null then save it
            string newWebsite = Websitename.Text;
            string newUsername = Username.Text;
            string newPassword = Password.Text;

            PasswordStruct newInfo = new PasswordStruct(newWebsite, newUsername, newPassword);
            form.Selected.passwordbase = newInfo;
            form.Selected.WebSite = newWebsite;
            form.Selected.Username = newUsername;
            form.Selected.Password = newPassword;

            form.PasswordsList[form.Selected.index] = newInfo;

            form.Selected.UpdateDisplay();

            //Revert website link textbox to read-only
            WebsiteLink.ReadOnly = true;
            WebsiteLink.BackColor = BackColor;
            TextLength(WebsiteLink);

            //Revert the username textbox to read-only
            Username.ReadOnly = true;
            Username.BackColor = BackColor;
            TextLength(Username);

            //Revert the password textbox to read-only and set it to the original size
            Password.ReadOnly = true;
            Password.BackColor = BackColor;
            Password.AutoSize = false;
            Password.Size = Password.GetPreferredSize(new Size(Password.Width, 0));
            }

        }
        /// <summary>
        /// updates position of hide button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordHideToggled(object? sender, EventArgs e)
        {
            TextLength(Password);
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
                Password.PasswordChar = '●';
            }
            else
            {
                Password.PasswordChar = '\0';
            }
        }

        /// <summary>
        /// Sets the Proper TextBoxLength for all Textboxes in infoDisplay
        /// </summary>
        public void TextLenghAll()
        {
            TextLength(Websitename);
            TextLength(WebsiteLink);
            TextLength(Username);
            TextLength(Password);
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
            WhatLengthAmI.Width = Test.Width+10;
            this.Controls.Remove(Test);
            if (WhatLengthAmI.Width < 60) WhatLengthAmI.Width = 60;
           
        }
        /// <summary>
        /// Copys username to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyUserButton_Click(object? sender, EventArgs e)
        {
            Clipboard.SetText(this.Username.Text);
        }

        /// <summary>
        /// Copys password to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyPassButton_Click (object? sender, EventArgs e)
        {
            Clipboard.SetText(this.Password.Text);
        }

        /// <summary>
        /// Somehow Textboxs in flow layout panels have a minimum bottom margin that is sepperate from the normal margin.
        /// You cannot remove this in any way or directly read its value.
        /// As such its value will be calculated through the sutraction of other items
        /// leaving the remainder to be the height of this magic bottom margin
        /// </summary>
        public void MagicMargin()
        {
            //Calculate magicmargin
            int TotalOfDiv = UsernamePasswordDiv.Height;
            int HeightOfContnets = form.CalcHeight(UsernamePasswordDiv);
            int differance = TotalOfDiv - HeightOfContnets;
            //since there are 2 labvles with magic margins we divide by 2
            MagicTextboxMargin = differance / 2;
        }
        /// <summary>
        /// Ads the proper margins to both of the copybuttons in infoDisplay.cs
        /// </summary>
        public void FixCopyMargins()
        {
            //Margin of Labels Height + magic number to align with actual username
            CopyUserButton.Margin = new Padding(0, UsernameLabel.Height + MagicTextboxMargin, 0, 0);
            //Above already accounts for one instance of Label and magic number
            //Height of full usernameDiv - the height of the button above gives margin to right below usernamediv
            //Add Another round of Label and magic number to align with actual password
            int heightOfUsername = UsernameDiv.Height - CopyUserButton.Height;
            CopyPassButton.Margin = new Padding(0, heightOfUsername + PasswordLabel.Height + MagicTextboxMargin, 0, 0);
        }
    }
}