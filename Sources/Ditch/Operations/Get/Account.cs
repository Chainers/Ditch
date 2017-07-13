using System;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AccountPublicKey
    {
        [JsonProperty("weight_threshold")]
        public int WeightThreshold { get; set; }

        [JsonProperty("account_auths")]
        public object[] AccountAuths { get; set; }

        [JsonProperty("key_auths")]
        public object[][] KeyAuths { get; set; }

        public string Value => KeyAuths != null && KeyAuths.Length == 1 ? (string)KeyAuths[0][0] : string.Empty;

        public override string ToString()
        {
            return Value;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Account
    {
        public const string OperationName = "get_accounts";
        //public const int Api = 0;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public AccountPublicKey Owner { get; set; }

        [JsonProperty("active")]
        public AccountPublicKey Active { get; set; }

        [JsonProperty("posting")]
        public AccountPublicKey Posting { get; set; }

        [JsonProperty("memo_key")]
        public string MemoKey { get; set; }

        [JsonProperty("json_metadata")]
        public string JsonMetadata { get; set; }

        [JsonProperty("proxy")]
        public string Proxy { get; set; }

        [JsonProperty("last_owner_update")]
        public DateTime LastOwnerUpdate { get; set; }

        [JsonProperty("last_account_update")]
        public DateTime LastAccountUpdate { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("mined")]
        public bool Mined { get; set; }

        [JsonProperty("owner_challenged")]
        public bool OwnerChallenged { get; set; }

        [JsonProperty("active_challenged")]
        public bool ActiveChallenged { get; set; }

        [JsonProperty("last_owner_proved")]
        public DateTime LastOwnerProved { get; set; }

        [JsonProperty("last_active_proved")]
        public DateTime LastActiveProved { get; set; }

        [JsonProperty("recovery_account")]
        public string RecoveryAccount { get; set; }

        [JsonProperty("last_account_recovery")]
        public DateTime LastAccountRecovery { get; set; }

        [JsonProperty("reset_account")]
        public string ResetAccount { get; set; }

        [JsonProperty("comment_count")]
        public int CommentCount { get; set; }

        [JsonProperty("lifetime_vote_count")]
        public int LifetimeVoteCount { get; set; }

        [JsonProperty("post_count")]
        public int PostCount { get; set; }

        [JsonProperty("can_vote")]
        public bool CanVote { get; set; }

        [JsonProperty("voting_power")]
        public int VotingPower { get; set; }

        [JsonProperty("last_vote_time")]
        public DateTime LastVoteTime { get; set; }

        [JsonProperty("balance")]
        public Money Balance { get; set; }

        [JsonProperty("savings_balance")]
        public Money SavingsBalance { get; set; }

        [JsonProperty("sbd_balance")]
        public Money SbdBalance { get; set; }

        [JsonProperty("sbd_seconds")]
        public long SbdSeconds { get; set; }

        [JsonProperty("sbd_seconds_last_update")]
        public DateTime SbdSecondsLastUpdate { get; set; }

        [JsonProperty("sbd_last_interest_payment")]
        public DateTime SbdLastInterestPayment { get; set; }

        [JsonProperty("savings_sbd_balance")]
        public Money SavingsSbdBalance { get; set; }

        [JsonProperty("savings_sbd_seconds")]
        public string SavingsSbdSeconds { get; set; }

        [JsonProperty("savings_sbd_seconds_last_update")]
        public DateTime SavingsSbdSecondsLastUpdate { get; set; }

        [JsonProperty("savings_sbd_last_interest_payment")]
        public DateTime SavingsSbdLastInterestPayment { get; set; }

        [JsonProperty("savings_withdraw_requests")]
        public int SavingsWithdrawRequests { get; set; }

        [JsonProperty("reward_sbd_balance")]
        public Money RewardSbdBalance { get; set; }

        [JsonProperty("reward_steem_balance")]
        public Money RewardSteemBalance { get; set; }

        [JsonProperty("reward_vesting_balance")]
        public Money RewardVestingBalance { get; set; }

        [JsonProperty("reward_vesting_steem")]
        public Money RewardVestingSteem { get; set; }

        [JsonProperty("vesting_shares")]
        public Money VestingShares { get; set; }

        [JsonProperty("delegated_vesting_shares")]
        public Money DelegatedVestingShares { get; set; }

        [JsonProperty("received_vesting_shares")]
        public Money ReceivedVestingShares { get; set; }

        [JsonProperty("vesting_withdraw_rate")]
        public Money VestingWithdrawRate { get; set; }

        [JsonProperty("next_vesting_withdrawal")]
        public DateTime NextVestingWithdrawal { get; set; }

        [JsonProperty("withdrawn")]
        public int Withdrawn { get; set; }

        [JsonProperty("to_withdraw")]
        public int ToWithdraw { get; set; }

        [JsonProperty("withdraw_routes")]
        public int WithdrawRoutes { get; set; }

        [JsonProperty("curation_rewards")]
        public int CurationRewards { get; set; }

        [JsonProperty("posting_rewards")]
        public int PostingRewards { get; set; }

        [JsonProperty("proxied_vsf_votes")]
        public int[] ProxiedVsfVotes { get; set; }

        [JsonProperty("witnesses_voted_for")]
        public int WitnessesVotedFor { get; set; }

        [JsonProperty("average_bandwidth")]
        public string AverageBandwidth { get; set; }

        [JsonProperty("lifetime_bandwidth")]
        public string LifetimeBandwidth { get; set; }

        [JsonProperty("last_bandwidth_update")]
        public DateTime LastBandwidthUpdate { get; set; }

        [JsonProperty("average_market_bandwidth")]
        public int AverageMarketBandwidth { get; set; }

        [JsonProperty("lifetime_market_bandwidth")]
        public int LifetimeMarketBandwidth { get; set; }

        [JsonProperty("last_market_bandwidth_update")]
        public DateTime LastMarketBandwidthUpdate { get; set; }

        [JsonProperty("last_post")]
        public DateTime LastPost { get; set; }

        [JsonProperty("last_root_post")]
        public DateTime LastRootPost { get; set; }

        [JsonProperty("vesting_balance")]
        public Money VestingBalance { get; set; }

        [JsonProperty("reputation")]
        public long Reputation { get; set; }

        [JsonProperty("transfer_history")]
        public object[] TransferHistory { get; set; }

        [JsonProperty("market_history")]
        public object[] MarketHistory { get; set; }

        [JsonProperty("post_history")]
        public object[] PostHistory { get; set; }

        [JsonProperty("vote_history")]
        public object[] VoteHistory { get; set; }

        [JsonProperty("other_history")]
        public object[] OtherHistory { get; set; }

        [JsonProperty("witness_votes")]
        public object[] WitnessVotes { get; set; }

        [JsonProperty("tags_usage")]
        public object[] TagsUsage { get; set; }

        [JsonProperty("guest_bloggers")]
        public object[] GuestBloggers { get; set; }
    }
}