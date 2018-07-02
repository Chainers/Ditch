using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_order_book_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetOrderBookReturn : OrderBook
    {
    }
}
