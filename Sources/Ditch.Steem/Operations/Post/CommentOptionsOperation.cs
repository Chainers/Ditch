using System;
using Ditch.Core;
using Ditch.Steem.Helpers;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations.Post
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CommentOptionsOperation : BaseOperation
    {
        public override OperationType Type => OperationType.CommentOptions;
        public override string TypeName => "comment_options";

        [SerializeHelper.MessageOrder(20)]
        [JsonProperty("author")]
        public string Author { get; set; }

        [SerializeHelper.MessageOrder(30)]
        [JsonProperty("permlink")]
        public string Permlink { get; set; }

        [JsonProperty("max_accepted_payout")]
        public string MaxAcceptedPayoutStr { get; set; }
        [SerializeHelper.MessageOrder(40)]
        public Money MaxAcceptedPayout
        {
            get => MaxAcceptedPayoutStr;
            set => MaxAcceptedPayoutStr = value;
        }

        [SerializeHelper.MessageOrder(50)]
        [JsonProperty("percent_steem_dollars")]
        public UInt16 PercentSteemDollars { get; set; }

        [SerializeHelper.MessageOrder(60)]
        [JsonProperty("allow_votes")]
        public bool AllowVotes { get; set; }

        [SerializeHelper.MessageOrder(70)]
        [JsonProperty("allow_curation_rewards")]
        public bool AllowCurationRewards { get; set; }

        [SerializeHelper.MessageOrder(80)]
        [JsonProperty("extensions")]
        public object[] Extensions { get; set; }

        public CommentOptionsOperation(string author, string permlink, Money maxAcceptedPayout, UInt16 percentSteemDollars, bool allowVotes, bool allowCurationRewards, params object[] extensions)
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