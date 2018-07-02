using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// api_comment_vote_object
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiCommentVoteObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: comment_vote_id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: voter
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("voter")]
        public string Voter {get; set;}

        /// <summary>
        /// API name: author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("author")]
        public string Author {get; set;}

        /// <summary>
        /// API name: permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("permlink")]
        public string Permlink {get; set;}

        /// <summary>
        /// API name: weight
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("weight")]
        public ulong Weight {get; set;}

        /// <summary>
        /// API name: rshares
        /// = 0;
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("rshares")]
        public long Rshares {get; set;}

        /// <summary>
        /// API name: vote_percent
        /// = 0;
        /// </summary>
        /// <returns>API type: int16_t</returns>
        [JsonProperty("vote_percent")]
        public short VotePercent {get; set;}

        /// <summary>
        /// API name: last_update
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_update")]
        public TimePointSec LastUpdate {get; set;}

        /// <summary>
        /// API name: num_changes
        /// = 0;
        /// </summary>
        /// <returns>API type: int8_t</returns>
        [JsonProperty("num_changes")]
        public byte NumChanges {get; set;}
    }
}
