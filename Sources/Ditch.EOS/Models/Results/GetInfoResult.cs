using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models.Results
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GetInfoResult
    {

        [JsonProperty("server_version")]
        public string ServerVersion { get; set; }

        [JsonProperty("head_block_num")]
        public UInt32 HeadBlockNum { get; set; }

        [JsonProperty("last_irreversible_block_num")]
        public UInt32 LastIrreversibleBlockNum { get; set; }

        [JsonProperty("head_block_id")]
        public string HeadBlockId { get; set; }

        [JsonProperty("head_block_time")]
        public DateTime HeadBlockTime { get; set; }

        [JsonProperty("head_block_producer")]
        public string HeadBlockProducer { get; set; }

        [JsonProperty("recent_slots")]
        public string RecentSlots { get; set; }

        [JsonProperty("participation_rate")]
        public string ParticipationRate { get; set; }
    }
}