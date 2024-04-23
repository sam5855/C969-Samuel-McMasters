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
            c.Close();




            customerDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            customerDGV.ReadOnly = true;
            customerDGV.MultiSelect = false;
            customerDGV.AllowUserToAddRows = false;

            


           
           


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
    }
}
