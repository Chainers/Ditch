using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SetalimitsAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "setalimits";

        public SetalimitsAction() : base(ContractName, ActionName) { }

        public SetalimitsAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, SetAccountLimits args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
