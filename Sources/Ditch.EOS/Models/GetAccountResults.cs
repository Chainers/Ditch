using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_account_results
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetAccountResults
    {
        /// <summary>
        /// API name: account_name
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// API name: head_block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("head_block_num")]
        public uint HeadBlockNum { get; set; }

        /// <summary>
        /// API name: head_block_time
        /// 
        /// </summary>
        /// <returns>API type: time_point</returns>
        [JsonProperty("head_block_time")]
        public TimePoint HeadBlockTime { get; set; }

        /// <summary>
        /// API name: privileged
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("privileged")]
        public bool Privileged { get; set; }

        /// <summary>
        /// API name: last_code_update
        /// 
        /// </summary>
        /// <returns>API type: time_point</returns>
        [JsonProperty("last_code_update")]
        public TimePoint LastCodeUpdate { get; set; }

        /// <summary>
        /// API name: created
        /// 
        /// </summary>
        /// <returns>API type: time_point</returns>
        [JsonProperty("created")]
        public TimePoint Created { get; set; }

        /// <summary>
        /// API name: core_liquid_balance
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("core_liquid_balance", NullValueHandling = NullValueHandling.Ignore)]
        public Asset CoreLiquidBalance { get; set; }

        /// <summary>
        /// API name: ram_quota
        /// = 0;
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("ram_quota")]
        public long RamQuota { get; set; }

        /// <summary>
        /// API name: net_weight
        /// = 0;
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("net_weight")]
        public long NetWeight { get; set; }

        /// <summary>
        /// API name: cpu_weight
        /// = 0;
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("cpu_weight")]
        public long CpuWeight { get; set; }

        /// <summary>
        /// API name: net_limit
        /// 
        /// </summary>
        /// <returns>API type: account_resource_limit</returns>
        [JsonProperty("net_limit")]
        public AccountResourceLimit NetLimit { get; set; }

        /// <summary>
        /// API name: cpu_limit
        /// 
        /// </summary>
        /// <returns>API type: account_resource_limit</returns>
        [JsonProperty("cpu_limit")]
        public AccountResourceLimit CpuLimit { get; set; }

        /// <summary>
        /// API name: ram_usage
        /// = 0;
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("ram_usage")]
        public long RamUsage { get; set; }

        /// <summary>
        /// API name: permissions
        /// 
        /// </summary>
        /// <returns>API type: permission</returns>
        [JsonProperty("permissions")]
        public Permission[] Permissions { get; set; }

        /// <summary>
        /// API name: total_resources
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("total_resources")]
        public object TotalResources { get; set; }

        /// <summary>
        /// API name: self_delegated_bandwidth
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("self_delegated_bandwidth")]
        public object SelfDelegatedBandwidth { get; set; }

        /// <summary>
        /// API name: refund_request
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("refund_request")]
        public object RefundRequest { get; set; }

        /// <summary>
        /// API name: voter_info
        /// 
        /// </summary>
        /// <returns>API type: variant</returns>
        [JsonProperty("voter_info")]
        public object VoterInfo { get; set; }
    }
}
