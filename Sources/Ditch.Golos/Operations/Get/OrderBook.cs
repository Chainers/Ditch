using Newtonsoft.Json;

namespace Ditch.Golos.Operations.Get
{
    /// <summary>
    /// order_book
    /// libraries\app\include\steemit\app\database_Api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class OrderBook
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
