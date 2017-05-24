using System;
using Newtonsoft.Json;

namespace Ditch.JsonRpc
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DynamicGlobalProperties
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("head_block_number")]
        public int HeadBlockNumber { get; set; }

        [JsonProperty("head_block_id")]
        public string HeadBlockId { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("current_witness")]
        public string CurrentWitness { get; set; }

        [JsonProperty("total_pow")]
        public int TotalPow { get; set; }

        [JsonProperty("num_pow_witnessesv")]
        public int NumPowWitnessesv { get; set; }

        [JsonProperty("virtual_supply")]
        public string VirtualSupply { get; set; }

        [JsonProperty("current_supply")]
        public string CurrentSupply { get; set; }

        [JsonProperty("confidential_supply")]
        public string ConfidentialSupply { get; set; }

        [JsonProperty("current_sbd_supply")]
        public string CurrentSbdSupply { get; set; }

        [JsonProperty("confidential_sbd_supply")]
        public string ConfidentialSbdSupply { get; set; }

        [JsonProperty("total_vesting_fund_steem")]
        public string TotalVestingFundSteem { get; set; }

        [JsonProperty("total_vesting_shares")]
        public string TotalVestingShares { get; set; }

        [JsonProperty("total_reward_fund_steem")]
        public string TotalRewardFundSteem { get; set; }

        [JsonProperty("total_reward_shares2")]
        public string TotalRewardShares2 { get; set; }

        [JsonProperty("sbd_interest_rate")]
        public int SbdInterestRate { get; set; }

        [JsonProperty("sbd_print_rate")]
        public int SbdPrintRate { get; set; }

        [JsonProperty("average_block_size")]
        public int AverageBlockSize { get; set; }

        [JsonProperty("maximum_block_size")]
        public int MaximumBlockSize { get; set; }

        [JsonProperty("current_aslot")]
        public int CurrentAslot { get; set; }

        [JsonProperty("recent_slots_filled")]
        public string RecentSlotsFilled { get; set; }

        [JsonProperty("participation_count")]
        public int ParticipationCount { get; set; }

        [JsonProperty("last_irreversible_block_num")]
        public int LastIrreversibleBlockNum { get; set; }

        [JsonProperty("max_virtual_bandwidthv")]
        public string MaxVirtualBandwidthv { get; set; }

        [JsonProperty("current_reserve_ratio")]
        public int CurrentReserveRatio { get; set; }

        [JsonProperty("vote_regeneration_per_day")]
        public int VoteRegenerationPerDay { get; set; }
    }
}
