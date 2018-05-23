using System;
using Ditch.Golos.Models.Operations;
using Ditch.Golos.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.ApiObject
{
    /// <summary>
    /// proposal_api_object
    /// plugins\database_api\include\golos\plugins\database_api\api_objects\proposal_api_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ProposalApiObject
    {

        /// <summary>
        /// API name: author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// API name: title
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// API name: memo
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("memo")]
        public string Memo { get; set; }

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
        [JsonProperty("review_period_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ReviewPeriodTime { get; set; }

        /// <summary>
        /// API name: proposed_operations
        /// 
        /// </summary>
        /// <returns>API type: operation</returns>
        [JsonProperty("proposed_operations")]
        public BaseOperation[] ProposedOperations { get; set; }

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
        public PublicKeyType[] AvailableKeyApprovals { get; set; }
    }
}
