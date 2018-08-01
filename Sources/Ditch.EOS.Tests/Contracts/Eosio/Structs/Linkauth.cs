using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Linkauth
    {
        [JsonProperty("account")]
        public BaseName Account {get; set;}

        [JsonProperty("code")]
        public BaseName Code {get; set;}

        [JsonProperty("type")]
        public BaseName Type {get; set;}

        [JsonProperty("requirement")]
        public BaseName Requirement {get; set;}

    }
}
