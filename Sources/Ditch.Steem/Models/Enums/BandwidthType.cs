using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Enums
{
    [JsonConverter(typeof(EnumConverter))]
    public enum BandwidthType
    {
        /// <summary>
        /// Rate limiting posting reward eligibility over time
        /// </summary>
        Post,

        /// <summary>
        /// Rate limiting for all forum related actins
        /// </summary>
        Forum,

        /// <summary>
        /// Rate limiting for all other actions
        /// </summary>
        Market
    }
}