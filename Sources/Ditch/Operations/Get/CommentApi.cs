using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CommentApi //comment_api_obj *https://github.com/steemit/steem/blob/master/libraries/app/include/steemit/app/steem_api_objects.hpp
    {
        [JsonProperty("id")]
        public UInt64 Id { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("parent_author")]
        public string ParentAuthor { get; set; }

        [JsonProperty("parent_permlink")]
        public string ParentPermlink { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("permlink")]
        public string Permlink { get; set; }

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
        public UInt16 Depth { get; set; }

        [JsonProperty("children")]
        public UInt32 Children { get; set; }

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
        public ulong TotalVoteWeight { get; set; }

        [JsonProperty("reward_weight")]
        public long RewardWeight { get; set; }

        [JsonProperty("total_payout_value")]
        public Money TotalPayoutValue { get; set; }

        [JsonProperty("curator_payout_value")]
        public Money CuratorPayoutValue { get; set; }

        [JsonProperty("author_rewards")]
        public long AuthorRewards { get; set; }

        [JsonProperty("net_votes")]
        public Int32 NetVotes { get; set; }

        [JsonProperty("root_comment")]
        public long RootComment { get; set; }

        [JsonProperty("max_accepted_payout")]
        public string MaxAcceptedPayout { get; set; }

        [JsonProperty("percent_steem_dollars")]
        public UInt16 PercentSteemDollars { get; set; }

        [JsonProperty("allow_replies")]
        public bool AllowReplies { get; set; }

        [JsonProperty("allow_votes")]
        public bool AllowVotes { get; set; }

        [JsonProperty("allow_curation_rewards")]
        public bool AllowCurationRewards { get; set; }

        [JsonProperty("beneficiaries")]
        public List<object> Beneficiaries { get; set; } //bip::vector< beneficiary_route_type, allocator< beneficiary_route_type > > beneficiaries;
    }
}