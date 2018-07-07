using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /**
     * Witnesses must vote on how to set certain chain properties to ensure a smooth
     * and well functioning network. Any time @owner is in the active set of witnesses these
     * properties will be used to control the blockchain configuration.
     */

    /// <summary>
    /// chain_properties_17
    /// libraries\protocol\include\golos\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ChainProperties17
    {
        /// <summary>
        /// API name: account_creation_fee
        /// 
        /// This fee, paid in STEEM, is converted into VESTING SHARES for the new account. Accounts without vesting shares cannot earn usage rations and therefore are powerless.This minimum fee requires all accounts to have some kind of commitment to the network that includes the ability to vote and make transactions.
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(10)]
        [JsonProperty("account_creation_fee")]
        public Asset AccountCreationFee { get; set; }

        /// <summary>
        /// API name: maximum_block_size
        /// 
        ///  This witnesses vote for the maximum_block_size which is used by the network to tune rate limiting and capacity
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [MessageOrder(20)]
        [JsonProperty("maximum_block_size")]
        public uint MaximumBlockSize { get; set; }

        /// <summary>
        /// API name: sbd_interest_rate
        /// = STEEMIT_DEFAULT_SBD_INTEREST_RATE;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [MessageOrder(30)]
        [JsonProperty("sbd_interest_rate")]
        public ushort SbdInterestRate { get; set; }

        public ChainProperties17(ushort sbdInterestRate, Asset accountCreationFee, uint maximumBlockSize)
        {
            SbdInterestRate = sbdInterestRate;
            AccountCreationFee = accountCreationFee;
            MaximumBlockSize = maximumBlockSize;
        }

        public ChainProperties17() { }
    }
}
