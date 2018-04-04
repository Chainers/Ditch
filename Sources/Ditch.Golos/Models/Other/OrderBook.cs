using Newtonsoft.Json;

namespace Ditch.Golos.Models.Objects
{
    /// <summary>
    /// order_book
    /// plugins\market_history\include\golos\plugins\market_history\market_history_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class OrderBook
    {
        /// <summary>
        /// API name: bids
        /// 
        /// </summary>
        /// <returns>API type: order</returns>
        [JsonProperty("bids")]
        public Order[] Bids { get; set; }

        /// <summary>
        /// API name: asks
        /// 
        /// </summary>
        /// <returns>API type: order</returns>
        [JsonProperty("asks")]
        public Order[] Asks { get; set; }
    }
}
