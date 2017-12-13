using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /// <summary>
    /// vote_state
    /// golos-0.16.3\libraries\app\include\steemit\app\state.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class VoteState
    {

        // bdType : string
        [JsonProperty("voter")]
        public string Voter { get; set; }

        // bdType : uint64_t | = 0;
        [JsonProperty("weight")]
        public UInt64 Weight { get; set; }

        // bdType : int64_t | = 0;
        [JsonProperty("rshares")]
        public Int64 Rshares { get; set; }

        // bdType : int16_t | = 0;
        [JsonProperty("percent")]
        public Int16 Percent { get; set; }

        // bdType : share_type | = 0;
        [JsonProperty("reputation")]
        public object Reputation { get; set; }

        // bdType : time_point_sec
        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }
}