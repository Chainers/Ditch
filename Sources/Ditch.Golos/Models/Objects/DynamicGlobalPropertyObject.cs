using System;
using Newtonsoft.Json;
using Ditch.Golos.Models.Other;

namespace Ditch.Golos.Models.Objects
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
    /// libraries\chain\include\golos\chain\objects\global_property_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class DynamicGlobalPropertyObject
    {
        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// API name: head_block_number
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("head_block_number")]
        public UInt32 HeadBlockNumber { get; set; }

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

        /**
         *  The total POW accumulated, aka the sum of num_pow_witness at the time new POW is added
         */
        /// <summary>
        /// API name: total_pow
        /// = -1;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("total_pow")]
        public UInt64 TotalPow { get; set; }


        /**
         * The current count of how many pending POW witnesses there are, determines the difficulty
         * of doing pow
         */
        /// <summary>
        /// API name: num_pow_witnesses
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("num_pow_witnesses")]
        public UInt32 NumPowWitnesses { get; set; }

        /// <summary>
        /// API name: virtual_supply
        /// = asset&lt;0,17,0>(0, STEEM_SYMBOL_NAME);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("virtual_supply")]
        public Asset VirtualSupply { get; set; }

        /// <summary>
        /// API name: current_supply
        /// = asset&lt;0,17,0>(0, STEEM_SYMBOL_NAME);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("current_supply")]
        public Asset CurrentSupply { get; set; }

        /// <summary>
        /// API name: confidential_supply
        /// = asset&lt;0,17,0>(0, STEEM_SYMBOL_NAME); ///&lt; total asset held in confidential balances
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("confidential_supply")]
        public Asset ConfidentialSupply { get; set; }

        /// <summary>
        /// API name: current_sbd_supply
        /// = asset&lt;0,17,0>(0, SBD_SYMBOL_NAME);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("current_sbd_supply")]
        public Asset CurrentSbdSupply { get; set; }

        /// <summary>
        /// API name: confidential_sbd_supply
        /// = asset&lt;0,17,0>(0, SBD_SYMBOL_NAME); ///&lt; total asset held in confidential balances
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("confidential_sbd_supply")]
        public Asset ConfidentialSbdSupply { get; set; }

        /// <summary>
        /// API name: total_vesting_fund_steem
        /// = asset&lt;0,17,0>(0, STEEM_SYMBOL_NAME);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("total_vesting_fund_steem")]
        public Asset TotalVestingFundSteem { get; set; }

        /// <summary>
        /// API name: total_vesting_shares
        /// = asset&lt;0,17,0>(0, VESTS_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("total_vesting_shares")]
        public Asset TotalVestingShares { get; set; }

        /// <summary>
        /// API name: total_reward_fund_steem
        /// = asset&lt;0,17,0>(0, STEEM_SYMBOL_NAME);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("total_reward_fund_steem")]
        public Asset TotalRewardFundSteem { get; set; }

        /// <summary>
        /// API name: total_reward_shares2
        /// the running total of REWARD^2
        /// </summary>
        /// <returns>API type: uint128</returns>
        [JsonProperty("total_reward_shares2")]
        public string TotalRewardShares2 { get; set; }


        /**
        *  This property defines the interest rate that SBD deposits receive.
        */
        /// <summary>
        /// API name: sbd_interest_rate
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("sbd_interest_rate")]
        public UInt16 SbdInterestRate { get; set; }

        /// <summary>
        /// API name: sbd_print_rate
        /// = STEEMIT_100_PERCENT;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("sbd_print_rate")]
        public UInt16 SbdPrintRate { get; set; }


        /**
         *  Average block size is updated every block to be:
         *
         *     average_block_size = (99 * average_block_size + new_block_size) / 100
         *
         *  This property is used to update the current_reserve_ratio to maintain approximately
         *  50% or less utilization of network capacity.
         */
        /// <summary>
        /// API name: average_block_size
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("average_block_size")]
        public UInt32 AverageBlockSize { get; set; }


        /**
         *  Maximum block size is decided by the set of active witnesses which change every round.
         *  Each witness posts what they think the maximum size should be as part of their witness
         *  properties, the median size is chosen to be the maximum block size for the round.
         *
         *  @note the minimum value for maximum_block_size is defined by the protocol to prevent the
         *  network from getting stuck by witnesses attempting to set this too low.
         */
        /// <summary>
        /// API name: maximum_block_size
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("maximum_block_size")]
        public UInt32 MaximumBlockSize { get; set; }


        /**
         * The current absolute slot number.  Equal to the total
         * number of slots since genesis.  Also equal to the total
         * number of missed slots plus head_block_number.
         */
        /// <summary>
        /// API name: current_aslot
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("current_aslot")]
        public UInt64 CurrentAslot { get; set; }


        /**
         * used to compute witness participation.
         */
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
        public UInt32 LastIrreversibleBlockNum { get; set; }


        /**
         * The maximum bandwidth the blockchain can support is:
         *
         *    max_bandwidth = maximum_block_size * STEEMIT_BANDWIDTH_AVERAGE_WINDOW_SECONDS / STEEMIT_BLOCK_INTERVAL
         *
         * The maximum virtual bandwidth is:
         *
         *    max_bandwidth * current_reserve_ratio
         */
        /// <summary>
        /// API name: max_virtual_bandwidth
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("max_virtual_bandwidth")]
        public UInt64 MaxVirtualBandwidth { get; set; }


        /**
         *   Any time average_block_size <= 50% maximum_block_size this value grows by 1 until it
         *   reaches STEEMIT_MAX_RESERVE_RATIO.  Any time average_block_size is greater than
         *   50% it falls by 1%.  Upward adjustments happen once per round, downward adjustments
         *   happen every block.
         */
        /// <summary>
        /// API name: current_reserve_ratio
        /// = 1;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("current_reserve_ratio")]
        public UInt64 CurrentReserveRatio { get; set; }


        /**
         * The number of votes regenerated per day.  Any user voting slower than this rate will be
         * "wasting" voting power through spillover; any user voting faster than this rate will have
         * their votes reduced.
         */
        /// <summary>
        /// API name: vote_regeneration_per_day
        /// = 40;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("vote_regeneration_per_day")]
        public UInt32 VoteRegenerationPerDay { get; set; }
    }
}