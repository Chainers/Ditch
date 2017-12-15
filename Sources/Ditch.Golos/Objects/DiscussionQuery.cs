using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /**
     * @class discussion_query
     * @brief The discussion_query structure implements the RPC API param set.
     *  Defines the arguments to a query as a struct so it can be easily extended
     */

    /// <summary>
    /// discussion_query
    /// libraries\application\include\golos\application\discussion_query.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class DiscussionQuery
    {

        /// <summary>
        /// API name: limit
        /// = 0; ///&lt; the discussions return amount top limit
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public UInt32 Limit { get; set; }

        /// <summary>
        /// API name: select_authors
        /// list of authors to select
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
        /// API name: filter_tags
        /// list of tags to exclude, posts with these tags are filtered;
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("filter_tags")]
        public string[] FilterTags { get; set; } = new string[0];

        /// <summary>
        /// API name: truncate_body
        /// = 0; ///&lt; the amount of bytes of the post body to return, 0 for all
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("truncate_body")]
        public UInt32 TruncateBody { get; set; }

        /// <summary>
        /// API name: select_languages
        /// list of language to select
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("select_languages")]
        public string[] SelectLanguages { get; set; } = new string[0];

        /// <summary>
        /// API name: filter_languages
        /// list of language to filter
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("filter_languages")]
        public string[] FilterLanguages { get; set; } = new string[0];
    }
}
