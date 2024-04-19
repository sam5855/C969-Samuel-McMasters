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


        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string timeStamp = DataHelper.CreateTimeStamp();
            string userName = DataHelper.GetCurrentUserName();

            int activeYes = 1;

            int countryId = Service.CreateRecord(timeStamp, userName, "country", $"'{customerCountryTextBox.Text}'");
            int cityId = Service.CreateRecord(timeStamp, userName, "city", $"'{customerCityTextBox.Text}', '{countryId}'");
            int addressId = Service.CreateRecord(timeStamp, userName, "address", $"'{customerAddressTextBox.Text}', '', '{cityId}', '{customerPostalCodeTextBox.Text}', '{customerPhoneNumberTextBox.Text}'");
            //Service.CreateRecord(timeStamp, userName, "customer", $"'{customerNameTextBox.Text}', '{addressId}', '{(activeYes.Checked ? 1 : 0)}'");
            Service.CreateRecord(timeStamp, userName, "customer", $"'{customerNameTextBox.Text}', '{addressId}', '{activeYes}'");
            
            
            Close();
            MainForm MainForm = new MainForm();
            MainForm.Show();
            
            
        }

    }
}
