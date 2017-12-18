using Ditch.Core.Helpers;
using Newtonsoft.Json;

namespace Ditch.Steem.Enums
{
    /// <summary>
    /// classification
    /// libraries\protocol\include\steemit\protocol\authority.hpp
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum Classification
    {

        /// <summary>
        /// API name: owner
        /// 0
        /// </summary>
        Owner,

        /// <summary>
        /// API name: active
        /// 1
        /// </summary>
        Active,

        /// <summary>
        /// API name: key
        /// 2
        /// </summary>
        Key,

        /// <summary>
        /// API name: posting
        /// 3
        /// </summary>
        Posting,
    }
}
