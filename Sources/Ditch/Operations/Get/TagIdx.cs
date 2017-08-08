using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TagIdx
    {
        // pending payouts
        [JsonProperty("trending")]
        public string[] Trending { get; set; }
    }
}