using System;
using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// api_vesting_delegation_expiration_object
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiVestingDelegationExpirationObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: vesting_delegation_expiration_id_type</returns>
        [JsonProperty("id")]
        public object Id {get; set;}

        /// <summary>
        /// API name: delegator
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("delegator")]
        public string Delegator {get; set;}

        /// <summary>
        /// API name: vesting_shares
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("vesting_shares")]
        public LegacyAsset VestingShares {get; set;}

        /// <summary>
        /// API name: expiration
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("expiration")]
        public DateTime Expiration {get; set;}
    }
}
