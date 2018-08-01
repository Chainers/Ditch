using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UnregprodAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "unregprod";

        public UnregprodAction() : base(ContractName, ActionName) { }

        public UnregprodAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Unregprod args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
