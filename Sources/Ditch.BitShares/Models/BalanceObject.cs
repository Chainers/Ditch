using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// balance_object
    /// libraries\chain\include\graphene\chain\balance_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class BalanceObject : AbstractObject<BalanceObject>
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
        /// = balance_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: address</returns>
        [JsonProperty("owner")]
        public object Owner { get; set; }

        /// <summary>
        /// API name: balance
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("balance")]
        public object Balance { get; set; }

        /// <summary>
        /// API name: vesting_policy
        /// 
        /// </summary>
        /// <returns>API type: linear_vesting_policy</returns>
        [JsonProperty("vesting_policy", NullValueHandling = NullValueHandling.Ignore)]
        public LinearVestingPolicy VestingPolicy { get; set; }

        /// <summary>
        /// API name: last_claim_date
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_claim_date")]
        public TimePointSec LastClaimDate { get; set; }
    }
}
