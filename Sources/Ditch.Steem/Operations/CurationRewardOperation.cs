using Ditch.Core.Attributes;
using Ditch.Steem.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    /// <inheritdoc />
    /// <summary>
    ///  ****
    /// curation_reward_operation
    /// libraries\protocol\include\steem\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CurationRewardOperation : BaseOperation
    {
        public const string OperationName = "curation_reward_operation";
        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.CurationReward;

        /// <summary>
        /// API name: curator
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("curator")]
        public string Curator { get; set; }

        /// <summary>
        /// API name: reward
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(30)]
        [JsonProperty("reward")]
        public Asset Reward { get; set; }

        /// <summary>
        /// API name: comment_author
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(40)]
        [JsonProperty("comment_author")]
        public string CommentAuthor { get; set; }

        /// <summary>
        /// API name: comment_permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(50)]
        [JsonProperty("comment_permlink")]
        public string CommentPermlink { get; set; }

    }
}
