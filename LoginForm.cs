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
using System.Globalization;

namespace C969_Samuel_McMasters
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            ShowLang();

            timeLabel.Text = DataHelper.getCurrentTime();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            DateTime timeStamp = DateTime.Now;
            string userName = usernameTextBox.Text;


            if (Service.FindUser(usernameTextBox.Text, passwordTextBox.Text) != 0)
            {
                DataHelper.UserLogFile($"USER {userName} has logged in at {timeStamp}.");
                MainForm MainForm = new MainForm();
                MainForm.Show();
                Hide();
            }
            else
            {
                DataHelper.UserLogFile($"Failed log-in attempt with USER {userName} at {timeStamp}");
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "es")
                {
                    MessageBox.Show("Usuario invalido.");
                }
                else
                {
                    MessageBox.Show("Invalid User.");
                }
            }
            

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void ShowLang()
        {
            switch (CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
            {
                case "en":
                    ShowEnglish();
                    break;
                case "es":
                    ShowSpanish();
                    break;
                default:
                    ShowEnglish();
                    break;
             
            }
        }

        private void ShowEnglish()
        {
            this.Text = "Login";
            welcomeLabel.Text = "Welcome";
            usernameLabel.Text = "Username:";
            passwordLabel.Text = "Password:";
            loginButton.Text = "Login";
            exitButton.Text = "Exit";
        }

        private void ShowSpanish()
        {
            this.Text = "Acceso";
            welcomeLabel.Text = "Bienvenido";
            usernameLabel.Text = "Nombre de usuario:";
            passwordLabel.Text = "Contrasena:";
            loginButton.Text = "Acceso";
            exitButton.Text = "Salida";
        }

    }
}
