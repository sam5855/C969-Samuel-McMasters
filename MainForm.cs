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


namespace C969_Samuel_McMasters
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            userLabel.Text = DataHelper.GetCurrentUserName();

          
            //Creating SQL Connection
            MySqlConnection c = new MySqlConnection(Service.homeConnectionString);
            c.Open();

            //Populate Customer DataGrid
            MySqlCommand query = new MySqlCommand("SELECT * FROM customer", c);
            MySqlDataAdapter adp = new MySqlDataAdapter(query);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            customerDGV.DataSource = dt;

            //Populate Appointments DataGrid
            MySqlCommand aptQuery = new MySqlCommand("SELECT * FROM appointment", c);
            MySqlDataAdapter aptAdp = new MySqlDataAdapter(aptQuery);
            DataTable aptDt = new DataTable();
            aptAdp.Fill(aptDt);
            appointmentDGV.DataSource = aptDt;

            c.Close();
            



            customerDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            customerDGV.ReadOnly = true;
            customerDGV.MultiSelect = false;
            customerDGV.AllowUserToAddRows = false;
            appointmentDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentDGV.ReadOnly = true;
            appointmentDGV.MultiSelect = false;
            appointmentDGV.AllowUserToAddRows = false;







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


            MySqlConnection c = new MySqlConnection(Service.homeConnectionString);
            c.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM appointment", c);
            MySqlDataAdapter adp = new MySqlDataAdapter(query);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            appointmentDGV.DataSource = dt;
            c.Close();
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
    }
}
