using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class NamebidInfo
    {
        [JsonProperty("newname")]
        public BaseName Newname {get; set;}

        [JsonProperty("high_bidder")]
        public BaseName HighBidder {get; set;}

        [JsonProperty("high_bid")]
        public long HighBid {get; set;}

        [JsonProperty("last_bid_time")]
        public ulong LastBidTime {get; set;}

    }
}
