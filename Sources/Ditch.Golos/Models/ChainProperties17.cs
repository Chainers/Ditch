using System;
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
        /// API name: sbd_interest_rate
        /// = STEEMIT_DEFAULT_SBD_INTEREST_RATE;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("sbd_interest_rate")]
        public UInt16 SbdInterestRate { get; set; }
    }
}
