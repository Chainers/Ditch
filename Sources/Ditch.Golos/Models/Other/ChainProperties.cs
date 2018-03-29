using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Objects
{
    /// <summary>
    /// chain_properties
    /// libraries\protocol\include\golos\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ChainProperties
    {
        // bdType : uint16_t | = steemit_default_sbd_interest_rate;
        [JsonProperty("sbd_interest_rate")]
        public UInt16 SbdInterestRate { get; set; }

        [JsonProperty("account_creation_fee")]
        public Asset AccountCreationFee { get; set; }

        [JsonProperty("maximum_block_size")]
        public UInt32 MaximumBlockSize { get; set; }
    }
}