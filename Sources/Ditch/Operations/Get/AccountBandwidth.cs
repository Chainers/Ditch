using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ditch.Operations.Get
{
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

    [JsonObject(MemberSerialization.OptIn)]
    public class AccountBandwidth
    {
        [JsonProperty("id")]
        public UInt64 Id { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public BandwidthType Type { get; set; }

        [JsonProperty("average_bandwidth")]
        public object AverageBandwidth { get; set; }

        [JsonProperty("lifetime_bandwidth")]
        public object LifetimeBandwidth { get; set; }

        [JsonProperty("last_bandwidth_update")]
        public string LastBandwidthUpdate { get; set; }
    }
}
