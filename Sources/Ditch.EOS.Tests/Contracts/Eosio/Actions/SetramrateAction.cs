using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SetramrateAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "setramrate";

        public SetramrateAction() : base(ContractName, ActionName) { }

        public SetramrateAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Setramrate args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
