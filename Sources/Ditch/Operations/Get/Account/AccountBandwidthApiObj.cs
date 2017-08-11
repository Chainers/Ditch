using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ditch.Operations.Get
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


    /// <summary>
    /// account_bandwidth_object
    /// golos-0.16.3\libraries\chain\include\steemit\chain\account_object.hpp
    /// steem-0.19.1\libraries\plugins\witness\include\steemit\witness\witness_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AccountBandwidthApiObj
    {

        // bdType : id_type
        [JsonProperty("id")]
        public object Id { get; set; }

        // bdType : account_name_type
        [JsonProperty("account")]
        public string Account { get; set; }

        // bdType : bandwidth_type
        [JsonProperty("type")]
        public BandwidthType Type { get; set; }

        // bdType : share_type
        [JsonProperty("average_bandwidth")]
        public object AverageBandwidth { get; set; }

        // bdType : share_type
        [JsonProperty("lifetime_bandwidth")]
        public object LifetimeBandwidth { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_bandwidth_update")]
        public DateTime LastBandwidthUpdate { get; set; }
    }
}
