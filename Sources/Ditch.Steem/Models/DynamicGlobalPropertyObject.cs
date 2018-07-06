using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// Shows an overview of various information regarding the current state of the STEEM network.
    /// dynamic_global_property_object
    /// steem-0.19.1\libraries\chain\include\steemit\chain\global_property_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DynamicGlobalPropertyObject
    {
        // bdType : id_type
        [JsonProperty("id")]
        public string Id { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("head_block_number")]
        public uint HeadBlockNumber { get; set; }

        //block_id_type
        [JsonProperty("head_block_id")]
        public string HeadBlockId { get; set; }

        // bdType : time_point_sec
        [JsonProperty("time")]
        public TimePointSec Time { get; set; }

        // bdType : account_name_type
        [JsonProperty("current_witness")]
        public string CurrentWitness { get; set; }

        // bdType : uint64_t | = -1;
        [JsonProperty("total_pow")]
        public ulong TotalPow { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("num_pow_witnesses")]
        public uint NumPowWitnesses { get; set; }

        // bdType : asset | = asset(0, steem_symbol);
        [JsonProperty("virtual_supply")]
        public Asset VirtualSupply { get; set; }

        // bdType : asset | = asset(0, steem_symbol);
        [JsonProperty("current_supply")]
        public Asset CurrentSupply { get; set; }

        // bdType : asset | = asset(0, steem_symbol); 
        /// <summary>
        /// total asset held in confidential balances
        /// </summary>
        [JsonProperty("confidential_supply")]
        public Asset ConfidentialSupply { get; set; }

        // bdType : asset | = asset(0, sbd_symbol);
        [JsonProperty("current_sbd_supply")]
        public Asset CurrentSbdSupply { get; set; }

        // bdType : asset | = asset(0, sbd_symbol); 
        /// <summary>
        /// total asset held in confidential balances
        /// </summary>
        [JsonProperty("confidential_sbd_supply")]
        public Asset ConfidentialSbdSupply { get; set; }

        // bdType : asset | = asset(0, steem_symbol);
        [JsonProperty("total_vesting_fund_steem")]
        public Asset TotalVestingFundSteem { get; set; }

        // bdType : asset | = asset(0, vests_symbol);
        [JsonProperty("total_vesting_shares")]
        public Asset TotalVestingShares { get; set; }

        // bdType : asset | = asset(0, steem_symbol);
        [JsonProperty("total_reward_fund_steem")]
        public Asset TotalRewardFundSteem { get; set; }

        //uint128
        [JsonProperty("total_reward_shares2")]
        public string TotalRewardShares2 { get; set; }

        // bdType : asset | = asset( 0, vests_symbol );
        [JsonProperty("pending_rewarded_vesting_shares")]
        public Asset PendingRewardedVestingShares { get; set; }

        // bdType : asset | = asset( 0, steem_symbol );
        [JsonProperty("pending_rewarded_vesting_steem")]
        public Asset PendingRewardedVestingSteem { get; set; }

        // bdType : uint16_t | = 0;
        [JsonProperty("sbd_interest_rate")]
        public ushort SbdInterestRate { get; set; }

        // bdType : uint16_t | = steemit_100_percent;
        [JsonProperty("sbd_print_rate")]
        public ushort SbdPrintRate { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("average_block_size")]
        public uint AverageBlockSize { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("maximum_block_size")]
        public uint MaximumBlockSize { get; set; }

        // bdType : uint64_t | = 0;
        [JsonProperty("current_aslot")]
        public ulong CurrentAslot { get; set; }

        //uint128_t
        [JsonProperty("recent_slots_filled")]
        public string RecentSlotsFilled { get; set; }

        // bdType : uint8_t | = 0; 
        /// <summary>
        /// divide by 128 to compute participation percentage
        /// </summary>
        [JsonProperty("participation_count")]
        public byte ParticipationCount { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("last_irreversible_block_num")]
        public uint LastIrreversibleBlockNum { get; set; }

        // bdType : uint64_t | = 0;
        [JsonProperty("max_virtual_bandwidth")]
        public ulong MaxVirtualBandwidth { get; set; }

        // bdType : uint64_t | = 1;
        [JsonProperty("current_reserve_ratio")]
        public ulong CurrentReserveRatio { get; set; }

        // bdType : uint32_t | = 40;
        [JsonProperty("vote_regeneration_per_day")]
        public uint VoteRegenerationPerDay { get; set; }

        // bdType : uint32_t | = 40;
        [JsonProperty("vote_power_reserve_rate")]
        public uint VotePowerReserveRate { get; set; }
    }
}