using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
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
        /// <returns>API type: fc::static_variant<transaction_id_type, packed_transaction>>
        //public StaticVariant<string, PackedTransaction> Trx { get; set; }
        public object Trx { get; set; }
    }
}
