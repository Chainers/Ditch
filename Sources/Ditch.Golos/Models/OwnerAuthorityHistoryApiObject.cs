using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// owner_authority_history_api_object
    /// plugins\database_api\include\golos\plugins\database_api\api_objects\owner_authority_history_api_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class OwnerAuthorityHistoryApiObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: owner_authority_history_object::id_type</returns>
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
        public TimePointSec LastValidTime {get; set;}
    }
}
