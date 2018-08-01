using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SetprivAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "setpriv";

        public SetprivAction() : base(ContractName, ActionName) { }

        public SetprivAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Setpriv args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
