using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * Contains invariants which are set at genesis and never changed.
     */

    /// <summary>
    /// chain_property_object
    /// libraries\chain\include\graphene\chain\chain_property_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ChainPropertyObject
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
        /// = impl_chain_property_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: chain_id
        /// 
        /// </summary>
        /// <returns>API type: chain_id_type</returns>
        [JsonProperty("chain_id")]
        public object ChainId { get; set; }

        /// <summary>
        /// API name: immutable_parameters
        /// 
        /// </summary>
        /// <returns>API type: immutable_chain_parameters</returns>
        [JsonProperty("immutable_parameters")]
        public ImmutableChainParameters ImmutableParameters { get; set; }
    }
}
