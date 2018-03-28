using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Other
{
    /// <summary>
    /// legacy_chain_properties
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class LegacyChainProperties
    {

        /// <summary>
        /// API name: account_creation_fee
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("account_creation_fee")]
        public LegacyAsset AccountCreationFee {get; set;}

        /// <summary>
        /// API name: sbd_interest_rate
        /// = STEEM_DEFAULT_SBD_INTEREST_RATE;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("sbd_interest_rate")]
        public UInt16 SbdInterestRate {get; set;}
    }
}
