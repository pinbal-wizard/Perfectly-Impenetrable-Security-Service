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
        private List<PasswordStruct> _passwordsList = new List<PasswordStruct>();
        //currently hash of "password"
        public byte[] hash = { 95, 77, 204, 59, 90, 167, 101, 214, 29, 131, 39, 222, 184, 130, 207, 153 };
        private FlowLayoutPanel _sidePanelContainer;
        private FlowLayoutPanel _sidePanelPasswords;
        private Button _newEntryButton;
        private TextBox _searchBar;

        public PasswordSideBar? Selected;
        public PasswordInfoDisplay InfoDisplay;

        /// <summary>
        /// Readonly Property for reading the list of PasswordsList
        /// ***This needs to change for future task of not keeping PasswordsList stored in ram***
        /// </summary>
        public List<PasswordStruct> PasswordsList
        {
            get { return _passwordsList; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Public Function for adding PasswordsList to the list off PasswordsList
        /// <br></br>***Will need to be change to be more secure to complete other backlog tasks***
        /// </summary>
        /// <returns></returns>
        public int AddEntry(string URL, string UserName, string Password)
        {
            _passwordsList.Add(new PasswordStruct(URL, UserName, Password));
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
            //This has been brought into the On_Load Function as it runs before it is rendered
            MasterPasswordPopup popupWindow = new MasterPasswordPopup(this);
            popupWindow.ShowDialog();
            popupWindow.BringToFront();
            if (popupWindow.DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
            Serializer.LoadFromFile(this);

           

           

            //Basic Load
            this.DoubleBuffered = true;
            this.ClientSizeChanged += FormResized;

            InitSidePanel();
            InfoDisplay = new PasswordInfoDisplay(this);
            this.Controls.Add(AddVerticalDivider());
            InitNewEntry();
            this.Controls.Add(_sidePanelContainer);
            this.Controls.Add(InfoDisplay);
            this.FormClosing += MainWindow_Deactivate;

        }


        private void FormResized(object? sender, EventArgs e)
        {
            //Sidepanel
            //Check if scrolling needed now
            //25v MessageBox.Show(sidePanelContainer.Controls[0].Height.ToString());
            //Height of searchbar section is 45
            int Percent20 = this.ClientSize.Width / 5;
            _sidePanelContainer.Width = Percent20;
            _sidePanelPasswords.Height = this.ClientSize.Height - 45;
            _sidePanelPasswords.Width = Percent20;
            _searchBar.Width = _sidePanelContainer.Width - _searchBar.Margin.Right-_searchBar.Margin.Left;
            _sidePanelPasswords.AutoScroll = true;

            if (CalcHeight(_sidePanelPasswords) < this.ClientSize.Height-115) _sidePanelPasswords.AutoScroll = false;

            foreach (Control password in _sidePanelPasswords.Controls)
            {
                password.MinimumSize = new Size(Percent20, password.Height);
            }


            //Update side divider relies on side panel being first
            this.Controls[0].Height = this.ClientSize.Height;
            this.Controls[0].Location= new Point(Percent20+1, this.Controls[0].Location.Y);

            //InfoDisplay update width and height
            InfoDisplay.Location = new Point(Percent20, 0);
            InfoDisplay.Width = this.ClientSize.Width - Percent20;
            InfoDisplay.Height = this.ClientSize.Height;
        }

        /// <summary>
        /// Initailses The Button for entering new entries
        /// </summary>
        private void InitNewEntry()
        {
            _newEntryButton = new Button();
            _newEntryButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            _newEntryButton.Location = new Point(ClientSize.Width - _newEntryButton.Width - _newEntryButton.Padding.Left, 10);
            _newEntryButton.Click += OpenPasswordEntry_Click;
            _newEntryButton.Text = "Add";
            _newEntryButton.AutoSize = true;
            _newEntryButton.Height = 40;
            this.Controls.Add(_newEntryButton);
        }


        /// <summary>
        /// Initalises the sidePanel       
        /// <br></br>*****This Function sucks because it says it initalises the sidePanel yet it initalises the whole form*****
        /// </summary>
        /// <returns></returns>
        private void InitSidePanel()
        {
            //First make the container div
            _sidePanelContainer = new FlowLayoutPanel();
            //ClientSize height is the height of the inner bit that is the actual form, normal height is the total window size, not useful
            _sidePanelContainer.Height = this.ClientSize.Height;
            _sidePanelContainer.Width = this.ClientSize.Width/5;

            //no scroling
            _sidePanelContainer.AutoScroll = false;
            //Searchbar
            _searchBar = new TextBox();
            _searchBar.Margin = new Padding(12, 10, 18, 10);
            _searchBar.Width = _sidePanelContainer.Width - _searchBar.Margin.Right - _searchBar.Margin.Left;
            _searchBar.TextChanged += SearchPasswords;

            //Add top elements
            _sidePanelContainer.Controls.Add(_searchBar);
            _sidePanelContainer.Controls.Add(AddSidePanelDivider());
            //Side panel init
            _sidePanelPasswords = new FlowLayoutPanel();
            _sidePanelPasswords.Height = this.ClientSize.Height - 40;
            _sidePanelPasswords.Width = this.ClientSize.Width / 5;
            //Disable horizontal scroll bars, setting autoscroll to false first is important
            _sidePanelPasswords.AutoScroll = false;
            _sidePanelPasswords.HorizontalScroll.Enabled = false;
            _sidePanelPasswords.HorizontalScroll.Visible = false;
            _sidePanelPasswords.HorizontalScroll.Maximum = 0;
            _sidePanelPasswords.AutoScroll = true;
            _sidePanelPasswords.FlowDirection = FlowDirection.TopDown;
            //Wrap is for scrolling to work
            _sidePanelPasswords.WrapContents = false;

            //Example entrys will later pull from file load
            /*passwords.Add(new password("https://google.com", "thetruecool", "password123"));
            passwords.Add(new password("https://yandex.com", "thetruecool", "password123"));
            passwords.Add(new password("https://outlook.com", "thetruecool", "password123"));
            passwords.Add(new password("https://github.com", "thetruecool", "password123"));
            passwords.Add(new password("https://typingclub.com", "thetruecool", "password123"));*/

            //Add password panels and dividers below them
            foreach (PasswordStruct pass in _passwordsList)
            {
                _sidePanelPasswords.Controls.Add(new PasswordSideBar(pass, this));
                _sidePanelPasswords.Controls.Add(AddSidePanelDivider());
            }
            //if content is less than height disable scrolling, fixes anoying extra scrolling
            if (CalcHeight(_sidePanelPasswords) + 30 < this.ClientSize.Height - 45) _sidePanelPasswords.AutoScroll = false;

            if (_sidePanelPasswords.Controls.Count > 0) Selected = (PasswordSideBar)_sidePanelPasswords.Controls[0];
            _sidePanelContainer.Controls.Add(_sidePanelPasswords);
        }

        private void SearchPasswords(object? sender, EventArgs e)
        {
            _sidePanelContainer.SuspendLayout();
            _sidePanelPasswords.SuspendLayout();
            //List<Control> changes = new List<Control>();
            //perform search
            _sidePanelPasswords.Controls.Clear();
            foreach (PasswordStruct pass in _passwordsList)
            {
                if (pass.WebSite.Contains(_searchBar.Text) || pass.Username.Contains(_searchBar.Text))
                {
                    _sidePanelPasswords.Controls.Add(new PasswordSideBar(pass, this));
                    _sidePanelPasswords.Controls.Add(AddSidePanelDivider());
                }
            }
            _sidePanelPasswords.ResumeLayout(true);
            _sidePanelContainer.ResumeLayout(true);

        }

        /// <summary>
        /// Very good form
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
                PasswordStruct p = new PasswordStruct(websiteName, username, password);
                _passwordsList.Add(p);

                //Displaying new entry

                _sidePanelPasswords.Controls.Add(new PasswordSideBar(p, this));
                _sidePanelPasswords.Controls.Add(AddSidePanelDivider());


                //update sidepanel scroll bars, same stuff as in form_resized
                _sidePanelContainer.Height = this.ClientSize.Height;
                _sidePanelPasswords.Height = this.ClientSize.Height - 45;
                _sidePanelPasswords.AutoScroll = true;
                if (CalcHeight(_sidePanelPasswords) < this.ClientSize.Height - 115) _sidePanelPasswords.AutoScroll = false;
            }
        }


        /// <summary>
        /// Adds A Horisontal Side Panel Divider
        /// </summary>
        /// <returns></returns>
        private Label AddSidePanelDivider()
        {
            Label divider = new Label();
            divider.Text = string.Empty;
            divider.BorderStyle = BorderStyle.Fixed3D;
            divider.AutoSize = false;
            divider.Height = 2;
            divider.Width = 2000;
            return divider;
        }

        /// <summary>
        /// Add Full Height Vertical Divider
        /// </summary>
        /// <returns></returns>
        private Label AddVerticalDivider()
        {
            Label divider = new Label();
            divider.Text = string.Empty;
            divider.BorderStyle = BorderStyle.Fixed3D;
            divider.AutoSize = false;
            divider.Height = this.Height;
            divider.Width = 2;
            divider.Location = new Point(this.ClientSize.Width/5+1, 0);
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