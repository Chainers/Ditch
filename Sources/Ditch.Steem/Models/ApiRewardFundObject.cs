using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// api_reward_fund_object
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiRewardFundObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: reward_fund_id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: reward_fund_name_type</returns>
        [JsonProperty("name")]
        public string Name {get; set;}

        /// <summary>
        /// API name: reward_balance
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("reward_balance")]
        public Asset RewardBalance {get; set;}

        /// <summary>
        /// API name: recent_claims
        /// = 0;
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("recent_claims")]
        public string RecentClaims {get; set;}

        /// <summary>
        /// API name: last_update
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_update")]
        public TimePointSec LastUpdate {get; set;}

        /// <summary>
        /// API name: content_constant
        /// = 0;
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("content_constant")]
        public string ContentConstant {get; set;}

        /// <summary>
        /// API name: percent_curation_rewards
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("percent_curation_rewards")]
        public ushort PercentCurationRewards {get; set;}

        /// <summary>
        /// API name: percent_content_rewards
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("percent_content_rewards")]
        public ushort PercentContentRewards {get; set;}

        /// <summary>
        /// API name: author_reward_curve
        /// 
        /// </summary>
        /// <returns>API type: curve_id</returns>
        [JsonProperty("author_reward_curve")]
        public CurveId AuthorRewardCurve {get; set;}

        /// <summary>
        /// API name: curation_reward_curve
        /// 
        /// </summary>
        /// <returns>API type: curve_id</returns>
        [JsonProperty("curation_reward_curve")]
        public CurveId CurationRewardCurve {get; set;}
    }
}
