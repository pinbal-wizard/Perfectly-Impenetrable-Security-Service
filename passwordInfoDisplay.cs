using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
    public class PasswordInfoDisplay : FlowLayoutPanel
    {
        public Label Websitename { get; set; }
        public Label Divider { get; set; }
        public Label WebsiteLinkLabel { get; set; }
        public Label WebsiteLink { get; set; }
        public Label UsernameLabel { get; set; }
        public Label Username { get; set; }
        public Label PasswordLabel { get; set; }
        public Panel PasswordPanel { get; set; }
        public Label Password { get; set; }
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

            PasswordPanel = new Panel();
            Password = new Label();
            HideButton = new Button();

            //Below is example default info so that it is not empty when you first open it
            RealPassword = "wake up";

            //Website top title
            Websitename = new Label();
            Websitename.Text = "example.com";
            Websitename.Font = new Font("Arial", 13, FontStyle.Bold);
            Websitename.Padding = new Padding(0, 30, 0, 15);
            Websitename.AutoSize = true;

            //Cool divider, padding 40 to create space bettwen it and things below
            Divider = new Label();
            Divider.Text = string.Empty;
            Divider.BorderStyle = BorderStyle.Fixed3D;
            Divider.AutoSize = false;
            Divider.Height = 2;
            Divider.Width = 400;
            Divider.Margin = new Padding(0, 0, 0, 40);

            //Website link Label and actual link, link will actually work in future
            WebsiteLinkLabel = new Label();
            WebsiteLinkLabel.Text = "Website Address";
            WebsiteLinkLabel.Font = new Font("Arial", 7);
            WebsiteLinkLabel.Margin = new Padding(0);
            WebsiteLinkLabel.AutoSize = true;
            WebsiteLink = new Label();
            WebsiteLink.Text = "https://example.com";
            WebsiteLink.ForeColor = Color.Blue;
            WebsiteLink.Click += WebsiteLink_Click;
            WebsiteLink.Margin = new Padding(0, 0, 0, 40);
            WebsiteLink.AutoSize = true;

            //Username Stuff
            UsernameLabel = new Label();
            UsernameLabel.Text = "Username";
            UsernameLabel.Margin = new Padding(0);
            UsernameLabel.Font = new Font("Arial", 7);
            UsernameLabel.AutoSize = true;
            Username = new Label();
            Username.Text = "Boe Jiden";
            Username.Font = new Font("Arial", 10);
            Username.Margin = new Padding(0, 0, 0, 40);
            Username.AutoSize = true;

            //Password Label
            PasswordLabel = new Label();
            PasswordLabel.Text = "Password";
            PasswordLabel.Font = new Font("Arial", 7);
            PasswordLabel.Margin = new Padding(0);
            PasswordLabel.AutoSize = true;

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
        }


        /// <summary>
        /// **Will open browser**
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void WebsiteLink_Click(object? sender, EventArgs e)
        {
            //This is how you do a function that hasnt been implemented 
            //Dont just fail silently 
            throw new NotImplementedException();
        }


        /// <summary>
        /// Will initalise the password panel
        /// </summary>
        private void InitPasswordPanel()
        {
            //Actuall password, hidden initially
            Password = new Label();
            Password.Text = "●●●●●●●●";
            Password.Font = new Font("Arial", 9);
            Password.Location = new Point(0, 1);
            Password.SizeChanged += PasswordHideToggled;
            Password.AutoSize = true;

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
            PasswordPanel.Margin = new Padding(0,0,0,40);
            PasswordPanel.AutoSize = true;
            PasswordPanel.Controls.Add(Password);
            PasswordPanel.Controls.Add(HideButton);
        }

        private void PasswordHideToggled(object? sender, EventArgs e)
        {
            HideButton.Location = new Point(Password.Size.Width, 0);
        }

        /// <summary>
        /// Will either show or or hide the real password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHidePasswordClick(object? sender, EventArgs e)
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
