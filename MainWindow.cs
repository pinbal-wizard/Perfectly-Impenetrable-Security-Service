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
    /// <summary>
    /// This is the class of the main window of the program
    /// </summary>
    public partial class MainWindow : Form
    {
        private List<password> _passwordsList = new List<password>();
        private List<Control> _infoDisplayItems = new List<Control>();

        private FlowLayoutPanel _sidePanel;
        private Button _newEntry;

        public passwordInfo? Selected;
        public passwordInfoDisplay InfoDisplay;


        /// <summary>
        /// Readonly Property for reading the list of PasswordsList
        /// ***This needs to change for future task of not keeping PasswordsList stored in ram***
        /// </summary>
        public List<password> PasswordsList
        {
            get { return _passwordsList; }
        }

        public MainWindow()
        {
            _sidePanel = new FlowLayoutPanel();
            InfoDisplay = new passwordInfoDisplay(this);
            _newEntry = new Button();

            InitializeComponent();
        }


        /// <summary>
        /// Public Function for adding PasswordsList to the list off PasswordsList
        /// <br></br>***Will need to be change to be more secure to complete other backlog tasks***
        /// </summary>
        /// <returns></returns>
        public int AddEntry(string URL, string UserName, string Password)
        {
            PasswordsList.Add(new password(URL, UserName, Password));
            return 0;
        }


        /// <summary>
        /// Saves PasswordsList to file as form is closed
        /// </summary>
        private void MainWindow_Deactivate(object? sender, EventArgs e)
        {
            Serializer.SaveToFile(this);
        }


        /// <summary>
        /// Main Function to Load the MainWindow form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            Serializer.LoadFromFile(this);
            //Basic Load
            this.DoubleBuffered = true;

            Init_sidePanel();

            this.Controls.Add(_sidePanel);
            this.Controls.Add(InfoDisplay);
        }

        /// <summary>
        /// Initalises the form       
        /// <br></br>*****This Function sucks because it says it initalises the sidePanel yet it initalises the whole form*****
        /// </summary>
        /// <returns></returns>
        private int Init_sidePanel()
        {
            _sidePanel = new FlowLayoutPanel();
            //ClientSize height is the height of the inner bit that is the actual form, normal height is the total window size, not useful
            _sidePanel.Height = this.ClientSize.Height;
            _sidePanel.Width = 200;

            //Disable horizontal scroll bars, setting autoscroll to false first is important
            _sidePanel.AutoScroll = false;
            _sidePanel.HorizontalScroll.Enabled = false;
            _sidePanel.HorizontalScroll.Visible = false;
            _sidePanel.HorizontalScroll.Maximum = 0;
            _sidePanel.AutoScroll = true;
            //Right side divider
            this.Controls.Add(AddFullHeightPanel());
            //Example entrys

            //Add password panels and dividers below them
            foreach (password pass in PasswordsList)
            {
                _sidePanel.Controls.Add(new passwordInfo(pass, this));
                _sidePanel.Controls.Add(AddSidePanel());
            }

            //if content is less than height disable scrolling, fixes anoying extra scrolling
            if (CalcHeight(_sidePanel) < _sidePanel.Height) _sidePanel.AutoScroll = false;


            //For now this works, will have to make more robust later
            Selected = (passwordInfo)_sidePanel.Controls[0];

            InfoDisplay = new passwordInfoDisplay(this);

            _newEntry = new Button();
            _newEntry.Location = new Point(this.ClientSize.Width - 100, 10);
            _newEntry.Click += NewEntry_Click;
            _newEntry.Text = "Add";
            _newEntry.AutoSize = true;
            _newEntry.Height = 40;

            this.Shown += MainWindow_Shown;
            this.Controls.Add(_newEntry);
            this.FormClosing += MainWindow_Deactivate;

            return 0;
        }

        /// <summary>
        /// Shows the password popup windows
        /// <br></br>****Needs to be edited so that you cant edit the previous window until this is closed****
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Shown(object? sender, EventArgs e)
        {
            Popup popupWindow = new Popup();
            popupWindow.Show();
            popupWindow.BringToFront();
        }

        /// <summary>
        /// Shows the NewEntry form and brings to front
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewEntry_Click(object? sender, EventArgs e)
        {
            PasswordEntry passwordEntryForm = new PasswordEntry();
            passwordEntryForm.Show();
        }

        /// <summary>
        /// 0 References gaming idk what this does but i can assume that this should be in the the password entry class i think ¯\_(ツ)_/¯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPasswordEntry_Click(object? sender, EventArgs e)
        {
            PasswordEntry passwordEntryForm = new PasswordEntry();

            //Getting info from the entry form
            if (passwordEntryForm.ShowDialog() == DialogResult.OK)
            {
                string websiteName = passwordEntryForm.WebsiteName;
                string username = passwordEntryForm.Username;
                string password = passwordEntryForm.Password;

                //Adding the info
                PasswordsList.Add(new password(websiteName, username, password));

                //Displaying new entry
                _sidePanel.Controls.Clear();

                foreach (password pass in PasswordsList)
                {
                    _sidePanel.Controls.Add(new passwordInfo(pass, this));
                    _sidePanel.Controls.Add(AddSidePanel());
                }
            }
        }


        /// <summary>
        /// Adds A Side Panel Divider
        /// </summary>
        /// <returns></returns>
        private Label AddSidePanel()
        {
            Label divider = new Label();
            divider.Text = string.Empty;
            divider.BorderStyle = BorderStyle.Fixed3D;
            divider.AutoSize = false;
            divider.Height = 2;
            divider.Width = 200;
            return divider;
        }

        /// <summary>
        /// Add Full Height Divider
        /// </summary>
        /// <returns></returns>
        private Label AddFullHeightPanel()
        {
            Label divider = new Label();
            divider.Text = string.Empty;
            divider.BorderStyle = BorderStyle.Fixed3D;
            divider.AutoSize = false;
            divider.Height = this.Height;
            divider.Width = 2;
            divider.Location = new Point(201, 0);
            return divider;
        }



        /// <summary>
        ///returns height of a panels content, there may be a better way to get this
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        private int CalcHeight(Control panel)
        {   
            int height = 0;
            foreach (Control ctr in panel.Controls)
            {
                height += ctr.Height;
            }
            return height;
        }
    }
}