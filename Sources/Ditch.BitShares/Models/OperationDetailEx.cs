using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// operation_detail_ex
    /// libraries\wallet\include\graphene\wallet\wallet.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class OperationDetailEx
    {

        /// <summary>
        /// API name: memo
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// API name: description
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// API name: op
        /// 
        /// </summary>
        /// <returns>API type: operation_history_object</returns>
        [JsonProperty("op")]
        public OperationHistoryObject Op { get; set; }

        /// <summary>
        /// API name: transaction_id
        /// 
        /// </summary>
        /// <returns>API type: transaction_id_type</returns>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
    }
}
