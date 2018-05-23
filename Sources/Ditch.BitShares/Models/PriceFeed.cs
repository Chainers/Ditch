using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  @class price_feed
     *  @brief defines market parameters for margin positions
     */

    /// <summary>
    /// price_feed
    /// libraries\chain\include\graphene\chain\protocol\asset.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class PriceFeed
    {

        /**
 *  Required maintenance collateral is defined
 *  as a fixed point number with a maximum value of 10.000
 *  and a minimum value of 1.000.  (denominated in GRAPHENE_COLLATERAL_RATIO_DENOM)
 *
 *  A black swan event occurs when value_of_collateral equals
 *  value_of_debt, to avoid a black swan a margin call is
 *  executed when value_of_debt * required_maintenance_collateral
 *  equals value_of_collateral using rate.
 *
 *  Default requirement is $1.75 of collateral per $1 of debt
 *
 *  BlackSwan ---> SQR ---> MCR ----> SP
 */
        ///@{
        /**
         * Forced settlements will evaluate using this price, defined as BITASSET / COLLATERAL
         */

        /// <summary>
        /// API name: settlement_price
        /// 
        /// </summary>
        /// <returns>API type: price</returns>
        [JsonProperty("settlement_price")]
        public Price SettlementPrice { get; set; }


        /// Price at which automatically exchanging this asset for CORE from fee pool occurs (used for paying fees)

        /// <summary>
        /// API name: core_exchange_rate
        /// 
        /// </summary>
        /// <returns>API type: price</returns>
        [JsonProperty("core_exchange_rate")]
        public Price CoreExchangeRate { get; set; }


        /** Fixed point between 1.000 and 10.000, implied fixed point denominator is GRAPHENE_COLLATERAL_RATIO_DENOM */

        /// <summary>
        /// API name: maintenance_collateral_ratio
        /// = GRAPHENE_DEFAULT_MAINTENANCE_COLLATERAL_RATIO;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("maintenance_collateral_ratio")]
        public UInt16 MaintenanceCollateralRatio { get; set; }


        /** Fixed point between 1.000 and 10.000, implied fixed point denominator is GRAPHENE_COLLATERAL_RATIO_DENOM */

        /// <summary>
        /// API name: maximum_short_squeeze_ratio
        /// = GRAPHENE_DEFAULT_MAX_SHORT_SQUEEZE_RATIO;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("maximum_short_squeeze_ratio")]
        public UInt16 MaximumShortSqueezeRatio { get; set; }
    }
}
