using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @class collateral_bid_object
     * @brief bids of collateral for debt after a black swan
     *
     * There should only be one collateral_bid_object per asset per account, and
     * only for smartcoin assets that have a global settlement_price.
     */

    /// <summary>
    /// collateral_bid_object
    /// libraries\chain\include\graphene\chain\market_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CollateralBidObject
    {

        /// <summary>
        /// API name: space_id
        /// = implementation_ids;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("space_id")]
        public byte SpaceId {get; set;}

        /// <summary>
        /// API name: type_id
        /// = impl_collateral_bid_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId {get; set;}

        /// <summary>
        /// API name: bidder
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("bidder")]
        public AccountIdType Bidder {get; set;}

        /// <summary>
        /// API name: inv_swan_price
        /// Collateral / Debt
        /// </summary>
        /// <returns>API type: price</returns>
        [JsonProperty("inv_swan_price")]
        public Price InvSwanPrice {get; set;}
    }
}
