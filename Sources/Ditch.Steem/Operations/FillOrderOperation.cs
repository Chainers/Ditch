using System;
using Ditch.Core.Attributes;
using Ditch.Steem.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    /// <inheritdoc />
    /// <summary>
    ///  ****
    /// fill_order_operation
    /// libraries\protocol\include\steem\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FillOrderOperation : BaseOperation
    {
        public const string OperationName = "fill_order_operation";
        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.FillOrder;

        /// <summary>
        /// API name: current_owner
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("current_owner")]
        public string CurrentOwner { get; set; }

        /// <summary>
        /// API name: current_orderid
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [MessageOrder(30)]
        [JsonProperty("current_orderid")]
        public UInt32 CurrentOrderid { get; set; }

        /// <summary>
        /// API name: current_pays
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(40)]
        [JsonProperty("current_pays")]
        public Asset CurrentPays { get; set; }
        
        /// <summary>
        /// API name: open_owner
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(50)]
        [JsonProperty("open_owner")]
        public string OpenOwner { get; set; }

        /// <summary>
        /// API name: open_orderid
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [MessageOrder(60)]
        [JsonProperty("open_orderid")]
        public UInt32 OpenOrderid { get; set; }

        /// <summary>
        /// API name: open_pays
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(70)]
        [JsonProperty("open_pays")]
        public Asset OpenPays { get; set; }
    }
}
