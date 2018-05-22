using System;
using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Other
{
    /// <summary>
    /// chain_properties
    /// steem-0.19.1\libraries\protocol\include\steemit\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ChainProperties
    {

        // bdType : asset | =
        /// <summary>
        /// This fee, paid in STEEM, is converted into VESTING SHARES for the new account.Accounts 
        /// without vesting shares cannot earn usage rations and therefore are powerless.This minimum 
        /// fee requires all accounts to have some kind of commitment to the network that includes the
        ///  ability to vote and make transactions.
        /// </summary>
        [MessageOrder(10)]
        [JsonProperty("account_creation_fee")]
        public Asset AccountCreationFee { get; set; }

        // bdType : uint32_t | = steemit_min_block_size_limit * 2;
        /// <summary>
        /// This witnesses vote for the maximum_block_size which is used by the network to tune rate limiting and capacity
        /// </summary>
        [MessageOrder(20)]
        [JsonProperty("maximum_block_size")]
        public UInt32 MaximumBlockSize { get; set; }

        // bdType : uint16_t | = steemit_default_sbd_interest_rate;
        [MessageOrder(30)]
        [JsonProperty("sbd_interest_rate")]
        public UInt16 SbdInterestRate { get; set; }
    }
}