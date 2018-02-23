using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /**
     *  Defines the arguments to a query as a struct so it can be easily extended
     */

    /// <summary>
    /// discussion_query
    /// libraries\app\include\steemit\app\database_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class DiscussionQuery
    {

        /// <summary>
        /// API name: tag
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// API name: limit
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public UInt32 Limit { get; set; }

        /// <summary>
        /// API name: filter_tags
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("filter_tags")]
        public string[] FilterTags { get; set; } = new string[0];

        /// <summary>
        /// API name: select_authors
        /// list of authors to include, posts not by this author are filtered
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("select_authors")]
        public string[] SelectAuthors { get; set; } = new string[0];

        /// <summary>
        /// API name: select_tags
        /// list of tags to include, posts without these tags are filtered
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("select_tags")]
        public string[] SelectTags { get; set; } = new string[0];

        /// <summary>
        /// API name: truncate_body
        /// = 0; ///&lt; the number of bytes of the post body to return, 0 for all
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("truncate_body")]
        public UInt32 TruncateBody { get; set; }

        /// <summary>
        /// API name: start_author
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("start_author")]
        public string StartAuthor { get; set; }

        /// <summary>
        /// API name: start_permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("start_permlink")]
        public string StartPermlink { get; set; }

        /// <summary>
        /// API name: parent_author
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("parent_author")]
        public string ParentAuthor { get; set; }

        /// <summary>
        /// API name: parent_permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("parent_permlink")]
        public string ParentPermlink { get; set; }
    }
}
