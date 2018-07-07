using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * Vesting balance object is a balance that is locked by the blockchain for a period of time.
     */

    /// <summary>
    /// vesting_balance_object
    /// libraries\chain\include\graphene\chain\vesting_balance_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class VestingBalanceObject
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
        /// = vesting_balance_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }


        /// Account which owns and may withdraw from this vesting balance

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("owner")]
        public AccountIdType Owner { get; set; }

        /// Total amount remaining in this vesting balance
        /// Includes the unvested funds, and the vested funds which have not yet been withdrawn

        /// <summary>
        /// API name: balance
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("balance")]
        public object Balance { get; set; }

        /// The vesting policy stores details on when funds vest, and controls when they may be withdrawn

        /// <summary>
        /// API name: policy
        /// 
        /// </summary>
        /// <returns>API type: vesting_policy</returns>
        [JsonProperty("policy")]
        public object Policy { get; set; }
    }
}
