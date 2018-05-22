using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// chain_parameters
    /// libraries\chain\include\graphene\chain\protocol\chain_parameters.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ChainParameters
    {

        /** using a smart ref breaks the circular dependency created between operations and the fee schedule */

        /// <summary>
        /// API name: current_fees
        /// current schedule of fees
        /// </summary>
        /// <returns>API type: smart_ref</returns>
        [JsonProperty("current_fees")]
        public FeeSchedule[] CurrentFees { get; set; }

        /// <summary>
        /// API name: block_interval
        /// = GRAPHENE_DEFAULT_BLOCK_INTERVAL; ///&lt; interval in seconds between blocks
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("block_interval")]
        public byte BlockInterval { get; set; }

        /// <summary>
        /// API name: maintenance_interval
        /// = GRAPHENE_DEFAULT_MAINTENANCE_INTERVAL; ///&lt; interval in sections between blockchain maintenance events
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("maintenance_interval")]
        public UInt32 MaintenanceInterval { get; set; }

        /// <summary>
        /// API name: maintenance_skip_slots
        /// = GRAPHENE_DEFAULT_MAINTENANCE_SKIP_SLOTS; ///&lt; number of block_intervals to skip at maintenance time
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("maintenance_skip_slots")]
        public byte MaintenanceSkipSlots { get; set; }

        /// <summary>
        /// API name: committee_proposal_review_period
        /// = GRAPHENE_DEFAULT_COMMITTEE_PROPOSAL_REVIEW_PERIOD_SEC; ///&lt; minimum time in seconds that a proposed transaction requiring committee authority may not be signed, prior to expiration
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("committee_proposal_review_period")]
        public UInt32 CommitteeProposalReviewPeriod { get; set; }

        /// <summary>
        /// API name: maximum_transaction_size
        /// = GRAPHENE_DEFAULT_MAX_TRANSACTION_SIZE; ///&lt; maximum allowable size in bytes for a transaction
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("maximum_transaction_size")]
        public UInt32 MaximumTransactionSize { get; set; }

        /// <summary>
        /// API name: maximum_block_size
        /// = GRAPHENE_DEFAULT_MAX_BLOCK_SIZE; ///&lt; maximum allowable size in bytes for a block
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("maximum_block_size")]
        public UInt32 MaximumBlockSize { get; set; }

        /// <summary>
        /// API name: maximum_time_until_expiration
        /// = GRAPHENE_DEFAULT_MAX_TIME_UNTIL_EXPIRATION; ///&lt; maximum lifetime in seconds for transactions to be valid, before expiring
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("maximum_time_until_expiration")]
        public UInt32 MaximumTimeUntilExpiration { get; set; }

        /// <summary>
        /// API name: maximum_proposal_lifetime
        /// = GRAPHENE_DEFAULT_MAX_PROPOSAL_LIFETIME_SEC; ///&lt; maximum lifetime in seconds for proposed transactions to be kept, before expiring
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("maximum_proposal_lifetime")]
        public UInt32 MaximumProposalLifetime { get; set; }

        /// <summary>
        /// API name: maximum_asset_whitelist_authorities
        /// = GRAPHENE_DEFAULT_MAX_ASSET_WHITELIST_AUTHORITIES; ///&lt; maximum number of accounts which an asset may list as authorities for its whitelist OR blacklist
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("maximum_asset_whitelist_authorities")]
        public byte MaximumAssetWhitelistAuthorities { get; set; }

        /// <summary>
        /// API name: maximum_asset_feed_publishers
        /// = GRAPHENE_DEFAULT_MAX_ASSET_FEED_PUBLISHERS; ///&lt; the maximum number of feed publishers for a given asset
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("maximum_asset_feed_publishers")]
        public byte MaximumAssetFeedPublishers { get; set; }

        /// <summary>
        /// API name: maximum_witness_count
        /// = GRAPHENE_DEFAULT_MAX_WITNESSES; ///&lt; maximum number of active witnesses
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("maximum_witness_count")]
        public UInt16 MaximumWitnessCount { get; set; }

        /// <summary>
        /// API name: maximum_committee_count
        /// = GRAPHENE_DEFAULT_MAX_COMMITTEE; ///&lt; maximum number of active committee_members
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("maximum_committee_count")]
        public UInt16 MaximumCommitteeCount { get; set; }

        /// <summary>
        /// API name: maximum_authority_membership
        /// = GRAPHENE_DEFAULT_MAX_AUTHORITY_MEMBERSHIP; ///&lt; largest number of keys/accounts an authority can have
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("maximum_authority_membership")]
        public UInt16 MaximumAuthorityMembership { get; set; }

        /// <summary>
        /// API name: reserve_percent_of_fee
        /// = GRAPHENE_DEFAULT_BURN_PERCENT_OF_FEE; ///&lt; the percentage of the network's allocation of a fee that is taken out of circulation
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("reserve_percent_of_fee")]
        public UInt16 ReservePercentOfFee { get; set; }

        /// <summary>
        /// API name: network_percent_of_fee
        /// = GRAPHENE_DEFAULT_NETWORK_PERCENT_OF_FEE; ///&lt; percent of transaction fees paid to network
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("network_percent_of_fee")]
        public UInt16 NetworkPercentOfFee { get; set; }

        /// <summary>
        /// API name: lifetime_referrer_percent_of_fee
        /// = GRAPHENE_DEFAULT_LIFETIME_REFERRER_PERCENT_OF_FEE; ///&lt; percent of transaction fees paid to network
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("lifetime_referrer_percent_of_fee")]
        public UInt16 LifetimeReferrerPercentOfFee { get; set; }

        /// <summary>
        /// API name: cashback_vesting_period_seconds
        /// = GRAPHENE_DEFAULT_CASHBACK_VESTING_PERIOD_SEC; ///&lt; time after cashback rewards are accrued before they become liquid
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("cashback_vesting_period_seconds")]
        public UInt32 CashbackVestingPeriodSeconds { get; set; }

        /// <summary>
        /// API name: cashback_vesting_threshold
        /// = GRAPHENE_DEFAULT_CASHBACK_VESTING_THRESHOLD; ///&lt; the maximum cashback that can be received without vesting
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("cashback_vesting_threshold")]
        public object CashbackVestingThreshold { get; set; }

        /// <summary>
        /// API name: count_non_member_votes
        /// = true; ///&lt; set to false to restrict voting privlegages to member accounts
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("count_non_member_votes")]
        public bool CountNonMemberVotes { get; set; }

        /// <summary>
        /// API name: allow_non_member_whitelists
        /// = false; ///&lt; true if non-member accounts may set whitelists and blacklists; false otherwise
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("allow_non_member_whitelists")]
        public bool AllowNonMemberWhitelists { get; set; }

        /// <summary>
        /// API name: witness_pay_per_block
        /// = GRAPHENE_DEFAULT_WITNESS_PAY_PER_BLOCK; ///&lt; CORE to be allocated to witnesses (per block)
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("witness_pay_per_block")]
        public object WitnessPayPerBlock { get; set; }

        /// <summary>
        /// API name: witness_pay_vesting_seconds
        /// = GRAPHENE_DEFAULT_WITNESS_PAY_VESTING_SECONDS; ///&lt; vesting_seconds parameter for witness VBO's
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("witness_pay_vesting_seconds")]
        public UInt32 WitnessPayVestingSeconds { get; set; }

        /// <summary>
        /// API name: worker_budget_per_day
        /// = GRAPHENE_DEFAULT_WORKER_BUDGET_PER_DAY; ///&lt; CORE to be allocated to workers (per day)
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("worker_budget_per_day")]
        public object WorkerBudgetPerDay { get; set; }

        /// <summary>
        /// API name: max_predicate_opcode
        /// = GRAPHENE_DEFAULT_MAX_ASSERT_OPCODE; ///&lt; predicate_opcode must be less than this number
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("max_predicate_opcode")]
        public UInt16 MaxPredicateOpcode { get; set; }

        /// <summary>
        /// API name: fee_liquidation_threshold
        /// = GRAPHENE_DEFAULT_FEE_LIQUIDATION_THRESHOLD; ///&lt; value in CORE at which accumulated fees in blockchain-issued market assets should be liquidated
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("fee_liquidation_threshold")]
        public object FeeLiquidationThreshold { get; set; }

        /// <summary>
        /// API name: accounts_per_fee_scale
        /// = GRAPHENE_DEFAULT_ACCOUNTS_PER_FEE_SCALE; ///&lt; number of accounts between fee scalings
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("accounts_per_fee_scale")]
        public UInt16 AccountsPerFeeScale { get; set; }

        /// <summary>
        /// API name: account_fee_scale_bitshifts
        /// = GRAPHENE_DEFAULT_ACCOUNT_FEE_SCALE_BITSHIFTS; ///&lt; number of times to left bitshift account registration fee at each scaling
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("account_fee_scale_bitshifts")]
        public byte AccountFeeScaleBitshifts { get; set; }

        /// <summary>
        /// API name: max_authority_depth
        /// = GRAPHENE_MAX_SIG_CHECK_DEPTH;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("max_authority_depth")]
        public byte MaxAuthorityDepth { get; set; }

        /// <summary>
        /// API name: extensions
        /// 
        /// </summary>
        /// <returns>API type: extensions_type</returns>
        [JsonProperty("extensions")]
        public object[] Extensions { get; set; }
    }
}
