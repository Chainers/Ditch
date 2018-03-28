using Ditch.Steem.Helpers;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Operations
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
