using System;
using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class VoteState
    {
        [JsonProperty("voter")]
        public string Voter { get; set; }

        [JsonProperty("weight")]
        public UInt64 Weight { get; set; }

        [JsonProperty("rshares")]
        public Int64 Rshares { get; set; }

        [JsonProperty("percent")]
        public Int16 Percent { get; set; }


        //share_type
        [JsonProperty("reputation")]
        public object Reputation { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }
}