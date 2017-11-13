using System;
using Ditch.Core;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations.Get
{
    /// <summary>
    /// Shows an overview of various information regarding the current state of the STEEM network.
    /// dynamic_global_property_object
    /// golos-0.16.3\libraries\chain\include\steemit\chain\global_property_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DynamicGlobalPropertyObject
    {
        // bdType : id_type
        [JsonProperty("id")]
        public string Id { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("head_block_number")]
        public UInt32 HeadBlockNumber { get; set; }

        //block_id_type
        [JsonProperty("head_block_id")]
        public string HeadBlockId { get; set; }

        // bdType : time_point_sec
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        // bdType : account_name_type
        [JsonProperty("current_witness")]
        public string CurrentWitness { get; set; }

        // bdType : uint64_t | = -1;
        [JsonProperty("total_pow")]
        public UInt64 TotalPow { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("num_pow_witnesses")]
        public UInt32 NumPowWitnesses { get; set; }

        // bdType : asset | = asset(0, steem_symbol);
        [JsonProperty("virtual_supply")]
        public Money VirtualSupply { get; set; }

        // bdType : asset | = asset(0, steem_symbol);
        [JsonProperty("current_supply")]
        public Money CurrentSupply { get; set; }

        // bdType : asset | = asset(0, steem_symbol); 
        /// <summary>
        /// total asset held in confidential balances
        /// </summary>
        [JsonProperty("confidential_supply")]
        public Money ConfidentialSupply { get; set; }

        // bdType : asset | = asset(0, sbd_symbol);
        [JsonProperty("current_sbd_supply")]
        public Money CurrentSbdSupply { get; set; }

        // bdType : asset | = asset(0, sbd_symbol); 
        /// <summary>
        /// total asset held in confidential balances
        /// </summary>
        [JsonProperty("confidential_sbd_supply")]
        public Money ConfidentialSbdSupply { get; set; }

        // bdType : asset | = asset(0, steem_symbol);
        [JsonProperty("total_vesting_fund_steem")]
        public Money TotalVestingFundSteem { get; set; }

        // bdType : asset | = asset(0, vests_symbol);
        [JsonProperty("total_vesting_shares")]
        public Money TotalVestingShares { get; set; }

        // bdType : asset | = asset(0, steem_symbol);
        [JsonProperty("total_reward_fund_steem")]
        public Money TotalRewardFundSteem { get; set; }

        //uint128
        [JsonProperty("total_reward_shares2")]
        public string TotalRewardShares2 { get; set; }

        // bdType : asset | = asset( 0, vests_symbol );
        [JsonProperty("pending_rewarded_vesting_shares")]
        public Money PendingRewardedVestingShares { get; set; }

        // bdType : asset | = asset( 0, steem_symbol );
        [JsonProperty("pending_rewarded_vesting_steem")]
        public Money PendingRewardedVestingSteem { get; set; }

        // bdType : uint16_t | = 0;
        [JsonProperty("sbd_interest_rate")]
        public UInt16 SbdInterestRate { get; set; }

        // bdType : uint16_t | = steemit_100_percent;
        [JsonProperty("sbd_print_rate")]
        public UInt16 SbdPrintRate { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("average_block_size")]
        public UInt32 AverageBlockSize { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("maximum_block_size")]
        public UInt32 MaximumBlockSize { get; set; }

        // bdType : uint64_t | = 0;
        [JsonProperty("current_aslot")]
        public UInt64 CurrentAslot { get; set; }

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
        public UInt32 LastIrreversibleBlockNum { get; set; }

        // bdType : uint64_t | = 0;
        [JsonProperty("max_virtual_bandwidth")]
        public UInt64 MaxVirtualBandwidth { get; set; }

        // bdType : uint64_t | = 1;
        [JsonProperty("current_reserve_ratio")]
        public UInt64 CurrentReserveRatio { get; set; }

        // bdType : uint32_t | = 40;
        [JsonProperty("vote_regeneration_per_day")]
        public UInt32 VoteRegenerationPerDay { get; set; }

        // bdType : uint32_t | = 40;
        [JsonProperty("vote_power_reserve_rate")]
        public UInt32 VotePowerReserveRate { get; set; }
    }
}