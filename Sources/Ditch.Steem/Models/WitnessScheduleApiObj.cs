using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// witness_schedule_api_obj
    /// steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WitnessScheduleApiObj : WitnessScheduleObject
    {
    }
}