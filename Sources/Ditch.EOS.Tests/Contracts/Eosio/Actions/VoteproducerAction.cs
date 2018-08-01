using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class VoteproducerAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "voteproducer";

        public VoteproducerAction() : base(ContractName, ActionName) { }

        public VoteproducerAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Voteproducer args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
