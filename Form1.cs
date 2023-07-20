namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        FlowLayoutPanel sidePanel;
        internal passwordInfoDisplay infoDisplay;
        public List<Control> infoDisplayItems = new List<Control>();
        List<passwordInfo> passwords = new List<passwordInfo>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Deactivate(Object sender, EventArgs e)
        {
            Serializer.SaveToFile(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            passwords.Add(new passwordInfo("yandex", "thetruecool", "password123",this));
            passwords.Add(new passwordInfo("outlook", "thetruecool", "password123",this));
            passwords.Add(new passwordInfo("github", "thetruecool", "password123",this));
            passwords.Add(new passwordInfo("typingclub", "thetruecool", "password123",this));
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

            infoDisplay = new passwordInfoDisplay(this);
            this.Controls.Add(sidePanel);
            this.Controls.Add(infoDisplay);
            this.FormClosing += Form1_Deactivate;
            
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

       

    }
}