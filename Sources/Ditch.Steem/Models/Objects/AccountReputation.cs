using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// account_reputation
    /// libraries\plugins\follow\include\steemit\follow\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AccountReputation
    {
        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
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
