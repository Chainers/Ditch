using Newtonsoft.Json;

namespace Ditch.Golos.Models.Other
{
    /// <summary>
    /// message_body
    /// libraries\plugins\private_message\include\golos\private_message\private_message_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class MessageBody
    {

        /// <summary>
        /// API name: thread_start
        /// the sent_time of the original message, if any
        /// </summary>
        /// <returns>API type: time_point</returns>
        [JsonProperty("thread_start")]
        public object ThreadStart { get; set; }

        /// <summary>
        /// API name: subject
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// API name: body
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// API name: json_meta
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("json_meta")]
        public string JsonMeta { get; set; }

        /// <summary>
        /// API name: cc
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("cc")]
        public string[] Cc { get; set; }
    }
}
