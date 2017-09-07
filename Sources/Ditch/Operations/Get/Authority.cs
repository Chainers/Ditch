using System;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    /// <summary>
    /// authority
    /// golos-0.16.3\libraries\protocol\include\steemit\protocol\authority.hpp
    /// steem-0.19.1\libraries\protocol\include\steemit\protocol\authority.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Authority
    {

        // bdType : uint32_t | = 0;
        [JsonProperty("weight_threshold")]
        public UInt32 WeightThreshold { get; set; }

        // bdType : account_authority_map
        [JsonProperty("account_auths")]
        public object AccountAuths { get; set; }

        // bdType : key_authority_map
        [JsonProperty("key_auths")]
        public object[][] KeyAuths { get; set; }
    }
}