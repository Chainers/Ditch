using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_trade_history_args
    /// libraries\plugins\apis\market_history_api\include\steem\plugins\market_history_api\market_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetTradeHistoryArgs
    {

        /// <summary>
        /// API name: start
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("start")]
        public TimePointSec Start {get; set;}

        /// <summary>
        /// API name: end
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("end")]
        public TimePointSec End {get; set;}

        /// <summary>
        /// API name: limit
        /// = 1000;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public uint Limit {get; set;}
    }
}
