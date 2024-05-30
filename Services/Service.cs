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
using System.Runtime.Remoting.Messaging;
using System.Drawing;

namespace C969_Samuel_McMasters.Services
{
    class Service
    {
        //Class to handle database operations
        
        //Database details for local machine
        public static string homeConnectionString = "server=127.0.0.1;uid=root;pwd=5855;database=client_schedule";

        //Database details for test server
        //public static string homeConnectionString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";





        //Returns number of records in table
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

        //Writes new records to database
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

        //Gets customer information
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

        //Gets customer information for MainForm DGV
        static public List<Customer> LoadCustomerInfo()
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

        //Gets customerId 
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

        //Gets user Id
        static public int GetUserId(string search)
        {
            int customerId;
            string query;

            if (int.TryParse(search, out customerId))
            {
                query = $"SELECT userId FROM user WHERE userName = '{search}'";
            }
            else
            {
                query = $"SELECT userId FROM user WHERE userName LIKE '{search}'";
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
        static public bool UpdateCustomer(Dictionary<string, string> updatedCustomer)
        {
            MySqlConnection c = new MySqlConnection(homeConnectionString);

            try
            {
                c.Open();

                //Update Customer Table
                string updateRecord = $"UPDATE customer" +
                    $" SET customerName = '{updatedCustomer["customerName"]}', lastUpdate = '{DataHelper.CreateTimeStamp()}', lastUpdateBy = '{DataHelper.GetCurrentUserName()}'" +
                    $" WHERE customerId = '{updatedCustomer["customerId"]}'";
                MySqlCommand cmd = new MySqlCommand(updateRecord, c);
                int customerUpdated = cmd.ExecuteNonQuery();
                
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                c.Close();
            }

        }

        //Delete customer information 
        static public bool DeleteCustomer(int customerId)
        {
            MySqlConnection c = new MySqlConnection(homeConnectionString);
            try
            {
                
                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = $"DELETE FROM customer WHERE customerId = {customerId}";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Customer has associated appointment. Please delete all appointments before deleting customer ");
                Console.WriteLine("Exception thrown when deleting customer: " + ex);
                return false;
            }
            finally
            {
                c.Close();
            }


        }

        //Deletes appointments
        static public bool DeleteAppointment(int appointmentId)
        {
            MySqlConnection c = new MySqlConnection(homeConnectionString);

            try
            {
                c.Open();

                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = $"DELETE FROM appointment WHERE appointmentId = {appointmentId}";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete appointment. Please check logs.");
                Console.WriteLine("Exception thrown when deleting appointment: " + ex);
                return false;
            }
            finally
            {
                c.Close();
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
        static public bool UpdateAppointment(Dictionary<string, string> updatedAppointment)
        {
            MySqlConnection c = new MySqlConnection(homeConnectionString);

            try
            {

                c.Open();

                //Update appointment table
                string updateRecord = $"UPDATE appointment" +
                    $" SET start = '{updatedAppointment["startDate"]}', end = '{updatedAppointment["endDate"]}', type = '{updatedAppointment["type"]}', customerId = '{updatedAppointment["customerId"]}', lastUpdate = '{DataHelper.CreateTimeStamp()}', lastUpdateBy = '{DataHelper.GetCurrentUserName()}'" +
                    $" WHERE appointmentId = '{updatedAppointment["appointmentId"]}'";
                MySqlCommand cmd = new MySqlCommand(updateRecord, c);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Exception thrown when getting updating appointment: " + ex);
                return false;
            }
            finally
            {
                c.Close();
            }


        }

        //Appointment DGV filter
        static public List<Appointment> GetSpecificAppointments(DateTime startDate, int userId)
        {
            List<Appointment> appointmentList = new List<Appointment>();
            MySqlConnection c = new MySqlConnection(homeConnectionString);

            

            try
            {


                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = $"SELECT start, end, type, appointmentId, customerId " +
                    "FROM appointment " +
                    "WHERE userId = @userId AND start >= @startDate AND start < @nextDay";

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@startDate", startDate.ToString("yyyyMMdd")); // Use only date part
                cmd.Parameters.AddWithValue("@nextDay", startDate.Date.AddDays(1)); // Next day
                cmd.ExecuteNonQuery();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime aptStartDate = Convert.ToDateTime(reader["start"]);
                        DateTime endDate = Convert.ToDateTime(reader["end"]);
                        appointmentList.Add(new Appointment()
                        {
                            StartDate = aptStartDate.ToLocalTime(),
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

            DateTime endOfMonth = startOfMonth.AddMonths(1);

            try
            {


                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = $"SELECT start, end, type, appointmentId, customerId FROM appointment WHERE userId = {userId} AND start >= {startOfMonth.ToUniversalTime().ToString("yyyyMMddHHmmss")} AND end <= {endOfMonth.ToUniversalTime().ToString("yyyyMMddHHmmss")}";

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
        static public bool CheckOverlappingAppointments(DateTime startTime, DateTime endTime, int userId)
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
        static public int FindUser(string username, string password)
        {
            MySqlConnection c = new MySqlConnection(Services.Service.homeConnectionString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT userId FROM user WHERE username = '{username}' AND password = '{password}'", c);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                DataHelper.SetCurrentUserId(Convert.ToInt32(rdr[0]));
                DataHelper.SetCurrentUserName(username);
                rdr.Close();
                c.Close();
                return DataHelper.GetCurrentUserId();
            }
            return 0;

        }

        //Alerts user if appointment is within 15 minutes of log-in time
        static public void AlertUser(int userId)
        {
            DateTime currentTime = DateTime.UtcNow;

            //DateTime currentTime = DateTime.Now;
            //currentTime.ToUniversalTime();


            MySqlConnection c = new MySqlConnection(homeConnectionString);

            //try
            //{
            //    c.Open();
            //    MySqlCommand cmd = c.CreateCommand();
            //    cmd.CommandText = $"SELECT COUNT(*) FROM appointment WHERE userId = @userId AND TIMESTAMPDIFF(MINUTE, start, @currentTime) <= 15 AND TIMESTAMPDIFF(MINUTE, start, @currentTime) >= 0";
            //    cmd.Parameters.AddWithValue("@userId", userId);
            //    cmd.Parameters.AddWithValue("@currentTime", currentTime.ToString("yyyyMMddHHmmss"));

            //    int appointmentCount = Convert.ToInt32(cmd.ExecuteScalar());

            //    if (appointmentCount > 0)
            //    {

            //        //MessageBox.Show("Upcoming appointment within 15 minutes!?");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Exception thrown when checking for overlapping appointments." + ex);
            //}
            //finally
            //{
            //    c.Close();
            //}

            
                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = $"SELECT COUNT(*) FROM appointment WHERE userId = @userId AND TIMESTAMPDIFF(MINUTE, start, @currentTime) <= 15 AND TIMESTAMPDIFF(MINUTE, start, @currentTime) >= 0";
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@currentTime", currentTime.ToString("yyyyMMddHHmmss"));

                int appointmentCount = Convert.ToInt32(cmd.ExecuteScalar());

                if (appointmentCount > 0)
                {
                    MessageBox.Show("Test");
                }

            
           
                c.Close();
            




        }

        //Sets Report Combo Box Data Source
        static public List<string> GetAllUsers()
        {
            List<string> userList = new List<string>();
            MySqlConnection c = new MySqlConnection(homeConnectionString);

            try
            {
                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = "SELECT userName FROM user";

                cmd.ExecuteNonQuery();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userList.Add(reader["userName"].ToString());
                        
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


            return userList;
        }

        //Sets Report Combo Box Data Source
        static public List<string> GetAllCustomers()
        {
            List<string> customerList = new List<string>();
            MySqlConnection c = new MySqlConnection(homeConnectionString);

            try
            {
                c.Open();
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = "SELECT customerName FROM customer";

                cmd.ExecuteNonQuery();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customerList.Add(reader["customerName"].ToString());

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
   

        //=====================================================================
        //Delegate and Lambda functionality below
        //=====================================================================



        //This lambda expression encapsultaes the database query to count the number of appointment, providing a more concise and readable approach
        public static Func<MySqlCommand, int> countAppointments = (cmd) =>
        {
            int appointmentCount = 0;
            try
            {
                appointmentCount = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown when getting appointment count: " + ex);
            }
            return appointmentCount;
        };

        //This lambda expression encapsulates the creation of an Appointment objects from the data reader, providing a more concise and readable approach
        public static Func<MySqlDataReader, Appointment> createAppointment = (reader) =>
        {
            DateTime startDate = Convert.ToDateTime(reader["start"]);
            DateTime endDate = Convert.ToDateTime(reader["end"]);
            return new Appointment()
            {
                StartDate = startDate.ToLocalTime(),
                EndDate = endDate.ToLocalTime(),
                Type = reader["type"].ToString(),
                AppointmentId = Convert.ToInt32(reader["appointmentId"]),
                CustomerId = Convert.ToInt32(reader["customerId"]),
                //UserId = userId
            };
        };

        //!!!!!!This is working with lambda
        static public string GenerateReport1(DateTime month, string type)
        {
            List<int> appointmentList = new List<int>();
            MySqlConnection c = new MySqlConnection(homeConnectionString);
            DateTime currentDate = month;
            DateTime startOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1);
            c.Open();
            MySqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM appointment WHERE type = @type AND start >= @start AND end <= @end";
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@start", startOfMonth.ToUniversalTime().ToString("yyyyMMddHHmmss"));
            cmd.Parameters.AddWithValue("@end", endOfMonth.ToUniversalTime().ToString("yyyyMMddHHmmss"));
            int appointmentCount = countAppointments(cmd); //Use of delegate and lambda above
            c.Close();
            return appointmentCount.ToString();
            
        }

        //!!!!!!This is working with lambda
        static public List<Appointment> GenerateReport2(int userId)
        {
            MySqlConnection c = new MySqlConnection(homeConnectionString);
            List<Appointment> appointmentList = new List<Appointment>();
            try
            {
                c.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT * FROM appointment WHERE userID = @userId",
                    c
                );
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) //Use of delegate and lambda above
                    {
                        appointmentList.Add(createAppointment(reader));
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

        //!!!!!!This is working with lambda
        static public string GenerateReport3(string customerName)
        {
            int customerId = GetCustomerId(customerName);
            MySqlConnection c = new MySqlConnection(homeConnectionString);
            c.Open();
            MySqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM appointment WHERE customerId = @customerId";
            cmd.Parameters.AddWithValue("@customerId", customerId);
            int appointmentCount = countAppointments(cmd); //Use of delegate and lambda above 
            c.Close();
            return appointmentCount.ToString();
        }





    }

}
