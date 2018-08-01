using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ReqauthAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "reqauth";

        public ReqauthAction() : base(ContractName, ActionName) { }

        public ReqauthAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, RequireAuth args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
