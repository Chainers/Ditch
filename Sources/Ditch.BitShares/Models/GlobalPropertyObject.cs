using System;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @class global_property_object
     * @brief Maintains global state information (committee_member list, current fees)
     * @ingroup object
     * @ingroup implementation
     *
     * This is an implementation detail. The values here are set by committee_members to tune the blockchain parameters.
     */

    /// <summary>
    /// global_property_object
    /// libraries\chain\include\graphene\chain\global_property_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GlobalPropertyObject : AbstractObject<GlobalPropertyObject>
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
        /// = impl_global_property_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: parameters
        /// 
        /// </summary>
        /// <returns>API type: chain_parameters</returns>
        [JsonProperty("parameters")]
        public ChainParameters Parameters { get; set; }

        /// <summary>
        /// API name: pending_parameters
        /// 
        /// </summary>
        /// <returns>API type: chain_parameters</returns>
        [JsonProperty("pending_parameters", NullValueHandling = NullValueHandling.Ignore)]
        public ChainParameters PendingParameters { get; set; }

        /// <summary>
        /// API name: next_available_vote_id
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("next_available_vote_id")]
        public UInt32 NextAvailableVoteId { get; set; }

        /// <summary>
        /// API name: active_committee_members
        /// updated once per maintenance interval
        /// </summary>
        /// <returns>API type: committee_member_id_type</returns>
        [JsonProperty("active_committee_members")]
        public object[] ActiveCommitteeMembers { get; set; }

        /// <summary>
        /// API name: active_witnesses
        /// updated once per maintenance interval
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("active_witnesses")]
        public object[] ActiveWitnesses { get; set; }
    }
}
