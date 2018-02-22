using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// api_owner_authority_history_object
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ApiOwnerAuthorityHistoryObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: owner_authority_history_id_type</returns>
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
        /// API name: previous_owner_authority
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [JsonProperty("previous_owner_authority")]
        public Authority PreviousOwnerAuthority {get; set;}

        /// <summary>
        /// API name: last_valid_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_valid_time")]
        public DateTime LastValidTime {get; set;}
    }
}
