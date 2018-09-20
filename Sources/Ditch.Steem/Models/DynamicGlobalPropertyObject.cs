using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
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
    /// libraries\chain\include\steem\chain\global_property_object.hpp
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
        public string Id { get; set; }

        /// <summary>
        /// API name: head_block_number
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("head_block_number")]
        public uint HeadBlockNumber { get; set; }

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
        public TimePointSec Time { get; set; }

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
        public ulong TotalPow { get; set; }

        /// <summary>
        /// API name: num_pow_witnesses
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("num_pow_witnesses")]
        public uint NumPowWitnesses { get; set; }

        /// <summary>
        /// API name: virtual_supply
        /// = asset( 0, STEEM_SYMBOL );
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("virtual_supply")]
        public Asset VirtualSupply { get; set; }

        /// <summary>
        /// API name: current_supply
        /// = asset( 0, STEEM_SYMBOL );
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("current_supply")]
        public Asset CurrentSupply { get; set; }

        /// <summary>
        /// API name: confidential_supply
        /// = asset( 0, STEEM_SYMBOL ); ///&lt; total asset held in confidential balances
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("confidential_supply")]
        public Asset ConfidentialSupply { get; set; }

        /// <summary>
        /// API name: current_sbd_supply
        /// = asset( 0, SBD_SYMBOL );
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("current_sbd_supply")]
        public Asset CurrentSbdSupply { get; set; }

        /// <summary>
        /// API name: confidential_sbd_supply
        /// = asset( 0, SBD_SYMBOL ); ///&lt; total asset held in confidential balances
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("confidential_sbd_supply")]
        public Asset ConfidentialSbdSupply { get; set; }

        /// <summary>
        /// API name: total_vesting_fund_steem
        /// = asset( 0, STEEM_SYMBOL );
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("total_vesting_fund_steem")]
        public Asset TotalVestingFundSteem { get; set; }

        /// <summary>
        /// API name: total_vesting_shares
        /// = asset( 0, VESTS_SYMBOL );
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("total_vesting_shares")]
        public Asset TotalVestingShares { get; set; }

        /// <summary>
        /// API name: total_reward_fund_steem
        /// = asset( 0, STEEM_SYMBOL );
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
        public UInt128 TotalRewardShares2 { get; set; }

        /// <summary>
        /// API name: pending_rewarded_vesting_shares
        /// = asset( 0, VESTS_SYMBOL );
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("pending_rewarded_vesting_shares")]
        public Asset PendingRewardedVestingShares { get; set; }

        /// <summary>
        /// API name: pending_rewarded_vesting_steem
        /// = asset( 0, STEEM_SYMBOL );
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("pending_rewarded_vesting_steem")]
        public Asset PendingRewardedVestingSteem { get; set; }

        /// <summary>
        /// API name: sbd_interest_rate
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("sbd_interest_rate")]
        public ushort SbdInterestRate { get; set; }

        /// <summary>
        /// API name: sbd_print_rate
        /// = STEEM_100_PERCENT;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("sbd_print_rate")]
        public ushort SbdPrintRate { get; set; }

        /// <summary>
        /// API name: maximum_block_size
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("maximum_block_size")]
        public uint MaximumBlockSize { get; set; }

        /// <summary>
        /// API name: current_aslot
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("current_aslot")]
        public ulong CurrentAslot { get; set; }

        /// <summary>
        /// API name: recent_slots_filled
        /// 
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("recent_slots_filled")]
        public UInt128 RecentSlotsFilled { get; set; }

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
        public uint LastIrreversibleBlockNum { get; set; }

        /// <summary>
        /// API name: vote_power_reserve_rate
        /// = STEEM_INITIAL_VOTE_POWER_RATE;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("vote_power_reserve_rate")]
        public uint VotePowerReserveRate { get; set; }

        /// <summary>
        /// API name: delegation_return_period
        /// = STEEM_DELEGATION_RETURN_PERIOD_HF0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("delegation_return_period")]
        public uint DelegationReturnPeriod { get; set; }

        /// <summary>
        /// API name: reverse_auction_seconds
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("reverse_auction_seconds")]
        public ulong ReverseAuctionSeconds { get; set; }

        /// <summary>
        /// API name: available_account_subsidies
        /// = 0;
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("available_account_subsidies")]
        public long AvailableAccountSubsidies { get; set; }

        /// <summary>
        /// API name: sbd_stop_percent
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("sbd_stop_percent")]
        public ushort SbdStopPercent { get; set; }

        /// <summary>
        /// API name: sbd_start_percent
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("sbd_start_percent")]
        public ushort SbdStartPercent { get; set; }

        /// <summary>
        /// API name: smt_creation_fee
        /// = asset( 1000000, SBD_SYMBOL );
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("smt_creation_fee")]
        public Asset SmtCreationFee { get; set; }
    }
}