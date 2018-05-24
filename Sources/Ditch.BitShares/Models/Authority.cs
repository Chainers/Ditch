using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  @class authority
     *  @brief Identifies a weighted set of keys and accounts that must approve operations.
     */

    /// <summary>
    /// authority
    /// libraries\chain\include\graphene\chain\protocol\authority.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Authority
    {

        /// <summary>
        /// API name: weight_threshold
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("weight_threshold")]
        public UInt32 WeightThreshold { get; set; }

        /// <summary>
        /// API name: account_auths
        /// 
        /// </summary>
        /// <returns>API type: flat_map</returns>
        [JsonProperty("account_auths")]
        public MapContainer<object, UInt16> AccountAuths { get; set; }

        /// <summary>
        /// API name: key_auths
        /// 
        /// </summary>
        /// <returns>API type: flat_map</returns>
        [JsonProperty("key_auths")]
        public MapContainer<object, UInt16> KeyAuths { get; set; }

        /** needed for backward compatibility only */

        /// <summary>
        /// API name: address_auths
        /// 
        /// </summary>
        /// <returns>API type: flat_map</returns>
        [JsonProperty("address_auths")]
        public MapContainer<object, UInt16> AddressAuths { get; set; }
    }
}
