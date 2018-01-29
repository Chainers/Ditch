using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /// <summary>
    /// owner_authority_history_api_obj
    /// golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class OwnerAuthorityHistoryApiObj
    {

        // bdType : owner_authority_history_id_type
        [JsonProperty("id")]
        public object Id { get; set; }

        // bdType : account_name_type
        [JsonProperty("account")]
        public string Account { get; set; }

        // bdType : authority
        [JsonProperty("previous_owner_authority")]
        public Authority PreviousOwnerAuthority { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_valid_time")]
        public DateTime LastValidTime { get; set; }
    }
}