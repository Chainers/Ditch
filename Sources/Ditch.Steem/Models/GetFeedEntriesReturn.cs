using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_feed_entries_return
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetFeedEntriesReturn
    {

        /// <summary>
        /// API name: feed
        /// 
        /// </summary>
        /// <returns>API type: feed_entry</returns>
        [JsonProperty("feed")]
        public FeedEntry[] Feed {get; set;}
    }
}
