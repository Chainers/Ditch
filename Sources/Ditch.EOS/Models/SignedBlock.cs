using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /**
     * This structure contains the set of signed transactions referenced by the
     * block summary. This inherits from block_summary/signed_block_header and is
     * what would be logged to disk to enable the regeneration of blockchain state.
     *
     * The transactions are grouped to mirror the cycles in block_summary, generated
     * transactions are not included.
     */

    /// <summary>
    /// signed_block
    /// libraries\chain\include\eosio\chain\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class SignedBlock : SignedBlockSummary
    {


        /// this is loaded and indexed into map<id,trx> that is referenced by summary; order doesn't matter

        /// <summary>
        /// API name: input_transactions
        /// 
        /// </summary>
        /// <returns>API type: packed_transaction</returns>
        [JsonProperty("input_transactions")]
        public PackedTransaction[] InputTransactions { get; set; }
    }
}
