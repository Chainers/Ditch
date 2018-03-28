using Newtonsoft.Json;

namespace Ditch.Golos.Models.Other
{
    /// <summary>
    /// order_book
    /// libraries\app\include\steemit\app\database_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class OrderBook
    {

        /// <summary>
        /// API name: asks
        /// 
        /// </summary>
        /// <returns>API type: order</returns>
        [JsonProperty("asks")]
        public Order[] Asks { get; set; }

        /// <summary>
        /// API name: bids
        /// 
        /// </summary>
        /// <returns>API type: order</returns>
        [JsonProperty("bids")]
        public Order[] Bids { get; set; }
    }
}
