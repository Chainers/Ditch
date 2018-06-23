using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_trending_tags_return
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetTrendingTagsReturn
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
