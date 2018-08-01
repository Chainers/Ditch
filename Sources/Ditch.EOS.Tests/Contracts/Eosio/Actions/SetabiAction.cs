using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SetabiAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "setabi";

        public SetabiAction() : base(ContractName, ActionName) { }

        public SetabiAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Setabi args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
