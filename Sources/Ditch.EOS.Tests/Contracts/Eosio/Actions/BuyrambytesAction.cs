using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BuyrambytesAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "buyrambytes";

        public BuyrambytesAction() : base(ContractName, ActionName) { }

        public BuyrambytesAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Buyrambytes args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
