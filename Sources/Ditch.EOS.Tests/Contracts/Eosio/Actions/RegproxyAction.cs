using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RegproxyAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "regproxy";

        public RegproxyAction() : base(ContractName, ActionName) { }

        public RegproxyAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Regproxy args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
