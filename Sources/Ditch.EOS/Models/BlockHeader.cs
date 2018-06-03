using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// block_header
    /// contracts\eosio.system\eosio.system.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BlockHeader
    {
        /// <summary>
        /// API name: block_num
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("block_num")]
        public uint BlockNum { get; set; }

        /// <summary>
        /// API name: previous
        /// 
        /// </summary>
        /// <returns>API type: checksum256</returns>
        [JsonProperty("previous")]
        public string Previous { get; set; }

        /// <summary>
        /// API name: timestamp
        /// 
        /// </summary>
        /// <returns>API type: time</returns>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// API name: transaction_mroot
        /// 
        /// </summary>
        /// <returns>API type: checksum256</returns>
        [JsonProperty("transaction_mroot")]
        public string TransactionMroot { get; set; }

        /// <summary>
        /// API name: action_mroot
        /// 
        /// </summary>
        /// <returns>API type: checksum256</returns>
        [JsonProperty("action_mroot")]
        public string ActionMroot { get; set; }

        /// <summary>
        /// API name: block_mroot
        /// 
        /// </summary>
        /// <returns>API type: checksum256</returns>
        [JsonProperty("block_mroot")]
        public string BlockMroot { get; set; }

        /// <summary>
        /// API name: producer
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("producer")]
        public string Producer { get; set; }

        /// <summary>
        /// API name: schedule_version
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("schedule_version")]
        public uint ScheduleVersion { get; set; }

        /// <summary>
        /// API name: new_producers
        /// 
        /// </summary>
        /// <returns>API type: producer_schedule</returns>
        [JsonProperty("new_producers", NullValueHandling = NullValueHandling.Ignore)]
        public ProducerSchedule NewProducers { get; set; }
    }
}
