using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// comment_feed_entry
    /// plugins\follow\include\golos\plugins\follow\follow_api_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CommentFeedEntry
    {

        /// <summary>
        /// API name: comment
        /// 
        /// </summary>
        /// <returns>API type: comment_api_object</returns>
        [JsonProperty("comment")]
        public CommentApiObject Comment {get; set;}

        /// <summary>
        /// API name: reblog_by
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("reblog_by")]
        public string[] ReblogBy {get; set;}

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
        public UInt32 EntryId {get; set;}
    }
}
