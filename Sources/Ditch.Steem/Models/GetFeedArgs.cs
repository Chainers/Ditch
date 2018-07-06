using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_feed_args
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetFeedArgs : GetFeedEntriesArgs
    {
    }
}
