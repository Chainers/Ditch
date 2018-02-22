using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// find_account_recovery_requests_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class FindAccountRecoveryRequestsReturn : ListAccountRecoveryRequestsReturn
    {
    }
}
