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
using C969_Samuel_McMasters.DataModels;
using Google.Protobuf.WellKnownTypes;

namespace C969_Samuel_McMasters
{
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
            maskedPhoneNumber.Mask = "000-000-0000";

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customerNameTextBox.Text) || string.IsNullOrEmpty(customerAddressTextBox.Text) || string.IsNullOrEmpty(customerCityTextBox.Text) || string.IsNullOrEmpty(customerCountryTextBox.Text)
                || string.IsNullOrEmpty(customerPostalCodeTextBox.Text) || string.IsNullOrEmpty(maskedPhoneNumber.Text))
            {
                MessageBox.Show("Please fill out all customer information");
            }
            else
            {


                string timeStamp = DataHelper.CreateTimeStamp();
                string userName = DataHelper.GetCurrentUserName();

                

                int countryId = Service.CreateRecord(timeStamp, userName, "country", $"'{customerCountryTextBox.Text}'");
                int cityId = Service.CreateRecord(timeStamp, userName, "city", $"'{customerCityTextBox.Text}', '{countryId}'");
                int addressId = Service.CreateRecord(timeStamp, userName, "address", $"'{customerAddressTextBox.Text}', '', '{cityId}', '{customerPostalCodeTextBox.Text}', '{maskedPhoneNumber.Text}'");
                Service.CreateRecord(timeStamp, userName, "customer", $"'{customerNameTextBox.Text}', '{addressId}', '{(activeCheckBox.Checked ? 1 : 0)}'");
                


                Close();
                MainForm MainForm = new MainForm();
                MainForm.Show();
            }
            
        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
