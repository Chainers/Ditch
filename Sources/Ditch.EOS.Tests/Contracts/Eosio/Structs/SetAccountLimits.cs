using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SetAccountLimits
    {
        [JsonProperty("account")]
        public BaseName Account {get; set;}

        [JsonProperty("ram_bytes")]
        public long RamBytes {get; set;}

        [JsonProperty("net_weight")]
        public long NetWeight {get; set;}

        [JsonProperty("cpu_weight")]
        public long CpuWeight {get; set;}

    }
}
