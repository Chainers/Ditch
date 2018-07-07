using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// vesting_delegation_expiration_object
    /// libraries\chain\include\golos\chain\objects\account_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class VestingDelegationExpirationObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: delegator
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("delegator")]
        public string Delegator { get; set; }

        /// <summary>
        /// API name: vesting_shares
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("vesting_shares")]
        public Asset VestingShares { get; set; }

        /// <summary>
        /// API name: expiration
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("expiration")]
        public TimePointSec Expiration { get; set; }
    }
}
