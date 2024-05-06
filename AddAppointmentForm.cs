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

            int userId = DataHelper.GetCurrentUserId();
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
            

            DateTime startDate = startDatePicker.Value;
            DateTime endDate = endDatePicker.Value;
            int userId = Convert.ToInt32(userIdTextBox.Text);

            if (String.IsNullOrEmpty(aptTypeComboBox.Text))
            {
                MessageBox.Show("Please enter all fields.");
            }
            else
            {



                if (DataHelper.CheckBusinessHours(startDate, endDate))
                {
                    if (Service.CheckOverlappingAppointments(startDate, endDate, userId))
                    {
                        MessageBox.Show("Appointment overlap error.");
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
                        apt.Type = aptTypeComboBox.Text;
                        apt.Url = "Not Needed";
                        apt.StartDate = startDatePicker.Value.ToLocalTime();
                        apt.EndDate = endDatePicker.Value.ToLocalTime();



                        Service.CreateRecord(timeStamp, userName, "appointment", $"'{apt.CustomerId}', '{apt.Title}', '{startDatePicker.Value.ToUniversalTime().ToString("yyyyMMddHHmmss")}', '{endDatePicker.Value.ToUniversalTime().ToString("yyyyMMddHHmmss")}'," +
                            $"'{apt.Type}', '{apt.Description}', '{apt.Location}', '{apt.Contact}', '{apt.Url}'", apt.UserId);




                        MessageBox.Show("Appointment created!");
                        Close();
                        MainForm MainForm = new MainForm();
                        MainForm.Show();
                    }


                }
                else
                {
                    MessageBox.Show("Appointment must start and end between 9:00am and 5:00pm.");
                }
            }
        }
    }
}
