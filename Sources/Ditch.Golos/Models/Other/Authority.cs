using System;
using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Other
{
    /// <summary>
    /// authority
    /// golos-0.16.3\libraries\protocol\include\steemit\protocol\authority.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Authority
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