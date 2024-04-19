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
                recordInsert = $"INSERT INTO {table} (appointmentId, customerId, start, end, type, userId, createDate, createdBy, lastUpdate, lastUpdateBy)" +
                $" VALUES ('{recordId}', {partOfQuery}, '{userId}', '{timeStamp}', '{userName}', '{timeStamp}', '{userName}')";
            }

            MySqlConnection c = new MySqlConnection(homeConnectionString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(recordInsert, c);
            cmd.ExecuteNonQuery();
            c.Close();

            return recordId;
        }


        

    }
}
