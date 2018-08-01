using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class WaitWeight
    {
        [JsonProperty("wait_sec")]
        public uint WaitSec {get; set;}

        [JsonProperty("weight")]
        public ushort Weight {get; set;}

    }
}
