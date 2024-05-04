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
            customerDGV.DataSource = Service.loadCustomerInfo();

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


            MySqlConnection c = new MySqlConnection(Service.homeConnectionString);
            c.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM customer", c);
            MySqlDataAdapter adp = new MySqlDataAdapter(query);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            customerDGV.DataSource = dt;
            c.Close();
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

            int currentUserId = DataHelper.getCurrentUserId();
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


        //Filter sets appointment DGV to all appointments
        private void allAppointmentsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            int currentUserId = DataHelper.getCurrentUserId();
            List<Appointment> allAppointments = Service.GetAllAppointments(currentUserId);
            appointmentDGV.DataSource = allAppointments;
        }

        //Filter sets appointment DGV to current week appointments
        private void currentWeekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            int currentUserId = DataHelper.getCurrentUserId();
            List<Appointment> currentWeekAppointments = Service.GetWeekAppointments(currentUserId);
            appointmentDGV.DataSource = currentWeekAppointments;
        }

        //Filter sets appointment DGV to current month appointments
        private void currentMonthRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            int currentUserId = DataHelper.getCurrentUserId();
            List<Appointment> currentWeekAppointments = Service.GetMonthAppointments(currentUserId);
            appointmentDGV.DataSource = currentWeekAppointments;
        }
    }
}
