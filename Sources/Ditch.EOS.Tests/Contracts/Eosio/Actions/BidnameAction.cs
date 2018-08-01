using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BidnameAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "bidname";

        public BidnameAction() : base(ContractName, ActionName) { }

        public BidnameAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Bidname args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
