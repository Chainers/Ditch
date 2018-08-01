using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Setcode
    {
        [JsonProperty("account")]
        public BaseName Account {get; set;}

        [JsonProperty("vmtype")]
        public byte Vmtype {get; set;}

        [JsonProperty("vmversion")]
        public byte Vmversion {get; set;}

        [JsonProperty("code")]
        public Bytes Code {get; set;}

    }
}
