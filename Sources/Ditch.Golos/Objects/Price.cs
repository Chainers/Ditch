using Ditch.Core;
using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /// <summary>
    /// price
    /// golos-0.16.3\libraries\protocol\include\steemit\protocol\asset.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Price
    {

        // bdType : asset
        [JsonProperty("base")]
        public Asset Base { get; set; }

        // bdType : asset
        [JsonProperty("quote")]
        public Asset Quote { get; set; }
    }
}