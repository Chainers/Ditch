using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RefundRequest
    {
        [JsonProperty("owner")]
        public BaseName Owner {get; set;}

        [JsonProperty("request_time")]
        public TimePointSec RequestTime {get; set;}

        [JsonProperty("net_amount")]
        public Asset NetAmount {get; set;}

        [JsonProperty("cpu_amount")]
        public Asset CpuAmount {get; set;}

    }
}
