using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_discussions_by_cashout_args
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetDiscussionsByCashoutArgs : DiscussionQuery
    {
    }
}
