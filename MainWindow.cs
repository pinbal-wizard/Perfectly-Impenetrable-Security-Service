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
using System.Security.Cryptography;
using System.Linq;

namespace WinFormsApp1
{
    /// <summary>
    /// This is the class of the main window of the program
    /// </summary>
    public partial class MainWindow : Form
    {
        private List<PasswordStruct> _passwordsList = new List<PasswordStruct>();
        //currently hash of "password"         source just trust me bro
        public byte[] _hash = { 095, 077, 204, 059, 090, 167, 101, 214, 029, 131, 039, 222, 184, 130, 207, 153 };

        private FlowLayoutPanel _sidePanelContainer;
        private FlowLayoutPanel _sidePanelPasswords;
        private Button _newEntryButton;
        private TextBox _searchBar;
        private Button _changeMasterPasswordButton;

        public PasswordSideTile? Selected;
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

            this.SuspendLayout();
            //This has been brought into the On_Load Function as it runs before it is rendered
            MasterPasswordPopup popupWindow = new MasterPasswordPopup(this);
            popupWindow.ShowDialog();
            if (popupWindow.DialogResult != DialogResult.OK & popupWindow.DialogResult != DialogResult.Yes)
            {
                Environment.Exit(1);
            }

            //_hash = 

            if (Serializer.LoadFromFile(this) == 2 & popupWindow.DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Welcome to our password Manager " +
                                "\nWe recommend that you press the change master password to add a master password you will use to login " +
                                "\nTo Begin Please Press the add new Entry to add your first password");
            }

            //Basic Load
            Controls.Add(AddVerticalDivider());
            InitializeSidePanel();

            //Initialise New Entry Button
            _newEntryButton = new Button();
            _newEntryButton.Click += NewEntryButton_Click;
            _newEntryButton.Text = "Add New Entry";
            _newEntryButton.AutoSize = true;
            _newEntryButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            _newEntryButton.Location = new Point(ClientSize.Width - _newEntryButton.Width - _newEntryButton.Padding.Left, 10);
            Controls.Add(_newEntryButton);


            //initalise change master password button
            _changeMasterPasswordButton = new Button();
            _changeMasterPasswordButton.AutoSize = true;
            _changeMasterPasswordButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            _changeMasterPasswordButton.Name = "ChangeMasterPassword";
            _changeMasterPasswordButton.Text = "Change Master Password";
            _changeMasterPasswordButton.UseVisualStyleBackColor = true;
            _changeMasterPasswordButton.Click += ChangeMasterPasswordButton_Click;
            _changeMasterPasswordButton.Location = new Point(this.ClientSize.Width - _changeMasterPasswordButton.Width, _newEntryButton.Height + 25);
            Controls.Add(_changeMasterPasswordButton);

            if (_sidePanelPasswords.Controls.Count != 0)
            {
                IntializeInfoDisplay();

                PasswordSideTile firstPasswordEntry = (PasswordSideTile)_sidePanelPasswords.Controls[0];
                firstPasswordEntry.PasswordInfo_Click(this, EventArgs.Empty);
            }

            this.DoubleBuffered = true;
            this.ClientSizeChanged += MainWindow_Resize;
            this.Shown += MainWindow_Shown;
            
