using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Delegatebw
    {
        [JsonProperty("from")]
        public BaseName From {get; set;}

        [JsonProperty("receiver")]
        public BaseName Receiver {get; set;}

        [JsonProperty("stake_net_quantity")]
        public Asset StakeNetQuantity {get; set;}

        [JsonProperty("stake_cpu_quantity")]
        public Asset StakeCpuQuantity {get; set;}

        [JsonProperty("transfer")]
        public bool Transfer {get; set;}

    }
}
