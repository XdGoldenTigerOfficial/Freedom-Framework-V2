using System;
using System.Collections.Generic;
using System.Linq;
using MySqlConnector;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace server
{
    public class Main : BaseScript
    {
        public Main()
        {
            Debug.WriteLine("[INFO] Freedom Framework V2 starting!");
        }

        [EventHandler("onServerResourceStart")]
        private void onServerResourceStart(string resourceName)
        {
            if (API.GetCurrentResourceName() != resourceName) return;

            Debug.WriteLine(
                "-------------------------------------------------------------------------------------------------------------------------------"
            );

            Debug.WriteLine(
                " ____  ____  ____  ____  ____   __   _  _    ____  ____   __   _  _  ____  _  _   __  ____  __ _    _  _  ____    \n" +
                "(  __)(  _ \\(  __)(  __)(    \\ /  \\ ( \\/ )  (  __)(  _ \\ / _\\ ( \\/ )(  __)/ )( \\ /  \\(  _ \\(  / )  / )( \\(___ \\  \n" +
                " ) _)  )   / ) _)  ) _)  ) D ((  O )/ \\/ \\   ) _)  )   //    \\/ \\/ \\ ) _) \\ /\\ /(  O ))   / )  (   \\ \\/ / / __/    \n" +
                "(__)  (__\\_)(____)(____)(____/ \\__/ \\_)(_/  (__)  (__\\_)\\_/\\_/\\_)(_/(____)(_/\\_) \\__/(__\\_)(__\\_)   \\__/ (____) "
            );

            Load.Config();

            Debug.WriteLine("[SUCCESS] Freedom Framework V2 started successfully!");

            Debug.WriteLine(
                "-------------------------------------------------------------------------------------------------------------------------------"
            );
        }

        [EventHandler("Freedom:IssueTicket")]
        private void IssueTicket([FromSource] Player player, Player TicketRecipient, int fine)
        {
            //Get Player Identifier
            var Identifier = player.Identifiers["license"];

            //Get Player Name
            string playername = player.Name;

            //Get The Recipient
            Player recipient = TicketRecipient;

            //Get Recipient Identifier
            var RecipientIdentifier = recipient.Identifiers["license"];

            //Get Recipient Name
            string recipientname = recipient.Name;

            if (Identifier == RecipientIdentifier)
            {
                player.TriggerEvent("Freedom:CannotTicketYourself");
            }
            else
            {
                //Trigger Player Event
                player.TriggerEvent("Freedom:TicketIssued", recipientname, fine);

                //Trigger Recipient Event
                recipient.TriggerEvent("Freedom:TicketRecieved", playername, fine);
            }
        }

        [EventHandler("Freedom:BankRobberyStarting")]
        private void BankRobberyStarting(string street)
        {
            TriggerClientEvent("Freedom:BankRobberyStartingGlobal", street);
        }

        [EventHandler("Freedom:BankRobberyComplete")]
        private void BankRobberyComplete(string street)
        {
            TriggerClientEvent("Freedom:BankRobberyCompleteGlobal", street);
        }

        [EventHandler("Freedom:PayPlayer")]
        private void PayPlayer([FromSource] Player player, Player recipientid, string amount)
        {
            //Get Player Identifier
            var Identifier = player.Identifiers["license"];

            //Get Player Name
            string playername = player.Name;

            //Get The Recipient
            Player recipient = recipientid;

            //Get Recipient Identifier
            var RecipientIdentifier = recipient.Identifiers["license"];

            //Get Recipient Name
            string recipientname = recipient.Name;

            if (Identifier == RecipientIdentifier)
            {
                player.TriggerEvent("Freedom:CannotPayYourself");
            }
            else
            {
                //Trigger Player Event
                player.TriggerEvent("Freedom:PaymentSent", recipientname, amount);

                //Trigger Recipient Event
                recipient.TriggerEvent("Freedom:PaymentRecieved", playername, amount);
            }
        }

        [EventHandler("Freedom:SendPlayerJobUpdate")]
        private void UpdatePlayerJob([FromSource] Player player, string job)
        {
            //Get Player Identifier
            var Identifier = player.Identifiers["license"];

            //Update Database
            Database.ExecuteUpdateQuery($"UPDATE users SET Job = '{job}' WHERE Identifier = '{Identifier}'");

            //Get New Salary
            MySqlDataReader Result5 = Database.ExecuteSelectQuery($"SELECT Salary FROM jobs WHERE Name = '{job}'");

            string GetJobSalary = "";
            while (Result5.Read())
            {
                GetJobSalary = Result5["Salary"].ToString();
            }

            //Close Connection
            Database.Connection.Close();

            //Send Salary to player
            player.TriggerEvent("Freedom:UpdatePlayerJob", GetJobSalary);
        }

        [EventHandler("Freedom:SavePlayerData")]
        private void SavePlayerData([FromSource] Player player, string cash, string bank, string job, string colas, string water, string bread)
        {
            //Get Player Identifier
            var Identifier = player.Identifiers["license"];

            //Update Player Info
            Database.ExecuteUpdateQuery($"UPDATE users SET Cash = '{cash}' WHERE Identifier = '{Identifier}'");
            Database.ExecuteUpdateQuery($"UPDATE users SET Bank = '{bank}' WHERE Identifier = '{Identifier}'");
            Database.ExecuteUpdateQuery($"UPDATE users SET Job = '{job}' WHERE Identifier = '{Identifier}'");

            //Update Player Inventory
            Database.ExecuteUpdateQuery($"UPDATE inventory SET Cola = {colas} WHERE Identifier = '{Identifier}'");
            Database.ExecuteUpdateQuery($"UPDATE inventory SET Water = {water} WHERE Identifier = '{Identifier}'");
            Database.ExecuteUpdateQuery($"UPDATE inventory SET Bread = {bread} WHERE Identifier = '{Identifier}'");

            //Close Connection
            Database.Connection.Close();
        }

        [EventHandler("Freedom:GetPlayerInventory")]
        private void GetPlayerInventory([FromSource] Player player)
        {
            //Get Player Identifier
            var Identifier = player.Identifiers["license"];

            //Request Cola
            MySqlDataReader Cola = Database.ExecuteSelectQuery($"SELECT Cola FROM inventory WHERE Identifier = '{Identifier}'");

            string GetColas = "";
            while (Cola.Read())
            {
                GetColas = Cola["Cola"].ToString();
            }

            //Close Connection
            Database.Connection.Close();

            //Request Water
            MySqlDataReader Water = Database.ExecuteSelectQuery($"SELECT Water FROM inventory WHERE Identifier = '{Identifier}'");

            string GetWater = "";
            while (Water.Read())
            {
                GetWater = Water["Water"].ToString();
            }

            //Close Connection
            Database.Connection.Close();

            //Request Bread
            MySqlDataReader Bread = Database.ExecuteSelectQuery($"SELECT Bread FROM inventory WHERE Identifier = '{Identifier}'");

            string GetBread = "";
            while (Bread.Read())
            {
                GetBread = Bread["Bread"].ToString();
            }

            //Close Connection
            Database.Connection.Close();

            //Trigger Event
            player.TriggerEvent("Freedom:PlayerInventory", GetColas, GetWater, GetBread);
        }

        [EventHandler("Freedom:GetPlayerInfo")]
        private void GetPlayerInfo([FromSource] Player player)
        {
            //Get Player Identifier
            var Identifier = player.Identifiers["license"];

            //Request Cash
            MySqlDataReader Result = Database.ExecuteSelectQuery($"SELECT Cash FROM users WHERE Identifier = '{Identifier}'");

            string GetPlayerCash = "";
            while (Result.Read())
            {
                GetPlayerCash = Result["Cash"].ToString();
            }

            //Close Connection
            Database.Connection.Close();

            //Request Bank
            MySqlDataReader Result2 = Database.ExecuteSelectQuery($"SELECT Bank FROM users WHERE Identifier = '{Identifier}'");

            string GetPlayerBank = "";
            while (Result2.Read())
            {
                GetPlayerBank = Result2["Bank"].ToString();
            }

            //Close Connection
            Database.Connection.Close();

            //Request Admin
            MySqlDataReader Result3 = Database.ExecuteSelectQuery($"SELECT Admin FROM users WHERE Identifier = '{Identifier}'");

            string GetPlayerAdmin = "";
            while (Result3.Read())
            {
                GetPlayerAdmin = Result3["Admin"].ToString();
            }

            //Close Connection
            Database.Connection.Close();

            //Request Job
            MySqlDataReader Result4 = Database.ExecuteSelectQuery($"SELECT Job FROM users WHERE Identifier = '{Identifier}'");

            string GetPlayerJob = "";
            while (Result4.Read())
            {
                GetPlayerJob = Result4["Job"].ToString();
            }

            //Close Connection
            Database.Connection.Close();

            //Request Salary
            MySqlDataReader Result5 = Database.ExecuteSelectQuery($"SELECT Salary FROM jobs WHERE Name = '{GetPlayerJob}'");

            string GetJobSalary = "";
            while (Result5.Read())
            {
                GetJobSalary = Result5["Salary"].ToString();
            }

            //Close Connection
            Database.Connection.Close();

            //Trigger Client Event
            player.TriggerEvent("Freedom:PlayerInfo", GetPlayerCash, GetPlayerBank, GetPlayerAdmin, GetPlayerJob, GetJobSalary);
        }

        [EventHandler("playerConnecting")]
        private async void OnPlayerConnecting([FromSource] Player player, string playerName, dynamic setKickReason, dynamic deferrals)
        {
            deferrals.defer();
            await Delay(0);

            var Identifier = player.Identifiers["license"];

            if (!string.IsNullOrEmpty(Identifier))
            {
                if (!GetPlayerExistDB(Identifier))
                {
                    Database.ExecuteInsertQuery($"INSERT INTO users (Identifier, Nickname, Name, Cash, Bank, Admin, Job) VALUES ('{Identifier}', '{playerName}', '{playerName}', 1000, 5000, 'false', 'Unemployed')");
                    Database.ExecuteInsertQuery($"INSERT INTO inventory (Identifier, Cola, Bread, Water) VALUE ('{Identifier}', 0, 0, 0)");
                }
            }

            deferrals.done();

            //Close Connection
            Database.Connection.Close();
        }

        private bool GetPlayerExistDB(string Identifier)
        {
            MySqlDataReader Result = Database.ExecuteSelectQuery($"SELECT ID FROM users WHERE Identifier = '{Identifier}'");

            bool GetPlayerExistDB = false;
            while (Result.Read())
            {
                GetPlayerExistDB = true;
            }
            Database.Connection.Close();

            return GetPlayerExistDB;
        }
    }
}
