using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// history_operation_detail
    /// libraries\app\include\graphene\app\api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class HistoryOperationDetail
    {

        /// <summary>
        /// API name: total_count
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("total_count")]
        public UInt32 TotalCount { get; set; }

        /// <summary>
        /// API name: operation_history_objs
        /// 
        /// </summary>
        /// <returns>API type: operation_history_object</returns>
        [JsonProperty("operation_history_objs")]
        public OperationHistoryObject[] OperationHistoryObjs { get; set; }
    }
}
