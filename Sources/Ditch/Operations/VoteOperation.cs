using System;
using Ditch.Helpers;
using Newtonsoft.Json;

namespace Ditch.Operations
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class VoteOperation : BaseOperation
    {
        private ushort _weight;

        [SerializeHelper.IgnoreForMessage]
        public override string TypeName => "vote";

        public override OperationType Type => OperationType.Vote;

        [JsonProperty("voter")]
        public string Voter { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("permlink")]
        public string Permlink { get; set; }

        [JsonProperty("weight")]
        public UInt16 Weight
        {
            get => _weight;
            set => _weight = Math.Min(value, (UInt16)10000);
        }
    }
}