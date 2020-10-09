using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlsLib.DBWrapper
{
    public static class MySqlWrapper
    {
        private static MySqlConnection connection = null;
        //TODO Адрес MySQL
        private static string connectionString = "SERVER=127.0.0.1;DATABASE=tours_v5;UID=administrator;PASSWORD=456Park();convert zero datetime=True";

        private static MySqlConnection GetConnection()
        {
            if (connection == null) connection = new MySqlConnection(connectionString);
            if (connection.State == ConnectionState.Closed) connection.Open();
            return connection;
        }

        public static int Execute(string sql)
        {
            MySqlConnection cc = GetConnection();
            MySqlCommand com = new MySqlCommand(sql, cc);
            com.ExecuteNonQuery();

            return (int)com.LastInsertedId;
        }

        public static DataTable Select(string sql)
        {
            MySqlConnection cc = GetConnection();
            MySqlCommand com = new MySqlCommand(sql, cc);
            com.ExecuteNonQuery();

            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(com);
            DataTable dataTabe = new DataTable();

            sqlAdapter.Fill(dataTabe);
            sqlAdapter.Update(dataTabe);

            return dataTabe;
        }
    }
}
