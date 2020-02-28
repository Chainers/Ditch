using System;
using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    /// <inheritdoc />
    /// <summary>
    ///  ****
    /// limit_order_cancel_operation
    /// libraries\protocol\include\steem\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class LimitOrderCancelOperation : BaseOperation
    {
        public const string OperationName = "limit_order_cancel_operation";
        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.LimitOrderCancel;

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// API name: orderid
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [MessageOrder(30)]
        [JsonProperty("orderid")]
        public UInt32 Orderid { get; set; }
    }
}
