using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Regproducer
    {
        [JsonProperty("producer")]
        public BaseName Producer {get; set;}

        [JsonProperty("producer_key")]
        public PublicKey ProducerKey {get; set;}

        [JsonProperty("url")]
        public string Url {get; set;}

        [JsonProperty("location")]
        public ushort Location {get; set;}

    }
}
