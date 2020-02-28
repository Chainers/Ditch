using System;
using Ditch.Core.Attributes;
using Ditch.Core.Models;
using Ditch.Steem.Models;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations
{
    /// <inheritdoc />
    /// <summary>
    ///  ****
    /// limit_order_create_operation
    /// libraries\protocol\include\steem\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class LimitOrderCreateOperation : BaseOperation
    {
        public const string OperationName = "limit_order_create_operation";
        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.LimitOrderCreate;

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

        /// <summary>
        /// API name: amount_to_sell
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(40)]
        [JsonProperty("amount_to_sell")]
        public Asset AmountToSell { get; set; }

        /// <summary>
        /// API name: min_to_receive
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(50)]
        [JsonProperty("min_to_receive")]
        public Asset MinToReceive { get; set; }

        /// <summary>
        /// API name: fill_or_kill
        /// 
        /// </summary>
        /// <returns>API type: bool</returns>
        [MessageOrder(60)]
        [JsonProperty("fill_or_kill")]
        public bool FillOrKill { get; set; }

        /// <summary>
        /// API name: expiration
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [MessageOrder(70)]
        [JsonProperty("expiration")]
        public TimePointSec Expiration { get; set; }
    }
}
