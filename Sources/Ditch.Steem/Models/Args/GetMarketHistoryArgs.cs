using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// get_market_history_args
    /// libraries\plugins\apis\market_history_api\include\steem\plugins\market_history_api\market_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetMarketHistoryArgs
    {

        /// <summary>
        /// API name: bucket_seconds
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("bucket_seconds")]
        public UInt32 BucketSeconds {get; set;}

        /// <summary>
        /// API name: start
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("start")]
        public DateTime Start {get; set;}

        /// <summary>
        /// API name: end
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("end")]
        public DateTime End {get; set;}
    }
}
