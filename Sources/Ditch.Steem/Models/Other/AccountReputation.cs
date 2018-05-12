using Newtonsoft.Json;

namespace Ditch.Steem.Models.Other
{
    /// <summary>
    /// account_reputation
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AccountReputation
    {
        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account")]
        public string Account {get; set;}

        /// <summary>
        /// API name: reputation
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("reputation")]
        public object Reputation {get; set;}
    }
}
