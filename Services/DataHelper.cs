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
            return DateTime.Now.ToString("yyyy-MM-dd");
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
