using System;
using Newtonsoft.Json;

namespace Ditch.Operations
{
    [JsonObject(MemberSerialization.OptIn)]
    public class VoteOperation : BaseOperation
    {
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
        public UInt16 Weight { get; set; }
    }
}