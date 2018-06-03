using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// get_active_votes_args
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetActiveVotesArgs : GetDiscussionArgs
    {
    }
}
