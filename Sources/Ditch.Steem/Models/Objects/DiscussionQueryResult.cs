using Ditch.Core;
using System;
using System.Collections.Generic; 
using Ditch.Steem.Objects;
using Newtonsoft.Json;
using Ditch.Steem.Models.Objects;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// discussion_query_result
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class DiscussionQueryResult
    {

        /// <summary>
        /// API name: discussions
        /// 
        /// </summary>
        /// <returns>API type: discussion</returns>
        [JsonProperty("discussions")]
        public Discussion[] Discussions {get; set;}
    }
}
