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
        FlowLayoutPanel sidePanel;
        internal passwordInfoDisplay infoDisplay;
        public List<Control> infoDisplayItems = new List<Control>();
        List<password> passwords = new List<password>();
        public passwordInfo Selected;

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
            this.Controls.Add(sidePanel);
            this.Controls.Add(infoDisplay);
        }

        private void FormResized(object? sender, EventArgs e)
        {
            //Check if scrolling needed now
            sidePanel.AutoScroll = true;
            sidePanel.Height = this.ClientSize.Height;
            if (calcHeight(sidePanel)+40 < sidePanel.Height) sidePanel.AutoScroll = false;

            //Update side divider relies on side panel being first
            this.Controls[0].Height = this.ClientSize.Height;

        }

        private void InitSidePanel()
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

            //Example entrys will later pull from file load
            passwords.Add(new password("https://google.com", "thetruecool", "password123"));
            passwords.Add(new password("https://yandex.com", "thetruecool", "password123"));
            passwords.Add(new password("https://outlook.com", "thetruecool", "password123"));
            passwords.Add(new password("https://github.com", "thetruecool", "password123"));
            passwords.Add(new password("https://typingclub.com", "thetruecool", "password123"));

            //Add password panels and dividers below them
            foreach (password pass in passwords)
            {
                sidePanel.Controls.Add(new passwordInfo(pass, this));
                sidePanel.Controls.Add(addDivider(0));
            }
            //if content is less than height disable scrolling, fixes anoying extra scrolling
            if (calcHeight(sidePanel)+20 < sidePanel.Height) sidePanel.AutoScroll = false;


            //For now this works, will have to make more robust later
            Selected = (passwordInfo)sidePanel.Controls[0];

            infoDisplay = new passwordInfoDisplay(this);
            this.FormClosing += Form1_Deactivate;

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