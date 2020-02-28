using System;
using Ditch.Core.Attributes;
using Ditch.Steem.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    /// <inheritdoc />
    /// <summary>
    ///  ****
    /// fill_convert_request_operation
    /// libraries\protocol\include\steem\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FillConvertRequestOperation : BaseOperation
    {
        public const string OperationName = "fill_convert_request_operation";
        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.FillConvertRequest;

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// API name: requestid
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [MessageOrder(30)]
        [JsonProperty("requestid")]
        public UInt32 Requestid { get; set; }

        /// <summary>
        /// API name: amount_in
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(40)]
        [JsonProperty("amount_in")]
        public Asset AmountIn { get; set; }

        /// <summary>
        /// API name: amount_out
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(50)]
        [JsonProperty("amount_out")]
        public Asset AmountOut { get; set; }
    }
}
