using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Other
{
    /// <summary>
    /// chain_properties
    /// libraries\protocol\include\golos\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ChainProperties
    {
        [JsonProperty("account_creation_fee")]
        [MessageOrder(10)]
        public Asset AccountCreationFee { get; set; }
        
        [JsonProperty("maximum_block_size")]
        [MessageOrder(20)]
        public uint MaximumBlockSize { get; set; }

        // bdType : uint16_t | = steemit_default_sbd_interest_rate;
        [MessageOrder(30)]
        [JsonProperty("sbd_interest_rate")]
        public ushort SbdInterestRate { get; set; }

        public ChainProperties(ushort sbdInterestRate, Asset accountCreationFee, uint maximumBlockSize)
        {
            SbdInterestRate = sbdInterestRate;
            AccountCreationFee = accountCreationFee;
            MaximumBlockSize = maximumBlockSize;
        }

        public ChainProperties() { }
    }
}
