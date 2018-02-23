using Ditch.Core;
using System;
using System.Collections.Generic; 
using Ditch.Steem.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// get_trending_tags_return
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetTrendingTagsReturn
    {

        /// <summary>
        /// API name: tags
        /// 
        /// </summary>
        /// <returns>API type: api_tag_object</returns>
        [JsonProperty("tags")]
        public ApiTagObject[] Tags {get; set;}
    }
}
