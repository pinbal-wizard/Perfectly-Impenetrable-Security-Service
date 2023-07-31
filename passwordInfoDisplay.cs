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
        public TextBox PasswordLabel { get; set; }
        public Panel PasswordPanel { get; set; }
        public TextBox Password { get; set; }
        public Label Divider2 { get; set; }
        public Button HideButton { get; set; }
        public string RealPassword { get; set; }
        public bool IsHidden { get; set; }

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
            this.DoubleBuffered = true;
            //Password hidden or not
            IsHidden = true;



            //Below is example default info so that it is not empty when you first open it
            RealPassword = "wake up";

            //Website top title
            Websitename = new TextBox();
            Websitename.Text = "example.com";
            Websitename.Font = new Font("Arial", 13, FontStyle.Bold);
            Websitename.Padding = new Padding(0, 30, 0, 15);

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
            Username = new TextBox();
            Username.Text = "Boe Jiden";
            Username.Font = new Font("Arial", 10);
            Username.Margin = new Padding(0, 0, 0, 40);

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
            this.Controls.Add(Username);
            this.Controls.Add(PasswordLabel);
            this.Controls.Add(PasswordPanel);
            this.Controls.Add(Divider2);

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
                    Label Test = new Label();
                    Test.AutoSize = true;
                    Test.Font = txt.Font;
                    Test.Text = txt.Text;
                    txt.MinimumSize = new Size(Test.Width, 0);
                    txt.AutoSize = true;


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
        /// Will initalise the password panel
        /// </summary>
        private void InitPasswordPanel()
        {
            //Actuall password, hidden initially
            Password = new TextBox();
            Password.Text = "●●●●●●●●";
            Password.Font = new Font("Arial", 9);
            Password.Location = new Point(0, 1);
            Password.SizeChanged += PasswordHideToggled;
            Password.AutoSize = true;
            Password.BorderStyle = BorderStyle.None;
            Password.BackColor = BackColor;
            Password.ReadOnly = true;

            //Button to hide and unhide password
            HideButton = new Button();
            HideButton.Size = new Size(23, 23);
            //Xpos is always offsett by the password width, means that it will never overlap
            HideButton.Location = new Point(Password.Size.Width, 0);
            HideButton.Click += Hide_Click;
            HideButton.Image = Image.FromFile("..\\..\\..\\assets\\passwordHide.png");
            HideButton.ImageAlign = ContentAlignment.TopCenter;
            HideButton.FlatStyle = FlatStyle.Flat;
            HideButton.FlatAppearance.BorderSize = 0;
            HideButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HideButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            HideButton.AutoSize = true;
            //Container Panel
            PasswordPanel = new Panel();
            PasswordPanel.Margin = new Padding(0, 0, 0, 40);
            PasswordPanel.AutoSize = true;
            PasswordPanel.Controls.Add(Password);
            PasswordPanel.Controls.Add(HideButton);
        }

        /// <summary>
        /// updates position of hide button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordHideToggled(object? sender, EventArgs e)
        {
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
    }
}