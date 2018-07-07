using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <inheritdoc />
    /// <summary>
    /// signed_block
    /// libraries\chain\include\graphene\chain\protocol\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SignedBlock : SignedBlockHeader
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
