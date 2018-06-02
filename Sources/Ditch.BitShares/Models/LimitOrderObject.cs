using System;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
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
    /// libraries\chain\include\graphene\chain\market_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class LimitOrderObject : AbstractObject<LimitOrderObject>
    {

        /// <summary>
        /// API name: space_id
        /// = protocol_ids;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("space_id")]
        public byte SpaceId { get; set; }

        /// <summary>
        /// API name: type_id
        /// = limit_order_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: expiration
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        /// <summary>
        /// API name: seller
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("seller")]
        public AccountIdType Seller { get; set; }

        /// <summary>
        /// API name: for_sale
        /// asset id is sell_price.base.asset_id
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

        /// <summary>
        /// API name: deferred_fee
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("deferred_fee")]
        public object DeferredFee { get; set; }
    }
}
