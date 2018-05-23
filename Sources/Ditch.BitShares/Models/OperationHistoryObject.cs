using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Ditch.BitShares.Models.Operations;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @brief tracks the history of all logical operations on blockchain state
     * @ingroup object
     * @ingroup implementation
     *
     *  All operations and virtual operations result in the creation of an
     *  operation_history_object that is maintained on disk as a stack.  Each
     *  real or virtual operation is assigned a unique ID / sequence number that
     *  it can be referenced by.
     *
     *  @note  by default these objects are not tracked, the account_history_plugin must
     *  be loaded fore these objects to be maintained.
     *
     *  @note  this object is READ ONLY it can never be modified
     */

    /// <summary>
    /// operation_history_object
    /// libraries\chain\include\graphene\chain\operation_history_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class OperationHistoryObject : AbstractObject<OperationHistoryObject>
    {

        /// <summary>
        /// API name: space_id
        /// = protocol_ids;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("space_id")]
        public byte SpaceId { get; set; }

        /// <summary>
        /// API name: type_id
        /// = operation_history_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: op
        /// 
        /// </summary>
        /// <returns>API type: operation</returns>
        [JsonProperty("op")]
        public BaseOperation Op { get; set; }

        /// <summary>
        /// API name: result
        /// 
        /// </summary>
        /// <returns>API type: operation_result</returns>
        [JsonProperty("result")]
        public object Result { get; set; }

        /** the block that caused this operation */

        /// <summary>
        /// API name: block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("block_num")]
        public UInt32 BlockNum { get; set; }

        /** the transaction in the block */

        /// <summary>
        /// API name: trx_in_block
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("trx_in_block")]
        public UInt16 TrxInBlock { get; set; }

        /** the operation within the transaction */

        /// <summary>
        /// API name: op_in_trx
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("op_in_trx")]
        public UInt16 OpInTrx { get; set; }

        /** any virtual operations implied by operation in block */

        /// <summary>
        /// API name: virtual_op
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("virtual_op")]
        public UInt16 VirtualOp { get; set; }
    }
}
