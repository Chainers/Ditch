using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// legacy_asset
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api_legacy_asset.hpp
    /// </summary>
    [JsonConverter(typeof(CustomConverter))]
    [JsonObject(MemberSerialization.OptIn)]
    public class LegacyAsset : Asset
    {
        public LegacyAsset() { }

        //public LegacyAsset(long amount, uint assetNum) : base(amount, assetNum) { }
    }
}
