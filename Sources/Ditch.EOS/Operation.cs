using Ditch.EOS.Models;
using Newtonsoft.Json;

namespace Ditch.EOS
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Operation : Action
    {
        public string ContractName { get; set; }

        public object Args { get; set; }


        public Operation() { }

        public Operation(string contractName, AccountName accountName, ActionName actionName, PermissionLevel[] permissionLevels, object args)
            : base(accountName, actionName, permissionLevels)
        {
            ContractName = contractName;
            Args = args;
        }

        public Operation(string contractName, AccountName accountName, ActionName actionName, PermissionLevel[] permissionLevels, Bytes data)
            : base(accountName, actionName, permissionLevels, data)
        {
            ContractName = contractName;
        }
    }
}