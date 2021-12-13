using CitizenFX.Core;
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

            Connection.OpenAsync();
            Connection.CloseAsync();
            
        }

        public static MySqlDataReader ExecuteSelectQuery(string Sql)
        {
            MySqlCommand Command = new MySqlCommand(Sql, Connection);

            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }

            MySqlDataReader Result = Command.ExecuteReader();

            return Result;
        }

        public static void ExecuteInsertQuery(string Sql)
        {
            MySqlCommand Command = new MySqlCommand(Sql, Connection);

            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }

            Command.ExecuteNonQuery();

            Connection.Close();
        }

        public static void ExecuteUpdateQuery(string Sql)
        {
            ExecuteInsertQuery(Sql);
        }
    }
}
