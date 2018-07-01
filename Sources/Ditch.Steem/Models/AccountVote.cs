using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// account_vote
    /// libraries\app\include\steemit\app\state.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AccountVote
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
        public ulong Weight { get; set; }

        /// <summary>
        /// API name: rshares
        /// = 0;
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("rshares")]
        public long Rshares { get; set; }

        /// <summary>
        /// API name: percent
        /// = 0;
        /// </summary>
        /// <returns>API type: int16_t</returns>
        [JsonProperty("percent")]
        public short Percent { get; set; }

        /// <summary>
        /// API name: time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("time")]
        public TimePointSec Time { get; set; }
    }
}
