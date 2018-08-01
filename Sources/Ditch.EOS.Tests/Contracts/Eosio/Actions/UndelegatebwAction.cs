using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Actions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UndelegatebwAction : BaseAction
    {
        public const string ContractName = "eosio";
        public const string ActionName = "undelegatebw";

        public UndelegatebwAction() : base(ContractName, ActionName) { }

        public UndelegatebwAction(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, Undelegatebw args)
            : base(ContractName, accountName, ActionName, permissionLevels, args) { }
    }
}
