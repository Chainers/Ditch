using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// list_decline_voting_rights_requests_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListDeclineVotingRightsRequestsReturn
    {

        /// <summary>
        /// API name: requests
        /// 
        /// </summary>
        /// <returns>API type: api_decline_voting_rights_request_object</returns>
        [JsonProperty("requests")]
        public ApiDeclineVotingRightsRequestObject[] Requests {get; set;}
    }
}
