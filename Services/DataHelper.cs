using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using C969_Samuel_McMasters.Services;


namespace C969_Samuel_McMasters.DataModels
{
    class DataHelper
    {
      
        public static int _currentUserId;
        public static string _currentUserName;

        public static DateTime businessOpen = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 9, 0, 0);
        public static DateTime businessClose = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 17, 0, 0);

        


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


        


      


    }
}
