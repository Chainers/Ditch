using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// witness_schedule_object
    /// libraries\chain\include\golos\chain\witness_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WitnessScheduleObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: current_virtual_time
        /// 
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("current_virtual_time")]
        public UInt128 CurrentVirtualTime { get; set; }

        /// <summary>
        /// API name: next_shuffle_block_num
        /// = 1;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("next_shuffle_block_num")]
        public uint NextShuffleBlockNum {get; set;}

        /// <summary>
        /// API name: current_shuffled_witnesses
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("current_shuffled_witnesses")]
        public object CurrentShuffledWitnesses { get; set; }

        /// <summary>
        /// API name: num_scheduled_witnesses
        /// = 1;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("num_scheduled_witnesses")]
        public byte NumScheduledWitnesses { get; set; }

        /// <summary>
        /// API name: top19_weight
        /// = 1;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("top19_weight")]
        public byte Top19Weight { get; set; }

        /// <summary>
        /// API name: timeshare_weight
        /// = 5;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("timeshare_weight")]
        public byte TimeshareWeight { get; set; }

        /// <summary>
        /// API name: miner_weight
        /// = 1;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("miner_weight")]
        public byte MinerWeight { get; set; }

        /// <summary>
        /// API name: witness_pay_normalization_factor
        /// = 25;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("witness_pay_normalization_factor")]
        public uint WitnessPayNormalizationFactor {get; set;}

        /// <summary>
        /// API name: median_props
        /// 
        /// </summary>
        /// <returns>API type: chain_properties</returns>
        [JsonProperty("median_props")]
        public ChainProperties MedianProps {get; set;}

        /// <summary>
        /// API name: majority_version
        /// 
        /// </summary>
        /// <returns>API type: version</returns>
        [JsonProperty("majority_version")]
        public string MajorityVersion {get; set;}
    }
}