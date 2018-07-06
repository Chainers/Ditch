using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /* Order Book */

    /// <summary>
    /// get_order_book_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetOrderBookArgs
    {

        /// <summary>
        /// API name: limit
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public uint Limit {get; set;}
    }
}
