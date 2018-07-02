using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_active_votes_return
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetActiveVotesReturn
    {

        /// <summary>
        /// API name: votes
        /// 
        /// </summary>
        /// <returns>API type: vote_state</returns>
        [JsonProperty("votes")]
        public VoteState[] Votes {get; set;}
    }
}
