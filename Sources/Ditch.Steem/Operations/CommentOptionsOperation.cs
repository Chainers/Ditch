using Ditch.Core.Attributes;
using Ditch.Steem.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CommentOptionsOperation : BaseOperation
    {
        public const string OperationName = "comment_options_operation";
        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.CommentOptions;

        [MessageOrder(20)]
        [JsonProperty("author")]
        public string Author { get; set; }

        [MessageOrder(30)]
        [JsonProperty("permlink")]
        public string Permlink { get; set; }

        [JsonProperty("max_accepted_payout")]
        [MessageOrder(40)]
        public Asset MaxAcceptedPayout { get; set; }

        [MessageOrder(50)]
        [JsonProperty("percent_steem_dollars")]
        public ushort PercentSteemDollars { get; set; }

        [MessageOrder(60)]
        [JsonProperty("allow_votes")]
        public bool AllowVotes { get; set; }

        [MessageOrder(70)]
        [JsonProperty("allow_curation_rewards")]
        public bool AllowCurationRewards { get; set; }

        [MessageOrder(80)]
        [JsonProperty("extensions")]
        public object[] Extensions { get; set; }

        public CommentOptionsOperation(string author, string permlink, Asset maxAcceptedPayout, ushort percentSteemDollars, bool allowVotes, bool allowCurationRewards, params object[] extensions)
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