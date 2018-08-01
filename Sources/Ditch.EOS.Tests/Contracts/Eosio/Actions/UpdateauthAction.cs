using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UpdateauthAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "updateauth";

        public UpdateauthAction() : base(ContractName, ActionName) { }

        public UpdateauthAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Updateauth args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
