﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969_Samuel_McMasters.DataModels;
using C969_Samuel_McMasters.Services;
using MySql.Data.MySqlClient;
using static Mysqlx.Expect.Open.Types;

namespace C969_Samuel_McMasters
{

    public partial class ModifyAppointmentForm : Form
    {
        
        



        public static Dictionary<string, string> appointmentDict = new Dictionary<string, string>();

        public ModifyAppointmentForm(int selectedAppointment, int customerId)
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

            string custId = customerId.ToString();

            foreach (DataGridViewRow row in customerDGV.Rows)
            {
                if (row.Cells[0].Value.ToString() == custId)
                    row.Selected = true;
            }

            startDatePicker.Format = DateTimePickerFormat.Custom;
            startDatePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";

            endDatePicker.Format = DateTimePickerFormat.Custom;
            endDatePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";

            appointmentDict = Service.GetAppointmentDetails(selectedAppointment);
            aptIdTextBox.Text = appointmentDict["appointmentId"];
            userIdTextBox.Text = appointmentDict["userId"];
            aptTypeComboBox.Text = appointmentDict["type"];

            DateTime startDate = Convert.ToDateTime(appointmentDict["startDate"]);
            startDatePicker.Value = startDate.ToLocalTime();
            DateTime endDate = Convert.ToDateTime(appointmentDict["endDate"]);
            endDatePicker.Value = endDate.ToLocalTime();
            
            



        }

        private void ModifyAppointmentForm_Load(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {

            DateTime startDate = startDatePicker.Value;
            DateTime endDate = endDatePicker.Value;
            int userId = Convert.ToInt32(userIdTextBox.Text);
            Dictionary<string, string> updatedForm = new Dictionary<string, string>();

            if (String.IsNullOrEmpty(aptTypeComboBox.Text))
            {
                MessageBox.Show("Please enter all fields.");
            }
            else
            {


                if (DataHelper.CheckBusinessHours(startDate, endDate))
                {
                    if (Service.CheckOverlappingAppointments(startDate.ToUniversalTime(), endDate.ToUniversalTime(), userId))
                    {
                        MessageBox.Show("Appointment overlap error.");
                    }
                    else
                    {


                        updatedForm.Add("appointmentId", aptIdTextBox.Text);
                        updatedForm.Add("userId", userIdTextBox.Text);
                        updatedForm.Add("startDate", startDatePicker.Value.ToUniversalTime().ToString("yyyyMMddHHmmss"));
                        updatedForm.Add("endDate", endDatePicker.Value.ToUniversalTime().ToString("yyyyMMddHHmmss"));
                        updatedForm.Add("type", aptTypeComboBox.Text);
                        updatedForm.Add("customerId", Convert.ToString(customerDGV.CurrentRow.Cells[0].Value));
                        if (Service.UpdateAppointment(updatedForm))
                        {
                            MessageBox.Show("Update Complete!");
                            Close();
                            MainForm MainForm = new MainForm();
                            MainForm.Show();
                        }
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
