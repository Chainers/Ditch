using System;
using Newtonsoft.Json;
using Ditch.Golos.Helpers;

namespace Ditch.Golos.Objects
{
    /// <summary>
    /// authority
    /// golos-0.16.3\libraries\protocol\include\steemit\protocol\authority.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Authority
    {
        // bdType : uint32_t | = 0;
        [JsonProperty("weight_threshold")]
        [MessageOrder(10)]
        public UInt32 WeightThreshold { get; set; }

        // bdType : account_authority_map
        [JsonProperty("account_auths")]
        [MessageOrder(20)]
        public object AccountAuths { get; set; }

        // bdType : key_authority_map
        [JsonProperty("key_auths")]
        [MessageOrder(30)]
        public object[][] KeyAuths { get; set; }
    }
}