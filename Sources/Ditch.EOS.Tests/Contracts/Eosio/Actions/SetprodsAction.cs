using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SetprodsAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "setprods";

        public SetprodsAction() : base(ContractName, ActionName) { }

        public SetprodsAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, SetProducers args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
