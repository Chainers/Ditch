using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// find_decline_voting_rights_requests_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FindDeclineVotingRightsRequestsArgs
    {

        /// <summary>
        /// API name: accounts
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("accounts")]
        public string[] Accounts {get; set;}
    }
}
