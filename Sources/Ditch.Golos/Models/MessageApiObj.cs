using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// message_api_obj
    /// plugins\private_message\include\golos\plugins\private_message\private_message_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class MessageApiObj
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: message_id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: from
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// API name: to
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// API name: from_memo_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("from_memo_key")]
        public PublicKeyType FromMemoKey { get; set; }

        /// <summary>
        /// API name: to_memo_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("to_memo_key")]
        public PublicKeyType ToMemoKey { get; set; }

        /// <summary>
        /// API name: sent_time
        /// 
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("sent_time")]
        public ulong SentTime {get; set;}

        /// <summary>
        /// API name: receive_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("receive_time")]
        public TimePointSec ReceiveTime { get; set; }

        /// <summary>
        /// API name: checksum
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("checksum")]
        public uint Checksum {get; set;}

        /// <summary>
        /// API name: encrypted_message
        /// 
        /// </summary>
        /// <returns>API type: char</returns>
        [JsonProperty("encrypted_message")]
        public char[] EncryptedMessage { get; set; }
    }
}