            this.FormClosed += MainWindow_Close;
            ResumeLayout();
        }

        private void MainWindow_Shown(object? sender, EventArgs e)
        {
            InfoDisplay.MagicMargin();
            InfoDisplay.FixCopyMargins();

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
        public int AddEntry(PasswordStruct password)
        {
            _passwordsList.Add(password);
            return 0;
        }

        #region Initialize Functions

        /// <summary>
        /// Initalises the sidePanel       
        /// <br></br>*****This Function sucks because it says it initalises the sidePanel yet it initalises the whole form*****
        /// </summary>
        /// <returns></returns>
        private void InitializeSidePanel()
        {
            //Initailse _sidePanelContainer the 
            _sidePanelContainer = new FlowLayoutPanel();
            _sidePanelContainer.Location = new Point(0, 0);
            _sidePanelContainer.Height = this.ClientSize.Height;
            _sidePanelContainer.Width = this.ClientSize.Width / 5;
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

            //Add password panels and dividers below them
            AddPasswordTiles(_passwordsList);

            //if content is less than height disable scrolling, fixes anoying extra scrolling
            if (CalcHeight(_sidePanelPasswords) + 30 < this.ClientSize.Height - 45) _sidePanelPasswords.AutoScroll = false;

            if (_sidePanelPasswords.Controls is null) Selected = (PasswordSideTile)_sidePanelPasswords.Controls[0];
            
            _sidePanelContainer.Controls.Add(_sidePanelPasswords);
            this.Controls.Add(_sidePanelContainer);
        }

        /// <summary>
        /// Function looks empty this is for default entries and stuff
        /// </summary>
        private void IntializeInfoDisplay()
        {
            InfoDisplay = new PasswordInfoDisplay(this);
            InfoDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            InfoDisplay.Location = new Point(ClientSize.Width/5, 0);
            InfoDisplay.Width = ((ClientSize.Width / 5)*4);
            InfoDisplay.Height = this.ClientSize.Height;

            this.Controls.Add(InfoDisplay);
        }

        #endregion

        /// <summary>
        /// Function resisied non autosizeable controls
        /// </summary>
        private void MainWindow_Resize(object? sender, EventArgs e)
        {
            //Sidepanel
            //Check if scrolling needed now
            //25v MessageBox.Show(sidePanelContainer.Controls[0].Height.ToString());
            //Height of searchbar section is 45
            int Percent20 = this.ClientSize.Width / 5;

            
            InfoDisplay.Location = new Point(Percent20, 0);
            InfoDisplay.Width = (this.ClientSize.Width - Percent20);
            InfoDisplay.Height = this.ClientSize.Height;
            InfoDisplay.Password.MaximumSize = new Size(Percent20, 4000);

            _sidePanelContainer.Width = Percent20;

            _sidePanelPasswords.Height = this.ClientSize.Height - 45;
            _sidePanelPasswords.Width = Percent20;
            _sidePanelPasswords.AutoScroll = (CalcHeight(_sidePanelPasswords) < this.ClientSize.Height - 115) ? false : true;

            _searchBar.Width = _sidePanelContainer.Width - _searchBar.Margin.Right - _searchBar.Margin.Left;

            foreach (Control password in _sidePanelPasswords.Controls)
            {
                password.MinimumSize = new Size(Percent20, password.Height);
            }

            //Update side divider relies on side panel being first
            this.Controls[0].Height = this.ClientSize.Height;
            this.Controls[0].Location = new Point(Percent20 + 1, this.Controls[0].Location.Y);
        }

        /// <summary>
        /// Saves PasswordsList to file as form is closed
        /// </summary>
        private void MainWindow_Close(object? sender, EventArgs e)
        {
            Serializer.SaveToFile(this);
        }

        /// <summary>
        /// Adds a list of Password Structs 
        /// </summary>
        /// <param name="passwordToAdd"></param>
        private void AddPasswordTiles(List<PasswordStruct> passwordToAdd)
        {
            for (int i = 0; i < passwordToAdd.Count; i++)
            {
                _sidePanelPasswords.Controls.Add(new PasswordSideTile(passwordToAdd[i], i, this));
                _sidePanelPasswords.Controls.Add(AddSidePanelDivider());
            }
        }

        private void SearchPasswords(object? sender, EventArgs e)
        {
            //why
            _sidePanelContainer.SuspendLayout();
            _sidePanelPasswords.SuspendLayout();
            //perform search
            _sidePanelPasswords.Controls.Clear();

            List<PasswordStruct> searchedPassword = (from password 
                                                     in _passwordsList 
                                                     where password.WebSite.Contains(_searchBar.Text) || password.Username.Contains(_searchBar.Text) 
                                                     select password).ToList();
            AddPasswordTiles(searchedPassword);
            _sidePanelPasswords.ResumeLayout(true);
            _sidePanelContainer.ResumeLayout(true);
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
            divider.Location = new Point(this.ClientSize.Width / 5 + 1, 0);
            return divider;
        }

        /// <summary>
        ///returns height of a panels content, there may be a better way to get this
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        public int CalcHeight(Control panel)
        {
            int height = 0;
            foreach (Control ctr in panel.Controls)
            {
                height += ctr.Height;
            }
            return height;
        }

        /// <summary>
        /// Opens the form to change the master password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeMasterPasswordButton_Click(object sender, EventArgs e)
        {
            ChangeMasterPasswordPopup changePasscodeForm = new ChangeMasterPasswordPopup(this);
            changePasscodeForm.ShowDialog();
        }

        private void NewEntryButton_Click(object? sender, EventArgs e)
        {
            NewPasswordEntry passwordEntryForm = new NewPasswordEntry();

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



                _sidePanelPasswords.Controls.Add(new PasswordSideTile(p, _passwordsList.IndexOf(p), this));
                _sidePanelPasswords.Controls.Add(AddSidePanelDivider());

                if (_sidePanelPasswords.Controls.Count == 2)
                {
                    IntializeInfoDisplay();
                    PasswordSideTile firstEntry = (PasswordSideTile)_sidePanelPasswords.Controls[0];
                    firstEntry.PasswordInfo_Click(this, EventArgs.Empty);
                }

                MainWindow_Resize(this, EventArgs.Empty);
            }
        }
    }
}