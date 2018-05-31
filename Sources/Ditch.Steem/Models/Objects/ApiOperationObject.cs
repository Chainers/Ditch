using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.Steem.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// api_operation_object
    /// libraries\plugins\apis\account_history_api\include\steem\plugins\account_history_api\account_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ApiOperationObject
    {

        /// <summary>
        /// API name: trx_id
        /// 
        /// </summary>
        /// <returns>API type: transaction_id_type</returns>
        [JsonProperty("trx_id")]
        public string TrxId { get; set; }

        /// <summary>
        /// API name: block
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("block")]
        public UInt32 Block { get; set; }

        /// <summary>
        /// API name: trx_in_block
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("trx_in_block")]
        public UInt32 TrxInBlock { get; set; }

        /// <summary>
        /// API name: op_in_trx
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("op_in_trx")]
        public UInt32 OpInTrx { get; set; }

        /// <summary>
        /// API name: virtual_op
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("virtual_op")]
        public UInt32 VirtualOp { get; set; }

        /// <summary>
        /// API name: timestamp
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// API name: op
        /// 
        /// </summary>
        /// <returns>API type: operation</returns>
        [JsonProperty("op")]
        public object Op { get; set; }
    }
}
