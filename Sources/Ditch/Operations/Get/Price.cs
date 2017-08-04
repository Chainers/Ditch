using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Price
    {
        [JsonProperty("base")]
        public Money Base { get; set; }

        [JsonProperty("quote")]
        public Money Quote { get; set; }
    }
}