using System;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// signed_block
    /// libraries\chain\include\eosio\chain\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SignedBlock : SignedBlockHeader
    {

        /// <summary>
        /// API name: transactions
        /// new or generated transactions
        /// </summary>
        /// <returns>API type: transaction_receipt</returns>
        [JsonProperty("transactions")]
        public TransactionReceipt[] Transactions { get; set; }

        /// <summary>
        /// API name: block_extensions
        /// 
        /// </summary>
        /// <returns>API type: extensions_type</returns>
        [JsonProperty("block_extensions")]
        public Tuple<UInt16, char[]>[] BlockExtensions { get; set; }
    }
}
