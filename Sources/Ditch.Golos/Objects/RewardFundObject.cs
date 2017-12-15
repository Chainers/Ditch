using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /// <summary>
    /// reward_fund_object
    /// libraries\chain\include\golos\chain\objects\steem_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class RewardFundObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: reward_fund_object::id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: reward_fund_name_type</returns>
        [JsonProperty("name")]
        public object Name { get; set; }

        /// <summary>
        /// API name: recent_claims
        /// = 0;
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("recent_claims")]
        public string RecentClaims { get; set; }

        /// <summary>
        /// API name: last_update
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_update")]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// API name: content_constant
        /// = 0;
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("content_constant")]
        public string ContentConstant { get; set; }

        /// <summary>
        /// API name: percent_curation_rewards
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("percent_curation_rewards")]
        public UInt16 PercentCurationRewards { get; set; }

        /// <summary>
        /// API name: percent_content_rewards
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("percent_content_rewards")]
        public UInt16 PercentContentRewards { get; set; }
    }
}
