using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Connector
    {
        [JsonProperty("balance")]
        public Asset Balance {get; set;}

        [JsonProperty("weight")]
        public double Weight {get; set;}

    }
}
