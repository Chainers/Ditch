using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// account_bandwidth_object
    /// libraries\plugins\witness\include\steem\plugins\witness\witness_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AccountBandwidthObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account")]
        public string Account {get; set;}

        /// <summary>
        /// API name: type
        /// 
        /// </summary>
        /// <returns>API type: bandwidth_type</returns>
        [JsonProperty("type")]
        public BandwidthType Type {get; set;}

        /// <summary>
        /// API name: average_bandwidth
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("average_bandwidth")]
        public object AverageBandwidth {get; set;}

        /// <summary>
        /// API name: lifetime_bandwidth
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("lifetime_bandwidth")]
        public object LifetimeBandwidth {get; set;}

        /// <summary>
        /// API name: last_bandwidth_update
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_bandwidth_update")]
        public TimePointSec LastBandwidthUpdate {get; set;}
    }
}
