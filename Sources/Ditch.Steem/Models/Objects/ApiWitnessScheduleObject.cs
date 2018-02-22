using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// api_witness_schedule_object
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ApiWitnessScheduleObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: witness_schedule_id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: current_virtual_time
        /// 
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("current_virtual_time")]
        public string CurrentVirtualTime {get; set;}

        /// <summary>
        /// API name: next_shuffle_block_num
        /// = 1;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("next_shuffle_block_num")]
        public UInt32 NextShuffleBlockNum {get; set;}

        /// <summary>
        /// API name: current_shuffled_witnesses
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("current_shuffled_witnesses")]
        public string[] CurrentShuffledWitnesses {get; set;}

        /// <summary>
        /// API name: num_scheduled_witnesses
        /// = 1;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("num_scheduled_witnesses")]
        public byte NumScheduledWitnesses {get; set;}

        /// <summary>
        /// API name: top19_weight
        /// = 1;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("top19_weight")]
        public byte Top19Weight {get; set;}

        /// <summary>
        /// API name: timeshare_weight
        /// = 5;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("timeshare_weight")]
        public byte TimeshareWeight {get; set;}

        /// <summary>
        /// API name: miner_weight
        /// = 1;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("miner_weight")]
        public byte MinerWeight {get; set;}

        /// <summary>
        /// API name: witness_pay_normalization_factor
        /// = 25;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("witness_pay_normalization_factor")]
        public UInt32 WitnessPayNormalizationFactor {get; set;}

        /// <summary>
        /// API name: median_props
        /// 
        /// </summary>
        /// <returns>API type: legacy_chain_properties</returns>
        [JsonProperty("median_props")]
        public LegacyChainProperties MedianProps {get; set;}

        /// <summary>
        /// API name: majority_version
        /// 
        /// </summary>
        /// <returns>API type: version</returns>
        [JsonProperty("majority_version")]
        public Version MajorityVersion {get; set;}

        /// <summary>
        /// API name: max_voted_witnesses
        /// = STEEM_MAX_VOTED_WITNESSES_HF0;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("max_voted_witnesses")]
        public byte MaxVotedWitnesses {get; set;}

        /// <summary>
        /// API name: max_miner_witnesses
        /// = STEEM_MAX_MINER_WITNESSES_HF0;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("max_miner_witnesses")]
        public byte MaxMinerWitnesses {get; set;}

        /// <summary>
        /// API name: max_runner_witnesses
        /// = STEEM_MAX_RUNNER_WITNESSES_HF0;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("max_runner_witnesses")]
        public byte MaxRunnerWitnesses {get; set;}

        /// <summary>
        /// API name: hardfork_required_witnesses
        /// = STEEM_HARDFORK_REQUIRED_WITNESSES;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("hardfork_required_witnesses")]
        public byte HardforkRequiredWitnesses {get; set;}
    }
}
