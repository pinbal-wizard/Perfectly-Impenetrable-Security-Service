namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        FlowLayoutPanel sidePanel;
        internal passwordInfoDisplay infoDisplay;
        public List<Control> infoDisplayItems = new List<Control>();
        List<password> passwords = new List<password>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            
            this.Shown += Form1_Shown;
           
            
        }

        private void Form1_Shown(object? sender, EventArgs e)
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
            passwords.Add(new password("google", "thetruecool", "password123"));
            passwords.Add(new password("yandex", "thetruecool", "password123"));
            passwords.Add(new password("outlook", "thetruecool", "password123"));
            passwords.Add(new password("outlook", "thetruecool", "password123"));
            passwords.Add(new password("typingclub", "thetruecool", "password123"));
            //passwords.Add(new passwordInfo("google", "thetruecool", "password123"));

            //Add password panels and dividers below them
            foreach (password pass in passwords)
            {
                sidePanel.Controls.Add(new passwordInfo(pass, this));
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
        }

        TransparentLabel addDivider(int type)
        {
            //adds divider
            TransparentLabel divider = new TransparentLabel();
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

    public class TransparentLabel : Label
    {
        public TransparentLabel()
        {
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parms = base.CreateParams;
                parms.ExStyle |= 0x20;  // Turn on WS_EX_TRANSPARENT
                return parms;
            }
        }
    }
}