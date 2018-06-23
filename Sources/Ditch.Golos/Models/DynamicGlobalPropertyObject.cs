using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /**
     * @class dynamic_global_property_object
     * @brief Maintains global state information
     * @ingroup object
     * @ingroup implementation
     *
     * This is an implementation detail. The values here are calculated during normal chain operations and reflect the
     * current values of global blockchain properties.
     */

    /// <summary>
    /// dynamic_global_property_object
    /// libraries\chain\include\golos\chain\global_property_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DynamicGlobalPropertyObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: head_block_number
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("head_block_number")]
        public UInt32 HeadBlockNumber {get; set;}

        /// <summary>
        /// API name: head_block_id
        /// 
        /// </summary>
        /// <returns>API type: block_id_type</returns>
        [JsonProperty("head_block_id")]
        public string HeadBlockId { get; set; }

        /// <summary>
        /// API name: time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        /// <summary>
        /// API name: current_witness
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("current_witness")]
        public string CurrentWitness { get; set; }

        /// <summary>
        /// API name: total_pow
        /// = -1;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("total_pow")]
        public UInt64 TotalPow {get; set;}

        /// <summary>
        /// API name: num_pow_witnesses
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("num_pow_witnesses")]
        public UInt32 NumPowWitnesses {get; set;}

        /// <summary>
        /// API name: virtual_supply
        /// = asset(0, STEEM_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("virtual_supply")]
        public Asset VirtualSupply { get; set; }

        /// <summary>
        /// API name: current_supply
        /// = asset(0, STEEM_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("current_supply")]
        public Asset CurrentSupply { get; set; }

        /// <summary>
        /// API name: confidential_supply
        /// = asset(0, STEEM_SYMBOL); ///&lt; total asset held in confidential balances
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("confidential_supply")]
        public Asset ConfidentialSupply { get; set; }

        /// <summary>
        /// API name: current_sbd_supply
        /// = asset(0, SBD_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("current_sbd_supply")]
        public Asset CurrentSbdSupply { get; set; }

        /// <summary>
        /// API name: confidential_sbd_supply
        /// = asset(0, SBD_SYMBOL); ///&lt; total asset held in confidential balances
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("confidential_sbd_supply")]
        public Asset ConfidentialSbdSupply { get; set; }

        /// <summary>
        /// API name: total_vesting_fund_steem
        /// = asset(0, STEEM_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("total_vesting_fund_steem")]
        public Asset TotalVestingFundSteem { get; set; }

        /// <summary>
        /// API name: total_vesting_shares
        /// = asset(0, VESTS_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("total_vesting_shares")]
        public Asset TotalVestingShares { get; set; }

        /// <summary>
        /// API name: total_reward_fund_steem
        /// = asset(0, STEEM_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("total_reward_fund_steem")]
        public Asset TotalRewardFundSteem { get; set; }

        /// <summary>
        /// API name: total_reward_shares2
        /// the running total of REWARD^2
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("total_reward_shares2")]
        public string TotalRewardShares2 { get; set; }

        /// <summary>
        /// API name: sbd_interest_rate
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("sbd_interest_rate")]
        public UInt16 SbdInterestRate {get; set;}

        /// <summary>
        /// API name: sbd_print_rate
        /// = STEEMIT_100_PERCENT;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("sbd_print_rate")]
        public UInt16 SbdPrintRate {get; set;}

        /// <summary>
        /// API name: average_block_size
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("average_block_size")]
        public UInt32 AverageBlockSize {get; set;}

        /// <summary>
        /// API name: maximum_block_size
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("maximum_block_size")]
        public UInt32 MaximumBlockSize {get; set;}

        /// <summary>
        /// API name: current_aslot
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("current_aslot")]
        public UInt64 CurrentAslot {get; set;}

        /// <summary>
        /// API name: recent_slots_filled
        /// 
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("recent_slots_filled")]
        public string RecentSlotsFilled { get; set; }

        /// <summary>
        /// API name: participation_count
        /// = 0; ///&lt; Divide by 128 to compute participation percentage
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("participation_count")]
        public byte ParticipationCount { get; set; }

        /// <summary>
        /// API name: last_irreversible_block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("last_irreversible_block_num")]
        public UInt32 LastIrreversibleBlockNum {get; set;}

        /// <summary>
        /// API name: max_virtual_bandwidth
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("max_virtual_bandwidth")]
        public UInt64 MaxVirtualBandwidth {get; set;}

        /// <summary>
        /// API name: current_reserve_ratio
        /// = 1;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("current_reserve_ratio")]
        public UInt64 CurrentReserveRatio {get; set;}

        /// <summary>
        /// API name: vote_regeneration_per_day
        /// = 40;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("vote_regeneration_per_day")]
        public UInt32 VoteRegenerationPerDay {get; set;}
    }
}