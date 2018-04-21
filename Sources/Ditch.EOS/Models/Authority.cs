using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// authority
    /// contracts\eosio.system\native.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Authority
    {

        /// <summary>
        /// API name: threshold
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("threshold")]
        public UInt32 Threshold {get; set;}

        /// <summary>
        /// API name: keys
        /// 
        /// </summary>
        /// <returns>API type: key_weight</returns>
        [JsonProperty("keys")]
        public KeyWeight[] Keys {get; set;}

        /// <summary>
        /// API name: accounts
        /// 
        /// </summary>
        /// <returns>API type: permission_level_weight</returns>
        [JsonProperty("accounts")]
        public PermissionLevelWeight[] Accounts {get; set;}
    }
}
