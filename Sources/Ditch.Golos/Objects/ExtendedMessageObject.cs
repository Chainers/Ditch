using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /// <summary>
    /// extended_message_object
    /// libraries\plugins\private_message\include\golos\private_message\private_message_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ExtendedMessageObject : MessageApiObj
    {

        /// <summary>
        /// API name: message
        /// 
        /// </summary>
        /// <returns>API type: message_body</returns>
        [JsonProperty("message")]
        public MessageBody Message {get; set;}
    }
}
