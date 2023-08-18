namespace WinFormsApp1
{
    /// <summary>
    /// Main info display div
    /// just a lot of label inits
    /// </summary>
    public class PasswordInfoDisplay : FlowLayoutPanel
    {
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

        private Button _editButton;
        private Button _saveButton;
        private Button _cancelButton;

        private Button _hidePasswordButton;
        private Button _copyPasswordButton;

        private string _realPassword;
        private bool _isPasswordHidden;
        private readonly MainWindow _form;
        public FlowLayoutPanel UsernamePasswordCopyDiv { get; set; }
        public FlowLayoutPanel UsernamePasswordDiv { get; set; }
        public FlowLayoutPanel CopyDiv { get; set; }
        public FlowLayoutPanel UsernameDiv { get; set; }
        public FlowLayoutPanel PasswordDiv { get; set; }
        int MagicTextboxMargin { get; set; }


        private string _tempWebsitelink { get; set; }
        private string _tempUsername { get; set; }
        private string _tempPassword { get; set; }


        public Button CopyUserButton { get; set; }
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
            WebsiteLink.Click += WebsiteLink_Click;
            WebsiteLink.Margin = new Padding(0, 0, 0, 40);

            //Username Stuff
            _usernameLabel = new TextBox();
            _usernameLabel.Text = "Username";
            _usernameLabel.Margin = new Padding(0);
            _usernameLabel.Font = new Font("Arial", 7);

            //Password Label
            _passwordLabel = new TextBox();
            _passwordLabel.Text = "Password";
            _passwordLabel.Font = new Font("Arial", 7);
            _passwordLabel.Margin = new Padding(0);

            //Seperate panel (like a div) for password and button so that they can be on the same y level
            InitPasswordPanel();
            InitUsernamePasswordCopyDiv();

            //Cool bottom divider
            _divider2 = new Label();
            _divider2.Text = string.Empty;
            _divider2.BorderStyle = BorderStyle.Fixed3D;
            _divider2.AutoSize = false;
            _divider2.Height = 2;
            _divider2.Width = 100;
            _divider2.Margin = new Padding(0);

            InitEditButtons();

            //Width is rest of the form.
            this.Width = form.ClientSize.Width - form.ClientSize.Width / 5;
            this.Height = form.ClientSize.Height;
            this.Location = new Point(form.ClientSize.Width / 5, 0);
            this.Padding = new Padding(40, 0, 40, 0);
            this.FlowDirection = FlowDirection.TopDown;
            this.AutoScroll = true;
            this.WrapContents = false;

            //Add items to the infodisplay
            this.Controls.Add(Websitename);
            this.Controls.Add(_divider);
            this.Controls.Add(_websiteLinkLabel);
            this.Controls.Add(WebsiteLink);
            this.Controls.Add(UsernamePasswordCopyDiv);
            this.Controls.Add(_divider2);
            this.Controls.Add(_editButton);
            this.Controls.Add(_cancelButton);
            this.Controls.Add(_saveButton);
       

            //Levels of optimisation you would never find in autogenerated code
            foreach (Control ctr in Controls)
            {
                if (ctr.GetType() == typeof(TextBox))
                {
                    TextBox txt = ((TextBox)ctr);
                    txt.AutoSize = false;
                    txt.BorderStyle = BorderStyle.None;
                    txt.BackColor = BackColor;
                    txt.ReadOnly = true;
                    TextLength(txt);
                }
                TextLenghAll();
            }
        }

        #region Init Functions

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
            _usernameLabel = new TextBox();
            _usernameLabel.Text = "Username";
            _usernameLabel.Margin = new Padding(0);
            _usernameLabel.Font = new Font("Arial", 7);
            _usernameLabel.BorderStyle = BorderStyle.None;
            _usernameLabel.BackColor = BackColor;
            _usernameLabel.ReadOnly = true;

            //Make the password Label
            _passwordLabel = new TextBox();
            _passwordLabel.Text = "Password";
            _passwordLabel.Font = new Font("Arial", 7);
            _passwordLabel.Margin = new Padding(0);
            _passwordLabel.BorderStyle = BorderStyle.None;
            _passwordLabel.BackColor = BackColor;
            _passwordLabel.ReadOnly = true;

            //Run subdiv init functions
            InitUsernameDiv();
            InitPasswordDiv();

            //Make the username password container div
            //Items added in the order of Label then div
            UsernamePasswordDiv = new FlowLayoutPanel();
            UsernamePasswordDiv.FlowDirection = FlowDirection.TopDown;
            UsernamePasswordDiv.AutoSize = true;
            UsernamePasswordDiv.Controls.Add(_usernameLabel);
            UsernamePasswordDiv.Controls.Add(UsernameDiv);
            UsernamePasswordDiv.Controls.Add(_passwordLabel);
            UsernamePasswordDiv.Controls.Add(PasswordDiv);
        }


        /// <summary>
        /// Initialises the div storing the username
        /// </summary>
        private void InitUsernameDiv()
        {
            //Make a username, has a margin bottom of 40 to space it and the password div below it
            Username = new TextBox();
            Username.Text = "This will be the Username";
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
            Password.Text = _realPassword;
            Password.PasswordChar = '●';
            Password.Font = new Font("Arial", 9);;
            Password.Margin = new Padding(0);
            Password.BorderStyle = BorderStyle.None;
            Password.BackColor = BackColor;
            Password.ReadOnly = true;

            //Button to hide and unhide password
            _hidePasswordButton = new Button();
            _hidePasswordButton.Size = new Size(23, 23);
            _hidePasswordButton.Margin = new Padding(10, 0, 0, 0);
            _hidePasswordButton.Click += HidePasswordButton_Click;
            _hidePasswordButton.Image = Image.FromFile("..\\..\\..\\assets\\passwordHide.png");
            _hidePasswordButton.ImageAlign = ContentAlignment.TopCenter;
            _hidePasswordButton.FlatStyle = FlatStyle.Flat;
            _hidePasswordButton.FlatAppearance.BorderSize = 0;
            _hidePasswordButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            _hidePasswordButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            _hidePasswordButton.AutoSize = true;

            //Password Div
            PasswordDiv = new FlowLayoutPanel();
            PasswordDiv.FlowDirection = FlowDirection.LeftToRight;
            PasswordDiv.Margin = new Padding(0);
            PasswordDiv.AutoSize = true;
            PasswordDiv.Controls.Add(Password);
            PasswordDiv.Controls.Add(_hidePasswordButton);
        }
        /// <summary>
        /// Initialises the div storing the copyButtons
        /// </summary>
        private void InitCopyDiv()
        {
            //Make a button to copy username
            CopyUserButton = new Button();
            CopyUserButton.Text = "Copy Username";
            CopyUserButton.Margin = new Padding(0, _usernameLabel.Height + MagicTextboxMargin, 0, 0);
            CopyUserButton.AutoSize = true;
            CopyUserButton.Click += CopyUserButton_Click;

            //Make a button to copy password
            _copyPasswordButton = new Button();
            _copyPasswordButton.Text = "Copy Password";
            _copyPasswordButton.Margin = new Padding(0, _passwordLabel.Height + MagicTextboxMargin, 0, 0);
            _copyPasswordButton.AutoSize = true;
            _copyPasswordButton.Click += CopyPassButton_Click;

            //Make the div to store both of the above copybuttons
            CopyDiv = new FlowLayoutPanel();
            CopyDiv.FlowDirection = FlowDirection.TopDown;
            CopyDiv.Margin = new Padding(0);
            CopyDiv.AutoSize = true;
            CopyDiv.Controls.Add(CopyUserButton);
            CopyDiv.Controls.Add(_copyPasswordButton);
        }

        /// <summary>
        /// Initializing the edit button
        /// </summary>
        private void InitEditButtons()
        {
            _editButton = new Button();
            _editButton.Text = "Edit";
            _editButton.AutoSize = true;
            _editButton.Click += new EventHandler(EditButton_Click);

            _saveButton = new Button();
            _saveButton.Text = "Save";
            _saveButton.AutoSize = true;
            _saveButton.Visible = false;
            _saveButton.Click += new EventHandler(SaveButton_Click);

            _cancelButton = new Button();
            _cancelButton.Text = "Cancel";
            _cancelButton.AutoSize = true;
            _cancelButton.Visible = false;
            _cancelButton.Click += new EventHandler(CancelButton_Click);
        }

        /// <summary>
        /// Will initalise the password panel
        /// </summary>
        private void InitPasswordPanel()
        {
            //Actuall password, hidden initially
            Password = new TextBox();
            Password.Text = _realPassword;
            Password.PasswordChar = '●';
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
            _hidePasswordButton = new Button();
            _hidePasswordButton.Size = new Size(23, 23);
            _hidePasswordButton.Margin = new Padding(10, 0, 0, 0);
            _hidePasswordButton.Click += HidePasswordButton_Click;
            _hidePasswordButton.Image = Image.FromFile("..\\..\\..\\assets\\passwordHide.png");
            _hidePasswordButton.ImageAlign = ContentAlignment.TopCenter;
            _hidePasswordButton.FlatStyle = FlatStyle.Flat;
            _hidePasswordButton.FlatAppearance.BorderSize = 0;
            _hidePasswordButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            _hidePasswordButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            _hidePasswordButton.AutoSize = true;

        }

        #endregion

        /// <summary>
        /// updates position of hide button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordHideToggled(object? sender, EventArgs e)
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
        private void HidePasswordButton_Click(object? sender, EventArgs e)
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

        private void CopyPassButton_Click(object? sender, EventArgs e)
        {
            Clipboard.SetText(this.Password.Text);
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
        /// Resest the read-only and the backcolor of the username and password textboxes to make it editable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            //You get 20% screen and thats it
            int Percent20 = _form.ClientSize.Width / 5;
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
            _saveButton.Location = new Point(_editButton.Right, _editButton.Top);
            _cancelButton.Location = new Point(_saveButton.Left, _saveButton.Bottom + 10);

            // Show both buttons 
            _saveButton.Visible = true;
            _cancelButton.Visible = true;
            _editButton.Visible = false;

            _tempWebsitelink = WebsiteLink.Text;
            _tempUsername = Username.Text;
            _tempPassword = Password.Text;
        }

        /// <summary>
        /// Reset the textboxes property to read-only on clicking the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(Object sender, EventArgs e)
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

            WebsiteLink.Text = _tempWebsitelink;
            Username.Text = _tempUsername;
            Password.Text = _tempPassword;

            Websitename.Text = WebsiteLink.Text.Split("://").Last();
            TextLenghAll();
        }

        /// <summary>
        /// Saves the updated ìnfo into 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(Object sender, EventArgs e)
        {
            // Current logic looks kinda wonky
            // Basically it will take these fields and return it as string and check if null or not
            if (string.IsNullOrEmpty(Websitename.Text) || string.IsNullOrEmpty(Username.Text) || string.IsNullOrEmpty(Password.Text))
            {
                MessageBox.Show("Please fill in all fields to finalize edit");
                return;
            }

            if (_form.Selected == null)
            {
                MessageBox.Show("Please Create a Password Before Editing");
                return;
            }

            PasswordStruct newInfo = new PasswordStruct(Websitename.Text, Username.Text, Password.Text);
            _form.Selected.passwordbase = newInfo;
            _form.Selected.WebSite = Websitename.Text;
            _form.Selected.Username = Username.Text;
            _form.Selected.Password = Password.Text;
            Websitename.Text = WebsiteLink.Text.Split("://").Last();

            _form.PasswordsList[_form.Selected.index] = newInfo;

            _form.Selected.UpdateDisplay();

            _form.Selected.UpdateDisplay();

            //Revert website link textbox to read-only
            WebsiteLink.ReadOnly = true;
            WebsiteLink.BackColor = BackColor;

            //Revert the username textbox to read-only
            Username.ReadOnly = true;
            Username.BackColor = BackColor;

            //Revert the password textbox to read-only and set it to the original size
            Password.ReadOnly = true;
            Password.BackColor = BackColor;
            Password.AutoSize = false;
            Password.Size = Password.GetPreferredSize(new Size(Password.Width, 0));

            //Change the visibility of the edit button and the cancel button
            _editButton.Visible = true;
            _cancelButton.Visible = false;
            _saveButton.Visible = false;

            TextLenghAll();
        }

        /// <summary>
        /// Will either show or or hide the real password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hide_Click(object? sender, EventArgs e)
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
        /// Copys username to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyUserButton_Click(object? sender, EventArgs e)
        {
            Clipboard.SetText(this._usernameLabel.Text);
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
            int HeightOfContnets = _form.CalcHeight(UsernamePasswordDiv);
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
            CopyUserButton.Margin = new Padding(0, _usernameLabel.Height + MagicTextboxMargin, 0, 0);
            //Above already accounts for one instance of Label and magic number
            //Height of full usernameDiv - the height of the button above gives margin to right below usernamediv
            //Add Another round of Label and magic number to align with actual password
            int heightOfUsername = UsernameDiv.Height - CopyUserButton.Height;
            _copyPasswordButton.Margin = new Padding(0, heightOfUsername + _passwordLabel.Height + MagicTextboxMargin, 0, 0);
        }

        #endregion
    }
}