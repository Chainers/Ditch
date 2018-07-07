using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// order_book_extended
    /// plugins\market_history\include\golos\plugins\market_history\market_history_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class OrderBookExtended
    {

        /// <summary>
        /// API name: bids
        /// 
        /// </summary>
        /// <returns>API type: order_extended</returns>
        [JsonProperty("bids")]
        public OrderExtended[] Bids {get; set;}

        /// <summary>
        /// API name: asks
        /// 
        /// </summary>
        /// <returns>API type: order_extended</returns>
        [JsonProperty("asks")]
        public OrderExtended[] Asks {get; set;}
    }
}
