using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_PersistenciaDatos.MySQLConnector
{
    public class MySQLConnectionSingleton
    {
        private static MySQLConnectionSingleton instance = null;
        private MySqlConnection connection;

        private MySQLConnectionSingleton(string server, string database, string user, string password)
        {
            string connectionString = $"Server={server};Database={database};User ID={user};Password={password};";
            connection = new MySqlConnection(connectionString);
        }

        public static MySQLConnectionSingleton Instance
            (string server, string database, string user, string password)
        {
            if (instance == null)
            {
                instance = new MySQLConnectionSingleton(server, database, user, password);
            }
            return instance;
        }

        public MySqlConnection GetConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed || connection.State == System.Data.ConnectionState.Broken)
            {
                connection.Open();
            }
            return connection;
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}