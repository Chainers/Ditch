using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Enums
{
    /// <summary>
    /// authority_type
    /// libraries\wallet\include\golos\wallet\wallet.hpp
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum AuthorityType
    {

        /// <summary>
        /// API name: owner
        /// posting
        /// </summary>
        Owner
    }
}
