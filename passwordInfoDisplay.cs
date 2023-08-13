namespace WinFormsApp1
{
    /// <summary>
    /// Main info display div
    /// just a lot of label inits
    /// </summary>
    public class PasswordInfoDisplay : FlowLayoutPanel
    {
        public TextBox Websitename { get; set; }
        public TextBox WebsiteLink { get; set; }
        public TextBox Password { get; set; }
        public TextBox Username { get; set; }


        private Label _divider;//Line underneath Website Name 
        private Label _divider2; //Line underneath Password
        private Label Test; //bruh

        private TextBox _websiteLinkLabel;
        private TextBox _usernameLabel;
        private TextBox _passwordLabel;

        private FlowLayoutPanel _usernamePanel;
        private FlowLayoutPanel _passwordPanel;

        private Button _editButton;
        private Button _saveButton;
        private Button _cancelButton;

        private Button _hidePasswordButton;
        private Button _copyPasswordButton;

        private string _realPassword;
        private bool _isPasswordHidden;
        private readonly MainWindow _form;

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
            this._form = form;
            this.DoubleBuffered = true;
            //Password hidden or not
            _isPasswordHidden = true;

            //TestLabel for width
            Test = new Label();

            //Below is example default info so that it is not empty when you first open it
            _realPassword = "Password";

            //Website top title
            Websitename = new TextBox();
            Websitename.Text = "Please Make A Password Entry -->";
            Websitename.Font = new Font("Arial", 13, FontStyle.Bold);
            Websitename.Margin = new Padding(0, 30, 0, 15);
            TextLength(Websitename);

            //Cool divider, padding 40 to create space bettwen it and things below
            _divider = new Label();
            _divider.Text = string.Empty;
            _divider.BorderStyle = BorderStyle.Fixed3D;
            _divider.AutoSize = false;
            _divider.Height = 2;
            _divider.Width = 400;
            _divider.Margin = new Padding(0, 0, 0, 40);

            //Website link Label and actual link, link will actually work in future
            _websiteLinkLabel = new TextBox();
            _websiteLinkLabel.Text = "Website Address";
            _websiteLinkLabel.Font = new Font("Arial", 7);
            _websiteLinkLabel.Margin = new Padding(0);

            WebsiteLink = new TextBox();
            WebsiteLink.Text = "This will be where the URL will be";
            WebsiteLink.ForeColor = Color.Blue;
            WebsiteLink.Click += _websiteLink_Click;
            WebsiteLink.Margin = new Padding(0, 0, 0, 40);

            //Username Stuff
            _usernameLabel = new TextBox();
            _usernameLabel.Text = "Username";
            _usernameLabel.Margin = new Padding(0);
            _usernameLabel.Font = new Font("Arial", 7);

            //Seperate panel (like a div) for username
            _initUsernamePanel();

            //Password Label
            _passwordLabel = new TextBox();
            _passwordLabel.Text = "Password";
            _passwordLabel.Font = new Font("Arial", 7);
            _passwordLabel.Margin = new Padding(0);

            //Seperate panel (like a div) for password and button so that they can be on the same y level
            _InitPasswordPanel();

            //Cool bottom divider
            _divider2 = new Label();
            _divider2.Text = string.Empty;
            _divider2.BorderStyle = BorderStyle.Fixed3D;
            _divider2.AutoSize = false;
            _divider2.Height = 2;
            _divider2.Width = 100;
            _divider2.Margin = new Padding(0);

            _initEditButtons();

            _copyPasswordButton = new Button();
            _copyPasswordButton.Text = "Copy Password";
            _copyPasswordButton.Margin = new Padding(0,10,10,10);
            _copyPasswordButton.AutoSize = true;
            _copyPasswordButton.Click += _copyPassButton_Click;

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
            this.Controls.Add(_divider);
            this.Controls.Add(_websiteLinkLabel);
            this.Controls.Add(WebsiteLink);
            this.Controls.Add(_usernameLabel);
            this.Controls.Add(_usernamePanel);
            this.Controls.Add(_passwordLabel);
            this.Controls.Add(_passwordPanel);
            this.Controls.Add(_divider2);
            this.Controls.Add(_copyPasswordButton);
            this.Controls.Add(_editButton);
            this.Controls.Add(_cancelButton);
            this.Controls.Add(_saveButton);

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

        #region Init Functions

        /// <summary>
        /// Will initalise the username panel
        /// </summary>
        private void _initUsernamePanel()
        {
            Username = new TextBox();
            Username.Text = "This will be the Username";
            Username.Font = new Font("Arial", 10);
            Username.Margin = new Padding(0, 0, 0, 40);
            Username.BorderStyle = BorderStyle.None;
            Username.BackColor = BackColor;
            Username.ReadOnly = true;
            TextLength(Username);

            _usernamePanel = new FlowLayoutPanel();
            _usernamePanel.Margin = new Padding(0, 0, 0,0);
            _usernamePanel.AutoSize = true;
            _usernamePanel.Controls.Add(Username);
        }

        /// <summary>
        /// Initializing the edit button
        /// </summary>
        private void _initEditButtons()
        {
            _editButton = new Button();
            _editButton.Text = "Edit";
            _editButton.AutoSize = true;
            _editButton.Click += new EventHandler(_editButton_Click);

            _saveButton = new Button();
            _saveButton.Text = "Save";
            _saveButton.AutoSize = true;
            _saveButton.Visible = false;
            _saveButton.Click += new EventHandler(_saveButton_Click);

            _cancelButton = new Button();
            _cancelButton.Text = "Cancel";
            _cancelButton.AutoSize = true;
            _cancelButton.Visible = false;
            _cancelButton.Click += new EventHandler(_cancelButton_Click);
        }

        /// <summary>
        /// Will initalise the password panel
        /// </summary>
        private void _InitPasswordPanel()
        {
            //Actuall password, hidden initially
            Password = new TextBox();
            Password.Text = _realPassword;
            Password.PasswordChar = '●';
            Password.Font = new Font("Arial", 9);
            Password.TextChanged += _passwordHideToggled;
            Password.Margin = new Padding(0, 2, 0, 0);
            Password.AutoSize = true;
            Password.MaximumSize = new Size(400, 400000);
            Password.BorderStyle = BorderStyle.None;
            Password.BackColor = BackColor;
            Password.ReadOnly = true;
            TextLength(Password);


            //Button to hide and unhide password
            _hidePasswordButton = new Button();
            _hidePasswordButton.Size = new Size(23, 23);
            _hidePasswordButton.Margin = new Padding(10, 0, 0, 0);
            _hidePasswordButton.Click += _hidePasswordButton_Click;
            _hidePasswordButton.Image = Image.FromFile("..\\..\\..\\assets\\passwordHide.png");
            _hidePasswordButton.ImageAlign = ContentAlignment.TopCenter;
            _hidePasswordButton.FlatStyle = FlatStyle.Flat;
            _hidePasswordButton.FlatAppearance.BorderSize = 0;
            _hidePasswordButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            _hidePasswordButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            _hidePasswordButton.AutoSize = true;

            //Container Panel
            _passwordPanel = new FlowLayoutPanel();
            _passwordPanel.Margin = new Padding(0, 0, 0, 40);
            _passwordPanel.AutoSize = true;
            _passwordPanel.Controls.Add(Password);
            _passwordPanel.Controls.Add(_hidePasswordButton);
            _passwordPanel.Controls.Add(_copyPasswordButton);
        }

        #endregion

        /// <summary>
        /// updates position of hide button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _passwordHideToggled(object? sender, EventArgs e)
        {
            TextLength(Password);
            _hidePasswordButton.Location = new Point(Password.Size.Width, 0);
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

        #region Click Events

        /// <summary>
        /// Will either show or or hide the real password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _hidePasswordButton_Click(object? sender, EventArgs e)
        {
            //simple hide unhide code
            _isPasswordHidden = !_isPasswordHidden;
            if (_isPasswordHidden == true)
            {
                Password.PasswordChar = '●';
            }
            else
            {
                Password.PasswordChar = '\0';
            }
        }

        private void _copyPassButton_Click (object? sender, EventArgs e)
        {
            Clipboard.SetText(this.Password.Text);
        }

        /// <summary>
        /// **Will open browser**
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _websiteLink_Click(object? sender, EventArgs e)
        {
            //If i wanted it to crash i would try to access the negitive index of an array
            //Must fail silently because its not failing okay i will comit hate crime if this crashes the form while testing
            //failing means something broke, nothing happening is not something breaking
        }

        /// <summary>
        /// Resest the read-only and the backcolor of the username and password textboxes to make it editable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _editButton_Click(object sender, EventArgs e)
        {
            // Change websitename textbox to be editable
            WebsiteLink.ReadOnly = false;
            WebsiteLink.BackColor = Color.White;
            TextLength(WebsiteLink);

            // Changing username textbox to be editable
            Username.ReadOnly = false;
            Username.BackColor = Color.White;
            TextLength(Username);

            // Do the same thing to the password textbox
            Password.ReadOnly = false;
            Password.BackColor = Color.White;
            TextLength(Password);

            // Update the position of the "Cancel" and "Save" buttons
            _saveButton.Location = new Point(_editButton.Right, _editButton.Top);
            _cancelButton.Location = new Point(_saveButton.Left, _saveButton.Bottom + 10);

            // Show both buttons 
            _saveButton.Visible = true;
            _cancelButton.Visible = true;
            _editButton.Visible = false;
        }

        /// <summary>
        /// Reset the textboxes property to read-only on clicking the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _cancelButton_Click(Object sender, EventArgs e)
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
            _editButton.Visible = true;
            _cancelButton.Visible = false;
            _saveButton.Visible = false;
        }

        /// <summary>
        /// Saves the updated ìnfo into 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _saveButton_Click(Object sender, EventArgs e)
        {
            string newWebsite = Websitename.Text;
            string newUsername = Username.Text;
            string newPassword = Password.Text;

            PasswordStruct newInfo = new PasswordStruct(newWebsite, newUsername, newPassword);
            _form.Selected.passwordbase = newInfo;
            _form.Selected.WebSite = newWebsite;
            _form.Selected.Username = newUsername;
            _form.Selected.Password = newPassword;

            _form.PasswordsList[_form.Selected.index] = newInfo;

            _form.Selected.UpdateDisplay();

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
            _editButton.Visible = true;
            _cancelButton.Visible = false;
            _saveButton.Visible = false;
        }

        #endregion 
    }
}