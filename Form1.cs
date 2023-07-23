namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        FlowLayoutPanel sidePanel;
        public Panel infoDisplay;
        public List<Control> infoDisplayItems = new List<Control>();
        List<passwordInfo> passwords = new List<passwordInfo>();

        public Form1()
        {
            InitializeComponent();
        }

        private void DisplayPopup(object? sender, EventArgs e)
        {
            Popup popup = new Popup();
            popup.TopMost = true;
            popup.Show();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayPopup(sender, e);
            sidePanel = new FlowLayoutPanel();
            //ClientSize height is the height of the inner bit that is the actual form, normal height is the total window size, not useful
            sidePanel.Height = this.ClientSize.Height;
            sidePanel.Width = 200;
            //Disable horizontal scroll bars, setting autoscroll to false first is important
            sidePanel.AutoScroll = false;
            sidePanel.HorizontalScroll.Enabled = false;
            sidePanel.HorizontalScroll.Visible = false;
            sidePanel.HorizontalScroll.Maximum = 0;
            sidePanel.AutoScroll = true;
            //Right side divider
            this.Controls.Add(addDivider(1));
            //Example entrys
            passwords.Add(new passwordInfo("google", "thetruecool", "password123",this));
            passwords.Add(new passwordInfo("google", "thetruecool", "password123",this));
            passwords.Add(new passwordInfo("google", "thetruecool", "password123",this));
            passwords.Add(new passwordInfo("google", "thetruecool", "password123",this));
            passwords.Add(new passwordInfo("google", "thetruecool", "password123",this));
            //passwords.Add(new passwordInfo("google", "thetruecool", "password123"));

            //Add password panels and dividers below them
            foreach (passwordInfo pass in passwords)
            {
                sidePanel.Controls.Add(pass);
                sidePanel.Controls.Add(addDivider(0));

               
            }
            //if content is less than height disable scrolling, fixes anoying extra scrolling
            if (calcHeight(sidePanel) < sidePanel.Height)
            {
                sidePanel.AutoScroll = false;   
            }

            infoDisplay = new Panel();
            DisplayInfoInit();
            this.Controls.Add(sidePanel);
            this.Controls.Add(infoDisplay);
        }

        Label addDivider(int type)
        {
            //adds divider
            Label divider = new Label();
            divider.Text = string.Empty;
            divider.BorderStyle = BorderStyle.Fixed3D;
            divider.AutoSize = false;
            if (type == 0)
            {
                
                divider.Height = 2;
                divider.Width = 198;
                return divider;
            }
            divider.Height = this.Height;
            divider.Width = 2;
            divider.Location = new Point(201, 0);
            return divider;
        }
        int calcHeight(Control panel)
        {   //returns height of a panels content, there may be a better way to get this
            int height = 0;
            foreach (Control ctr in panel.Controls)
            {
                height += ctr.Height;
            }
            return height;
        }

        void DisplayInfoInit()
        {
            infoDisplay.Width = this.ClientSize.Width - 200;
            infoDisplay.Height = this.ClientSize.Height;
            infoDisplay.Location = new Point(220, 10);

            Label websitename = new Label();
            Label divider = new Label();
            Label websiteLinkLabel = new Label();
            Label websiteLink = new Label();
            Label usernameLabel = new Label();
            Label username = new Label();
            Label passwordLabel = new Label();
            Label password = new Label();

            websitename.Text = "example.com";
            websitename.Location = new Point(0, 0);

            divider.Text = string.Empty;
            divider.BorderStyle = BorderStyle.Fixed3D;
            divider.AutoSize = false;
            divider.Height = 2;
            divider.Width = 400;
            divider.Location = new Point(0, 30);

            websiteLinkLabel.Text = "Website Address";
            websiteLinkLabel.Location = new Point(0, 40);
            websiteLink.Text = "https://example.com";
            websiteLink.Location = new Point(0, 60);
            websiteLink.AutoSize = true;

            usernameLabel.Text = "Username";
            usernameLabel.Location = new Point(0, 90);
            username.Text = "Boe Jiden";
            username.Location = new Point(0, 110);

            passwordLabel.Text = "Password";
            passwordLabel.Location = new Point(0, 140);
            password.Text = "wake up";
            password.Location = new Point(0, 160);

            //add to the infodisplay
            infoDisplay.Controls.Add(websitename);
            infoDisplay.Controls.Add(divider);
            infoDisplay.Controls.Add(websiteLinkLabel);
            infoDisplay.Controls.Add(websiteLink);
            infoDisplay.Controls.Add(usernameLabel);
            infoDisplay.Controls.Add(username);
            infoDisplay.Controls.Add(passwordLabel);
            infoDisplay.Controls.Add(password);

            //add to list for easy modification
            infoDisplayItems.Add(websitename);
            infoDisplayItems.Add(websiteLink);;
            infoDisplayItems.Add(username);
            infoDisplayItems.Add(password);

        }

    }
}