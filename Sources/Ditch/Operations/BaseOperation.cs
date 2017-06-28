using Ditch.Helpers;
using Newtonsoft.Json;

namespace Ditch.Operations
{
    [JsonObject(MemberSerialization.OptIn)]
    internal abstract class BaseOperation
    {
        public abstract OperationType Type { get; }
        
        [SerializeHelper.IgnoreForMessage]
        public abstract string TypeName { get; }
    }
}