using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Buyram
    {
        [JsonProperty("payer")]
        public BaseName Payer {get; set;}

        [JsonProperty("receiver")]
        public BaseName Receiver {get; set;}

        [JsonProperty("quant")]
        public Asset Quant {get; set;}

    }
}
