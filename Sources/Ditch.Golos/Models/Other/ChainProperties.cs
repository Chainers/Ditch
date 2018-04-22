using System;
using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Other
{
    /// <summary>
    /// chain_properties
    /// libraries\protocol\include\golos\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ChainProperties
    {
        // bdType : uint16_t | = steemit_default_sbd_interest_rate;
        [MessageOrder(10)]
        [JsonProperty("sbd_interest_rate")]
        public UInt16 SbdInterestRate { get; set; }

        [JsonProperty("account_creation_fee")]
        [MessageOrder(20)]
        public Asset AccountCreationFee { get; set; }

        [JsonProperty("maximum_block_size")]
        [MessageOrder(30)]
        public UInt32 MaximumBlockSize { get; set; }

        public ChainProperties(UInt16 sbdInterestRate, Asset accountCreationFee, UInt32 maximumBlockSize)
        {
            SbdInterestRate = sbdInterestRate;
            AccountCreationFee = accountCreationFee;
            MaximumBlockSize = maximumBlockSize;
        }

        public ChainProperties() { }
    }
}
