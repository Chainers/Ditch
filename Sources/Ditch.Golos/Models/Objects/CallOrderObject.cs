using Newtonsoft.Json;

namespace Ditch.Golos.Models.Objects
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
    /// libraries\chain\include\golos\chain\objects\market_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class CallOrderObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: order_id
        /// 
        /// </summary>
        /// <returns>API type: integral_id_type</returns>
        [JsonProperty("order_id")]
        public object OrderId { get; set; }

        /// <summary>
        /// API name: borrower
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("borrower")]
        public string Borrower { get; set; }

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
