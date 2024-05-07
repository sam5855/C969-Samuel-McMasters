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
            maskedPhoneNumber.Mask = "000-000-0000";



            customerDict = Service.GetCustomerDetails(selectedCustomer);
            modCustomerIdTextBox.Text = customerDict["customerId"];
            modCustomerNameTextBox.Text = customerDict["customerName"];
            modCustomerAddressTextBox.Text = customerDict["address"];
            modCustomerCityTextBox.Text = customerDict["cityName"];
            modCustomerCountryTextBox.Text = customerDict["country"];
            modCustomerPostalCodeTextBox.Text = customerDict["postalCode"];
            maskedPhoneNumber.Text = customerDict["phone"];
            

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

        private void saveButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(modCustomerNameTextBox.Text) || string.IsNullOrEmpty(modCustomerAddressTextBox.Text) || string.IsNullOrEmpty(modCustomerCityTextBox.Text) || string.IsNullOrEmpty(modCustomerCountryTextBox.Text)
                || string.IsNullOrEmpty(modCustomerPostalCodeTextBox.Text) || string.IsNullOrEmpty(maskedPhoneNumber.Text))
            {
                MessageBox.Show("Please fill out all customer information");
            }
            else
            {


                Dictionary<string, string> updatedForm = new Dictionary<string, string>();

                updatedForm.Add("customerId", modCustomerIdTextBox.Text);
                updatedForm.Add("customerName", modCustomerNameTextBox.Text);
                updatedForm.Add("phone", maskedPhoneNumber.Text);
                updatedForm.Add("address", modCustomerAddressTextBox.Text);
                updatedForm.Add("city", modCustomerCityTextBox.Text);
                updatedForm.Add("zip", modCustomerPostalCodeTextBox.Text);
                updatedForm.Add("country", modCustomerCountryTextBox.Text);



                if (Service.UpdateCustomer(updatedForm))
                {
                    MessageBox.Show("Update Complete!");
                    Close();
                    MainForm MainForm = new MainForm();
                    MainForm.Show();
                }
                else
                {
                    MessageBox.Show("Update Could not complete");
                }
            }
        }

        private void modCustomerPhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
