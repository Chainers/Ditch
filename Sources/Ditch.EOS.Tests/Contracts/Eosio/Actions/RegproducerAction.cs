using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RegproducerAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "regproducer";

        public RegproducerAction() : base(ContractName, ActionName) { }

        public RegproducerAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Regproducer args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
