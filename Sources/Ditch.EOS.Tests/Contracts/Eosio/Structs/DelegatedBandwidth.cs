using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DelegatedBandwidth
    {
        [JsonProperty("from")]
        public BaseName From {get; set;}

        [JsonProperty("to")]
        public BaseName To {get; set;}

        [JsonProperty("net_weight")]
        public Asset NetWeight {get; set;}

        [JsonProperty("cpu_weight")]
        public Asset CpuWeight {get; set;}

    }
}
