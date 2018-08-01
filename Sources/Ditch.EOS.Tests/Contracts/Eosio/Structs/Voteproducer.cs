using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Voteproducer
    {
        [JsonProperty("voter")]
        public BaseName Voter {get; set;}

        [JsonProperty("proxy")]
        public BaseName Proxy {get; set;}

        [JsonProperty("producers")]
        public AccountName[] Producers {get; set;}

    }
}
