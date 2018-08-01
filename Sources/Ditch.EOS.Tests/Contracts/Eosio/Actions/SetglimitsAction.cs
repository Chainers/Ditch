using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SetglimitsAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "setglimits";

        public SetglimitsAction() : base(ContractName, ActionName) { }

        public SetglimitsAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, SetGlobalLimits args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
