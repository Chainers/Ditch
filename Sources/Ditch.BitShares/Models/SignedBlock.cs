using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// signed_block
    /// libraries\chain\include\graphene\chain\protocol\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class SignedBlock : SignedBlockHeader
    {

        /// <summary>
        /// API name: transactions
        /// 
        /// </summary>
        /// <returns>API type: processed_transaction</returns>
        [JsonProperty("transactions")]
        public ProcessedTransaction[] Transactions { get; set; }
    }
}
