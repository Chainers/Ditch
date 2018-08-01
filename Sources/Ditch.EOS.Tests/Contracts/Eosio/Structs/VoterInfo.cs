using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class VoterInfo
    {
        [JsonProperty("owner")]
        public BaseName Owner {get; set;}

        [JsonProperty("proxy")]
        public BaseName Proxy {get; set;}

        [JsonProperty("producers")]
        public AccountName[] Producers {get; set;}

        [JsonProperty("staked")]
        public long Staked {get; set;}

        [JsonProperty("last_vote_weight")]
        public double LastVoteWeight {get; set;}

        [JsonProperty("proxied_vote_weight")]
        public double ProxiedVoteWeight {get; set;}

        [JsonProperty("is_proxy")]
        public bool IsProxy {get; set;}

    }
}
