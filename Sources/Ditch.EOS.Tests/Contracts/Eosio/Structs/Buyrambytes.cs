using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Buyrambytes
    {
        [JsonProperty("payer")]
        public BaseName Payer {get; set;}

        [JsonProperty("receiver")]
        public BaseName Receiver {get; set;}

        [JsonProperty("bytes")]
        public uint Bytes {get; set;}

    }
}
