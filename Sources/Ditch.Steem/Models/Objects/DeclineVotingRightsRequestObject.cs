using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// decline_voting_rights_request_object
    /// libraries\chain\include\steem\chain\steem_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DeclineVotingRightsRequestObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account")]
        public string Account {get; set;}

        /// <summary>
        /// API name: effective_date
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("effective_date")]
        public DateTime EffectiveDate {get; set;}
    }
}
