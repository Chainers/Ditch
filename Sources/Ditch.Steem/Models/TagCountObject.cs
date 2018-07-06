using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// tag_count_object
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TagCountObject
    {

        /// <summary>
        /// API name: tag
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("tag")]
        public string Tag {get; set;}

        /// <summary>
        /// API name: count
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("count")]
        public uint Count {get; set;}
    }
}
