using CitizenFX.Core;
using SharpConfig;
using System;
using static CitizenFX.Core.Native.API;

namespace server
{
    // DO NOT SET ANY VARIABLES IN HERE - USE THE CONFIG.INI FILE
    // DO NOT SET ANY VARIABLES IN HERE - USE THE CONFIG.INI FILE
    // DO NOT SET ANY VARIABLES IN HERE - USE THE CONFIG.INI FILE
    // DO NOT SET ANY VARIABLES IN HERE - USE THE CONFIG.INI FILE

    public class Config
    {
        public static Load Load;
    }

    public struct Load
    {
        public string Host;
        public uint Port;
        public string User;
        public string Password;
        public string Database;

        public static void Config()
        {
            Load config = new Load()
            {
                Host = "127.0.0.1",
                Port = 3306,
                User = "root",
                Password = "",
                Database = "freedom"
            };

            var configFile = Configuration.LoadFromFile(string.Format("{0}/server/config/config.ini", GetResourcePath(GetCurrentResourceName())));

            try
            {
                bool isFileNotNull = !string.IsNullOrWhiteSpace(configFile.ToString());

                if (isFileNotNull)
                {
                    var mysqlConfigsection = configFile["MYSQL"];

                    config.Host = mysqlConfigsection["HOST"].StringValue;
                    config.Port = (uint)mysqlConfigsection["PORT"].IntValue;
                    config.User = mysqlConfigsection["USER"].StringValue;
                    config.Password = mysqlConfigsection["PASSWORD"].StringValue;
                    config.Database = mysqlConfigsection["DATABASE"].StringValue;

                    server.Config.Load = config;

                    Debug.WriteLine("[SUCCESS] The Config has been loaded!");

                    server.Database.Initialize();
                }
                else
                {
                    Debug.WriteLine("[ERROR] The Config file is empty, Please make sure the information is in there!");
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Something went wrong while loading the config. {ex}");
                return;
            }
        }
    }
}
