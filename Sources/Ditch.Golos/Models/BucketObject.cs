using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// bucket_object
    /// plugins\market_history\include\golos\plugins\market_history\market_history_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BucketObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: open
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("open")]
        public DateTime Open {get; set;}

        /// <summary>
        /// API name: seconds
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("seconds")]
        public UInt32 Seconds {get; set;}

        /// <summary>
        /// API name: high_steem
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("high_steem")]
        public object HighSteem {get; set;}

        /// <summary>
        /// API name: high_sbd
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("high_sbd")]
        public object HighSbd {get; set;}

        /// <summary>
        /// API name: low_steem
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("low_steem")]
        public object LowSteem {get; set;}

        /// <summary>
        /// API name: low_sbd
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("low_sbd")]
        public object LowSbd {get; set;}

        /// <summary>
        /// API name: open_steem
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("open_steem")]
        public object OpenSteem {get; set;}

        /// <summary>
        /// API name: open_sbd
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("open_sbd")]
        public object OpenSbd {get; set;}

        /// <summary>
        /// API name: close_steem
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("close_steem")]
        public object CloseSteem {get; set;}

        /// <summary>
        /// API name: close_sbd
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("close_sbd")]
        public object CloseSbd {get; set;}

        /// <summary>
        /// API name: steem_volume
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("steem_volume")]
        public object SteemVolume {get; set;}

        /// <summary>
        /// API name: sbd_volume
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("sbd_volume")]
        public object SbdVolume {get; set;}
    }
}
