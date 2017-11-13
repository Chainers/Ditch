using Ditch.Steem.Helpers;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations.Post
{
    /// <summary>
    /// base_operation
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class BaseOperation
    {
        [SerializeHelper.MessageOrder(10)]
        public abstract OperationType Type { get; }

        public abstract string TypeName { get; }
    }
}
