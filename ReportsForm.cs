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
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            monthDateTimePicker.Format = DateTimePickerFormat.Custom;
            monthDateTimePicker.CustomFormat = "MM/yyyy";

            
            userComboBox.DataSource = Service.GetAllUsers();
            customerComboBox.DataSource = Service.GetAllCustomers();
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

        private void generateReport1Button_Click(object sender, EventArgs e)
        {
            DateTime month = monthDateTimePicker.Value;
            string type = aptTypeComboBox.Text;
            
            countLabel.Text = Service.GenerateReport1(month, type);
            monthLabel.Text = month.Month.ToString();
            typeLabel.Text = type;
        }
    }
}
