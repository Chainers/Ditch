using System;
using Ditch.Core.Attributes;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Other
{
    /// <summary>
    /// authority
    /// steem-0.19.1\libraries\protocol\include\steemit\protocol\authority.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Authority
    {

        // bdType : uint32_t | = 0;
        [MessageOrder(10)]
        [JsonProperty("weight_threshold")]
        public UInt32 WeightThreshold { get; set; }

        // bdType : account_authority_map
        [MessageOrder(20)]
        [JsonProperty("account_auths")]
        public MapContainer<string, UInt16> AccountAuths { get; set; }

        // bdType : key_authority_map
        [MessageOrder(30)]
        [JsonProperty("key_auths")]
        public MapContainer<PublicKeyType, UInt16> KeyAuths { get; set; }

        public Authority()
        {
            WeightThreshold = 1;
            AccountAuths = new MapContainer<string, ushort>();
            KeyAuths = new MapContainer<PublicKeyType, ushort>();
        }
    }
}