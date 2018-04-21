using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// permission_level_weight
    /// contracts\eosio.system\native.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class PermissionLevelWeight
    {

        /// <summary>
        /// API name: permission
        /// 
        /// </summary>
        /// <returns>API type: permission_level</returns>
        [JsonProperty("permission")]
        public PermissionLevel Permission { get; set; }

        /// <summary>
        /// API name: weight
        /// 
        /// </summary>
        /// <returns>API type: weight_type</returns>
        [JsonProperty("weight")]
        public UInt16 Weight { get; set; }
    }
}
