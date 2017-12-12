using System;
using Ditch.Steem.Dtos;
using Newtonsoft.Json;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// witness_schedule_object
    /// steem-0.19.1\libraries\chain\include\steemit\chain\witness_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WitnessScheduleObject
    {

        // bdType : id_type
        [JsonProperty("id")]
        public object Id { get; set; }

        // bdType : uint128
        [JsonProperty("current_virtual_time")]
        public string CurrentVirtualTime { get; set; }

        // bdType : uint32_t | = 1;
        [JsonProperty("next_shuffle_block_num")]
        public UInt32 NextShuffleBlockNum { get; set; }

        // bdType : array<account_name_type,steemit_max_witnesses>
        [JsonProperty("current_shuffled_witnesses")]
        public object CurrentShuffledWitnesses { get; set; }

        // bdType : uint8_t | = 1;
        [JsonProperty("num_scheduled_witnesses")]
        public byte NumScheduledWitnesses { get; set; }

        // bdType : uint8_t | = 1;
        [JsonProperty("top19_weight")]
        public byte Top19Weight { get; set; }

        // bdType : uint8_t | = 5;
        [JsonProperty("timeshare_weight")]
        public byte TimeshareWeight { get; set; }

        // bdType : uint8_t | = 1;
        [JsonProperty("miner_weight")]
        public byte MinerWeight { get; set; }

        // bdType : uint32_t | = 25;
        [JsonProperty("witness_pay_normalization_factor")]
        public UInt32 WitnessPayNormalizationFactor { get; set; }

        // bdType : chain_properties
        [JsonProperty("median_props")]
        public ChainProperties MedianProps { get; set; }

        // bdType : version
        [JsonProperty("majority_version")]
        public string MajorityVersion { get; set; }

        // bdType : uint8_t | = steemit_max_voted_witnesses_hf0;
        [JsonProperty("max_voted_witnesses")]
        public byte MaxVotedWitnesses { get; set; }

        // bdType : uint8_t | = steemit_max_miner_witnesses_hf0;
        [JsonProperty("max_miner_witnesses")]
        public byte MaxMinerWitnesses { get; set; }

        // bdType : uint8_t | = steemit_max_runner_witnesses_hf0;
        [JsonProperty("max_runner_witnesses")]
        public byte MaxRunnerWitnesses { get; set; }

        // bdType : uint8_t | = steemit_hardfork_required_witnesses;
        [JsonProperty("hardfork_required_witnesses")]
        public byte HardforkRequiredWitnesses { get; set; }
    }
}