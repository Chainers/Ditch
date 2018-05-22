using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  @brief adds a signature to a transaction
     */

    /// <summary>
    /// signed_transaction
    /// libraries\chain\include\graphene\chain\protocol\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class SignedTransaction : Transaction
    {

        /// <summary>
        /// API name: signatures
        /// 
        /// </summary>
        /// <returns>API type: signature_type</returns>
        [JsonProperty("signatures")]
        public byte[][] Signatures { get; set; }
    }
}
