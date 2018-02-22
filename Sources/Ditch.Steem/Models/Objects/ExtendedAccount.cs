using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    ///  extended_account 
    /// steem-0.19.1\libraries\app\include\steemit\app\state.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ExtendedAccount : AccountApiObj
    {
        // bdType : asset
        /// <summary>
        /// convert vesting_shares to vesting steem
        /// </summary>
        [JsonProperty("vesting_balance")]
        public Asset VestingBalance { get; set; }

        // bdType : share_type | = 0;
        [JsonProperty("reputation")]
        public object Reputation { get; set; }

        // bdType : map<uint64_t,applied_operation>
        /// <summary>
        /// transfer to/from vesting
        /// </summary>
        [JsonProperty("transfer_history")]
        public object TransferHistory { get; set; }

        // bdType : map<uint64_t,applied_operation>
        /// <summary>
        /// limit order / cancel / fill
        /// </summary>
        [JsonProperty("market_history")]
        public object MarketHistory { get; set; }

        // bdType : map<uint64_t,applied_operation>
        [JsonProperty("post_history")]
        public object PostHistory { get; set; }

        // bdType : map<uint64_t,applied_operation>
        [JsonProperty("vote_history")]
        public object VoteHistory { get; set; }

        // bdType : map<uint64_t,applied_operation>
        [JsonProperty("other_history")]
        public object OtherHistory { get; set; }

        // bdType : set<string>
        [JsonProperty("witness_votes")]
        public string[] WitnessVotes { get; set; }

        // bdType : vector<pair<string,uint32_t>>
        [JsonProperty("tags_usage")]
        public KeyValuePair<string, UInt32>[] TagsUsage { get; set; }

        // bdType : vector<pair<account_name_type,uint32_t>>
        [JsonProperty("guest_bloggers")]
        public KeyValuePair<string, UInt32>[] GuestBloggers { get; set; }

        // bdType : optional<map<uint32_t,extended_limit_order>>
        [JsonProperty("open_orders")]
        public object OpenOrders { get; set; }

        // bdType : optional<vector<string>>
        /// <summary>
        /// permlinks for this user
        /// </summary>
        [JsonProperty("comments")]
        public string[] Comments { get; set; }

        // bdType : optional<vector<string>>
        /// <summary>
        /// blog posts for this user
        /// </summary>
        [JsonProperty("blog")]
        public string[] Blog { get; set; }

        // bdType : optional<vector<string>>
        /// <summary>
        /// feed posts for this user
        /// </summary>
        [JsonProperty("feed")]
        public string[] Feed { get; set; }

        // bdType : optional<vector<string>>
        /// <summary>
        /// blog posts for this user
        /// </summary>
        [JsonProperty("recent_replies")]
        public string[] RecentReplies { get; set; }

        // bdType : map<string,vector<string>>
        /// <summary>
        ///  blog posts for this user
        /// </summary>
        [JsonProperty("blog_category")]
        public object BlogCategory { get; set; }

        // bdType : optional<vector<string>>
        /// <summary>
        /// posts recommened for this user
        /// </summary>
        [JsonProperty("recommended")]
        public string[] Recommended { get; set; }
    }
}