using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @class blinded_balance_object
     * @brief tracks a blinded balance commitment
     * @ingroup object
     * @ingroup protocol
     */

    /// <summary>
    /// blinded_balance_object
    /// libraries\chain\include\graphene\chain\confidential_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BlindedBalanceObject
    {

        /// <summary>
        /// API name: space_id
        /// = implementation_ids;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("space_id")]
        public byte SpaceId { get; set; }

        /// <summary>
        /// API name: type_id
        /// = impl_blinded_balance_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: commitment
        /// 
        /// </summary>
        /// <returns>API type: commitment_type</returns>
        [JsonProperty("commitment")]
        public char Commitment { get; set; }

        /// <summary>
        /// API name: asset_id
        /// 
        /// </summary>
        /// <returns>API type: asset_id_type</returns>
        [JsonProperty("asset_id")]
        public AssetIdType AssetId { get; set; }

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [JsonProperty("owner")]
        public Authority Owner { get; set; }
    }
}
