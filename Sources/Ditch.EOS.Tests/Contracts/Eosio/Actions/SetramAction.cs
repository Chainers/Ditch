using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SetramAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "setram";

        public SetramAction() : base(ContractName, ActionName) { }

        public SetramAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Setram args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
