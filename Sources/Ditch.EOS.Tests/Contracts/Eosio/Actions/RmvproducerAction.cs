using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RmvproducerAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "rmvproducer";

        public RmvproducerAction() : base(ContractName, ActionName) { }

        public RmvproducerAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Rmvproducer args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
