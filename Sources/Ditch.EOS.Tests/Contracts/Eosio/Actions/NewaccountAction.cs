using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class NewaccountAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "newaccount";

        public NewaccountAction() : base(ContractName, ActionName) { }

        public NewaccountAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Newaccount args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
