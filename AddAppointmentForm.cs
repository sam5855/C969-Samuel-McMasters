using C969_Samuel_McMasters.DataModels;
using C969_Samuel_McMasters.Services;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace C969_Samuel_McMasters
{
    public partial class AddAppointmentForm : Form
    {
        public AddAppointmentForm()
        {
            InitializeComponent();

            //Populate customer DGV
            MySqlConnection c = new MySqlConnection(Service.homeConnectionString);
            c.Open();
            MySqlCommand query = new MySqlCommand("SELECT customerId, customerName FROM customer", c);
            MySqlDataAdapter adp = new MySqlDataAdapter(query);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            customerDGV.DataSource = dt;
            c.Close();

            //DGV Formatting
            customerDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            customerDGV.ReadOnly = true;
            customerDGV.MultiSelect = false;
            customerDGV.AllowUserToAddRows = false;
            customerDGV.Columns[0].HeaderText = "Customer ID";
            customerDGV.Columns[1].HeaderText = "Customer Name";

            int userId = DataHelper.getCurrentUserId();
            userIdTextBox.Text = userId.ToString();


            startDatePicker.Format = DateTimePickerFormat.Custom;
            startDatePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";

            endDatePicker.Format = DateTimePickerFormat.Custom;
            endDatePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";


        }

        private void AddAppointmentForm_Load(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        private void createAppointmentButton_Click(object sender, EventArgs e)
        {

            if (startDatePicker.Value < DataHelper.businessOpen || startDatePicker.Value > DataHelper.businessClose)
            {
                MessageBox.Show("Invalid appointment time. Please adjust appointment time between business hours 9:00am - 5:00pm");
            }
            else if (endDatePicker.Value < DataHelper.businessOpen || endDatePicker.Value > DataHelper.businessClose)
            {
                MessageBox.Show("Invalid appointment time. Please adjust appointment time between business hours 9:00am - 5:00pm");
            }
            else
            {
                string timeStamp = DataHelper.CreateTimeStamp();
                string userName = DataHelper.GetCurrentUserName();


                Appointment apt = new Appointment();


                apt.CustomerId = Convert.ToInt32(customerDGV.CurrentRow.Cells[0].Value);
                apt.UserId = Convert.ToInt32(userIdTextBox.Text);
                apt.Title = "Not Needed";
                apt.Description = "Not Needed";
                apt.Location = "Not Needed";
                apt.Contact = "Not Needed";
                apt.Type = aptTypeTextBox.Text;
                apt.Url = "Not Needed";
                apt.StartDate = startDatePicker.Value.ToLocalTime();
                apt.EndDate = endDatePicker.Value.ToLocalTime();



                Service.CreateRecord(timeStamp, userName, "appointment", $"'{apt.CustomerId}', '{apt.Title}', '{startDatePicker.Value.ToUniversalTime().ToString("yyyyMMddHHmmss")}', '{endDatePicker.Value.ToUniversalTime().ToString("yyyyMMddHHmmss")}'," +
                    $"'{apt.Type}', '{apt.Description}', '{apt.Location}', '{apt.Contact}', '{apt.Url}'", apt.UserId);





                Close();
                MainForm MainForm = new MainForm();
                MainForm.Show();
            }
        }
    }
}
