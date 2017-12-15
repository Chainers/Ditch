using System;
using Ditch.Core;
using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /**
     *  @brief tracks bitassets scheduled for force settlement at some point in the future.
     *
     *  On the @ref settlement_date the @ref balance will be converted to the collateral asset
     *  and paid to @ref owner and then this object will be deleted.
     */

    /// <summary>
    /// force_settlement_object
    /// libraries\chain\include\golos\chain\objects\market_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ForceSettlementObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// API name: settlement_id
        /// 
        /// </summary>
        /// <returns>API type: integral_id_type</returns>
        [JsonProperty("settlement_id")]
        public object SettlementId { get; set; }

        /// <summary>
        /// API name: balance
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("balance")]
        public Asset Balance { get; set; }

        /// <summary>
        /// API name: settlement_date
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("settlement_date")]
        public DateTime SettlementDate { get; set; }
    }
}
