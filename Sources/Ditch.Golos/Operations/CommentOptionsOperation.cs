using System;
using Ditch.Core;
using Ditch.Golos.Helpers;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations
{
    /**
     *  Authors of posts may not want all of the benefits that come from creating a post. This
     *  operation allows authors to update properties associated with their post.
     *
     *  The max_accepted_payout may be decreased, but never increased.
     *  The percent_steem_dollars may be decreased, but never increased
     *
     */

    /// <summary>
    /// comment_options_operation
    /// libraries\protocol\include\golos\protocol\operations\comment_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CommentOptionsOperation : BaseOperation
    {
        public override OperationType Type => OperationType.CommentOptions;
        public override string TypeName => "comment_options";

        /// <summary>
        /// API name: author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// API name: permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(30)]
        [JsonProperty("permlink")]
        public string Permlink { get; set; }

        /// <summary>        
        /// API name: max_accepted_payout 
        /// = {1000000000, SBD_SYMBOL_NAME};   
        /// SBD value of the maximum payout this post will receive
        /// </summary>
        /// <returns>API type: asset&lt;Major, Hardfork, Release></returns>
        [JsonProperty("max_accepted_payout")]
        public string MaxAcceptedPayoutStr { get; set; }
        [MessageOrder(40)]
        public Asset MaxAcceptedPayout
        {
            get => MaxAcceptedPayoutStr;
            set => MaxAcceptedPayoutStr = value;
        }

        /// <summary>
        /// API name: percent_steem_dollars
        /// = STEEMIT_100_PERCENT; 
        /// the percent of Golos Gold to key, unkept amounts will be received as Golos Power
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [MessageOrder(50)]
        [JsonProperty("percent_steem_dollars")]
        public UInt16 PercentSteemDollars { get; set; }

        /// <summary>
        /// API name: allow_votes
        /// = true; /// allows a post to receive votes;
        /// </summary>
        /// <returns>API type: bool</returns>
        [MessageOrder(60)]
        [JsonProperty("allow_votes")]
        public bool AllowVotes { get; set; }

        /// <summary>
        /// API name: allow_curation_rewards
        /// = true; 
        /// allows voters to recieve curation rewards. Rewards return to reward fund.
        /// </summary>
        /// <returns>API type: bool</returns>
        [MessageOrder(70)]
        [JsonProperty("allow_curation_rewards")]
        public bool AllowCurationRewards { get; set; }

        /// <summary>
        /// API name: extensions
        /// 
        /// </summary>
        /// <returns>API type: comment_options_extensions_type</returns>
        [MessageOrder(80)]
        [JsonProperty("extensions")]
        public object[] Extensions { get; set; }

        public CommentOptionsOperation(string author, string permlink, Asset maxAcceptedPayout, UInt16 percentSteemDollars, bool allowVotes, bool allowCurationRewards, params object[] extensions)
        {
            Author = author;
            Permlink = permlink;
            MaxAcceptedPayout = maxAcceptedPayout;
            PercentSteemDollars = percentSteemDollars;
            AllowVotes = allowVotes;
            AllowCurationRewards = allowCurationRewards;
            Extensions = extensions;
        }
    }
}