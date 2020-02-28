using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.EosioToken.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.EosioToken.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CreateAction : BaseAction
    {
        public const string ContractName = "eosio.token";
        public const string ActionName = "create";

        public CreateAction() : base(ContractName, ActionName) { }

        public CreateAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Create args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
