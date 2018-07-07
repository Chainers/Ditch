using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <inheritdoc />
    /// <summary>
    /// transaction_receipt
    /// libraries\chain\include\eosio\chain\block.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TransactionReceipt : TransactionReceiptHeader
    {

        /// <summary>
        /// API name: trx
        /// 
        /// </summary>
        /// <returns>API type: fc::static_variant&lt;transaction_id_type, packed_transaction>></returns>
        public object Trx { get; set; }
    }
}
