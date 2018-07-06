using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  @brief tracks bitassets scheduled for force settlement at some point in the future.
     *
     *  On the @ref settlement_date the @ref balance will be converted to the collateral asset
     *  and paid to @ref owner and then this object will be deleted.
     */

    /// <summary>
    /// force_settlement_object
    /// libraries\chain\include\graphene\chain\market_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ForceSettlementObject : AbstractObject<ForceSettlementObject>
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
        /// = force_settlement_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("owner")]
        public AccountIdType Owner { get; set; }

        /// <summary>
        /// API name: balance
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("balance")]
        public object Balance { get; set; }

        /// <summary>
        /// API name: settlement_date
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("settlement_date")]
        public TimePointSec SettlementDate { get; set; }
    }
}
