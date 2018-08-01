using Ditch.EOS.Models;
using Newtonsoft.Json;

namespace Ditch.EOS
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BaseAction : Action
    {
        public string ContractName { get; set; }

        public object Args { get; set; }


        public BaseAction() { }

        public BaseAction(string contractName, ActionName actionName)
            : base(actionName)
        {
            ContractName = contractName;
        }

        public BaseAction(string contractName, AccountName accountName, ActionName actionName, PermissionLevel[] permissionLevels, object args)
            : base(accountName, actionName, permissionLevels)
        {
            ContractName = contractName;
            Args = args;
        }

        public BaseAction(string contractName, AccountName accountName, ActionName actionName, PermissionLevel[] permissionLevels, Bytes data)
            : base(accountName, actionName, permissionLevels, data)
        {
            ContractName = contractName;
        }
    }
}