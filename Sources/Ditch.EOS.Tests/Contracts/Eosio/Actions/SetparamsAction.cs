using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SetparamsAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "setparams";

        public SetparamsAction() : base(ContractName, ActionName) { }

        public SetparamsAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Setparams args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
