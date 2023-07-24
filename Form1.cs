using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        FlowLayoutPanel sidePanelContainer;
        FlowLayoutPanel sidePanelPasswords;
        internal passwordInfoDisplay infoDisplay;
        List<password> passwords = new List<password>();
        public passwordInfo Selected;
        TextBox SearchBar;

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
            //Basic Load
            this.DoubleBuffered = true;
            this.ClientSizeChanged += FormResized;
            InitSidePanel();
            infoDisplay = new passwordInfoDisplay(this);
            //side panel must be first
            this.Controls.Add(addDivider(1));
            this.Controls.Add(sidePanelContainer);
            this.Controls.Add(infoDisplay);
            this.FormClosing += Form1_Deactivate;
        }

        private void FormResized(object? sender, EventArgs e)
        {
            //Sidepanel
            //Check if scrolling needed now
            //25v MessageBox.Show(sidePanelContainer.Controls[0].Height.ToString());
            //Height of searchbar section is 45
            sidePanelContainer.Height = this.ClientSize.Height;
            sidePanelPasswords.Height = this.ClientSize.Height-45;
            sidePanelPasswords.AutoScroll = true;
            if (calcHeight(sidePanelPasswords)+30 < this.ClientSize.Height-45) sidePanelPasswords.AutoScroll = false;


            //Update side divider relies on side panel being first
            this.Controls[0].Height = this.ClientSize.Height;

            //InfoDisplay update width and height
            infoDisplay.Width = this.ClientSize.Width - 200;
            infoDisplay.Height = this.ClientSize.Height;       
        }

        private void InitSidePanel()
        {
            //First make the container div
            sidePanelContainer = new FlowLayoutPanel();
            //ClientSize height is the height of the inner bit that is the actual form, normal height is the total window size, not useful
            sidePanelContainer.Height = this.ClientSize.Height;
            sidePanelContainer.Width = 200;
           
            //no scroling
            sidePanelContainer.AutoScroll = false;
            //Searchbar
            SearchBar = new TextBox();
            SearchBar.Margin = new Padding(12,10, 18, 10);
            SearchBar.Width = 170;
            SearchBar.TextChanged += SearchPasswords;

            //Add top elements
            sidePanelContainer.Controls.Add(SearchBar);
            sidePanelContainer.Controls.Add(addDivider(0));
            //Disable horizontal scroll bars, setting autoscroll to false first is important
            //Wrap is for scrolling to work
            sidePanelPasswords = new FlowLayoutPanel();
            sidePanelPasswords.Height = this.ClientSize.Height - 40;
            sidePanelPasswords.AutoScroll = false;
            sidePanelPasswords.HorizontalScroll.Enabled = false;
            sidePanelPasswords.HorizontalScroll.Visible = false;
            sidePanelPasswords.HorizontalScroll.Maximum = 0;
            sidePanelPasswords.AutoScroll = true;
            sidePanelPasswords.FlowDirection = FlowDirection.TopDown;
            sidePanelPasswords.WrapContents = false;



            //Example entrys will later pull from file load
            passwords.Add(new password("https://google.com", "thetruecool", "password123"));
            passwords.Add(new password("https://yandex.com", "thetruecool", "password123"));
            passwords.Add(new password("https://outlook.com", "thetruecool", "password123"));
            passwords.Add(new password("https://github.com", "thetruecool", "password123"));
            passwords.Add(new password("https://typingclub.com", "thetruecool", "password123"));

            //Add password panels and dividers below them
            foreach (password pass in passwords)
            {
                sidePanelPasswords.Controls.Add(new passwordInfo(pass, this));
                sidePanelPasswords.Controls.Add(addDivider(0));
            }
            //if content is less than height disable scrolling, fixes anoying extra scrolling
            if (calcHeight(sidePanelPasswords) + 20 < this.ClientSize.Height - 45) sidePanelContainer.AutoScroll = false;

            //For now this works, will have to make more robust later
            Selected = (passwordInfo)sidePanelPasswords.Controls[0];
            sidePanelContainer.Controls.Add(sidePanelPasswords);
        }

        private void SearchPasswords(object? sender, EventArgs e)
        {
            List<passwordInfo> changes = new List<passwordInfo>();
            //perform search
            foreach (password pass in passwords)
            {
                if(pass.WebSite.Contains(SearchBar.Text) || pass.Username.Contains(SearchBar.Text))
                {
                    changes.Add(new passwordInfo(pass, this));
                }
            }
            //loop through until differance is found
            //i declared here becaue it is used elsewhere
            int i;
            for(i = 0; i < changes.Count && i < sidePanelPasswords.Controls.Count/2; i++)
            {
                //i*2 because every second element is a passwordInfo, every other is a Label
                passwordInfo current = (passwordInfo)sidePanelPasswords.Controls[i * 2];

                if (current.WebSite == changes[i].WebSite && current.Username == changes[i].Username)
                {

                }
                else
                {
                    //inversion cringe
                    //differance found, position marked with i
                    break;
                }
            }
            //remove rest of panel based of where change was found, start at i*2 to skip labels
            for(int j = i*2; sidePanelPasswords.Controls.Count != i*2; j++)
            {
                //remove at i because all elements drop down when you remove one
                sidePanelPasswords.Controls.RemoveAt(i);
            }
            //add rest of changes
            for (;i < changes.Count; i++)
            {
                sidePanelPasswords.Controls.Add(changes[i]);
                sidePanelPasswords.Controls.Add(addDivider(0));
            }
        }

        Label addDivider(int type)
        {
            //adds divider
            //Type 0 is for side Panel
            //Type 1 is a full Height veritcal
            Label divider = new Label();
            divider.Text = string.Empty;
            divider.BorderStyle = BorderStyle.Fixed3D;
            divider.AutoSize = false;
            if (type == 0)
            {  
                divider.Height = 2;
                divider.Width = 200;
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