using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// api_limit_order_object
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ApiLimitOrderObject : LimitOrderObject
    {
    }
}
