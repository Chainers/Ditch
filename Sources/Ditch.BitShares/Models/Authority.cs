using System;
using System.Collections.Generic;
using Ditch.Core.Attributes;
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
        [MessageOrder(10)]
        [JsonProperty("weight_threshold")]
        public UInt32 WeightThreshold { get; set; }

        /// <summary>
        /// API name: account_auths
        /// 
        /// </summary>
        /// <returns>API type: flat_map<account_id_type,weight_type></returns>
        [MessageOrder(20)]
        [JsonProperty("account_auths")]
        public MapContainer<AccountIdType, UInt16> AccountAuths { get; set; }

        /// <summary>
        /// API name: key_auths
        /// 
        /// </summary>
        /// <returns>API type: flat_map<public_key_type,weight_type></returns>
        [MessageOrder(30)]
        [JsonProperty("key_auths")]
        public MapContainer<PublicKeyType, UInt16> KeyAuths { get; set; }

        /** needed for backward compatibility only */

        /// <summary>
        /// API name: address_auths
        /// 
        /// </summary>
        /// <returns>API type: flat_map<address,weight_type></returns>
        [MessageOrder(40)]
        [JsonProperty("address_auths")]
        public MapContainer<object, UInt16> AddressAuths { get; set; }

        public Authority()
        {
            WeightThreshold = 1;
            AccountAuths = new MapContainer<AccountIdType, ushort>();
            KeyAuths = new MapContainer<PublicKeyType, ushort>();
            AddressAuths = new MapContainer<object, UInt16>();
        }

        public Authority(PublicKeyType key)
            : this()
        {
            KeyAuths.Add(new KeyValuePair<PublicKeyType, ushort>(key, 1));
        }
    }
}
