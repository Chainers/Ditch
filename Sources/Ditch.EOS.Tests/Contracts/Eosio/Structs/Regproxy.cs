using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Regproxy
    {
        [JsonProperty("proxy")]
        public BaseName Proxy {get; set;}

        [JsonProperty("isproxy")]
        public bool Isproxy {get; set;}

    }
}
