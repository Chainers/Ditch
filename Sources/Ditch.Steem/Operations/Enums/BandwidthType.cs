using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ditch.Steem.Operations.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BandwidthType
    {
        /// <summary>
        /// Rate limiting posting reward eligibility over time
        /// </summary>
        [JsonProperty("post")]
        Post,

        /// <summary>
        /// Rate limiting for all forum related actins
        /// </summary>
        [JsonProperty("forum")]
        Forum,

        /// <summary>
        /// Rate limiting for all other actions
        /// </summary>
        [JsonProperty("market")]
        Market
    }
}