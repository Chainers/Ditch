using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Objects
{
    /// <summary>
    /// account_vote
    /// libraries\app\include\steemit\app\state.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AccountVote
    {

        /// <summary>
        /// API name: authorperm
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("authorperm")]
        public string Authorperm { get; set; }

        /// <summary>
        /// API name: weight
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("weight")]
        public UInt64 Weight { get; set; }

        /// <summary>
        /// API name: rshares
        /// = 0;
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("rshares")]
        public Int64 Rshares { get; set; }

        /// <summary>
        /// API name: percent
        /// = 0;
        /// </summary>
        /// <returns>API type: int16_t</returns>
        [JsonProperty("percent")]
        public Int16 Percent { get; set; }

        /// <summary>
        /// API name: time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }
}
