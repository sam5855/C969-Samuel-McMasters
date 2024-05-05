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
using C969_Samuel_McMasters.Services;

namespace C969_Samuel_McMasters
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (Service.FindUser(usernameTextBox.Text, passwordTextBox.Text) != 0)
            {
                MainForm MainForm = new MainForm();
                MainForm.Show();
                Hide();
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
