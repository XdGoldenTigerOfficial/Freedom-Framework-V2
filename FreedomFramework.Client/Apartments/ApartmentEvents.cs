using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client.Apartments
{
    public class ApartmentEvents : BaseScript
    {
        public ApartmentEvents()
        {
            
        }

        [EventHandler("Freedom:EnterHouseComplete")]
        private static void EnteredHouse(int playerID)
        {
            
        }

        [EventHandler("Freedom:ExitHouseComplete")]
        private static void ExitedHouse(int playerID)
        {
            
        }
    }
}
