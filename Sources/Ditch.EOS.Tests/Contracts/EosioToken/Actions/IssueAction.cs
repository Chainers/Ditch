using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.EosioToken.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.EosioToken.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class IssueAction : BaseAction
    {
        public const string ContractName = "eosio.token";
        public const string ActionName = "issue";

        public IssueAction() : base(ContractName, ActionName) { }

        public IssueAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Issue args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
