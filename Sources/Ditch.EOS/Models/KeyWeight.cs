using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// key_weight
    /// contracts\eosio.system\native.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class KeyWeight
    {

        /// <summary>
        /// API name: key
        /// 
        /// </summary>
        /// <returns>API type: public_key</returns>
        [JsonProperty("key")]
        public PublicKey Key {get; set;}

        /// <summary>
        /// API name: weight
        /// 
        /// </summary>
        /// <returns>API type: weight_type</returns>
        [JsonProperty("weight")]
        public UInt16 Weight {get; set;}
    }
}
