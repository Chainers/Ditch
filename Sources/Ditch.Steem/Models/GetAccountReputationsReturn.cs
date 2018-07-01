using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_account_reputations_return
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetAccountReputationsReturn
    {

        /// <summary>
        /// API name: reputations
        /// 
        /// </summary>
        /// <returns>API type: account_reputation</returns>
        [JsonProperty("reputations")]
        public AccountReputation[] Reputations {get; set;}
    }
}
