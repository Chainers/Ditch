using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_feed_return
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetFeedReturn
    {

        /// <summary>
        /// API name: feed
        /// 
        /// </summary>
        /// <returns>API type: comment_feed_entry</returns>
        [JsonProperty("feed")]
        public CommentFeedEntry[] Feed {get; set;}
    }
}
