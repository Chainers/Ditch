using Ditch.Golos.Helpers;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations.Post
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
