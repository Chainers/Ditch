using System;
using Ditch.Steem.Operations.Enums;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations.Get
{
    /// <summary>
    /// account_bandwidth_object
    /// steem-0.19.1\libraries\plugins\witness\include\steemit\witness\witness_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AccountBandwidthObject
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
