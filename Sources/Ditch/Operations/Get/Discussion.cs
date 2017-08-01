using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Discussion : CommentApi
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("root_title")]
        public string RootTitle { get; set; }

        [JsonProperty("pending_payout_value")]
        public Money PendingPayoutValue { get; set; }

        [JsonProperty("total_pending_payout_value")]
        public Money TotalPendingPayoutValue { get; set; }

        [JsonProperty("active_votes")]
        public List<VoteState> ActiveVotes { get; set; }

        [JsonProperty("replies")]
        public List<string> Replies { get; set; }

        //share_type
        [JsonProperty("author_reputation")]
        public object AuthorReputation { get; set; }

        [JsonProperty("promoted")]
        public Money Promoted { get; set; }

        [JsonProperty("body_length")]
        public UInt32 BodyLength { get; set; }

        [JsonProperty("reblogged_by")]
        public List<string> RebloggedBy { get; set; }

        //public optional<account_name_type> first_reblogged_by;
        //public optional<time_point_sec> first_reblogged_on;

    }
}