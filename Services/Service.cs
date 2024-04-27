using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C969_Samuel_McMasters.DataModels;
using Org.BouncyCastle.Asn1.Tsp;
using System.Data.SqlTypes;

namespace C969_Samuel_McMasters.Services
{
    class Service
    {
        //Class to handle database operations
        public static string vmConnectionString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";
        public static string homeConnectionString = "server=127.0.0.1;uid=root;pwd=5855;database=client_schedule";






        public static int CreateRecordId(string table)
        {
            MySqlConnection c = new MySqlConnection(homeConnectionString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT {table + "Id"} FROM {table}", c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<int> idList = new List<int>();
            while (rdr.Read())
            {
                idList.Add(Convert.ToInt32(rdr[0]));
            }
            rdr.Close();
            c.Close();
            return DataHelper.NewID(idList);
        }


        public static int CreateRecord(string timeStamp, string userName, string table, string partOfQuery, int userId = 0)
        {
            int recordId = CreateRecordId(table);
            string recordInsert;

            if (userId == 0)
            {
                recordInsert = $"INSERT INTO {table}" +
                $" VALUES ('{recordId}', {partOfQuery}, '{timeStamp}', '{userName}', '{timeStamp}', '{userName}')";
            }
            else
            {
                recordInsert = $"INSERT INTO {table} (appointmentId, customerId, title, start, end, type, description, location, contact, url, userId, createDate, createdBy, lastUpdate, lastUpdateBy)" +
                $" VALUES ('{recordId}', {partOfQuery}, '{userId}', '{timeStamp}', '{userName}', '{timeStamp}', '{userName}')";
            }

            MySqlConnection c = new MySqlConnection(homeConnectionString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(recordInsert, c);
            cmd.ExecuteNonQuery();
            c.Close();

            return recordId;
        }


        //Get Customer Information
        static public Dictionary<string, string> GetCustomerDetails(int customerId)
        {
            string query = $"SELECT * FROM customer WHERE customerId = '{customerId.ToString()}'";

            MySqlConnection c = new MySqlConnection(homeConnectionString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            Dictionary<string, string> customerDict = new Dictionary<string, string>();
            // Customer Table Details
            customerDict.Add("customerId", customerId.ToString());
            customerDict.Add("customerName", rdr[1].ToString());
            customerDict.Add("addressId", rdr[2].ToString());
            customerDict.Add("active", rdr[3].ToString());
            rdr.Close();

            query = $"SELECT * FROM address WHERE addressId = '{customerDict["addressId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            rdr.Read();

            // Address Table Details
            customerDict.Add("address", rdr[1].ToString());
            customerDict.Add("cityId", rdr[3].ToString());
            customerDict.Add("postalCode", rdr[4].ToString());
            customerDict.Add("phone", rdr[5].ToString());
            rdr.Close();

            query = $"SELECT * FROM city WHERE cityId = '{customerDict["cityId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            rdr.Read();

            // City Table Details
            customerDict.Add("cityName", rdr[1].ToString());
            customerDict.Add("countryId", rdr[2].ToString());
            rdr.Close();

            query = $"SELECT * FROM country WHERE CountryId = '{customerDict["countryId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            rdr.Read();

            // Country Table Details
            customerDict.Add("country", rdr[1].ToString());
            rdr.Close();
            c.Close();

            return customerDict;
        }


        //Get CustomerId 
        static public int GetCustomerId(string search)
        {
            int customerId;
            string query;

            if (int.TryParse(search, out customerId))
            {
                query = $"SELECT CustomerId FROM customer WHERE customerId = '{search}'";
            }
            else
            {
                query = $"SELECT customerId FROM customer WHERE customerName LIKE '{search}'";
            }

            MySqlConnection c = new MySqlConnection(homeConnectionString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                customerId = Convert.ToInt32(rdr[0]);
                rdr.Close();
                c.Close();
                return customerId;
            }

            return 0;
        }


        //Update customer information
        static public bool updateCustomer(Dictionary<string, string> updatedCustomer)
        {
            MySqlConnection c = new MySqlConnection(homeConnectionString);
            c.Open();

            //Update Customer Table
            string updateRecord = $"UPDATE customer" +
                $" SET customerName = '{updatedCustomer["customerName"]}', lastUpdate = '{DataHelper.CreateTimeStamp()}', lastUpdateBy = '{DataHelper.GetCurrentUserName()}'" +
                $" WHERE customerId = '{updatedCustomer["customerId"]}'";
            MySqlCommand cmd = new MySqlCommand(updateRecord, c);
            int customerUpdated = cmd.ExecuteNonQuery();

            c.Close();

            if (customerUpdated != 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


        //Delete customer information
        //Check if I need to delete associated records as well 
        static public bool DeleteCustomer(int customerId)
        {
            MySqlConnection c = new MySqlConnection(homeConnectionString);
            c.Open();

            MySqlCommand cmd = c.CreateCommand();
            cmd.CommandText = $"DELETE FROM customer WHERE customerId = {customerId}";
            cmd.ExecuteNonQuery();

            int customerUpdated = 1;

            if (customerUpdated != 0)
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        public int AddAppointment(Appointment apt)
        {
            MySqlConnection c = new MySqlConnection(homeConnectionString);

            int aptId = -1;

            try
            {
                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = "INSERT INTO appointment(customerId, userId, title, description, location, contact, type, url, start, end) VALUES(@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end);" +
                    "SELECT appointmentId FROM appointment ORDER BY appointmentId DESC LIMIT 1";
                //cmd.CommandText = "INSERT INTO appointment(customerId, userId, title, description, location, contact, type, url, start, end) VALUES(@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end)";

                cmd.Parameters.AddWithValue("@customerId", apt.CustomerId);
                cmd.Parameters.AddWithValue("@userId", apt.UserId);
                cmd.Parameters.AddWithValue("@title", apt.Title);
                cmd.Parameters.AddWithValue("@description", apt.Description);
                cmd.Parameters.AddWithValue("@location", apt.Location);
                cmd.Parameters.AddWithValue("@contact", apt.Contact);
                cmd.Parameters.AddWithValue("@type", apt.Type);
                cmd.Parameters.AddWithValue("@url", apt.Url);
                cmd.Parameters.AddWithValue("@start", apt.StartDate);
                cmd.Parameters.AddWithValue("@end", apt.EndDate);
                aptId = (int)cmd.ExecuteScalar();
            }
            //catches errors in case the above code fails
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when adding appointment: " + ex);
            }
            //Close connection regardless of whether the try block executes or not.
            finally
            {
                c.Close();
            }

            return aptId;

        }

        static public bool DeleteAppointment(int appointmentId)
        {
            MySqlConnection c = new MySqlConnection(homeConnectionString);
            c.Open();

            MySqlCommand cmd = c.CreateCommand();
            cmd.CommandText = $"DELETE FROM appointment WHERE appointmentId = {appointmentId}";
            cmd.ExecuteNonQuery();

            int appointmentUpdated = 1;

            if (appointmentUpdated != 0)
            {
                return true;
            }
            else
            {
                return false;
            }



        }


        //Get Appointment Information
        static public Dictionary<string, string> GetAppointmentDetails(int appointmentId)
        {
            string query = $"SELECT * FROM appointment WHERE appointmentId = '{appointmentId}'";

            MySqlConnection c = new MySqlConnection(homeConnectionString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            Dictionary<string, string> appointmentDict = new Dictionary<string, string>();
            // Customer Table Details
            appointmentDict.Add("appointmentId", rdr[0].ToString());
            appointmentDict.Add("userId", rdr[1].ToString());
            appointmentDict.Add("startDate", rdr[9].ToString());
            appointmentDict.Add("endDate", rdr[10].ToString());
            appointmentDict.Add("type", rdr[7].ToString());
            rdr.Close();
            c.Close();

         

            return appointmentDict;
        }


        //Update appointment information
        static public bool updateAppointment(Dictionary<string, string> updatedAppointment)
        {
            MySqlConnection c = new MySqlConnection(homeConnectionString);
            c.Open();

            //Update appointment table
            string updateRecord = $"UPDATE appointment" +
                $" SET start = '{updatedAppointment["startDate"]}', end = '{updatedAppointment["endDate"]}', type = '{updatedAppointment["type"]}', customerId = '{updatedAppointment["customerId"]}', lastUpdate = '{DataHelper.CreateTimeStamp()}', lastUpdateBy = '{DataHelper.GetCurrentUserName()}'" +
                $" WHERE appointmentId = '{updatedAppointment["appointmentId"]}'";
            MySqlCommand cmd = new MySqlCommand(updateRecord, c);
            int appointmentUpdated = cmd.ExecuteNonQuery();

            c.Close();

            if (appointmentUpdated != 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}
