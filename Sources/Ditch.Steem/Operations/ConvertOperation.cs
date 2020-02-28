using System;
using Ditch.Core.Attributes;
using Ditch.Steem.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    /// <inheritdoc />
    /// <summary>
    ///  ****
    /// convert_operation
    /// libraries\protocol\include\steem\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ConvertOperation : BaseOperation
    {
        public const string OperationName = "convert_operation";
        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.Convert;

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
        /// API name: amount
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(40)]
        [JsonProperty("amount")]
        public Asset Amount { get; set; }
    }
}
