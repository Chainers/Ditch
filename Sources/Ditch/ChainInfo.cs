using Newtonsoft.Json;

namespace Ditch
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChainInfo
    {
        [JsonProperty("chain_id")]
        public byte[] ChainId { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("steem_symbol")]
        public string SteemSymbol { get; set; }

        [JsonProperty("sbd_symbol")]
        public string SbdSymbol { get; set; }

        [JsonProperty("vests_symbol")]
        public string VestsSymbol { get; set; }

        public string Url { get; internal set; }
    }
}