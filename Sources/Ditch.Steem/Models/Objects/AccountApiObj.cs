using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// account_api_obj
    /// steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AccountApiObj
    {
        // bdType : account_id_type
        [JsonProperty("id")]
        public UInt64 Id { get; set; }

        // bdType : account_name_type
        [JsonProperty("name")]
        public string Name { get; set; }

        // bdType : authority
        /// <summary>
        /// used for backup control, can set owner or active
        /// </summary>
        [Obsolete("used in v0.19.1")]
        [JsonProperty("owner")]
        public Authority Owner { get; set; }

        // bdType : authority
        /// <summary>
        /// used for all monetary operations, can set active or posting
        /// </summary>
        [Obsolete("used in v0.19.1")]
        [JsonProperty("active")]
        public Authority Active { get; set; }

        // bdType : authority
        /// <summary>
        /// used for voting and posting
        /// </summary>
        [Obsolete("used in v0.19.1")]
        [JsonProperty("posting")]
        public Authority Posting { get; set; }

        // bdType : public_key_type
        [JsonProperty("memo_key")]
        public PublicKeyType MemoKey { get; set; }

        // bdType : string
        [JsonProperty("json_metadata")]
        public string JsonMetadata { get; set; }

        // bdType : account_name_type
        [JsonProperty("proxy")]
        public string Proxy { get; set; }

        // bdType : time_point_sec
        [Obsolete("used in v0.19.1")]
        [JsonProperty("last_owner_update")]
        public DateTime LastOwnerUpdate { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_account_update")]
        public DateTime LastAccountUpdate { get; set; }

        // bdType : time_point_sec
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        // bdType : bool | = false;
        [JsonProperty("mined")]
        public bool Mined { get; set; }

        // bdType : bool | = false;
        [JsonProperty("owner_challenged")]
        public bool OwnerChallenged { get; set; }

        // bdType : bool | = false;
        [JsonProperty("active_challenged")]
        public bool ActiveChallenged { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_owner_proved")]
        public DateTime LastOwnerProved { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_active_proved")]
        public DateTime LastActiveProved { get; set; }

        // bdType : account_name_type
        [JsonProperty("recovery_account")]
        public string RecoveryAccount { get; set; }

        // bdType : account_name_type
        [JsonProperty("reset_account")]
        public string ResetAccount { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_account_recovery")]
        public DateTime LastAccountRecovery { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("comment_count")]
        public UInt32 CommentCount { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("lifetime_vote_count")]
        public UInt32 LifetimeVoteCount { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("post_count")]
        public UInt32 PostCount { get; set; }

        // bdType : bool | = false;
        [JsonProperty("can_vote")]
        public bool CanVote { get; set; }

        // bdType : uint16_t | = 0;
        /// <summary>
        /// Current voting power of this account, it falls after every vote
        /// </summary>
        [JsonProperty("voting_power")]
        public UInt16 VotingPower { get; set; }

        // bdType : time_point_sec
        /// <summary>
        /// used to increase the voting power of this account the longer it goes without voting.
        /// </summary>
        [JsonProperty("last_vote_time")]
        public DateTime LastVoteTime { get; set; }

        // bdType : asset
        /// <summary>
        /// total liquid shares held by this account
        /// </summary>
        [JsonProperty("balance")]
        public Asset Balance { get; set; }

        // bdType : asset
        /// <summary>
        /// total liquid shares held by this account
        /// </summary>
        [JsonProperty("savings_balance")]
        public Asset SavingsBalance { get; set; }


        /**
        *  SBD Deposits pay interest based upon the interest rate set by witnesses. The purpose of these
        *  fields is to track the total (time * sbd_balance) that it is held. Then at the appointed time
        *  interest can be paid using the following equation:
        *
        *  interest = interest_rate * sbd_seconds / seconds_per_year
        *
        *  Every time the sbd_balance is updated the sbd_seconds is also updated. If at least
        *  STEEMIT_MIN_COMPOUNDING_INTERVAL_SECONDS has past since sbd_last_interest_payment then
        *  interest is added to sbd_balance.
        *
        *  @defgroup sbd_data sbd Balance Data
        */

        // bdType : asset
        /// <summary>
        /// Total sbd balance
        /// </summary>
        [JsonProperty("sbd_balance")]
        public Asset SbdBalance { get; set; }

        // bdType : uint128_t
        /// <summary>
        /// Total sbd * how long it has been hel
        /// </summary>
        [JsonProperty("sbd_seconds")]
        public string SbdSeconds { get; set; }

        // bdType : time_point_sec
        /// <summary>
        /// the last time the sbd_seconds was updated
        /// </summary>
        [JsonProperty("sbd_seconds_last_update")]
        public DateTime SbdSecondsLastUpdate { get; set; }

        // bdType : time_point_sec
        /// <summary>
        /// used to pay interest at most once per month
        /// </summary>
        [JsonProperty("sbd_last_interest_payment")]
        public DateTime SbdLastInterestPayment { get; set; }

        // bdType : asset
        /// <summary>
        /// total sbd balance
        /// </summary>
        [JsonProperty("savings_sbd_balance")]
        public Asset SavingsSbdBalance { get; set; }

        // bdType : uint128_t
        /// <summary>
        /// total sbd * how long it has been hel
        /// </summary>
        [JsonProperty("savings_sbd_seconds")]
        public string SavingsSbdSeconds { get; set; }

        // bdType : time_point_sec
        /// <summary>
        /// the last time the sbd_seconds was updated
        /// </summary>
        [JsonProperty("savings_sbd_seconds_last_update")]
        public DateTime SavingsSbdSecondsLastUpdate { get; set; }

        // bdType : time_point_sec
        /// <summary>
        /// used to pay interest at most once per month
        /// </summary>
        [JsonProperty("savings_sbd_last_interest_payment")]
        public DateTime SavingsSbdLastInterestPayment { get; set; }

        // bdType : uint8_t | = 0;
        [JsonProperty("savings_withdraw_requests")]
        public byte SavingsWithdrawRequests { get; set; }

        // bdType : asset
        [JsonProperty("reward_sbd_balance")]
        public Asset RewardSbdBalance { get; set; }

        // bdType : asset
        [JsonProperty("reward_steem_balance")]
        public Asset RewardSteemBalance { get; set; }

        // bdType : asset
        [JsonProperty("reward_vesting_balance")]
        public Asset RewardVestingBalance { get; set; }

        // bdType : asset
        [JsonProperty("reward_vesting_steem")]
        public Asset RewardVestingSteem { get; set; }

        // bdType : share_type
        [JsonProperty("curation_rewards")]
        public object CurationRewards { get; set; }

        // bdType : share_type
        [JsonProperty("posting_rewards")]
        public object PostingRewards { get; set; }

        // bdType : asset
        /// <summary>
        /// total vesting shares held by this account, controls its voting power
        /// </summary>
        [JsonProperty("vesting_shares")]
        public Asset VestingShares { get; set; }

        // bdType : asset
        [JsonProperty("delegated_vesting_shares")]
        public Asset DelegatedVestingShares { get; set; }

        // bdType : asset
        [JsonProperty("received_vesting_shares")]
        public Asset ReceivedVestingShares { get; set; }

        // bdType : asset
        /// <summary>
        /// at the time this is updated it can be at most vesting_shares/104
        /// </summary>
        [JsonProperty("vesting_withdraw_rate")]
        public Asset VestingWithdrawRate { get; set; }

        // bdType : time_point_sec
        /// <summary>
        /// after every withdrawal this is incremented by 1 week
        /// </summary>
        [JsonProperty("next_vesting_withdrawal")]
        public DateTime NextVestingWithdrawal { get; set; }

        // bdType : share_type
        /// <summary>
        /// Track how many shares have been withdrawn
        /// </summary>
        [JsonProperty("withdrawn")]
        public object Withdrawn { get; set; }

        // bdType : share_type 
        /// <summary>
        /// Might be able to look this up with operation history.
        /// </summary>
        [JsonProperty("to_withdraw")]
        public object ToWithdraw { get; set; }

        // bdType : uint16_t | = 0;
        [JsonProperty("withdraw_routes")]
        public UInt16 WithdrawRoutes { get; set; }

        // bdType : vector<share_type>
        [JsonProperty("proxied_vsf_votes")]
        public object[] ProxiedVsfVotes { get; set; }

        // bdType : uint16_t
        [JsonProperty("witnesses_voted_for")]
        public UInt16 WitnessesVotedFor { get; set; }

        // bdType : share_type | = 0;
        [JsonProperty("average_bandwidth")]
        public object AverageBandwidth { get; set; }

        // bdType : share_type | = 0;
        [JsonProperty("lifetime_bandwidth")]
        public object LifetimeBandwidth { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_bandwidth_update")]
        public DateTime LastBandwidthUpdate { get; set; }

        // bdType : share_type | = 0;
        [JsonProperty("average_market_bandwidth")]
        public object AverageMarketBandwidth { get; set; }

        // bdType : share_type | = 0;
        [JsonProperty("lifetime_market_bandwidth")]
        public object LifetimeMarketBandwidth { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_market_bandwidth_update")]
        public DateTime LastMarketBandwidthUpdate { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_post")]
        public DateTime LastPost { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_root_post")]
        public DateTime LastRootPost { get; set; }

        // bdType : share_type | = steemit_100_percent;
        [JsonProperty("post_bandwidth")]
        public object PostBandwidth { get; set; }

        // bdType : share_type
        [JsonProperty("new_average_bandwidth")]
        public object NewAverageBandwidth { get; set; }

        // bdType : share_type
        [JsonProperty("new_average_market_bandwidth")]
        public object NewAverageMarketBandwidth { get; set; }
    }
}