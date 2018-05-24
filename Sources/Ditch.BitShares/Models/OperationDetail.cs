using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// operation_detail
    /// libraries\wallet\include\graphene\wallet\wallet.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class OperationDetail
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
    }
}
