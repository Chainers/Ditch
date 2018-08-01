using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BlockchainParameters
    {
        [JsonProperty("max_block_net_usage")]
        public ulong MaxBlockNetUsage {get; set;}

        [JsonProperty("target_block_net_usage_pct")]
        public uint TargetBlockNetUsagePct {get; set;}

        [JsonProperty("max_transaction_net_usage")]
        public uint MaxTransactionNetUsage {get; set;}

        [JsonProperty("base_per_transaction_net_usage")]
        public uint BasePerTransactionNetUsage {get; set;}

        [JsonProperty("net_usage_leeway")]
        public uint NetUsageLeeway {get; set;}

        [JsonProperty("context_free_discount_net_usage_num")]
        public uint ContextFreeDiscountNetUsageNum {get; set;}

        [JsonProperty("context_free_discount_net_usage_den")]
        public uint ContextFreeDiscountNetUsageDen {get; set;}

        [JsonProperty("max_block_cpu_usage")]
        public uint MaxBlockCpuUsage {get; set;}

        [JsonProperty("target_block_cpu_usage_pct")]
        public uint TargetBlockCpuUsagePct {get; set;}

        [JsonProperty("max_transaction_cpu_usage")]
        public uint MaxTransactionCpuUsage {get; set;}

        [JsonProperty("min_transaction_cpu_usage")]
        public uint MinTransactionCpuUsage {get; set;}

        [JsonProperty("max_transaction_lifetime")]
        public uint MaxTransactionLifetime {get; set;}

        [JsonProperty("deferred_trx_expiration_window")]
        public uint DeferredTrxExpirationWindow {get; set;}

        [JsonProperty("max_transaction_delay")]
        public uint MaxTransactionDelay {get; set;}

        [JsonProperty("max_inline_action_size")]
        public uint MaxInlineActionSize {get; set;}

        [JsonProperty("max_inline_action_depth")]
        public ushort MaxInlineActionDepth {get; set;}

        [JsonProperty("max_authority_depth")]
        public ushort MaxAuthorityDepth {get; set;}

    }
}
