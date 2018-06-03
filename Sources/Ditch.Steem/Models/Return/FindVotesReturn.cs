using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// find_votes_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FindVotesReturn : ListVotesReturn
    {
    }
}
