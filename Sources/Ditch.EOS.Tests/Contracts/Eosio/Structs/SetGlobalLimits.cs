using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SetGlobalLimits
    {
        [JsonProperty("cpu_usec_per_period")]
        public long CpuUsecPerPeriod {get; set;}

    }
}
