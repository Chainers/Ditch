using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ClaimrewardsAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "claimrewards";

        public ClaimrewardsAction() : base(ContractName, ActionName) { }

        public ClaimrewardsAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Claimrewards args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
