using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  Contains the confirmation receipt the sender must give the receiver and
     *  the meta data about the receipt that helps the sender identify which receipt is
     *  for the receiver and which is for the change address.
     */

    /// <summary>
    /// blind_confirmation
    /// libraries\wallet\include\graphene\wallet\wallet.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class BlindConfirmation
    {

        /// <summary>
        /// API name: trx
        /// 
        /// </summary>
        /// <returns>API type: signed_transaction</returns>
        [JsonProperty("trx")]
        public SignedTransaction Trx { get; set; }

        /// <summary>
        /// API name: outputs
        /// 
        /// </summary>
        /// <returns>API type: output</returns>
        [JsonProperty("outputs")]
        public Output[] Outputs { get; set; }
    }
}
