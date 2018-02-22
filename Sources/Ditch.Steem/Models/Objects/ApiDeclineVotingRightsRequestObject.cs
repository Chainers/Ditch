using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
{
    /// <summary>
    /// api_decline_voting_rights_request_object
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ApiDeclineVotingRightsRequestObject : DeclineVotingRightsRequestObject
    {
    }
}
