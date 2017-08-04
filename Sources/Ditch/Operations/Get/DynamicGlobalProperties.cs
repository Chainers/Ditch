using System;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    /// <summary>
    /// Shows an overview of various information regarding the current state of the STEEM network.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DynamicGlobalProperties
    {
        public static readonly DynamicGlobalProperties Default = new DynamicGlobalProperties { HeadBlockId = "0000000000000000000000000000000000000000", Time = DateTime.Now, HeadBlockNumber = 0 };

        public const string Reques = "get_dynamic_global_properties";

        //id_type
        [JsonProperty("id")]
        public string Id { get; set; }

        //uint32_t
        [JsonProperty("head_block_number")]
        public UInt32 HeadBlockNumber { get; set; }

        //block_id_type
        [JsonProperty("head_block_id")]
        public string HeadBlockId { get; set; }

        //time_point_sec
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        //account_name_type
        [JsonProperty("current_witness")]
        public string CurrentWitness { get; set; }

        //uint64_t
        [JsonProperty("total_pow")]
        public UInt64 TotalPow { get; set; }

        //uint32_t
        [JsonProperty("num_pow_witnesses")]
        public UInt32 NumPowWitnesses { get; set; }

        //asset( 0, STEEM_SYMBOL )
        [JsonProperty("virtual_supply")]
        public Money VirtualSupply { get; set; }

        //asset( 0, STEEM_SYMBOL )
        [JsonProperty("current_supply")]
        public Money CurrentSupply { get; set; }

        //asset( 0, STEEM_SYMBOL )
        [JsonProperty("confidential_supply")]
        public Money ConfidentialSupply { get; set; }

        //asset( 0, SBD_SYMBOL )
        [JsonProperty("current_sbd_supply")]
        public Money CurrentSbdSupply { get; set; }

        //asset( 0, SBD_SYMBOL )
        [JsonProperty("confidential_sbd_supply")]
        public Money ConfidentialSbdSupply { get; set; }

        //asset( 0, STEEM_SYMBOL )
        [JsonProperty("total_vesting_fund_steem")]
        public Money TotalVestingFundSteem { get; set; }

        //asset( 0, VESTS_SYMBOL )
        [JsonProperty("total_vesting_shares")]
        public Money TotalVestingShares { get; set; }

        //asset( 0, STEEM_SYMBOL )
        [JsonProperty("total_reward_fund_steem")]
        public Money TotalRewardFundSteem { get; set; }

        //uint128
        [JsonProperty("total_reward_shares2")]
        public string TotalRewardShares2 { get; set; }

        //asset(0, VESTS_SYMBOL);
        [JsonProperty("pending_rewarded_vesting_shares")]
        public Money PendingRewardedVestingShares { get; set; }

        //asset(0, STEEM_SYMBOL);
        [JsonProperty("pending_rewarded_vesting_steem")]
        public Money PendingRewardedVestingSteem { get; set; }

        //uint16_t
        [JsonProperty("sbd_interest_rate")]
        public UInt16 SbdInterestRate { get; set; }

        //uint16_t
        [JsonProperty("sbd_print_rate")]
        public UInt16 SbdPrintRate { get; set; }

        //uint32_t
        [JsonProperty("average_block_size")]
        public UInt32 AverageBlockSize { get; set; }

        //uint32_t
        [JsonProperty("maximum_block_size")]
        public UInt32 MaximumBlockSize { get; set; }

        //uint64_t
        [JsonProperty("current_aslot")]
        public UInt64 CurrentAslot { get; set; }

        //uint128_t
        [JsonProperty("recent_slots_filled")]
        public string RecentSlotsFilled { get; set; }

        //uint8_t
        [JsonProperty("participation_count")]
        public byte ParticipationCount { get; set; }

        //uint32_t 
        [JsonProperty("last_irreversible_block_num")]
        public UInt32 LastIrreversibleBlockNum { get; set; }

        //uint64_t
        [JsonProperty("max_virtual_bandwidthv")]
        public UInt64 MaxVirtualBandwidthv { get; set; }

        //uint64_t
        [JsonProperty("current_reserve_ratio")]
        public UInt64 CurrentReserveRatio { get; set; }

        //uint32_t
        [JsonProperty("vote_regeneration_per_day")]
        public UInt32 VoteRegenerationPerDay { get; set; }
    }
}