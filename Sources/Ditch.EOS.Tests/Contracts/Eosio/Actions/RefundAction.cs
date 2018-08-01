using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RefundAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "refund";

        public RefundAction() : base(ContractName, ActionName) { }

        public RefundAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Refund args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
