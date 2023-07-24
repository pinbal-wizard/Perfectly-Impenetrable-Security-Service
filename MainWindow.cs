using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Policy;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainWindow : Form
    {
        FlowLayoutPanel sidePanel;
        internal passwordInfoDisplay infoDisplay;
        public List<Control> infoDisplayItems = new();
        List<password> passwords = new List<password>();
        public passwordInfo? Selected;
        private Button NewEntry;

        /// <summary>
        /// Readonly Property for reading the list of passwords
        /// ***This needs to change for future task of not keeping passwords stored in ram***
        /// </summary>
        public List<password> Passwords
        {
            get { return passwords; }
        }

        public MainWindow()
        {
            sidePanel= new FlowLayoutPanel();
            infoDisplay = new passwordInfoDisplay(this);
            NewEntry = new Button();

            InitializeComponent();
        }

        /// <summary>
        /// Public Function for adding passwords to the list off passwords
        /// ***Will need to be change to be more secure***
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int addEntry(string URL, string UserName, string Password)
        {
            passwords.Add(new password(URL, UserName, Password));
            return 0;
        }


        /// <summary>
        /// Saves Passwords to file as form is closed
        /// </summary>
        private void MainWindow_Deactivate(object? sender, EventArgs e)
        {
            Serializer.SaveToFile(this);
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            Serializer.LoadFromFile(this);
            //Basic Load
            this.DoubleBuffered = true;
            InitSidePanel();
            infoDisplay = new passwordInfoDisplay(this);
            this.Controls.Add(sidePanel);
            this.Controls.Add(infoDisplay);
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
            //Example entrys
            //No need to add any example entries as they save and load from file

            //Add password panels and dividers below them
            foreach (password pass in passwords)
            {
                sidePanel.Controls.Add(new passwordInfo(pass, this));
                sidePanel.Controls.Add(addDivider(0));
            }
            //if content is less than height disable scrolling, fixes anoying extra scrolling
            if (calcHeight(sidePanel) < sidePanel.Height) sidePanel.AutoScroll = false;


            //For now this works, will have to make more robust later
            Selected = (passwordInfo)sidePanel.Controls[0];

            infoDisplay = new passwordInfoDisplay(this);

            NewEntry = new Button();
            NewEntry.Location = new Point(this.ClientSize.Width - 100, 10);
            NewEntry.Click += NewEntry_Click;
            NewEntry.Text = "Add";
            NewEntry.AutoSize = true;
            NewEntry.Height = 40;

            this.Shown += MainWindow_Shown;
            this.Controls.Add(NewEntry);
            this.FormClosing +=  MainWindow_Deactivate;

        }


        private void MainWindow_Shown(object? sender, EventArgs e)
        {
            Popup pop = new Popup();
            pop.Show();
            NewEntry.BringToFront();
        }


        private void NewEntry_Click(object? sender, EventArgs e)
        {
            PasswordEntry pwde = new PasswordEntry();
            pwde.Show();
        }


        private void openPasswordEntry_Click(object sender, EventArgs e)
        {
            using (var passwordEntryForm = new PasswordEntry())
            {
                //Getting info from the entry form
                if (passwordEntryForm.ShowDialog() == DialogResult.OK)
                {
                    string websiteName = passwordEntryForm.WebsiteName;
                    string username = passwordEntryForm.Username; 
                    string password = passwordEntryForm.Password;

                    //Adding the info
                    passwords.Add(new password(websiteName, username, password));

                    //Displaying new entry
                    sidePanel.Controls.Clear();
                    
                    foreach(password pass in passwords)
                    {
                        sidePanel.Controls.Add(new passwordInfo(pass,this));
                        sidePanel.Controls.Add(addDivider(0));
                    }
                }
                else
                {

                }
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