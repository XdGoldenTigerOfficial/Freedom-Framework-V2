using System;
using System.Collections.Generic;
using System.Linq;
using MySqlConnector;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace server.CEO
{
    public class CEOMain : BaseScript
    {
        public CEOMain()
        {

        }

        [EventHandler("Freedom:CreateOrganization")]
        private void CreateOrganization([FromSource] Player player, string displayString)
        {
            var Identifier = player.Identifiers["license"];
            string playername = player.Name;

            Database.ExecuteQuery($"INSERT INTO ff_ceo (Identifier, IsCEO, OrganizationName) VALUE ('{Identifier}', 'true', '{displayString}')");

            TriggerClientEvent("Freedom:OrganizationCreated", displayString, playername);
        }
    }
}
