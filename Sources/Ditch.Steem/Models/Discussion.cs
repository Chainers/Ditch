using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// discussion
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Discussion
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: comment_id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: category
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("category")]
        public string Category {get; set;}

        /// <summary>
        /// API name: parent_author
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("parent_author")]
        public string ParentAuthor {get; set;}

        /// <summary>
        /// API name: parent_permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("parent_permlink")]
        public string ParentPermlink {get; set;}

        /// <summary>
        /// API name: author
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("author")]
        public string Author {get; set;}

        /// <summary>
        /// API name: permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("permlink")]
        public string Permlink {get; set;}

        /// <summary>
        /// API name: title
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("title")]
        public string Title {get; set;}

        /// <summary>
        /// API name: body
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("body")]
        public string Body {get; set;}

        /// <summary>
        /// API name: json_metadata
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("json_metadata")]
        public string JsonMetadata {get; set;}

        /// <summary>
        /// API name: last_update
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_update")]
        public TimePointSec LastUpdate {get; set;}

        /// <summary>
        /// API name: created
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("created")]
        public TimePointSec Created {get; set;}

        /// <summary>
        /// API name: active
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("active")]
        public TimePointSec Active {get; set;}

        /// <summary>
        /// API name: last_payout
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_payout")]
        public TimePointSec LastPayout {get; set;}

        /// <summary>
        /// API name: depth
        /// = 0;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("depth")]
        public byte Depth {get; set;}

        /// <summary>
        /// API name: children
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("children")]
        public uint Children {get; set;}

        /// <summary>
        /// API name: net_rshares
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("net_rshares")]
        public object NetRshares {get; set;}

        /// <summary>
        /// API name: abs_rshares
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("abs_rshares")]
        public object AbsRshares {get; set;}

        /// <summary>
        /// API name: vote_rshares
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("vote_rshares")]
        public object VoteRshares {get; set;}

        /// <summary>
        /// API name: children_abs_rshares
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("children_abs_rshares")]
        public object ChildrenAbsRshares {get; set;}

        /// <summary>
        /// API name: cashout_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("cashout_time")]
        public TimePointSec CashoutTime {get; set;}

        /// <summary>
        /// API name: max_cashout_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("max_cashout_time")]
        public TimePointSec MaxCashoutTime {get; set;}

        /// <summary>
        /// API name: total_vote_weight
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("total_vote_weight")]
        public ulong TotalVoteWeight {get; set;}

        /// <summary>
        /// API name: reward_weight
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("reward_weight")]
        public ushort RewardWeight {get; set;}

        /// <summary>
        /// API name: total_payout_value
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("total_payout_value")]
        public Asset TotalPayoutValue {get; set;}

        /// <summary>
        /// API name: curator_payout_value
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("curator_payout_value")]
        public Asset CuratorPayoutValue {get; set;}

        /// <summary>
        /// API name: author_rewards
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("author_rewards")]
        public object AuthorRewards {get; set;}

        /// <summary>
        /// API name: net_votes
        /// = 0;
        /// </summary>
        /// <returns>API type: int32_t</returns>
        [JsonProperty("net_votes")]
        public int NetVotes {get; set;}

        /// <summary>
        /// API name: root_author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("root_author")]
        public string RootAuthor {get; set;}

        /// <summary>
        /// API name: root_permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("root_permlink")]
        public string RootPermlink {get; set;}

        /// <summary>
        /// API name: max_accepted_payout
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("max_accepted_payout")]
        public Asset MaxAcceptedPayout {get; set;}

        /// <summary>
        /// API name: percent_steem_dollars
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("percent_steem_dollars")]
        public ushort PercentSteemDollars {get; set;}

        /// <summary>
        /// API name: allow_replies
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("allow_replies")]
        public bool AllowReplies {get; set;}

        /// <summary>
        /// API name: allow_votes
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("allow_votes")]
        public bool AllowVotes {get; set;}

        /// <summary>
        /// API name: allow_curation_rewards
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("allow_curation_rewards")]
        public bool AllowCurationRewards {get; set;}

        /// <summary>
        /// API name: beneficiaries
        /// 
        /// </summary>
        /// <returns>API type: beneficiary_route_type</returns>
        [JsonProperty("beneficiaries")]
        public BeneficiaryRouteType[] Beneficiaries {get; set;}

        /// <summary>
        /// API name: url
        /// category/@rootauthor/root_permlink#author/permlink
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("url")]
        public string Url {get; set;}

        /// <summary>
        /// API name: root_title
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("root_title")]
        public string RootTitle {get; set;}

        /// <summary>
        /// API name: pending_payout_value
        /// sbd
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("pending_payout_value")]
        public Asset PendingPayoutValue {get; set;}

        /// <summary>
        /// API name: total_pending_payout_value
        /// sbd including replies
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("total_pending_payout_value")]
        public Asset TotalPendingPayoutValue {get; set;}

        /// <summary>
        /// API name: active_votes
        /// 
        /// </summary>
        /// <returns>API type: vote_state</returns>
        [JsonProperty("active_votes")]
        public VoteState[] ActiveVotes {get; set;}

        /// <summary>
        /// API name: replies
        /// author/slug mapping
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("replies")]
        public string[] Replies {get; set;}

        /// <summary>
        /// API name: author_reputation
        /// = 0;
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("author_reputation")]
        public object AuthorReputation {get; set;}

        /// <summary>
        /// API name: promoted
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("promoted")]
        public Asset Promoted {get; set;}

        /// <summary>
        /// API name: body_length
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("body_length")]
        public uint BodyLength {get; set;}

        /// <summary>
        /// API name: reblogged_by
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("reblogged_by")]
        public string[] RebloggedBy {get; set;}

        /// <summary>
        /// API name: first_reblogged_by
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("first_reblogged_by", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstRebloggedBy {get; set;}

        /// <summary>
        /// API name: first_reblogged_on
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("first_reblogged_on", NullValueHandling = NullValueHandling.Ignore)]
        public TimePointSec FirstRebloggedOn {get; set;}
    }
}