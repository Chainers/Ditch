using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// get_blog_args
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetBlogArgs : GetFeedEntriesArgs
    {
    }
}
