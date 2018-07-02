using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /**
     *  @brief an offer to sell a amount of a asset at a specified exchange rate by a certain time
     *  @ingroup object
     *  @ingroup protocol
     *  @ingroup market
     *
     *  This limit_order_objects are indexed by @ref expiration and is automatically deleted on the first block after expiration.
     */

    /// <summary>
    /// limit_order_object
    /// libraries\chain\include\steemit\chain\steem_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class LimitOrderObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: created
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("created")]
        public TimePointSec Created { get; set; }

        /// <summary>
        /// API name: expiration
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("expiration")]
        public TimePointSec Expiration { get; set; }

        /// <summary>
        /// API name: seller
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("seller")]
        public string Seller { get; set; }

        /// <summary>
        /// API name: orderid
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("orderid")]
        public uint Orderid { get; set; }

        /// <summary>
        /// API name: for_sale
        /// asset id is sell_price.base.symbol
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("for_sale")]
        public object ForSale { get; set; }

        /// <summary>
        /// API name: sell_price
        /// 
        /// </summary>
        /// <returns>API type: price</returns>
        [JsonProperty("sell_price")]
        public Price SellPrice { get; set; }
    }
}
