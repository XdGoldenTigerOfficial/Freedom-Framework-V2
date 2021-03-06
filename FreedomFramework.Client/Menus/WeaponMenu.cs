using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using NativeUI;
using GTA.Native;

namespace client.Menus
{
    public class WeaponMenu : BaseScript 
    {
        public static MenuPool _weaponmenuPool;
        public static UIMenu weaponMenu;

        public void MeleeWeapons(UIMenu menu)
        {
            var melee = _weaponmenuPool.AddSubMenu(menu, "Melee Weapons");
            for (int i = 0; i < 1; i++) ;

            melee.MouseEdgeEnabled = false;
            melee.ControlDisablingEnabled = false;

            //Knife
            var knife = new UIMenuItem("Knife");
            knife.SetRightLabel("~g~$100");
            melee.AddItem(knife);
            melee.OnItemSelect += (sender, item, index) =>
            {
                if (item == knife)
                {
                    if (Utilities.Constructors.playerMoney >= 100) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 100);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.Knife, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Knife", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.Knife);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Hatchet
            var Hatchet = new UIMenuItem("Hatchet");
            Hatchet.SetRightLabel("~g~$75");
            melee.AddItem(Hatchet);
            melee.OnItemSelect += (sender, item, index) =>
            {
                if (item == Hatchet)
                {
                    if (Utilities.Constructors.playerMoney >= 75) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 75);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.Hatchet, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Hatchet", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.Hatchet);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };
        }

        public void HandgunWeapons(UIMenu menu)
        {
            var handguns = _weaponmenuPool.AddSubMenu(menu, "Handguns");
            for (int i = 0; i < 1; i++) ;

            handguns.MouseEdgeEnabled = false;
            handguns.ControlDisablingEnabled = false;

            //Pistol
            var Pistol = new UIMenuItem("Pistol");
            Pistol.SetRightLabel("~g~$350");
            handguns.AddItem(Pistol);
            handguns.OnItemSelect += (sender, item, index) =>
            {
                if (item == Pistol)
                {
                    if (Utilities.Constructors.playerMoney >= 350) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 350);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.Pistol, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Pistol", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.Pistol);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Heavy Pistol
            var HeavyPistol = new UIMenuItem("Heavy Pistol");
            HeavyPistol.SetRightLabel("~g~$550");
            handguns.AddItem(HeavyPistol);
            handguns.OnItemSelect += (sender, item, index) =>
            {
                if (item == HeavyPistol)
                {
                    if (Utilities.Constructors.playerMoney >= 550) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 550);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.HeavyPistol, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Heavy Pistol", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.HeavyPistol);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //AP Pistol
            var APPistol = new UIMenuItem("AP Pistol");
            APPistol.SetRightLabel("~g~$1,000");
            handguns.AddItem(APPistol);
            handguns.OnItemSelect += (sender, item, index) =>
            {
                if (item == APPistol)
                {
                    if (Utilities.Constructors.playerMoney >= 1000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.APPistol, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "AP Pistol", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.APPistol);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };
        }

        public void ShotgunWeapons(UIMenu menu)
        {
            var shotguns = _weaponmenuPool.AddSubMenu(menu, "Shotguns");
            for (int i = 0; i < 1; i++) ;

            shotguns.MouseEdgeEnabled = false;
            shotguns.ControlDisablingEnabled = false;

            //Pump Action
            var pump = new UIMenuItem("Pump Action");
            pump.SetRightLabel("~g~$750");
            shotguns.AddItem(pump);
            shotguns.OnItemSelect += (sender, item, index) =>
            {
                if (item == pump)
                {
                    if (Utilities.Constructors.playerMoney >= 750) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 750);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.PumpShotgun, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Pump Shotgun", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.PumpShotgun);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Assault Shotgun
            var assault = new UIMenuItem("Assault Shotgun");
            assault.SetRightLabel("~g~$1,000");
            shotguns.AddItem(assault);
            shotguns.OnItemSelect += (sender, item, index) =>
            {
                if (item == assault)
                {
                    if (Utilities.Constructors.playerMoney >= 1000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.AssaultShotgun, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Assault Shotgun", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.AssaultShotgun);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Bullpup Shotgun
            var Bullpup = new UIMenuItem("Bullpup Shotgun");
            Bullpup.SetRightLabel("~g~$650");
            shotguns.AddItem(Bullpup);
            shotguns.OnItemSelect += (sender, item, index) =>
            {
                if (item == Bullpup)
                {
                    if (Utilities.Constructors.playerMoney >= 650) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 650);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.BullpupShotgun, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Bullpup Shotgun", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.BullpupShotgun);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Heavy Shotgun
            var Heavy = new UIMenuItem("Heavy Shotgun");
            Heavy.SetRightLabel("~g~$850");
            shotguns.AddItem(Heavy);
            shotguns.OnItemSelect += (sender, item, index) =>
            {
                if (item == Heavy)
                {
                    if (Utilities.Constructors.playerMoney >= 850) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 850);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.HeavyShotgun, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Heavy Shotgun", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.HeavyShotgun);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };
        }

        public void MachinegunWeapons(UIMenu menu)
        {
            var machineguns = _weaponmenuPool.AddSubMenu(menu, "Machine Guns");
            for (int i = 0; i < 1; i++) ;

            machineguns.MouseEdgeEnabled = false;
            machineguns.ControlDisablingEnabled = false;

            //Micro
            var Micro = new UIMenuItem("Micro SMG");
            Micro.SetRightLabel("~g~$750");
            machineguns.AddItem(Micro);
            machineguns.OnItemSelect += (sender, item, index) =>
            {
                if (item == Micro)
                {
                    if (Utilities.Constructors.playerMoney >= 750) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 750);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.MicroSMG, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Micro SMG", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.MicroSMG);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //SMG
            var SMG = new UIMenuItem("SMG");
            SMG.SetRightLabel("~g~$550");
            machineguns.AddItem(SMG);
            machineguns.OnItemSelect += (sender, item, index) =>
            {
                if (item == SMG)
                {
                    if (Utilities.Constructors.playerMoney >= 550) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 550);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.SMG, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "SMG", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.SMG);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //ASSULT SMG
            var ASSULT = new UIMenuItem("Assault SMG");
            ASSULT.SetRightLabel("~g~$950");
            machineguns.AddItem(ASSULT);
            machineguns.OnItemSelect += (sender, item, index) =>
            {
                if (item == ASSULT)
                {
                    if (Utilities.Constructors.playerMoney >= 950) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 950);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.AssaultSMG, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Assault SMG", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.AssaultSMG);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //MG
            var MG = new UIMenuItem("MG");
            MG.SetRightLabel("~g~$1,250");
            machineguns.AddItem(MG);
            machineguns.OnItemSelect += (sender, item, index) =>
            {
                if (item == MG)
                {
                    if (Utilities.Constructors.playerMoney >= 1250) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1250);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.MG, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "MG", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.MG);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Combat MG
            var CombatMG = new UIMenuItem("Combat SMG");
            CombatMG.SetRightLabel("~g~$1,250");
            machineguns.AddItem(CombatMG);
            machineguns.OnItemSelect += (sender, item, index) =>
            {
                if (item == CombatMG)
                {
                    if (Utilities.Constructors.playerMoney >= 1250) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1250);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.CombatMG, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Combat MG", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.CombatMG);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Combat PDW
            var PDW = new UIMenuItem("Combat PDW");
            PDW.SetRightLabel("~g~$2,000");
            machineguns.AddItem(PDW);
            machineguns.OnItemSelect += (sender, item, index) =>
            {
                if (item == PDW)
                {
                    if (Utilities.Constructors.playerMoney >= 2000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 2000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.CombatPDW, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Combat PDW", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.CombatPDW);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };
        }

        public void RifleWeapons(UIMenu menu)
        {
            var rifles = _weaponmenuPool.AddSubMenu(menu, "Rifles");
            for (int i = 0; i < 1; i++) ;

            rifles.MouseEdgeEnabled = false;
            rifles.ControlDisablingEnabled = false;

            //Assault Rifle
            var Assault = new UIMenuItem("Assault Rifle");
            Assault.SetRightLabel("~g~$750");
            rifles.AddItem(Assault);
            rifles.OnItemSelect += (sender, item, index) =>
            {
                if (item == Assault)
                {
                    if (Utilities.Constructors.playerMoney >= 750) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 750);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.AssaultRifle, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Assault Rifle", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.AssaultRifle);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Carbine Rifle
            var Carbine = new UIMenuItem("Carbine Rifle");
            Carbine.SetRightLabel("~g~$750");
            rifles.AddItem(Carbine);
            rifles.OnItemSelect += (sender, item, index) =>
            {
                if (item == Carbine)
                {
                    if (Utilities.Constructors.playerMoney >= 750) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 750);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.CarbineRifle, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Carbine Rifle", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.CarbineRifle);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Advanced Rifle
            var Advanced = new UIMenuItem("Advanced Rifle");
            Advanced.SetRightLabel("~g~$750");
            rifles.AddItem(Advanced);
            rifles.OnItemSelect += (sender, item, index) =>
            {
                if (item == Advanced)
                {
                    if (Utilities.Constructors.playerMoney >= 750) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 750);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.AdvancedRifle, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Advanced Rifle", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.AdvancedRifle);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Special Carbine
            var Special = new UIMenuItem("Special Carbine");
            Special.SetRightLabel("~g~$750");
            rifles.AddItem(Special);
            rifles.OnItemSelect += (sender, item, index) =>
            {
                if (item == Special)
                {
                    if (Utilities.Constructors.playerMoney >= 750) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 750);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.SpecialCarbine, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Special Carbine", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.SpecialCarbine);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Bullpup
            var Bullpup = new UIMenuItem("Bullpup Rifle");
            Bullpup.SetRightLabel("~g~$750");
            rifles.AddItem(Bullpup);
            rifles.OnItemSelect += (sender, item, index) =>
            {
                if (item == Bullpup)
                {
                    if (Utilities.Constructors.playerMoney >= 750) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 750);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.BullpupRifle, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Bullpup Rifle", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.BullpupRifle);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };
        }

        public void SniperWeapons(UIMenu menu)
        {
            var snipers = _weaponmenuPool.AddSubMenu(menu, "Sniper Rifles");
            for (int i = 0; i < 1; i++) ;

            snipers.MouseEdgeEnabled = false;
            snipers.ControlDisablingEnabled = false;

            //Sniper Rifle
            var Sniper = new UIMenuItem("Sniper Rifle");
            Sniper.SetRightLabel("~g~$1,000");
            snipers.AddItem(Sniper);
            snipers.OnItemSelect += (sender, item, index) =>
            {
                if (item == Sniper)
                {
                    if (Utilities.Constructors.playerMoney >= 1000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.SniperRifle, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Sniper Rifle", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.SniperRifle);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Heavy Sniper
            var Heavy = new UIMenuItem("Heavy Sniper");
            Heavy.SetRightLabel("~g~$1,000");
            snipers.AddItem(Heavy);
            snipers.OnItemSelect += (sender, item, index) =>
            {
                if (item == Heavy)
                {
                    if (Utilities.Constructors.playerMoney >= 1000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.HeavySniper, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Heavy Sniper", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.HeavySniper);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Marksman Rifle
            var Marksman = new UIMenuItem("Marksman Rifle");
            Marksman.SetRightLabel("~g~$1,000");
            snipers.AddItem(Marksman);
            snipers.OnItemSelect += (sender, item, index) =>
            {
                if (item == Marksman)
                {
                    if (Utilities.Constructors.playerMoney >= 1000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.MarksmanRifle, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Marksman Rifle", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.MarksmanRifle);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };
        }

        public void HeavyWeapons(UIMenu menu)
        {
            var heavy = _weaponmenuPool.AddSubMenu(menu, "Heavy Weapons");
            for (int i = 0; i < 1; i++) ;

            heavy.MouseEdgeEnabled = false;
            heavy.ControlDisablingEnabled = false;

            //Grenade Launcher
            var Launcher = new UIMenuItem("Grenade Launcher");
            Launcher.SetRightLabel("~g~$5,000");
            heavy.AddItem(Launcher);
            heavy.OnItemSelect += (sender, item, index) =>
            {
                if (item == Launcher)
                {
                    if (Utilities.Constructors.playerMoney >= 5000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 5000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.GrenadeLauncher, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Grenade Launcher", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.GrenadeLauncher);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //RPG
            var RPG = new UIMenuItem("RPG");
            RPG.SetRightLabel("~g~$5,000");
            heavy.AddItem(RPG);
            heavy.OnItemSelect += (sender, item, index) =>
            {
                if (item == RPG)
                {
                    if (Utilities.Constructors.playerMoney >= 5000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 5000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.RPG, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "RPG", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.RPG);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Minigun
            var Minigun = new UIMenuItem("RPG");
            Minigun.SetRightLabel("~g~$5,000");
            heavy.AddItem(Minigun);
            heavy.OnItemSelect += (sender, item, index) =>
            {
                if (item == Minigun)
                {
                    if (Utilities.Constructors.playerMoney >= 5000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 5000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.Minigun, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Minigun", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.Minigun);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Railgun
            var Railgun = new UIMenuItem("Railgun");
            Railgun.SetRightLabel("~g~$5,000");
            heavy.AddItem(Railgun);
            heavy.OnItemSelect += (sender, item, index) =>
            {
                if (item == Railgun)
                {
                    if (Utilities.Constructors.playerMoney >= 5000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 5000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.Railgun, 999, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Railgun", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.Railgun);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };
        }

        public void ExplosiveWeapons(UIMenu menu)
        {
            var explosives = _weaponmenuPool.AddSubMenu(menu, "Explosives");
            for (int i = 0; i < 1; i++) ;

            explosives.MouseEdgeEnabled = false;
            explosives.ControlDisablingEnabled = false;

            //Grenade
            var Grenade = new UIMenuItem("Grenade");
            Grenade.SetRightLabel("~g~$1,000");
            explosives.AddItem(Grenade);
            explosives.OnItemSelect += (sender, item, index) =>
            {
                if (item == Grenade)
                {
                    if (Utilities.Constructors.playerMoney >= 1000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.Grenade, 25, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Grenade", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.Grenade);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Sticky Bomb
            var Sticky = new UIMenuItem("Sticky Bomb");
            Sticky.SetRightLabel("~g~$1,000");
            explosives.AddItem(Sticky);
            explosives.OnItemSelect += (sender, item, index) =>
            {
                if (item == Sticky)
                {
                    if (Utilities.Constructors.playerMoney >= 1000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.StickyBomb, 25, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Sticky Bomb", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.StickyBomb);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Tear Gas
            var Tear = new UIMenuItem("Tear Gas");
            Tear.SetRightLabel("~g~$1,000");
            explosives.AddItem(Tear);
            explosives.OnItemSelect += (sender, item, index) =>
            {
                if (item == Tear)
                {
                    if (Utilities.Constructors.playerMoney >= 1000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.BZGas, 25, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Tear Gas", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.BZGas);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };

            //Proximity Mines
            var Proximity = new UIMenuItem("Proximity Mines");
            Proximity.SetRightLabel("~g~$1,000");
            explosives.AddItem(Proximity);
            explosives.OnItemSelect += (sender, item, index) =>
            {
                if (item == Proximity)
                {
                    if (Utilities.Constructors.playerMoney >= 1000) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1000);

                        //Give Player Knife
                        CitizenFX.Core.Game.Player.Character.Weapons.Give(CitizenFX.Core.WeaponHash.ProximityMine, 25, false, true);

                        //Show Notification
                        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("Weapon Purchased", "Proximity Mine", (GTA.Native.WeaponHash)CitizenFX.Core.WeaponHash.ProximityMine);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };
        }

          static void BodyArmor(UIMenu menu)
          {
            var armorsub = _weaponmenuPool.AddSubMenu(menu, "Body Armor");
            for (int i = 0; i < 1; i++) ;

            armorsub.MouseEdgeEnabled = false;
            armorsub.ControlDisablingEnabled = false;

            //Body Armor
            var Armor = new UIMenuItem("Body Armor");
            Armor.SetRightLabel("~g~$250");
            armorsub.AddItem(Armor);
            armorsub.OnItemSelect += (sender, item, index) =>
            {
                if (item == Armor)
                {
                    if (Utilities.Constructors.playerMoney >= 250) //Check to ensure player has enough money
                    {
                        //Take Money Away
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 250);

                        // Not working!
                        //CitizenFX.Core.Player.Character.Armor += 100;
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }
                }
            };
          }

        public WeaponMenu()
        {
            _weaponmenuPool = new MenuPool();
            weaponMenu = new UIMenu("Weapon Menu", "~p~Freedom Framework V2");
            _weaponmenuPool.Add(weaponMenu);

            MeleeWeapons(weaponMenu);
            HandgunWeapons(weaponMenu);
            ShotgunWeapons(weaponMenu);
            MachinegunWeapons(weaponMenu);
            RifleWeapons(weaponMenu);
            SniperWeapons(weaponMenu);
            HeavyWeapons(weaponMenu);
            ExplosiveWeapons(weaponMenu);
            BodyArmor(weaponMenu);

            _weaponmenuPool.MouseEdgeEnabled = false;
            _weaponmenuPool.ControlDisablingEnabled = false;
            _weaponmenuPool.RefreshIndex();

            Tick += async () =>
            {
                _weaponmenuPool.ProcessMenus();
            };
        }
    }
}
