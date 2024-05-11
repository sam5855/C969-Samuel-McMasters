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
using C969_Samuel_McMasters.Services;
using MySql.Data.MySqlClient;

namespace C969_Samuel_McMasters
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            monthDateTimePicker.Format = DateTimePickerFormat.Custom;
            monthDateTimePicker.CustomFormat = "MM/yyyy";


            userComboBox.DataSource = Service.GetAllUsers();
            customerComboBox.DataSource = Service.GetAllCustomers();

            //DGV Formatting
            reportTwoDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reportTwoDGV.ReadOnly = true;
            reportTwoDGV.MultiSelect = false;
            reportTwoDGV.AllowUserToAddRows = false;
            


        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }


        //=====================================================================
        //Report click events below
        //=====================================================================




        private void generateReport1Button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(aptTypeComboBox.Text)) 
            { 
                MessageBox.Show("Please fill out all report fields"); 
            }
            else
            {
                DateTime month = monthDateTimePicker.Value;
                string type = aptTypeComboBox.Text;
                countLabel.Text = Service.GenerateReport1(month, type);
                monthLabel.Text = month.Month.ToString();
                typeLabel.Text = type;
            }
 
        }


        private void generateReport2Button_Click(object sender, EventArgs e)
        {
            int userId = Service.GetUserId(userComboBox.Text);
            reportTwoDGV.DataSource = Service.GenerateReport2(userId);
            reportTwoDGV.Columns[2].Visible = false;
            reportTwoDGV.Columns[3].Visible = false;
            reportTwoDGV.Columns[4].Visible = false;
            reportTwoDGV.Columns[5].Visible = false;
            reportTwoDGV.Columns[6].Visible = false;
            reportTwoDGV.Columns[8].Visible = false;
            
        }


        private void generateReport3Button_Click(object sender, EventArgs e)
        {
            customerLabel.Text = customerComboBox.Text;
            appointmentCountLabel.Text = Service.GenerateReport3(customerComboBox.Text);
        }
        


    }


}
