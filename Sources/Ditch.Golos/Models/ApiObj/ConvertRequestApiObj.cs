using Ditch.Golos.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.ApiObj
{
    /// <summary>
    /// convert_request_api_obj
    /// golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ConvertRequestApiObj : ConvertRequestObject
    {
    }
}
