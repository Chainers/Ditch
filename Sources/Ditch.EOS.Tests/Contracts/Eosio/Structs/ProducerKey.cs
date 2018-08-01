using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ProducerKey
    {
        [JsonProperty("producer_name")]
        public BaseName ProducerName {get; set;}

        [JsonProperty("block_signing_key")]
        public PublicKey BlockSigningKey {get; set;}

    }
}
