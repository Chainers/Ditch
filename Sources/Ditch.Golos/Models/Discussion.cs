using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <inheritdoc />
    /// <summary>
    /// discussion
    /// libraries\api\include\golos\api\discussion.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Discussion : CommentApiObject
    {

        /// <summary>
        /// API name: url
        /// category/@rootauthor/root_permlink#author/permlink
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// API name: pending_author_payout_value
        /// = asset(0, SBD_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("pending_author_payout_value")]
        public Asset PendingAuthorPayoutValue { get; set; }

        /// <summary>
        /// API name: pending_author_payout_gbg_value
        /// = asset(0, SBD_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("pending_author_payout_gbg_value")]
        public Asset PendingAuthorPayoutGbgValue { get; set; }

        /// <summary>
        /// API name: pending_author_payout_gests_value
        /// = asset(0, VESTS_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("pending_author_payout_gests_value")]
        public Asset PendingAuthorPayoutGestsValue { get; set; }

        /// <summary>
        /// API name: pending_author_payout_golos_value
        /// = asset(0, STEEM_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("pending_author_payout_golos_value")]
        public Asset PendingAuthorPayoutGolosValue { get; set; }

        /// <summary>
        /// API name: pending_benefactor_payout_value
        /// = asset(0, SBD_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("pending_benefactor_payout_value")]
        public Asset PendingBenefactorPayoutValue { get; set; }

        /// <summary>
        /// API name: pending_benefactor_payout_gests_value
        /// = asset(0, VESTS_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("pending_benefactor_payout_gests_value")]
        public Asset PendingBenefactorPayoutGestsValue { get; set; }

        /// <summary>
        /// API name: pending_curator_payout_value
        /// = asset(0, SBD_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("pending_curator_payout_value")]
        public Asset PendingCuratorPayoutValue { get; set; }

        /// <summary>
        /// API name: pending_curator_payout_gests_value
        /// = asset(0, VESTS_SYMBOL);
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("pending_curator_payout_gests_value")]
        public Asset PendingCuratorPayoutGestsValue { get; set; }

        /// <summary>
        /// API name: pending_payout_value
        /// = asset(0, SBD_SYMBOL); ///&lt; sbd
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("pending_payout_value")]
        public Asset PendingPayoutValue { get; set; }

        /// <summary>
        /// API name: total_pending_payout_value
        /// = asset(0, SBD_SYMBOL); ///&lt; sbd including replies
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("total_pending_payout_value")]
        public Asset TotalPendingPayoutValue { get; set; }

        /// <summary>
        /// API name: active_votes
        /// 
        /// </summary>
        /// <returns>API type: vote_state</returns>
        [JsonProperty("active_votes")]
        public VoteState[] ActiveVotes { get; set; }

        /// <summary>
        /// API name: active_votes_count
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("active_votes_count")]
        public uint ActiveVotesCount { get; set; }

        /// <summary>
        /// API name: replies
        /// author/slug mapping
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("replies")]
        public string[] Replies { get; set; }

        /// <summary>
        /// API name: author_reputation
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("author_reputation", NullValueHandling = NullValueHandling.Ignore)]
        public object AuthorReputation { get; set; }

        /// <summary>
        /// API name: promoted
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("promoted", NullValueHandling = NullValueHandling.Ignore)]
        public Asset Promoted { get; set; }

        /// <summary>
        /// API name: hot
        /// = 0;
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("hot")]
        public double Hot { get; set; }

        /// <summary>
        /// API name: trending
        /// = 0;
        /// </summary>
        /// <returns>API type: double</returns>
        [JsonProperty("trending")]
        public double Trending { get; set; }

        /// <summary>
        /// API name: body_length
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("body_length")]
        public uint BodyLength { get; set; }

        /// <summary>
        /// API name: reblogged_by
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("reblogged_by")]
        public string[] RebloggedBy { get; set; }

        /// <summary>
        /// API name: first_reblogged_by
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("first_reblogged_by")]
        public string FirstRebloggedBy { get; set; }

        /// <summary>
        /// API name: first_reblogged_on
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("first_reblogged_on")]
        public TimePointSec FirstRebloggedOn { get; set; }

        /// <summary>
        /// API name: reblog_author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("reblog_author", NullValueHandling = NullValueHandling.Ignore)]
        public string ReblogAuthor { get; set; }

        /// <summary>
        /// API name: reblog_title
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("reblog_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ReblogTitle { get; set; }

        /// <summary>
        /// API name: reblog_body
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("reblog_body", NullValueHandling = NullValueHandling.Ignore)]
        public string ReblogBody { get; set; }

        /// <summary>
        /// API name: reblog_json_metadata
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("reblog_json_metadata", NullValueHandling = NullValueHandling.Ignore)]
        public string ReblogJsonMetadata { get; set; }

        /// <summary>
        /// API name: reblog_entries
        /// 
        /// </summary>
        /// <returns>API type: reblog_entry</returns>
        [JsonProperty("reblog_entries")]
        public object[] ReblogEntries { get; set; }
    }
}