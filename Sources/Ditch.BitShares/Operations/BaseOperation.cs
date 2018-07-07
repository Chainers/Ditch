using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.BitShares.Operations
{

    [JsonObject(MemberSerialization.OptIn)]
    public abstract class BaseOperation
    {
        [MessageOrder(10)]
        public abstract OperationType Type { get; }

        public abstract string TypeName { get; }

        [JsonProperty("prefix", NullValueHandling = NullValueHandling.Ignore)]
        public string Prefix { get; set; }
    }
}
