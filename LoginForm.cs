using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969_Samuel_McMasters.DataModels;
using MySql.Data.MySqlClient;

namespace C969_Samuel_McMasters
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        //Method to authenticate user login
        public static int FindUser(string username, string password)
        {
            MySqlConnection c = new MySqlConnection(Services.Service.homeConnectionString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT userId FROM user WHERE username = '{username}' AND password = '{password}'", c);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                DataHelper.setCurrentUserId(Convert.ToInt32(rdr[0]));
                DataHelper.setCurrentUserName(username);
                rdr.Close();
                c.Close();
                return DataHelper.getCurrentUserId();
            }
            return 0;

        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (FindUser(usernameTextBox.Text, passwordTextBox.Text) != 0)
            {
                this.Hide();
                MainForm MainForm = new MainForm();
                MainForm.Show();
            }
            
            else
            {
                MessageBox.Show("Invalid User");
            }
            
            
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
