using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// order_extended
    /// plugins\market_history\include\golos\plugins\market_history\market_history_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class OrderExtended
    {

        /// <summary>
        /// API name: order_price
        /// 
        /// </summary>
        /// <returns>API type: price</returns>
        [JsonProperty("order_price")]
        public Price OrderPrice { get; set; }

        /// <summary>
        /// API name: real_price
        /// dollars per steem
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("real_price")]
        public double RealPrice { get; set; }

        /// <summary>
        /// API name: steem
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("steem")]
        public object Steem { get; set; }

        /// <summary>
        /// API name: sbd
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("sbd")]
        public object Sbd { get; set; }

        /// <summary>
        /// API name: created
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("created")]
        public TimePointSec Created { get; set; }
    }
}
