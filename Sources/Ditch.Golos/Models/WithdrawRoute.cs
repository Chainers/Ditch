using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// withdraw_route
    /// plugins\database_api\include\golos\plugins\database_api\plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WithdrawRoute
    {

        /// <summary>
        /// API name: from_account
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("from_account")]
        public string FromAccount { get; set; }

        /// <summary>
        /// API name: to_account
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("to_account")]
        public string ToAccount { get; set; }

        /// <summary>
        /// API name: percent
        /// 
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("percent")]
        public UInt16 Percent {get; set;}

        /// <summary>
        /// API name: auto_vest
        /// 
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("auto_vest")]
        public bool AutoVest { get; set; }
    }
}
