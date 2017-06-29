using System;
using Ditch.Helpers;
using Newtonsoft.Json;

namespace Ditch.Responses
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Content
    {
        [SerializeHelper.IgnoreForMessage]
        public const string OperationName = "get_content";
        [SerializeHelper.IgnoreForMessage]
        public const int Api = 0;


        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("permlink")]
        public string Permlink { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("parent_author")]
        public string ParentAuthor { get; set; }

        [JsonProperty("parent_permlink")]
        public string ParentPermlink { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("json_metadata")]
        public string JsonMetadata { get; set; }

        [JsonProperty("last_update")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("active")]
        public DateTime Active { get; set; }

        [JsonProperty("last_payout")]
        public DateTime LastPayout { get; set; }

        [JsonProperty("depth")]
        public long Depth { get; set; }

        [JsonProperty("children")]
        public long Children { get; set; }

        [JsonProperty("net_rshares")]
        public long NetRshares { get; set; }

        [JsonProperty("abs_rshares")]
        public long AbsRshares { get; set; }

        [JsonProperty("vote_rshares")]
        public long VoteRshares { get; set; }

        [JsonProperty("children_abs_rshares")]
        public long ChildrenAbsRshares { get; set; }

        [JsonProperty("cashout_time")]
        public DateTime CashoutTime { get; set; }

        [JsonProperty("max_cashout_time")]
        public DateTime MaxCashoutTime { get; set; }

        [JsonProperty("total_vote_weight")]
        public long TotalVoteWeight { get; set; }

        [JsonProperty("reward_weight")]
        public long RewardWeight { get; set; }

        [JsonProperty("total_payout_value")]
        public Money TotalPayoutValue { get; set; }

        [JsonProperty("curator_payout_value")]
        public Money CuratorPayoutValue { get; set; }

        [JsonProperty("author_rewards")]
        public long AuthorRewards { get; set; }

        [JsonProperty("net_votes")]
        public long NetVotes { get; set; }

        [JsonProperty("root_comment")]
        public long RootComment { get; set; }

        [JsonProperty("max_accepted_payout")]
        public string MaxAcceptedPayout { get; set; }

        [JsonProperty("percent_steem_dollars")]
        public long PercentSteemDollars { get; set; }

        [JsonProperty("allow_replies")]
        public bool AllowReplies { get; set; }

        [JsonProperty("allow_votes")]
        public bool AllowVotes { get; set; }

        [JsonProperty("allow_curation_rewards")]
        public bool AllowCurationRewards { get; set; }

        //beneficiaries

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("root_title")]
        public string RootTitle { get; set; }

        [JsonProperty("pending_payout_value")]
        public Money PendingPayoutValue { get; set; }

        [JsonProperty("total_pending_payout_value")]
        public string TotalPendingPayoutValue { get; set; }

        //[JsonProperty("active_votes")]
        //public string ActiveVotes { get; set; } //  [],

        //[JsonProperty("replies")]
        //public string Replies { get; set; } // [)],

        [JsonProperty("author_reputation")]
        public string AuthorReputation { get; set; }

        [JsonProperty("promoted")]
        public string Promoted { get; set; }

        [JsonProperty("body_length")]
        public long BodyLength { get; set; }

        //[JsonProperty("reblogged_by")]
        //public long RebloggedBy { get; set; } //[]

        //[JsonProperty("mode")]
        //public string Mode { get; set; } // "first_payout",


        public Money NewTotalPayoutReward => TotalPayoutValue + CuratorPayoutValue + PendingPayoutValue;
    }
}