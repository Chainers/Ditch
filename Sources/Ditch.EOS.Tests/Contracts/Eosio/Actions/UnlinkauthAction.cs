using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UnlinkauthAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "unlinkauth";

        public UnlinkauthAction() : base(ContractName, ActionName) { }

        public UnlinkauthAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Unlinkauth args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
