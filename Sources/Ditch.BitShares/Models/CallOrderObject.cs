using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @class call_order_object
     * @brief tracks debt and call price information
     *
     * There should only be one call_order_object per asset pair per account and
     * they will all have the same call price.
     */

    /// <summary>
    /// call_order_object
    /// libraries\chain\include\graphene\chain\market_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CallOrderObject
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
        /// = call_order_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: borrower
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("borrower")]
        public AccountIdType Borrower { get; set; }

        /// <summary>
        /// API name: collateral
        /// call_price.base.asset_id, access via get_collateral
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("collateral")]
        public object Collateral { get; set; }

        /// <summary>
        /// API name: debt
        /// call_price.quote.asset_id, access via get_collateral
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("debt")]
        public object Debt { get; set; }

        /// <summary>
        /// API name: call_price
        /// Debt / Collateral
        /// </summary>
        /// <returns>API type: price</returns>
        [JsonProperty("call_price")]
        public Price CallPrice { get; set; }
    }
}
