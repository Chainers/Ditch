using Ditch.Core;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations.Get
{
    /// <summary>
    /// price
    /// golos-0.16.3\libraries\protocol\include\steemit\protocol\asset.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Price
    {

        // bdType : asset
        [JsonProperty("base")]
        public Money Base { get; set; }

        // bdType : asset
        [JsonProperty("quote")]
        public Money Quote { get; set; }
    }
}