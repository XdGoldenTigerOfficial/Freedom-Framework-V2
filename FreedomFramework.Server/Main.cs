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
            var Identifier = player.Identifiers["license"];

            string playername = player.Name;

            Player recipient = TicketRecipient;

            var RecipientIdentifier = recipient.Identifiers["license"];

            string recipientname = recipient.Name;

            if (Identifier == RecipientIdentifier)
            {
                player.TriggerEvent("Freedom:CannotTicketYourself");
            }
            else
            {
                player.TriggerEvent("Freedom:TicketIssued", recipientname, fine);

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
            var Identifier = player.Identifiers["license"];

            string playername = player.Name;

            Player recipient = recipientid;

            var RecipientIdentifier = recipient.Identifiers["license"];

            string recipientname = recipient.Name;

            if (Identifier == RecipientIdentifier)
            {
                player.TriggerEvent("Freedom:CannotPayYourself");
            }
            else
            {
                player.TriggerEvent("Freedom:PaymentSent", recipientname, amount);

                recipient.TriggerEvent("Freedom:PaymentRecieved", playername, amount);
            }
        }

        [EventHandler("Freedom:SendPlayerJobUpdate")]
        private void UpdatePlayerJob([FromSource] Player player, string job)
        {
            var Identifier = player.Identifiers["license"];

            Database.ExecuteQuery($"UPDATE ff_users SET Job = '{job}' WHERE Identifier = '{Identifier}'");

            MySqlDataReader Result5 = Database.SelectQuery($"SELECT Salary FROM ff_jobs WHERE Name = '{job}'");

            string GetJobSalary = "";

            while (Result5.Read())
            {
                GetJobSalary = Result5["Salary"].ToString();
            }

            Database.Connection.Close();

            player.TriggerEvent("Freedom:UpdatePlayerJob", GetJobSalary);
        }

        [EventHandler("Freedom:SavePlayerData")]
        private void SavePlayerData([FromSource] Player player, string cash, string bank, string job, string colas, string water, string bread)
        {
            var Identifier = player.Identifiers["license"];

            Database.ExecuteQuery($"UPDATE ff_users SET Cash = '{cash}' WHERE Identifier = '{Identifier}'");
            Database.ExecuteQuery($"UPDATE ff_users SET Bank = '{bank}' WHERE Identifier = '{Identifier}'");
            Database.ExecuteQuery($"UPDATE ff_users SET Job = '{job}' WHERE Identifier = '{Identifier}'");

            Database.ExecuteQuery($"UPDATE ff_inventory SET Cola = {colas} WHERE Identifier = '{Identifier}'");
            Database.ExecuteQuery($"UPDATE ff_inventory SET Water = {water} WHERE Identifier = '{Identifier}'");
            Database.ExecuteQuery($"UPDATE ff_inventory SET Bread = {bread} WHERE Identifier = '{Identifier}'");

            Database.Connection.Close();
        }

        [EventHandler("Freedom:GetPlayerInventory")]
        private void GetPlayerInventory([FromSource] Player player)
        {
            var Identifier = player.Identifiers["license"];

            MySqlDataReader Cola = Database.SelectQuery($"SELECT Cola FROM ff_inventory WHERE Identifier = '{Identifier}'");

            string GetColas = "";

            while (Cola.Read())
            {
                GetColas = Cola["Cola"].ToString();
            }

            Database.Connection.Close();

            MySqlDataReader Water = Database.SelectQuery($"SELECT Water FROM ff_inventory WHERE Identifier = '{Identifier}'");

            string GetWater = "";

            while (Water.Read())
            {
                GetWater = Water["Water"].ToString();
            }

            Database.Connection.Close();

            MySqlDataReader Bread = Database.SelectQuery($"SELECT Bread FROM ff_inventory WHERE Identifier = '{Identifier}'");

            string GetBread = "";

            while (Bread.Read())
            {
                GetBread = Bread["Bread"].ToString();
            }

            Database.Connection.Close();

            player.TriggerEvent("Freedom:PlayerInventory", GetColas, GetWater, GetBread);
        }

        [EventHandler("Freedom:GetPlayerInfo")]
        private void GetPlayerInfo([FromSource] Player player)
        {
            var Identifier = player.Identifiers["license"];

            MySqlDataReader Result = Database.SelectQuery($"SELECT Cash FROM ff_users WHERE Identifier = '{Identifier}'");

            string GetPlayerCash = "";

            while (Result.Read())
            {
                GetPlayerCash = Result["Cash"].ToString();
            }

            Database.Connection.Close();

            MySqlDataReader Result2 = Database.SelectQuery($"SELECT Bank FROM ff_users WHERE Identifier = '{Identifier}'");

            string GetPlayerBank = "";

            while (Result2.Read())
            {
                GetPlayerBank = Result2["Bank"].ToString();
            }

            Database.Connection.Close();

            MySqlDataReader Result3 = Database.SelectQuery($"SELECT Admin FROM ff_users WHERE Identifier = '{Identifier}'");

            string GetPlayerAdmin = "";

            while (Result3.Read())
            {
                GetPlayerAdmin = Result3["Admin"].ToString();
            }

            Database.Connection.Close();

            MySqlDataReader Result4 = Database.SelectQuery($"SELECT Job FROM ff_users WHERE Identifier = '{Identifier}'");

            string GetPlayerJob = "";

            while (Result4.Read())
            {
                GetPlayerJob = Result4["Job"].ToString();
            }

            Database.Connection.Close();

            MySqlDataReader Result5 = Database.SelectQuery($"SELECT Salary FROM ff_jobs WHERE Name = '{GetPlayerJob}'");

            string GetJobSalary = "";

            while (Result5.Read())
            {
                GetJobSalary = Result5["Salary"].ToString();
            }

            Database.Connection.Close();

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
                    Database.ExecuteQuery($"INSERT INTO ff_users (Identifier, Nickname, Name, Cash, Bank, Admin, Job) VALUES ('{Identifier}', '{playerName}', '{playerName}', 1000, 5000, 'false', 'Unemployed')");
                    Database.ExecuteQuery($"INSERT INTO ff_inventory (Identifier, Cola, Bread, Water) VALUE ('{Identifier}', 0, 0, 0)");
                }
            }

            deferrals.done();

            Database.Connection.Close();
        }

        private bool GetPlayerExistDB(string Identifier)
        {
            MySqlDataReader Result = Database.SelectQuery($"SELECT ID FROM ff_users WHERE Identifier = '{Identifier}'");

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
