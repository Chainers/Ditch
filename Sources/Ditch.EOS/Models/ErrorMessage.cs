using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// error_message
    /// libraries\chain\include\eosio\chain\abi_def.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ErrorMessage
    {

        /// <summary>
        /// API name: error_code
        /// 
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("error_code")]
        public UInt64 ErrorCode {get; set;}

        /// <summary>
        /// API name: error_msg
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("error_msg")]
        public string ErrorMsg {get; set;}
    }
}
