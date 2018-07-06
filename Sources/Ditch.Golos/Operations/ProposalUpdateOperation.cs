using Ditch.Core.Attributes;
using Ditch.Golos.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations
{
    /**
     * @brief The proposal_update_operation updates an existing transaction proposal
     * @ingroup operations
     *
     * This operation allows accounts to add or revoke approval of a proposed transaction. Signatures sufficient to
     * satisfy the authority of each account in approvals are required on the transaction containing this operation.
     *
     * If an account with a multi-signature authority is listed in approvals_to_add or approvals_to_remove, either all
     * required signatures to satisfy that account's authority must be provided in the transaction containing this
     * operation, or a secondary proposal must be created which contains this operation.
     *
     * NOTE: If the proposal requires only an account's active authority, the account must not update adding its owner
     * authority's approval. This is considered an error. An owner approval may only be added if the proposal requires
     * the owner's authority.
     *
     * If an account's owner and active authority are both required, only the owner authority may approve. An attempt to
     * add or remove active authority approval to such a proposal will fail.
     */

    /// <summary>
    /// proposal_update_operation
    /// libraries\protocol\include\golos\protocol\proposal_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ProposalUpdateOperation : BaseOperation
    {
        public const string OperationName = "proposal_update";

        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.ProposalUpdate;


        /// <summary>
        /// API name: author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("author")]
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// API name: title
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(30)]
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// API name: active_approvals_to_add
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [MessageOrder(40)]
        [JsonProperty("active_approvals_to_add")]
        public string[] ActiveApprovalsToAdd { get; set; } = new string[0];

        /// <summary>
        /// API name: active_approvals_to_remove
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [MessageOrder(50)]
        [JsonProperty("active_approvals_to_remove")]
        public string[] ActiveApprovalsToRemove { get; set; } = new string[0];

        /// <summary>
        /// API name: owner_approvals_to_add
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [MessageOrder(60)]
        [JsonProperty("owner_approvals_to_add")]
        public string[] OwnerApprovalsToAdd { get; set; } = new string[0];

        /// <summary>
        /// API name: owner_approvals_to_remove
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [MessageOrder(70)]
        [JsonProperty("owner_approvals_to_remove")]
        public string[] OwnerApprovalsToRemove { get; set; } = new string[0];

        /// <summary>
        /// API name: posting_approvals_to_add
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [MessageOrder(80)]
        [JsonProperty("posting_approvals_to_add")]
        public string[] PostingApprovalsToAdd { get; set; } = new string[0];

        /// <summary>
        /// API name: posting_approvals_to_remove
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [MessageOrder(90)]
        [JsonProperty("posting_approvals_to_remove")]
        public string[] PostingApprovalsToRemove { get; set; } = new string[0];

        /// <summary>
        /// API name: key_approvals_to_add
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [MessageOrder(100)]
        [JsonProperty("key_approvals_to_add")]
        public PublicKeyType[] KeyApprovalsToAdd { get; set; } = new PublicKeyType[0];

        /// <summary>
        /// API name: key_approvals_to_remove
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [MessageOrder(110)]
        [JsonProperty("key_approvals_to_remove")]
        public PublicKeyType[] KeyApprovalsToRemove { get; set; } = new PublicKeyType[0];

        /// <summary>
        /// API name: extensions
        /// 
        /// </summary>
        /// <returns>API type: extensions_type</returns>
        [MessageOrder(120)]
        [JsonProperty("extensions")]
        public object[] Extensions { get; set; } = new object[0];
    }
}
