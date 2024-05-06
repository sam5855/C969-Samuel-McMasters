using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969_Samuel_McMasters.DataModels;
using C969_Samuel_McMasters.Services;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace C969_Samuel_McMasters
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            userLabel.Text = DataHelper.GetCurrentUserName();
            

            //Populate customer DGV
            customerDGV.DataSource = Service.LoadCustomerInfo();

            //Populate appointment DGV
            allAppointmentsRadioButton.Checked = true;

            //DGV Formatting 
            customerDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            customerDGV.ReadOnly = true;
            customerDGV.MultiSelect = false;
            customerDGV.AllowUserToAddRows = false;
            appointmentDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentDGV.ReadOnly = true;
            appointmentDGV.MultiSelect = false;
            appointmentDGV.AllowUserToAddRows = false;
            appointmentDGV.Columns[3].Visible = false;
            appointmentDGV.Columns[4].Visible = false;
            appointmentDGV.Columns[5].Visible = false;
            appointmentDGV.Columns[6].Visible = false;
            appointmentDGV.Columns[8].Visible = false;
            customerDGV.Columns[2].Visible = false;
            customerDGV.Columns[4].Visible = false;
           








        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            this.Close();
            DataHelper.ShowAddCustomer();
        }

        private void modifyCustomerButton_Click(object sender, EventArgs e)
        {
            //Grabs customer ID from selected DGV row
            int selectedCustomer = Convert.ToInt32(customerDGV.CurrentRow.Cells[0].Value);

            //Passes selected customer ID to modify form
            ModifyCustomerForm ModifyCustomerForm = new ModifyCustomerForm(selectedCustomer);

            this.Close();
            ModifyCustomerForm.ShowDialog();
         
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            int selectedCustomer = Convert.ToInt32(customerDGV.CurrentRow.Cells[0].Value);
            Service.DeleteCustomer(selectedCustomer);
            customerDGV.DataSource = Service.LoadCustomerInfo();
        }

        private void createAppointmentButton_Click(object sender, EventArgs e)
        {
            this.Close();
            AddAppointmentForm aaf = new AddAppointmentForm();
            aaf.ShowDialog();
        }

        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {
            int selectedAppointment = Convert.ToInt32(appointmentDGV.CurrentRow.Cells[0].Value);
            Service.DeleteAppointment(selectedAppointment);

            int currentUserId = DataHelper.GetCurrentUserId();
            List<Appointment> allAppointments = Service.GetAllAppointments(currentUserId);
            appointmentDGV.DataSource = allAppointments;
        }

        private void modifyAppointmentButton_Click(object sender, EventArgs e)
        {
            //Grabs appointment ID from selected DGV row
            int selectedAppointment = Convert.ToInt32(appointmentDGV.CurrentRow.Cells[0].Value);
            int customerId = Convert.ToInt32(appointmentDGV.CurrentRow.Cells[1].Value);
            //Passes selected appointment ID to modify form
            ModifyAppointmentForm ModifyAppointmentForm = new ModifyAppointmentForm(selectedAppointment, customerId);

            this.Close();
            ModifyAppointmentForm.ShowDialog();
        }

        private void FilterAppointments(Func<int, List<Appointment>> filterFunction)
        {
            int currentUserId = DataHelper.GetCurrentUserId();
            appointmentDGV.DataSource = filterFunction(currentUserId);
        }

        //Filter sets appointment DGV to all appointments
        //Lambda expression reduced amount of code 
        private void allAppointmentsRadioButton_CheckedChanged(object sender, EventArgs e) => FilterAppointments(Service.GetAllAppointments);


        //Filter sets appointment DGV to current week appointments
        //Lambda expression reduced amount of code
        private void currentWeekRadioButton_CheckedChanged(object sender, EventArgs e) => FilterAppointments(Service.GetWeekAppointments);


        //Filter sets appointment DGV to current month appointments
        //Lambda expression made code more readable
        private void currentMonthRadioButton_CheckedChanged(object sender, EventArgs e) => FilterAppointments(Service.GetMonthAppointments);
        

        private void customerGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void reportsButton_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            this.Close();
            reportsForm.ShowDialog();
        }
    }
}
