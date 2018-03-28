using System;
using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// api_account_object
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ApiAccountObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("name")]
        public string Name {get; set;}

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [JsonProperty("owner")]
        public Authority Owner {get; set;}

        /// <summary>
        /// API name: active
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [JsonProperty("active")]
        public Authority Active {get; set;}

        /// <summary>
        /// API name: posting
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [JsonProperty("posting")]
        public Authority Posting {get; set;}

        /// <summary>
        /// API name: memo_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("memo_key")]
        public PublicKeyType MemoKey {get; set;}

        /// <summary>
        /// API name: json_metadata
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("json_metadata")]
        public string JsonMetadata {get; set;}

        /// <summary>
        /// API name: proxy
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("proxy")]
        public string Proxy {get; set;}

        /// <summary>
        /// API name: last_owner_update
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_owner_update")]
        public DateTime LastOwnerUpdate {get; set;}

        /// <summary>
        /// API name: last_account_update
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_account_update")]
        public DateTime LastAccountUpdate {get; set;}

        /// <summary>
        /// API name: created
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("created")]
        public DateTime Created {get; set;}

        /// <summary>
        /// API name: mined
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("mined")]
        public bool Mined {get; set;}

        /// <summary>
        /// API name: recovery_account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("recovery_account")]
        public string RecoveryAccount {get; set;}

        /// <summary>
        /// API name: reset_account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("reset_account")]
        public string ResetAccount {get; set;}

        /// <summary>
        /// API name: last_account_recovery
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_account_recovery")]
        public DateTime LastAccountRecovery {get; set;}

        /// <summary>
        /// API name: comment_count
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("comment_count")]
        public UInt32 CommentCount {get; set;}

        /// <summary>
        /// API name: lifetime_vote_count
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("lifetime_vote_count")]
        public UInt32 LifetimeVoteCount {get; set;}

        /// <summary>
        /// API name: post_count
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("post_count")]
        public UInt32 PostCount {get; set;}

        /// <summary>
        /// API name: can_vote
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("can_vote")]
        public bool CanVote {get; set;}

        /// <summary>
        /// API name: voting_power
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("voting_power")]
        public UInt16 VotingPower {get; set;}

        /// <summary>
        /// API name: last_vote_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_vote_time")]
        public DateTime LastVoteTime {get; set;}

        /// <summary>
        /// API name: balance
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("balance")]
        public LegacyAsset Balance {get; set;}

        /// <summary>
        /// API name: savings_balance
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("savings_balance")]
        public LegacyAsset SavingsBalance {get; set;}

        /// <summary>
        /// API name: sbd_balance
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("sbd_balance")]
        public LegacyAsset SbdBalance {get; set;}

        /// <summary>
        /// API name: sbd_seconds
        /// 
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("sbd_seconds")]
        public string SbdSeconds {get; set;}

        /// <summary>
        /// API name: sbd_seconds_last_update
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("sbd_seconds_last_update")]
        public DateTime SbdSecondsLastUpdate {get; set;}

        /// <summary>
        /// API name: sbd_last_interest_payment
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("sbd_last_interest_payment")]
        public DateTime SbdLastInterestPayment {get; set;}

        /// <summary>
        /// API name: savings_sbd_balance
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("savings_sbd_balance")]
        public LegacyAsset SavingsSbdBalance {get; set;}

        /// <summary>
        /// API name: savings_sbd_seconds
        /// 
        /// </summary>
        /// <returns>API type: uint128_t</returns>
        [JsonProperty("savings_sbd_seconds")]
        public string SavingsSbdSeconds {get; set;}

        /// <summary>
        /// API name: savings_sbd_seconds_last_update
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("savings_sbd_seconds_last_update")]
        public DateTime SavingsSbdSecondsLastUpdate {get; set;}

        /// <summary>
        /// API name: savings_sbd_last_interest_payment
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("savings_sbd_last_interest_payment")]
        public DateTime SavingsSbdLastInterestPayment {get; set;}

        /// <summary>
        /// API name: savings_withdraw_requests
        /// = 0;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("savings_withdraw_requests")]
        public byte SavingsWithdrawRequests {get; set;}

        /// <summary>
        /// API name: reward_sbd_balance
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("reward_sbd_balance")]
        public LegacyAsset RewardSbdBalance {get; set;}

        /// <summary>
        /// API name: reward_steem_balance
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("reward_steem_balance")]
        public LegacyAsset RewardSteemBalance {get; set;}

        /// <summary>
        /// API name: reward_vesting_balance
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("reward_vesting_balance")]
        public LegacyAsset RewardVestingBalance {get; set;}

        /// <summary>
        /// API name: reward_vesting_steem
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("reward_vesting_steem")]
        public LegacyAsset RewardVestingSteem {get; set;}

        /// <summary>
        /// API name: curation_rewards
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("curation_rewards")]
        public object CurationRewards {get; set;}

        /// <summary>
        /// API name: posting_rewards
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("posting_rewards")]
        public object PostingRewards {get; set;}

        /// <summary>
        /// API name: vesting_shares
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("vesting_shares")]
        public LegacyAsset VestingShares {get; set;}

        /// <summary>
        /// API name: delegated_vesting_shares
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("delegated_vesting_shares")]
        public LegacyAsset DelegatedVestingShares {get; set;}

        /// <summary>
        /// API name: received_vesting_shares
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("received_vesting_shares")]
        public LegacyAsset ReceivedVestingShares {get; set;}

        /// <summary>
        /// API name: vesting_withdraw_rate
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("vesting_withdraw_rate")]
        public LegacyAsset VestingWithdrawRate {get; set;}

        /// <summary>
        /// API name: next_vesting_withdrawal
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("next_vesting_withdrawal")]
        public DateTime NextVestingWithdrawal {get; set;}

        /// <summary>
        /// API name: withdrawn
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("withdrawn")]
        public object Withdrawn {get; set;}

        /// <summary>
        /// API name: to_withdraw
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("to_withdraw")]
        public object ToWithdraw {get; set;}

        /// <summary>
        /// API name: withdraw_routes
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("withdraw_routes")]
        public UInt16 WithdrawRoutes {get; set;}

        /// <summary>
        /// API name: proxied_vsf_votes
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("proxied_vsf_votes")]
        public object[] ProxiedVsfVotes {get; set;}

        /// <summary>
        /// API name: witnesses_voted_for
        /// 
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("witnesses_voted_for")]
        public UInt16 WitnessesVotedFor {get; set;}

        /// <summary>
        /// API name: last_post
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_post")]
        public DateTime LastPost {get; set;}

        /// <summary>
        /// API name: last_root_post
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_root_post")]
        public DateTime LastRootPost {get; set;}
    }
}
