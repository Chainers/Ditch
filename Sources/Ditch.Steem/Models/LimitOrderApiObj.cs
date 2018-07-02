using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// limit_order_api_obj
    /// libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class LimitOrderApiObj : LimitOrderObject
    {
    }
}
