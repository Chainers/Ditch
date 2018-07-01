using System;
using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    /// <summary>
    /// Vote up/down/flag post
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class VoteOperation : BaseOperation
    {
        public const short MaxFlagVote = -10000;
        public const short MaxUpVote = 10000;
        public const short NoneVote = 0;

        private short _weight;

        public override string TypeName => "vote";

        public override OperationType Type => OperationType.Vote;

        [MessageOrder(20)]
        [JsonProperty("voter")]
        public string Voter { get; set; }

        [MessageOrder(30)]
        [JsonProperty("author")]
        public string Author { get; set; }

        [MessageOrder(40)]
        [JsonProperty("permlink")]
        public string Permlink { get; set; }

        /// <summary>
        /// An weignt from 0 to 10000. -10000 for flag
        /// </summary>
        [MessageOrder(50)]
        [JsonProperty("weight")]
        public short Weight
        {
            get => _weight;
            set => _weight = Math.Min(value, (short)10000);
        }

        public VoteOperation(string voter, string author, string permlink, short weight)
        {
            Voter = voter;
            Author = author;
            Permlink = permlink;
            Weight = weight;
        }
    }
}