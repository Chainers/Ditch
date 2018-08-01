using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CanceldelayAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "canceldelay";

        public CanceldelayAction() : base(ContractName, ActionName) { }

        public CanceldelayAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Canceldelay args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
