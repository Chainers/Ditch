using Ditch.Core.Attributes;
using Ditch.Core.Models;
using Ditch.Golos.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations
{
    /**
     * @brief The proposal_create_operation creates a transaction proposal, for use in multi-sig scenarios
     * @ingroup operations
     *
     * Creates a transaction proposal. The operations which compose the transaction are listed in order in proposed_ops,
     * and expiration_time specifies the time by which the proposal must be accepted or it will fail permanently. The
     * expiration_time cannot be farther in the future than the maximum expiration time set in the global properties
     * object.
     */

    /// <inheritdoc />
    /// <summary>
    /// proposal_create_operation
    /// libraries\protocol\include\golos\protocol\proposal_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ProposalCreateOperation : BaseOperation
    {
        public const string OperationName = "proposal_create";

        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.ProposalCreate;


        /// <summary>
        /// API name: author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// API name: title
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(30)]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// API name: memo
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(40)]
        [JsonProperty("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// API name: expiration_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [MessageOrder(50)]
        [JsonProperty("expiration_time")]
        public TimePointSec ExpirationTime { get; set; }

        /// <summary>
        /// API name: proposed_operations
        /// 
        /// </summary>
        /// <returns>API type: operation_wrapper</returns>
        [MessageOrder(60)]
        [JsonProperty("proposed_operations")]
        public OperationWrapper[] ProposedOperations { get; set; } = new OperationWrapper[0];

        /// <summary>
        /// API name: review_period_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [MessageOrder(80)]
        [JsonProperty("review_period_time", NullValueHandling = NullValueHandling.Ignore)]
        public TimePointSec ReviewPeriodTime { get; set; }

        /// <summary>
        /// API name: extensions
        /// 
        /// </summary>
        /// <returns>API type: extensions_type</returns>
        [MessageOrder(90)]
        [JsonProperty("extensions")]
        public object[] Extensions { get; set; } = new object[0];


        public ProposalCreateOperation(string author, string title, string memo, TimePointSec expirationTime)
        {
            Author = author;
            Title = title;
            Memo = memo;
            ExpirationTime = expirationTime;
        }
    }
}
