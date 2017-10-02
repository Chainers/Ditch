using System;
using Newtonsoft.Json;
using System.Numerics;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Content
    {
        public const string OperationName = "get_content";
        public const int Api = 0;

        //id_type
        [JsonProperty("id")]
        public long Id { get; set; }

        //fixed_string_16
        [JsonProperty("author")]
        public string Author { get; set; }

        //shared_string
        [JsonProperty("permlink")]
        public string Permlink { get; set; }

        //shared_string
        [JsonProperty("category")]
        public string Category { get; set; }

        //fixed_string_16
        [JsonProperty("parent_author")]
        public string ParentAuthor { get; set; }

        //shared_string
        [JsonProperty("parent_permlink")]
        public string ParentPermlink { get; set; }

        //shared_string
        [JsonProperty("title")]
        public string Title { get; set; }

        //shared_string
        [JsonProperty("body")]
        public string Body { get; set; }

        //shared_string
        [JsonProperty("json_metadata")]
        public string JsonMetadata { get; set; }

        //time_point_sec
        [JsonProperty("last_update")]
        public DateTime LastUpdate { get; set; }

        //time_point_sec
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        //time_point_sec
        [JsonProperty("active")]
        public DateTime Active { get; set; }

        //time_point_sec
        [JsonProperty("last_payout")]
        public DateTime LastPayout { get; set; }


        //uint16_t
        [JsonProperty("depth")]
        public UInt16 Depth { get; set; }

        //uint32_t
        [JsonProperty("children")]
        public UInt32 Children { get; set; }


        //share_type
        [JsonProperty("net_rshares")]
        public long NetRshares { get; set; }

        //share_type
        [JsonProperty("abs_rshares")]
        public long AbsRshares { get; set; }

        //share_type
        [JsonProperty("vote_rshares")]
        public long VoteRshares { get; set; }

        //share_type
        [JsonProperty("children_abs_rshares")]
        public long ChildrenAbsRshares { get; set; }

        //time_point_sec
        [JsonProperty("cashout_time")]
        public DateTime CashoutTime { get; set; }

        //time_point_sec
        [JsonProperty("max_cashout_time")]
        public DateTime MaxCashoutTime { get; set; }

        //uint64_t
        [JsonProperty("total_vote_weight")]
        public ulong TotalVoteWeight { get; set; }

        //uint16_t
        [JsonProperty("reward_weight")]
        public long RewardWeight { get; set; }

        //asset(0, SBD_SYMBOL)
        [JsonProperty("total_payout_value")]
        public Money TotalPayoutValue { get; set; }

        //asset(0, SBD_SYMBOL)
        [JsonProperty("curator_payout_value")]
        public Money CuratorPayoutValue { get; set; }

        //share_type
        [JsonProperty("author_rewards")]
        public long AuthorRewards { get; set; }

        //int32_t
        [JsonProperty("net_votes")]
        public Int32 NetVotes { get; set; }

        //id_type
        [JsonProperty("root_comment")]
        public long RootComment { get; set; }

        //asset( 1000000000, SBD_SYMBOL );  
        [JsonProperty("max_accepted_payout")]
        public string MaxAcceptedPayout { get; set; }

        //uint16_t
        [JsonProperty("percent_steem_dollars")]
        public UInt16 PercentSteemDollars { get; set; }

        //bool
        [JsonProperty("allow_replies")]
        public bool AllowReplies { get; set; }

        //bool
        [JsonProperty("allow_votes")]
        public bool AllowVotes { get; set; }

        //bool
        [JsonProperty("allow_curation_rewards")]
        public bool AllowCurationRewards { get; set; }

        //bip::vector< beneficiary_route_type, allocator< beneficiary_route_type > > beneficiaries;

        //string
        [JsonProperty("url")]
        public string Url { get; set; }// /category/@rootauthor/root_permlink#author/permlink

        //string
        [JsonProperty("root_title")]
        public string RootTitle { get; set; }

        //asset
        [JsonProperty("pending_payout_value")]
        public Money PendingPayoutValue { get; set; }

        //asset
        [JsonProperty("total_pending_payout_value")]
        public string TotalPendingPayoutValue { get; set; }

        //[JsonProperty("active_votes")]
        //public string ActiveVotes { get; set; } //  [],

        //[JsonProperty("replies")]
        //public string Replies { get; set; } // [)],

        //share_type
        [JsonProperty("author_reputation")]
        public string AuthorReputation { get; set; }

        [JsonProperty("promoted")]
        public string Promoted { get; set; }

        //uint32_t
        [JsonProperty("body_length")]
        public UInt32 BodyLength { get; set; }

        // vector<account_name_type>
        //[JsonProperty("reblogged_by")]
        //public long RebloggedBy { get; set; } //[]

        //[JsonProperty("mode")]
        //public string Mode { get; set; } // "first_payout",


        public Money NewTotalPayoutReward => TotalPayoutValue + CuratorPayoutValue + PendingPayoutValue;
    }
}