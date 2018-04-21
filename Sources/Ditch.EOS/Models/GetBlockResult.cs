using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// https://eosio.github.io/eos/group__eosiorpc.html
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetBlockResult
    {
        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("transaction_mroot")]
        public string TransactionMerkleRoot { get; set; }

        [JsonProperty("action_mroot")]
        public string ActionMerkleRoot { get; set; }

        [JsonProperty("block_mroot")]
        public string BlockMerkleRoot { get; set; }

        [JsonProperty("schedule_version")]
        public UInt32 ScheduleVersion { get; set; }

        [JsonProperty("producer")]
        public string Producer { get; set; }

        [JsonProperty("producer_changes")]
        public object[] ProducerChanges { get; set; }

        [JsonProperty("producer_signature")]
        public string ProducerSignature { get; set; }

        [JsonProperty("cycles")]
        public object[] Cycles { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("block_num")]
        public UInt32 BlockNum { get; set; }

        [JsonProperty("ref_block_prefix")]
        public UInt32 RefBlockPrefix { get; set; }
    }
}