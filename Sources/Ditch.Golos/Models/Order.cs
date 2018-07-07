using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// order
    /// plugins\market_history\include\golos\plugins\market_history\market_history_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Order
    {

        /// <summary>
        /// API name: price
        /// 
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("price")]
        public double Price { get; set; }

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
    }
}
