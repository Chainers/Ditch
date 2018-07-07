using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  @brief tracks the approval of a partially approved transaction 
     *  @ingroup object
     *  @ingroup protocol
     */

    /// <summary>
    /// proposal_object
    /// libraries\chain\include\graphene\chain\proposal_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ProposalObject
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
        /// = proposal_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: expiration_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("expiration_time")]
        public TimePointSec ExpirationTime { get; set; }

        /// <summary>
        /// API name: review_period_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("review_period_time", NullValueHandling = NullValueHandling.Ignore)]
        public TimePointSec ReviewPeriodTime { get; set; }

        /// <summary>
        /// API name: proposed_transaction
        /// 
        /// </summary>
        /// <returns>API type: transaction</returns>
        [JsonProperty("proposed_transaction")]
        public Transaction ProposedTransaction { get; set; }

        /// <summary>
        /// API name: required_active_approvals
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("required_active_approvals")]
        public object[] RequiredActiveApprovals { get; set; }

        /// <summary>
        /// API name: available_active_approvals
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("available_active_approvals")]
        public object[] AvailableActiveApprovals { get; set; }

        /// <summary>
        /// API name: required_owner_approvals
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("required_owner_approvals")]
        public object[] RequiredOwnerApprovals { get; set; }

        /// <summary>
        /// API name: available_owner_approvals
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("available_owner_approvals")]
        public object[] AvailableOwnerApprovals { get; set; }

        /// <summary>
        /// API name: available_key_approvals
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("available_key_approvals")]
        public object[] AvailableKeyApprovals { get; set; }

        /// <summary>
        /// API name: proposer
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("proposer")]
        public AccountIdType Proposer { get; set; }
    }
}
