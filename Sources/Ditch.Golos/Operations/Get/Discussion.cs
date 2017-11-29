using System;
using Ditch.Core;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations.Get
{
    /// <summary>
    /// discussion
    /// golos-0.16.3\libraries\app\include\steemit\app\state.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Discussion : CommentApiObj
    {

        // bdType : string
        /// <summary>
        ///  /category/@rootauthor/root_permlink#author/permlink
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        // bdType : string
        [JsonProperty("root_title")]
        public string RootTitle { get; set; }

        // bdType : asset | = asset(0, sbd_symbol); 
        /// <summary>
        /// sbd
        /// </summary>
        [JsonProperty("pending_payout_value")]
        public Money PendingPayoutValue { get; set; }

        // bdType : asset | = asset(0, sbd_symbol); 
        /// <summary>
        /// sbd including replies
        /// </summary>
        [JsonProperty("total_pending_payout_value")]
        public Money TotalPendingPayoutValue { get; set; }

        // bdType : vector<vote_state>
        [JsonProperty("active_votes")]
        public VoteState[] ActiveVotes { get; set; }

        // bdType : vector<string>
        /// <summary>
        /// author/slug mapping
        /// </summary>
        [JsonProperty("replies")]
        public string[] Replies { get; set; }

        // bdType : share_type | = 0;
        [JsonProperty("author_reputation")]
        public object AuthorReputation { get; set; }

        // bdType : asset | = asset(0, sbd_symbol);
        [JsonProperty("promoted")]
        public Money Promoted { get; set; }

        // bdType : uint32_t | = 0;
        [JsonProperty("body_length")]
        public UInt32 BodyLength { get; set; }

        // bdType : vector<account_name_type>
        [JsonProperty("reblogged_by")]
        public string[] RebloggedBy { get; set; }

        // bdType : optional<account_name_type>
        [JsonProperty("first_reblogged_by")]
        public object FirstRebloggedBy { get; set; }

        // bdType : optional<time_point_sec>
        [JsonProperty("first_reblogged_on")]
        public object FirstRebloggedOn { get; set; }
    }
}