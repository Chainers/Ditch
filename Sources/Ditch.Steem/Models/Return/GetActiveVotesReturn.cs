using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_active_votes_return
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetActiveVotesReturn
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
