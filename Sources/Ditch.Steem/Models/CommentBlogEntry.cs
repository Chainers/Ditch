using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// comment_blog_entry
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CommentBlogEntry
    {
        /// <summary>
        /// API name: comment
        /// 
        /// </summary>
        /// <returns>API type: database_api::api_comment_object</returns>
        [JsonProperty("comment")]
        public ApiCommentObject Comment {get; set;}

        /// <summary>
        /// API name: blog
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("blog")]
        public string Blog {get; set;}

        /// <summary>
        /// API name: reblog_on
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("reblog_on")]
        public TimePointSec ReblogOn {get; set;}

        /// <summary>
        /// API name: entry_id
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("entry_id")]
        public uint EntryId {get; set;}
    }
}
