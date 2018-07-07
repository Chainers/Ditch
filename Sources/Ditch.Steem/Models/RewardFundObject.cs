using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// reward_fund_object
    /// libraries\chain\include\steemit\chain\steem_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class RewardFundObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: reward_fund_id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: reward_fund_name_type</returns>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// API name: reward_balance
        /// = asset( 0, STEEM_SYMBOL );
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("reward_balance")]
        public Asset RewardBalance { get; set; }

        /// <summary>
        /// API name: recent_claims
        /// = 0;
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("recent_claims")]
        public UInt128 RecentClaims { get; set; }

        /// <summary>
        /// API name: last_update
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_update")]
        public TimePointSec LastUpdate { get; set; }

        /// <summary>
        /// API name: content_constant
        /// = 0;
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("content_constant")]
        public UInt128 ContentConstant { get; set; }

        /// <summary>
        /// API name: percent_curation_rewards
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("percent_curation_rewards")]
        public ushort PercentCurationRewards { get; set; }

        /// <summary>
        /// API name: percent_content_rewards
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("percent_content_rewards")]
        public ushort PercentContentRewards { get; set; }

        /// <summary>
        /// API name: author_reward_curve
        /// = linear;
        /// </summary>
        /// <returns>API type: curve_id</returns>
        [JsonProperty("author_reward_curve")]
        public object AuthorRewardCurve { get; set; }

        /// <summary>
        /// API name: curation_reward_curve
        /// = square_root;
        /// </summary>
        /// <returns>API type: curve_id</returns>
        [JsonProperty("curation_reward_curve")]
        public object CurationRewardCurve { get; set; }
    }
}
