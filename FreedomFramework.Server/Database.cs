using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using CitizenFX.Core.Native;
using MySqlConnector;
using System;
using System.Data;

namespace server
{
    public class Database
    {
        public static MySqlConnection Connection;

        public static void Initialize()
        {
            MySqlConnectionStringBuilder Builder = new MySqlConnectionStringBuilder
            {
                Server = Config.Load.Host,
                Port = Config.Load.Port,
                UserID = Config.Load.User,
                Password = Config.Load.Password,
                Database = Config.Load.Database
            };

            Connection = new MySqlConnection(Builder.ToString());

            try
            {
                MySqlDataReader data = SelectQuery("SELECT * FROM ff_users");
            }
            catch
            {
                var frameworkSQL = LoadResourceFile(GetCurrentResourceName(), GetResourceMetadata(GetCurrentResourceName(), "auto_sql_file", 0));

                ExecuteQuery(frameworkSQL);

                Debug.WriteLine("[INFO] Automatically created the tables in the Database!");
            }

            Connection.Close();
        }

        public static MySqlDataReader SelectQuery(string Sql)
        {
            MySqlCommand Command = new MySqlCommand(Sql, Connection);

            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }

            MySqlDataReader Result = Command.ExecuteReader();

            return Result;
        }

        public static void ExecuteQuery(string Sql)
        {
            MySqlCommand Command = new MySqlCommand(Sql, Connection);

            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }

            Command.ExecuteNonQuery();

            Connection.Close();
        }
    }
}
