using Newtonsoft.Json;

namespace Ditch
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class BaseOperation
    {
        public abstract OperationType Type { get; }
        
        [SerializeHelper.IgnoreForMessage]
        public abstract string TypeName { get; }
    }
}