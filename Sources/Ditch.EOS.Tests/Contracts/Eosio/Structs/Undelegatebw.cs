using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Undelegatebw
    {
        [JsonProperty("from")]
        public BaseName From {get; set;}

        [JsonProperty("receiver")]
        public BaseName Receiver {get; set;}

        [JsonProperty("unstake_net_quantity")]
        public Asset UnstakeNetQuantity {get; set;}

        [JsonProperty("unstake_cpu_quantity")]
        public Asset UnstakeCpuQuantity {get; set;}

    }
}
