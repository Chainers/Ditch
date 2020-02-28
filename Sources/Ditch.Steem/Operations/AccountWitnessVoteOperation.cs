using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    /// <inheritdoc />
    /// <summary>
    ///  ****
    /// account_witness_vote_operation
    /// libraries\protocol\include\steem\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AccountWitnessVoteOperation : BaseOperation
    {
        public const string OperationName = "account_witness_vote_operation";
        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.AccountWitnessVote;

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// API name: witness
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(30)]
        [JsonProperty("witness")]
        public string Witness { get; set; }

        /// <summary>
        /// API name: approve
        /// 
        /// </summary>
        /// <returns>API type: bool</returns>
        [MessageOrder(40)]
        [JsonProperty("approve")]
        public bool Approve { get; set; }
    }
}
