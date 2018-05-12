using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// list_limit_orders_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ListLimitOrdersReturn
    {

        /// <summary>
        /// API name: orders
        /// 
        /// </summary>
        /// <returns>API type: api_limit_order_object</returns>
        [JsonProperty("orders")]
        public ApiLimitOrderObject[] Orders {get; set;}
    }
}
