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
using MySql.Data;
using MySql.Data.MySqlClient;


namespace C969_Samuel_McMasters
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //Creating SQL Connection
            MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=5855;database=client_schedule");
            conn.Open();

            MySqlCommand query = new MySqlCommand("SELECT * FROM city", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(query);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            customerDGV.DataSource = dt;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //testing vm
        }
    }
}
