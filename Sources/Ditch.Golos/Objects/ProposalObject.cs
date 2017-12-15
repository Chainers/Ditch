using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /**
     *  @brief tracks the approval of a partially approved transaction
     *  @ingroup object
     *  @ingroup protocol
     */

    /// <summary>
    /// proposal_object
    /// libraries\chain\include\golos\chain\objects\proposal_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ProposalObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: proposal_id
        /// 
        /// </summary>
        /// <returns>API type: integral_id_type</returns>
        [JsonProperty("proposal_id")]
        public object ProposalId { get; set; }

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// API name: expiration_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("expiration_time")]
        public DateTime ExpirationTime { get; set; }

        /// <summary>
        /// API name: review_period_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("review_period_time")]
        public DateTime ReviewPeriodTime { get; set; }

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
        public string[] RequiredActiveApprovals { get; set; }

        /// <summary>
        /// API name: available_active_approvals
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("available_active_approvals")]
        public string[] AvailableActiveApprovals { get; set; }

        /// <summary>
        /// API name: required_owner_approvals
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("required_owner_approvals")]
        public string[] RequiredOwnerApprovals { get; set; }

        /// <summary>
        /// API name: available_owner_approvals
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("available_owner_approvals")]
        public string[] AvailableOwnerApprovals { get; set; }

        /// <summary>
        /// API name: required_posting_approvals
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("required_posting_approvals")]
        public string[] RequiredPostingApprovals { get; set; }

        /// <summary>
        /// API name: available_posting_approvals
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("available_posting_approvals")]
        public string[] AvailablePostingApprovals { get; set; }

        /// <summary>
        /// API name: available_key_approvals
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("available_key_approvals")]
        public object[] AvailableKeyApprovals { get; set; }
    }
}
