using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.EosioToken.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.EosioToken.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CloseAction : BaseAction
    {
        public const string ContractName = "eosio.token";
        public const string ActionName = "close";

        public CloseAction() : base(ContractName, ActionName) { }

        public CloseAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Close args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
