using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Enums
{
    /// <summary>
    /// bandwidth_type
    /// libraries\chain\include\steem\chain\steem_object_types.hpp
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum BandwidthType
    {

        /// <summary>
        /// API name: post
        /// Rate limiting posting reward eligibility over time
        /// </summary>
        Post,

        /// <summary>
        /// API name: forum
        /// Rate limiting for all forum related actins
        /// </summary>
        Forum,

        /// <summary>
        /// API name: market
        /// Rate limiting for all other actions
        /// </summary>
        Market,
    }
}