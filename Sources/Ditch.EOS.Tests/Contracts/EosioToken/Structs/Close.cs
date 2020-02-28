using Newtonsoft.Json;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.EosioToken.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Close
    {
        [JsonProperty("owner")]
        public BaseName Owner {get; set;}

        [JsonProperty("symbol")]
        public Symbol Symbol {get; set;}
    }
}
