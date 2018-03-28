using System;
using Ditch.Steem.Models.ApiObj;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Other
{
    /// <summary>
    /// comment_blog_entry
    /// libraries\plugins\follow\include\steemit\follow\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class CommentBlogEntry
    {
        /// <summary>
        /// API name: comment
        /// 
        /// </summary>
        /// <returns>API type: comment_api_obj</returns>
        [JsonProperty("comment")]
        public CommentApiObj Comment {get; set;}

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
        public DateTime ReblogOn {get; set;}

        /// <summary>
        /// API name: entry_id
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("entry_id")]
        public UInt32 EntryId {get; set;}
    }
}
