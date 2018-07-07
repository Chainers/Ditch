using Ditch.Core.Attributes;
using Ditch.Steem.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    /// <inheritdoc />
    /// <summary>
    /// claim_reward_balance_operation
    /// libraries\protocol\include\steem\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ClaimRewardBalanceOperation : BaseOperation
    {
        public const string OperationName = "claim_reward_balance_operation";
        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.ClaimRewardBalance;

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// API name: reward_steem
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(30)]
        [JsonProperty("reward_steem")]
        public Asset RewardSteem { get; set; }

        /// <summary>
        /// API name: reward_sbd
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(40)]
        [JsonProperty("reward_sbd")]
        public Asset RewardSbd { get; set; }

        /// <summary>
        /// API name: reward_vests
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(50)]
        [JsonProperty("reward_vests")]
        public Asset RewardVests { get; set; }


        public ClaimRewardBalanceOperation(string account, Asset rewardSteem, Asset rewardSbd, Asset rewardVests)
        {
            Account = account;
            RewardSteem = rewardSteem;
            RewardSbd = rewardSbd;
            RewardVests = rewardVests;
        }
    }
}
