using Ditch.Core;
using System;
using System.Collections.Generic; 
using Ditch.Steem.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// get_tags_used_by_author_return
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetTagsUsedByAuthorReturn
    {

        /// <summary>
        /// API name: tags
        /// 
        /// </summary>
        /// <returns>API type: tag_count_object</returns>
        [JsonProperty("tags")]
        public TagCountObject[] Tags {get; set;}
    }
}
