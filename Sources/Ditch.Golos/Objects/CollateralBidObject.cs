using Newtonsoft.Json;

namespace Ditch.Golos.Objects
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
    /// libraries\chain\include\golos\chain\objects\market_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class CollateralBidObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: bidder
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("bidder")]
        public string Bidder { get; set; }

        /// <summary>
        /// API name: inv_swan_price
        /// Collateral / Debt
        /// </summary>
        /// <returns>API type: price</returns>
        [JsonProperty("inv_swan_price")]
        public Price InvSwanPrice { get; set; }
    }
}
