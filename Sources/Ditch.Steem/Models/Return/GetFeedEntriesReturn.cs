using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_feed_entries_return
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetFeedEntriesReturn
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
