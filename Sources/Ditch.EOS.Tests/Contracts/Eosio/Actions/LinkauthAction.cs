using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class LinkauthAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "linkauth";

        public LinkauthAction() : base(ContractName, ActionName) { }

        public LinkauthAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Linkauth args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
