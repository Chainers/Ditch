using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EosioGlobalState
    {
        [JsonProperty("max_ram_size")]
        public ulong MaxRamSize {get; set;}

        [JsonProperty("total_ram_bytes_reserved")]
        public ulong TotalRamBytesReserved {get; set;}

        [JsonProperty("total_ram_stake")]
        public long TotalRamStake {get; set;}

        [JsonProperty("last_producer_schedule_update")]
        public BlockTimestampType LastProducerScheduleUpdate {get; set;}

        [JsonProperty("last_pervote_bucket_fill")]
        public ulong LastPervoteBucketFill {get; set;}

        [JsonProperty("pervote_bucket")]
        public long PervoteBucket {get; set;}

        [JsonProperty("perblock_bucket")]
        public long PerblockBucket {get; set;}

        [JsonProperty("total_unpaid_blocks")]
        public uint TotalUnpaidBlocks {get; set;}

        [JsonProperty("total_activated_stake")]
        public long TotalActivatedStake {get; set;}

        [JsonProperty("thresh_activated_stake_time")]
        public ulong ThreshActivatedStakeTime {get; set;}

        [JsonProperty("last_producer_schedule_size")]
        public ushort LastProducerScheduleSize {get; set;}

        [JsonProperty("total_producer_vote_weight")]
        public double TotalProducerVoteWeight {get; set;}

        [JsonProperty("last_name_close")]
        public BlockTimestampType LastNameClose {get; set;}

    }
}
