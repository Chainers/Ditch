using Ditch.Core.Attributes;
using Ditch.Steem.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    /// <inheritdoc />
    /// <summary>
    ///  ****
    /// author_reward_operation
    /// libraries\protocol\include\steem\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AuthorRewardOperation : BaseOperation
    {
        public const string OperationName = "author_reward_operation";
        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.AuthorReward;

        /// <summary>
        /// API name: author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// API name: permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(30)]
        [JsonProperty("permlink")]
        public string Permlink { get; set; }

        /// <summary>
        /// API name: sbd_payout
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(40)]
        [JsonProperty("sbd_payout")]
        public Asset SbdPayout { get; set; }

        /// <summary>
        /// API name: steem_payout
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(50)]
        [JsonProperty("steem_payout")]
        public Asset SteemPayout { get; set; }

        /// <summary>
        /// API name: vesting_payout
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(60)]
        [JsonProperty("vesting_payout")]
        public Asset VestingPayout { get; set; }

    }
}
