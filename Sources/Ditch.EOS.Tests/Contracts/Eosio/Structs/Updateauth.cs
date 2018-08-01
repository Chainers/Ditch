using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Updateauth
    {
        [JsonProperty("account")]
        public BaseName Account {get; set;}

        [JsonProperty("permission")]
        public BaseName Permission {get; set;}

        [JsonProperty("parent")]
        public BaseName Parent {get; set;}

        [JsonProperty("auth")]
        public Authority Auth {get; set;}

    }
}
