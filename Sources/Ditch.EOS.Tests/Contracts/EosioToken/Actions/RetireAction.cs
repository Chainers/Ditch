using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.EosioToken.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.EosioToken.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RetireAction : BaseAction
    {
        public const string ContractName = "eosio.token";
        public const string ActionName = "retire";

        public RetireAction() : base(ContractName, ActionName) { }

        public RetireAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Retire args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
