using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class OnerrorAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "onerror";

        public OnerrorAction() : base(ContractName, ActionName) { }

        public OnerrorAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Onerror args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
