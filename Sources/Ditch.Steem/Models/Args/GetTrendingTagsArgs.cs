using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// get_trending_tags_args
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetTrendingTagsArgs
    {

        /// <summary>
        /// API name: start_tag
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("start_tag")]
        public string StartTag {get; set;}

        /// <summary>
        /// API name: limit
        /// = 100;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public UInt32 Limit {get; set;}
    }
}
