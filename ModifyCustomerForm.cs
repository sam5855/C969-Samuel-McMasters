using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969_Samuel_McMasters.Services;

namespace C969_Samuel_McMasters
{
    public partial class ModifyCustomerForm : Form
    {
        public static Dictionary<string, string> customerDict = new Dictionary<string, string>();


        public ModifyCustomerForm(int selectedCustomer)
        {
            InitializeComponent();
            
            customerDict = Service.GetCustomerDetails(selectedCustomer);
            modCustomerNameTextBox.Text = customerDict["customerName"];
            modCustomerAddressTextBox.Text = customerDict["address"];
            modCustomerCityTextBox.Text = customerDict["cityName"];
            modCustomerCountryTextBox.Text = customerDict["country"];
            modCustomerPostalCodeTextBox.Text = customerDict["postalCode"];
            modCustomerPhoneNumberTextBox.Text = customerDict["phone"];

        }

        private void ModifyCustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }
    }
}
