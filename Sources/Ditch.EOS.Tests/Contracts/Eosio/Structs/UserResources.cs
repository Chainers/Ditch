using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UserResources
    {
        [JsonProperty("owner")]
        public BaseName Owner {get; set;}

        [JsonProperty("net_weight")]
        public Asset NetWeight {get; set;}

        [JsonProperty("cpu_weight")]
        public Asset CpuWeight {get; set;}

        [JsonProperty("ram_bytes")]
        public ulong RamBytes {get; set;}

    }
}
