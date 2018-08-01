using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DelegatebwAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "delegatebw";

        public DelegatebwAction() : base(ContractName, ActionName) { }

        public DelegatebwAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Delegatebw args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
