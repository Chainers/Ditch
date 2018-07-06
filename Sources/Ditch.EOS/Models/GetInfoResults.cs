using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_info_results
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetInfoResults
    {

        /// <summary>
        /// API name: server_version
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("server_version")]
        public string ServerVersion {get; set;}

        /// <summary>
        /// API name: chain_id
        /// 
        /// </summary>
        /// <returns>API type: chain_id_type</returns>
        [JsonProperty("chain_id")]
        public string ChainId {get; set;}

        /// <summary>
        /// API name: head_block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("head_block_num")]
        public UInt32 HeadBlockNum {get; set;}

        /// <summary>
        /// API name: last_irreversible_block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("last_irreversible_block_num")]
        public UInt32 LastIrreversibleBlockNum {get; set;}

        /// <summary>
        /// API name: last_irreversible_block_id
        /// 
        /// </summary>
        /// <returns>API type: block_id_type</returns>
        [JsonProperty("last_irreversible_block_id")]
        public string LastIrreversibleBlockId { get; set; }

        /// <summary>
        /// API name: head_block_id
        /// 
        /// </summary>
        /// <returns>API type: block_id_type</returns>
        [JsonProperty("head_block_id")]
        public string HeadBlockId { get; set; }

        /// <summary>
        /// API name: head_block_time
        /// 
        /// </summary>
        /// <returns>API type: time_point</returns>
        [JsonProperty("head_block_time")]
        public TimePoint HeadBlockTime {get; set;}

        /// <summary>
        /// API name: head_block_producer
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("head_block_producer")]
        public string HeadBlockProducer {get; set;}

        /// <summary>
        /// API name: virtual_block_cpu_limit
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("virtual_block_cpu_limit")]
        public UInt64 VirtualBlockCpuLimit {get; set;}

        /// <summary>
        /// API name: virtual_block_net_limit
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("virtual_block_net_limit")]
        public UInt64 VirtualBlockNetLimit {get; set;}

        /// <summary>
        /// API name: block_cpu_limit
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("block_cpu_limit")]
        public UInt64 BlockCpuLimit {get; set;}

        /// <summary>
        /// API name: block_net_limit
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("block_net_limit")]
        public UInt64 BlockNetLimit {get; set;}
    }
}
