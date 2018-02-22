using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// message_api_obj
    /// libraries\plugins\private_message\include\steemit\private_message\private_message_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class MessageApiObj
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: message_id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: from
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("from")]
        public string From {get; set;}

        /// <summary>
        /// API name: to
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("to")]
        public string To {get; set;}

        /// <summary>
        /// API name: from_memo_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("from_memo_key")]
        public PublicKeyType FromMemoKey {get; set;}

        /// <summary>
        /// API name: to_memo_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("to_memo_key")]
        public PublicKeyType ToMemoKey {get; set;}

        /// <summary>
        /// API name: sent_time
        /// 
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("sent_time")]
        public UInt64 SentTime {get; set;}

        /// <summary>
        /// API name: receive_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("receive_time")]
        public DateTime ReceiveTime {get; set;}

        /// <summary>
        /// API name: checksum
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("checksum")]
        public UInt32 Checksum {get; set;}

        /// <summary>
        /// API name: encrypted_message
        /// 
        /// </summary>
        /// <returns>API type: char</returns>
        [JsonProperty("encrypted_message")]
        public char[] EncryptedMessage {get; set;}
    }
}
