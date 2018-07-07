using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// delegations_type
    /// plugins\database_api\include\golos\plugins\database_api\plugin.hpp
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum DelegationsType
    {

        /// <summary>
        /// API name: delegated
        /// 
        /// </summary>
        Delegated
    }
}
