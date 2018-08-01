using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Sellram
    {
        [JsonProperty("account")]
        public BaseName Account {get; set;}

        [JsonProperty("bytes")]
        public ulong Bytes {get; set;}

    }
}
