using System;
using Ditch.Golos.Models.ApiObject;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Other
{
    /// <summary>
    /// comment_blog_entry
    /// plugins\follow\include\golos\plugins\follow\follow_api_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CommentBlogEntry
    {

        /// <summary>
        /// API name: comment
        /// 
        /// </summary>
        /// <returns>API type: comment_api_object</returns>
        [JsonProperty("comment")]
        public CommentApiObject Comment {get; set;}

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
        public uint EntryId {get; set;}
    }
}
