namespace UserData
{
    public partial class Form1 : Form
    {
        private Label? lblWebsiteName;
        private Label? lblUsername;
        private Label? lblPassword;
        private TextBox? txtWebsiteName;
        private TextBox? txtUsername;
        private TextBox? txtPassword;
        private Button btnAdd;

        public Form1()
        {
            InitializeComponent();
            CreateFormControls();
        }

        private void CreateFormControls()
        {
            // Creating the labels
            lblWebsiteName = new Label();
            lblWebsiteName.Text = "Website Name: ";
            lblWebsiteName.Location = new Point(20, 20);
            this.Controls.Add(lblWebsiteName);

            lblUsername = new Label();
            lblUsername.Text = "Username: ";
            lblUsername.Location = new Point(20, 50);
            this.Controls.Add(lblUsername);

            lblPassword = new Label();
            lblPassword.Text = "Password";
            lblPassword.Location = new Point(20, 80);
            this.Controls.Add(lblPassword);

            // Creating the text boxes
            txtWebsiteName = new TextBox();
            txtWebsiteName.Location = new Point(120, 20);
            this.Controls.Add(txtWebsiteName);

            txtUsername = new TextBox();
            txtUsername.Location = new Point(120, 50);
            this.Controls.Add(txtUsername);

            txtPassword = new TextBox();
            txtPassword.Location = new Point(120, 80);
            this.Controls.Add(txtPassword);

            btnAdd = new Button();
            btnAdd.Text = "Add";
            btnAdd.Location = new Point(20, 110);
            btnAdd.Click += new EventHandler(BtnAdd_Click); // Assign the event handler for the button click
            this.Controls.Add(btnAdd);
        }

        // Event handler for the "Add" button click
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // You can access the entered data using the class-level fields directly.
            string websiteName = txtWebsiteName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            this.Close();
        }
    }
}
