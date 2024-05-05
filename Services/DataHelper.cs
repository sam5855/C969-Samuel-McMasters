using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using C969_Samuel_McMasters.Services;
using Google.Protobuf.WellKnownTypes;
using System.IO;

namespace C969_Samuel_McMasters.DataModels
{
    class DataHelper
    {
      
        public static int _currentUserId;
        public static string _currentUserName;

        


        public static int getCurrentUserId()
        {
            return _currentUserId;
        }
        public static void setCurrentUserId(int currentUserID)
        {
            _currentUserId = currentUserID; 
        }

        public static string GetCurrentUserName()
        {
            return _currentUserName;
        }

        public static void setCurrentUserName(string currentUserName)
        {
            _currentUserName = currentUserName;
        }

        public static string CreateTimeStamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public static int NewID(List<int> idList)
        {
            int highestID = 0;
            foreach (int id in idList)
            {
                if (id > highestID)
                    highestID = id;
            }
            return highestID + 1;
        }

        //Loads Add Customer Form
        public static void ShowAddCustomer()
        {
            AddCustomerForm AddCustomerForm = new AddCustomerForm();
            AddCustomerForm.ShowDialog();
        }

        public static bool CheckBusinessHours(DateTime startTime, DateTime endTime)
        {
            // Define business hours
            TimeSpan openingTime = new TimeSpan(9, 0, 0); // 9:00am
            TimeSpan closingTime = new TimeSpan(17, 0, 0); // 5:00pm

            // Extract time component from startTime and endTime
            TimeSpan startTimeOfDay = startTime.TimeOfDay;
            TimeSpan endTimeOfDay = endTime.TimeOfDay;

            // Check if startTime and endTime fall within business hours
            if (startTimeOfDay >= openingTime && startTimeOfDay <= closingTime &&
        endTimeOfDay >= openingTime && endTimeOfDay <= closingTime)
            {
                // Both startTime and endTime are within business hours
                return true;


            }
            else
            {
                return false;
            }
        }

        public static string getCurrentTime()
        {
            DateTime currentTime = DateTime.Now;
            return currentTime.ToString();
        }

        //Creates log file, or appends to existing one
        public static void UserLogFile(string logText) 
        {
            //Gets current directory
            DirectoryInfo di = new DirectoryInfo("C:\\Users\\Sam\\Source\\Repos\\C969");

            string logPath = di + "\\Login_History.txt";
            if (!File.Exists(logPath))
            {
                var file = File.Create(logPath);
                file.Close();
                TextWriter writer = new StreamWriter(logPath);
                writer.WriteLine(logText);
                writer.Close();
            }
            else if (File.Exists(logPath))
            {
                using (var writer = new StreamWriter(logPath, true))
                {
                   writer.WriteLine(logText);   
                }
            }

        }

    }
}
