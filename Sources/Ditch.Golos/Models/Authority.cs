using System;
using Ditch.Core.Attributes;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// authority
    /// libraries\protocol\include\golos\protocol\authority.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Authority
    {

        /// <summary>
        /// API name: weight_threshold
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("weight_threshold")]
        [MessageOrder(10)]
        public UInt32 WeightThreshold { get; set; }

        /// <summary>
        /// API name: account_auths
        /// 
        /// </summary>
        /// <returns>API type: account_authority_map</returns>
        [JsonProperty("account_auths")]
        [MessageOrder(20)]
        public MapContainer<string, ushort> AccountAuths { get; set; }

        /// <summary>
        /// API name: key_auths
        /// 
        /// </summary>
        /// <returns>API type: key_authority_map</returns>
        [JsonProperty("key_auths")]
        [MessageOrder(30)]
        public MapContainer<PublicKeyType, ushort> KeyAuths { get; set; }

        public Authority()
        {
            WeightThreshold = 1;
            AccountAuths = new MapContainer<string, ushort>();
            KeyAuths = new MapContainer<PublicKeyType, ushort>();
        }
    }
}