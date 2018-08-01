using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Authority
    {
        [JsonProperty("threshold")]
        public uint Threshold {get; set;}

        [JsonProperty("keys")]
        public KeyWeight[] Keys {get; set;}

        [JsonProperty("accounts")]
        public PermissionLevelWeight[] Accounts {get; set;}

        [JsonProperty("waits")]
        public WaitWeight[] Waits {get; set;}

    }
}
