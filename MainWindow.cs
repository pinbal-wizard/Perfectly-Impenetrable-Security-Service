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

        private FlowLayoutPanel _sidePanelContainer;
        private FlowLayoutPanel _sidePanelPasswords;
        private Button _newEntry;
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
            Serializer.LoadFromFile(this);

            //This has been brought into the On_Load Function as it runs before it is rendered
            MasterPasswordPopup popupWindow = new MasterPasswordPopup();
            popupWindow.ShowDialog();
            popupWindow.BringToFront();

            if(popupWindow.DialogResult == DialogResult.OK)
            {            }

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
            _sidePanelContainer.Height = this.ClientSize.Height;
            _sidePanelPasswords.Height = this.ClientSize.Height - 45;
            _sidePanelPasswords.AutoScroll = true;
            if (CalcHeight(_sidePanelPasswords) + 30 < this.ClientSize.Height - 45) _sidePanelPasswords.AutoScroll = false;


            //Update side divider relies on side panel being first
            //How tf is it that during init this is control[0] but after the add button is in first place
            this.Controls[1].Height = this.ClientSize.Height;

            //InfoDisplay update width and height
            InfoDisplay.Width = this.ClientSize.Width - 200;
            InfoDisplay.Height = this.ClientSize.Height;
       
        }

        /// <summary>
        /// Initailses The Button for entering new entries
        /// </summary>
        private void InitNewEntry()
        {
            _newEntry = new Button();
            _newEntry.Location = new Point(this.ClientSize.Width - 100, 10);
            _newEntry.Click += OpenPasswordEntry_Click;
            _newEntry.Text = "Add";
            _newEntry.AutoSize = true;
            _newEntry.Height = 40;
            this.Controls.Add(_newEntry);
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
            _sidePanelContainer.Width = 200;

            //no scroling
            _sidePanelContainer.AutoScroll = false;
            //Searchbar
            _searchBar = new TextBox();
            _searchBar.Margin = new Padding(12, 10, 18, 10);
            _searchBar.Width = 170;
            _searchBar.TextChanged += SearchPasswords;

            //Add top elements
            _sidePanelContainer.Controls.Add(_searchBar);
            _sidePanelContainer.Controls.Add(AddSidePanelDivider());
            //Side panel init
            _sidePanelPasswords = new FlowLayoutPanel();
            _sidePanelPasswords.Height = this.ClientSize.Height - 40;
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

            //For now this works, will have to make more robust later
            Selected = (PasswordSideBar)_sidePanelPasswords.Controls[0];
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
            divider.Width = 200;
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