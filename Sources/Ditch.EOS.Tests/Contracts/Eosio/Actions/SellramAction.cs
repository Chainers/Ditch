using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SellramAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "sellram";

        public SellramAction() : base(ContractName, ActionName) { }

        public SellramAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Sellram args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
