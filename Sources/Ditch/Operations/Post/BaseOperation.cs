using Ditch.Helpers;
using Newtonsoft.Json;

namespace Ditch.Operations.Post
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class BaseOperation
    {
        [SerializeHelper.MessageOrder(10)]
        public abstract OperationType Type { get; }
        
        public abstract string TypeName { get; }
    }
}