using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// find_owner_histories_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FindOwnerHistoriesReturn : ListOwnerHistoriesReturn
    {
    }
}
