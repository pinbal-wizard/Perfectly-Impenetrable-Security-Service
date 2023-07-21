//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//
//namespace WinFormsApp1
//{
//    public class Labels
//    {
//        public Label? lblWebsiteName;
//        public Label? lblUsername;
//        public Label? lblPassword;
//        public TextBox? txtWebsiteName;
//        public TextBox? txtUsername;
//        public TextBox? txtPassword;
//        public Button btnAdd;
//    }
//
//    public void CreateFormControls()
//    {
//        // Creating the labels
//        lblWebsiteName = new Label();
//        lblWebsiteName.Text = "Website Name: ";
//        lblWebsiteName.Location = new Point(20, 20);
//        this.Controls.Add(lblWebsiteName);
//
//        lblUsername = new Label();
//        lblUsername.Text = "Username: ";
//        lblUsername.Location = new Point(20, 50);
//        this.Controls.Add(lblUsername);
//
//        lblPassword = new Label();
//        lblPassword.Text = "Password";
//        lblPassword.Location = new Point(20, 80);
//        this.Controls.Add(lblPassword);
//
//        // Creating the text boxes
//        txtWebsiteName = new TextBox();
//        txtWebsiteName.Location = new Point(120, 20);
//        this.Controls.Add(txtWebsiteName);
//
//        txtUsername = new TextBox();
//        txtUsername.Location = new Point(120, 50);
//        this.Controls.Add(txtUsername);
//
//        txtPassword = new TextBox();
//        txtPassword.Location = new Point(120, 80);
//        this.Controls.Add(txtPassword);
//
//        btnAdd = new Button();
//        btnAdd.Text = "Add";
//        btnAdd.Location = new Point(20, 110);
//        btnAdd.Click += new EventHandler(BtnAdd_Click); // Assign the event handler for the button click
//        this.Controls.Add(btnAdd);
//    }
//}
//