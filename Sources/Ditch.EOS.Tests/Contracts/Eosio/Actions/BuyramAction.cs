using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BuyramAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "buyram";

        public BuyramAction() : base(ContractName, ActionName) { }

        public BuyramAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Buyram args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
