using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SetcodeAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "setcode";

        public SetcodeAction() : base(ContractName, ActionName) { }

        public SetcodeAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Setcode args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
