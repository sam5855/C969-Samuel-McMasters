using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace C969_Samuel_McMasters.DataModels
{
    class DataHelper
    {
        //Two connection strings to handle database on vm vs home pc
        public static string vmConnectionString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";
        public static string homeConnectionString = "server=127.0.0.1;uid=root;pwd=5855;database=client_schedule";
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

        public static string getCurrentUserName()
        {
            return _currentUserName;
        }

        public static void setCurrentUserName(string currentUserName)
        {
            _currentUserName = currentUserName;
        }

      


    }
}
