using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client.CEO
{
    public class CEOClient : BaseScript
    {
        public static bool CanRegisterCEO = false;
        public CEOClient()
        {
            API.RegisterCommand("organization", new Action<int, List<object>, string>((src, args, raw) =>
            {
                var argList = args.Select(o => o.ToString()).ToList();

                if (argList.Any())
                {
                    string displayString = string.Join(" ", argList.ToArray());

                    TriggerServerEvent("Freedom:CreateOrganization", displayString);
                }
            }), false);
        }
    }
}
