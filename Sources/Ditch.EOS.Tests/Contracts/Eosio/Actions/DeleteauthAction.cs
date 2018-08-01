using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DeleteauthAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "deleteauth";

        public DeleteauthAction() : base(ContractName, ActionName) { }

        public DeleteauthAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Deleteauth args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
