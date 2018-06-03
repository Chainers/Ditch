using Ditch.Core.Attributes;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Other
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
        public uint WeightThreshold { get; set; }

        // bdType : account_authority_map
        [JsonProperty("account_auths")]
        [MessageOrder(20)]
        public MapContainer<string, ushort> AccountAuths { get; set; }

        // bdType : key_authority_map
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