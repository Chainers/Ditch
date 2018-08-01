using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Bidname
    {
        [JsonProperty("bidder")]
        public BaseName Bidder {get; set;}

        [JsonProperty("newname")]
        public BaseName Newname {get; set;}

        [JsonProperty("bid")]
        public Asset Bid {get; set;}

    }
}
