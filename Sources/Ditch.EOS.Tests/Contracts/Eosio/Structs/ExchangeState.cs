using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ExchangeState
    {
        [JsonProperty("supply")]
        public Asset Supply {get; set;}

        [JsonProperty("base")]
        public Connector Base {get; set;}

        [JsonProperty("quote")]
        public Connector Quote {get; set;}

    }
}
