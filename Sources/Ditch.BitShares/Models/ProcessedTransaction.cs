using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  @brief captures the result of evaluating the operations contained in the transaction
     *
     *  When processing a transaction some operations generate
     *  new object IDs and these IDs cannot be known until the
     *  transaction is actually included into a block.  When a
     *  block is produced these new ids are captured and included
     *  with every transaction.  The index in operation_results should
     *  correspond to the same index in operations.
     *
     *  If an operation did not create any new object IDs then 0
     *  should be returned.
     */

    /// <summary>
    /// processed_transaction
    /// libraries\chain\include\graphene\chain\protocol\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ProcessedTransaction : SignedTransaction
    {

        /// <summary>
        /// API name: operation_results
        /// 
        /// </summary>
        /// <returns>API type: operation_result</returns>
        [JsonProperty("operation_results")]
        public object[] OperationResults { get; set; }
    }
}
