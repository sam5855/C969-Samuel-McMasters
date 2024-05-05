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
using System.Linq.Expressions;
using System.Globalization;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.X509;
using System.Configuration;

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

        static public List<Customer> loadCustomerInfo()
        {
            List<Customer> customerList = new List<Customer>();
            MySqlConnection c = new MySqlConnection(Service.homeConnectionString);
            try
            {
                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = $"SELECT customerId, customerName, active FROM customer";

                cmd.ExecuteNonQuery();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int isActive = Convert.ToInt32(reader["active"]);
                        bool active;
                        if (isActive == 1)
                        {
                            active = true;
                        }
                        else
                        {
                            active = false;
                        }
                        customerList.Add(new Customer()
                        {
                            CustomerId = Convert.ToInt32(reader["customerId"]),
                            CustomerName = reader["customerName"].ToString(),
                            Active = active
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when getting current week appointments: " + ex);
            }

            finally
            {
                c.Close();
            }
            return customerList;
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
        static public bool DeleteCustomer(int customerId)
        {

            try
            {
                MySqlConnection c = new MySqlConnection(homeConnectionString);
                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = $"DELETE FROM customer WHERE customerId = {customerId}";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                MessageBox.Show("Customer has associated appointment. Please delete all appointments before deleting customer");
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

        //Deletes appointments
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

        //Appointment DGV filter
        static public List<Appointment> GetWeekAppointments(int userId)
        {
            List<Appointment> appointmentList = new List<Appointment>();
            MySqlConnection c = new MySqlConnection(homeConnectionString);

            DateTime currentDate = DateTime.Today;

            DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);

            DateTime endOfWeek = startOfWeek.AddDays(6);

            try
            {


                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = $"SELECT start, end, type, appointmentId, customerId FROM appointment WHERE userId = {userId} AND start >= {startOfWeek.ToUniversalTime().ToString("yyyyMMddHHmmss")} AND end <= {endOfWeek.ToUniversalTime().ToString("yyyyMMddHHmmss")}";

                cmd.ExecuteNonQuery();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime startDate = Convert.ToDateTime(reader["start"]);
                        DateTime endDate = Convert.ToDateTime(reader["end"]);
                        appointmentList.Add(new Appointment()
                        {
                            StartDate = startDate.ToLocalTime(),
                            EndDate = endDate.ToLocalTime(),
                            Type = reader["type"].ToString(),
                            AppointmentId = Convert.ToInt32(reader["appointmentId"]),
                            CustomerId = Convert.ToInt32(reader["customerId"]),
                            UserId = userId
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when getting current week appointments: " + ex);
            }

            finally
            {
                c.Close();
            }


            return appointmentList;

        }

        //Appointment DGV filter
        static public List<Appointment> GetMonthAppointments(int userId)
        {
            List<Appointment> appointmentList = new List<Appointment>();
            MySqlConnection c = new MySqlConnection(homeConnectionString);

            DateTime currentDate = DateTime.Today;

            DateTime startOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);

            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            try
            {


                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = $"SELECT start, end, type, appointmentId, customerId FROM appointment WHERE userId = {userId} AND start >= {startOfMonth.ToUniversalTime().ToString("yyyyMMddHHmmss")} AND end <= {endOfMonth.ToUniversalTime().ToString("yyyyMMddHHmmss")}";

                cmd.ExecuteNonQuery();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    //while (reader.Read())
                    //{

                    //    appointmentList.Add(new Appointment()
                    //    {
                    //        StartDate = Convert.ToDateTime(reader["start"]),
                    //        EndDate = Convert.ToDateTime(reader["end"]),
                    //        Type = reader["type"].ToString(),
                    //        AppointmentId = Convert.ToInt32(reader["appointmentId"]),
                    //        CustomerId = Convert.ToInt32(reader["customerId"]),
                    //        UserId = userId
                    //    }); ;
                    //}
                    while (reader.Read())
                    {
                        DateTime startDate = Convert.ToDateTime(reader["start"]);
                        DateTime endDate = Convert.ToDateTime(reader["end"]);
                        appointmentList.Add(new Appointment()
                        {
                            StartDate = startDate.ToLocalTime(),
                            EndDate = endDate.ToLocalTime(),
                            Type = reader["type"].ToString(),
                            AppointmentId = Convert.ToInt32(reader["appointmentId"]),
                            CustomerId = Convert.ToInt32(reader["customerId"]),
                            UserId = userId
                        }); ;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when getting current week appointments: " + ex);
            }

            finally
            {
                c.Close();
            }


            return appointmentList;

        }

        //Appointment DGV filter
        static public List<Appointment> GetAllAppointments(int userId)
        {
            List<Appointment> appointmentList = new List<Appointment>();
            MySqlConnection c = new MySqlConnection(homeConnectionString);

            try
            {
                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = $"SELECT start, end, type, appointmentId, customerId FROM appointment";

                cmd.ExecuteNonQuery();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime startDate = Convert.ToDateTime(reader["start"]);
                        DateTime endDate = Convert.ToDateTime(reader["end"]);
                        appointmentList.Add(new Appointment()
                        {
                            StartDate = startDate.ToLocalTime(),
                            EndDate = endDate.ToLocalTime(),
                            Type = reader["type"].ToString(),
                            AppointmentId = Convert.ToInt32(reader["appointmentId"]),
                            CustomerId = Convert.ToInt32(reader["customerId"]),
                            UserId = userId
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when getting current week appointments: " + ex);
            }

            finally
            {
                c.Close();
            }


            return appointmentList;

        }

        //Checks for overalapping appointments
        public static bool CheckOverlappingAppointments(DateTime startTime, DateTime endTime, int userId)
        {

            MySqlConnection c = new MySqlConnection(homeConnectionString);
            bool overlap = false;


            try
            {


                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = $"SELECT COUNT(*) FROM appointment WHERE userId = {userId} AND (('{startTime.ToUniversalTime().ToString("yyyyMMddHHmmss")}' < end AND '{endTime.ToUniversalTime().ToString("yyyyMMddHHmmss")}' > start) OR ('{endTime.ToUniversalTime().ToString("yyyyMMddHHmmss")}' > start AND '{startTime.ToUniversalTime().ToString("yyyyMMddHHmmss")}' < end))";


                if (cmd.ExecuteScalar().ToString() != "0")
                {
                    overlap = true;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when checking for overlapping appointments." + ex);
            }
            finally
            {
                
                c.Close();
            }

            return overlap;
                

            




        }

        //Method to authenticate user login
        public static int FindUser(string username, string password)
        {
            MySqlConnection c = new MySqlConnection(Services.Service.homeConnectionString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT userId FROM user WHERE username = '{username}' AND password = '{password}'", c);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                DataHelper.setCurrentUserId(Convert.ToInt32(rdr[0]));
                DataHelper.setCurrentUserName(username);
                rdr.Close();
                c.Close();
                return DataHelper.getCurrentUserId();
            }
            return 0;

        }

        //Alerts user if appointment is within 15 minutes of log-in time
        public static void AlertUser(int userId)
        {
            DateTime currentTime = DateTime.UtcNow;
            MySqlConnection c = new MySqlConnection(homeConnectionString);

            try
            {
                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = $"SELECT COUNT(*) FROM appointment WHERE userId = @userId AND TIMESTAMPDIFF(MINUTE, start, @currentTime) <= 15 AND TIMESTAMPDIFF(MINUTE, start, @currentTime) >= 0";
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@currentTime", currentTime.ToString("yyyyMMddHHmmss"));

                int appointmentCount = Convert.ToInt32(cmd.ExecuteScalar());

                if (appointmentCount > 0)
                {
                    MessageBox.Show("Upcoming appointment within 15 minutes!");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when checking for overlapping appointments." + ex);
            }
            finally
            {
                c.Close();
            }







        }
    }

}
