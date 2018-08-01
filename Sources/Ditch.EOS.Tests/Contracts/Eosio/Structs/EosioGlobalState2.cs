using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EosioGlobalState2
    {
        [JsonProperty("new_ram_per_block")]
        public ushort NewRamPerBlock {get; set;}

        [JsonProperty("last_ram_increase")]
        public BlockTimestampType LastRamIncrease {get; set;}

        [JsonProperty("last_block_num")]
        public BlockTimestampType LastBlockNum {get; set;}

        [JsonProperty("reserved")]
        public double Reserved {get; set;}

        [JsonProperty("revision")]
        public byte Revision {get; set;}

    }
}
