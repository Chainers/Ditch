using System;
using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.ApiObj
{
    /// <summary>
    /// account_recovery_request_api_obj
    /// steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AccountRecoveryRequestApiObj
    {

        // bdType : account_recovery_request_id_type
        [JsonProperty("id")]
        public object Id { get; set; }

        // bdType : account_name_type
        [JsonProperty("account_to_recover")]
        public string AccountToRecover { get; set; }

        // bdType : authority
        [JsonProperty("new_owner_authority")]
        public Authority NewOwnerAuthority { get; set; }

        // bdType : time_point_sec
        [JsonProperty("expires")]
        public DateTime Expires { get; set; }
    }
}
