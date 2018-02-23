using System;
using Ditch.Golos.Enums;
using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /// <summary>
    /// comment_api_obj
    /// golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class CommentApiObj
    {

        // bdType : comment_id_type
        [JsonProperty("id")]
        public UInt64 Id { get; set; }

        // bdType : string
        [JsonProperty("category")]
        public string Category { get; set; }

        // bdType : account_name_type
        [JsonProperty("parent_author")]
        public string ParentAuthor { get; set; }

        // bdType : string
        [JsonProperty("parent_permlink")]
        public string ParentPermlink { get; set; }

        // bdType : account_name_type
        [JsonProperty("author")]
        public string Author { get; set; }

        // bdType : string
        [JsonProperty("permlink")]
        public string Permlink { get; set; }

        // bdType : string
        [JsonProperty("title")]
        public string Title { get; set; }

        // bdType : string
        [JsonProperty("body")]
        public string Body { get; set; }

        // bdType : string
        [JsonProperty("json_metadata")]
        public string JsonMetadata { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_update")]
        public DateTime LastUpdate { get; set; }

        // bdType : time_point_sec
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        // bdType : time_point_sec
        [JsonProperty("active")]
        public DateTime Active { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_payout")]
        public DateTime LastPayout { get; set; }

        // bdType : uint8_t | = 0;
        [JsonProperty("depth")]
        public byte Depth { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("children")]
        public UInt32 Children { get; set; }

        // bdType : uint128_t
        [JsonProperty("children_rshares2")]
        public string ChildrenRshares2 { get; set; }

        // bdType : share_type
        [JsonProperty("net_rshares")]
        public object NetRshares { get; set; }

        // bdType : share_type
        [JsonProperty("abs_rshares")]
        public object AbsRshares { get; set; }

        // bdType : share_type
        [JsonProperty("vote_rshares")]
        public object VoteRshares { get; set; }

        // bdType : share_type
        [JsonProperty("children_abs_rshares")]
        public object ChildrenAbsRshares { get; set; }

        // bdType : time_point_sec
        [JsonProperty("cashout_time")]
        public DateTime CashoutTime { get; set; }

        // bdType : time_point_sec
        [JsonProperty("max_cashout_time")]
        public DateTime MaxCashoutTime { get; set; }

        // bdType : uint64_t | = 0;
        [JsonProperty("total_vote_weight")]
        public UInt64 TotalVoteWeight { get; set; }

        // bdType : uint16_t | = 0;
        [JsonProperty("reward_weight")]
        public UInt16 RewardWeight { get; set; }

        // bdType : asset
        [JsonProperty("total_payout_value")]
        public Asset TotalPayoutValue { get; set; }

        // bdType : asset
        [JsonProperty("curator_payout_value")]
        public Asset CuratorPayoutValue { get; set; }

        // bdType : share_type
        [JsonProperty("author_rewards")]
        public object AuthorRewards { get; set; }

        // bdType : int32_t | = 0;
        [JsonProperty("net_votes")]
        public Int32 NetVotes { get; set; }

        // bdType : comment_id_type
        [JsonProperty("root_comment")]
        public UInt64 RootComment { get; set; }

        // bdType : comment_mode
        [JsonProperty("mode")]
        public CommentMode Mode { get; set; }

        // bdType : asset
        [JsonProperty("max_accepted_payout")]
        public Asset MaxAcceptedPayout { get; set; }

        // bdType : uint16_t | = 0;
        [JsonProperty("percent_steem_dollars")]
        public UInt16 PercentSteemDollars { get; set; }

        // bdType : bool | = false;
        [JsonProperty("allow_replies")]
        public bool AllowReplies { get; set; }

        // bdType : bool | = false;
        [JsonProperty("allow_votes")]
        public bool AllowVotes { get; set; }

        // bdType : bool | = false;
        [JsonProperty("allow_curation_rewards")]
        public bool AllowCurationRewards { get; set; }

        // bdType : vector<beneficiary_route_type>
        [JsonProperty("beneficiaries")]
        public object[] Beneficiaries { get; set; }
    }
}