using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FeedHistory
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("current_median_history")]
        public Price CurrentMedianHistory { get; set; }

        [JsonProperty("price_history")]
        public Price[] PriceHistory { get; set; }
    }
}
