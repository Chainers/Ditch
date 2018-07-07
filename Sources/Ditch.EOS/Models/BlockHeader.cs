using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// block_header
    /// libraries\chain\include\eosio\chain\block_header.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BlockHeader
    {

        /// <summary>
        /// API name: timestamp
        /// 
        /// </summary>
        /// <returns>API type: block_timestamp_type</returns>
        [JsonProperty("timestamp")]
        public BlockTimestampType Timestamp { get; set; }

        /// <summary>
        /// API name: producer
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("producer")]
        public AccountName Producer { get; set; }

        /// <summary>
        /// API name: confirmed
        /// = 1;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("confirmed")]
        public ushort Confirmed { get; set; }

        /// <summary>
        /// API name: previous
        /// 
        /// </summary>
        /// <returns>API type: block_id_type</returns>
        [JsonProperty("previous")]
        public object Previous { get; set; }

        /// <summary>
        /// API name: transaction_mroot
        /// mroot of cycles_summary
        /// </summary>
        /// <returns>API type: checksum256_type</returns>
        [JsonProperty("transaction_mroot")]
        public object TransactionMroot { get; set; }

        /// <summary>
        /// API name: action_mroot
        /// mroot of all delivered action receipts
        /// </summary>
        /// <returns>API type: checksum256_type</returns>
        [JsonProperty("action_mroot")]
        public object ActionMroot { get; set; }

        /// <summary>
        /// API name: schedule_version
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("schedule_version")]
        public uint ScheduleVersion { get; set; }

        /// <summary>
        /// API name: new_producers
        /// 
        /// </summary>
        /// <returns>API type: producer_schedule_type</returns>
        [JsonProperty("new_producers", NullValueHandling = NullValueHandling.Ignore)]
        public object NewProducers { get; set; }

        /// <summary>
        /// API name: header_extensions
        /// 
        /// </summary>
        /// <returns>API type: extensions_type</returns>
        [JsonProperty("header_extensions")]
        public object HeaderExtensions { get; set; }
    }
}
