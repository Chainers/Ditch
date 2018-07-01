using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// legacy_chain_properties
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class LegacyChainProperties
    {

        /// <summary>
        /// API name: account_creation_fee
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [MessageOrder(10)]
        [JsonProperty("account_creation_fee")]
        public LegacyAsset AccountCreationFee {get; set;}

        // bdType : uint32_t | = steemit_min_block_size_limit * 2;
        /// <summary>
        /// This witnesses vote for the maximum_block_size which is used by the network to tune rate limiting and capacity
        /// </summary>
        [MessageOrder(20)]
        [JsonProperty("maximum_block_size")]
        public uint MaximumBlockSize { get; set; }
        
        /// <summary>
        /// API name: sbd_interest_rate
        /// = STEEM_DEFAULT_SBD_INTEREST_RATE;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [MessageOrder(30)]
        [JsonProperty("sbd_interest_rate")]
        public ushort SbdInterestRate {get; set;}

        public LegacyChainProperties(ushort sbdInterestRate, LegacyAsset accountCreationFee, uint maximumBlockSize)
        {
            SbdInterestRate = sbdInterestRate;
            AccountCreationFee = accountCreationFee;
            MaximumBlockSize = maximumBlockSize;
        }

        public LegacyChainProperties() { }
    }
}
