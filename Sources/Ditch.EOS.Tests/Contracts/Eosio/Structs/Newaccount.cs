using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Newaccount
    {
        [JsonProperty("creator")]
        public BaseName Creator {get; set;}

        [JsonProperty("name")]
        public BaseName Name {get; set;}

        [JsonProperty("owner")]
        public Authority Owner {get; set;}

        [JsonProperty("active")]
        public Authority Active {get; set;}

    }
}
