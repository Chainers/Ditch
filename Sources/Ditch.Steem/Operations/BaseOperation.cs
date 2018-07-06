using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    /// <summary>
    /// base_operation
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class BaseOperation
    {
        [MessageOrder(10)]
        public abstract OperationType Type { get; }

        public abstract string TypeName { get; }
    }
}
