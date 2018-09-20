using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// reblog_entry
    /// libraries\api\include\golos\api\reblog_entry.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ReblogEntry
    {

        /// <summary>
        /// API name: author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// API name: title
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// API name: body
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// API name: json_metadata
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("json_metadata")]
        public string JsonMetadata { get; set; }
    }
}
