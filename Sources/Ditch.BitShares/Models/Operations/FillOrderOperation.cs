using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models.Operations
{
    /**
     * @ingroup operations
     *
     * @note This is a virtual operation that is created while matching orders and
     * emitted for the purpose of accurately tracking account history, accelerating
     * a reindex.
     */

    /// <summary>
    /// fill_order_operation
    /// libraries\chain\include\graphene\chain\protocol\market.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class FillOrderOperation : BaseOperation
    {
        public override OperationType Type => OperationType.FillOrder;

        public override string TypeName => "fill_order";


        /// <summary>
        /// API name: order_id
        /// 
        /// </summary>
        /// <returns>API type: object_id_type</returns>
        [MessageOrder(20)]
        [JsonProperty("order_id")]
        public object OrderId { get; set; }

        /// <summary>
        /// API name: account_id
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [MessageOrder(30)]
        [JsonProperty("account_id")]
        public object AccountId { get; set; }

        /// <summary>
        /// API name: pays
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(40)]
        [JsonProperty("pays")]
        public object Pays { get; set; }

        /// <summary>
        /// API name: receives
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(50)]
        [JsonProperty("receives")]
        public object Receives { get; set; }

        /// <summary>
        /// API name: fee
        /// paid by receiving account
        /// </summary>
        /// <returns>API type: asset</returns>
        [MessageOrder(60)]
        [JsonProperty("fee")]
        public object Fee { get; set; }

        /// <summary>
        /// API name: fill_price
        /// 
        /// </summary>
        /// <returns>API type: price</returns>
        [MessageOrder(70)]
        [JsonProperty("fill_price")]
        public Price FillPrice { get; set; }

        /// <summary>
        /// API name: is_maker
        /// 
        /// </summary>
        /// <returns>API type: bool</returns>
        [MessageOrder(80)]
        [JsonProperty("is_maker")]
        public bool IsMaker { get; set; }
    }
}
