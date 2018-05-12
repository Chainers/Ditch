using Ditch.Core.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.Steem.Models.Other
{
    /// <summary>
    /// legacy_asset
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api_legacy_asset.hpp
    /// </summary>
    [JsonConverter(typeof(ToArrayConverter))]
    [JsonObject(MemberSerialization.OptIn)]
    public partial class LegacyAsset : IComplexArray
    {
        /// <summary>
        /// API name: amount
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
      //  [JsonProperty("amount")]
        public object Amount { get; set; }

        /// <summary>
        /// API name: symbol
        /// = STEEM_SYMBOL;
        /// </summary>
        /// <returns>API type: asset_symbol_type</returns>
      //  [JsonProperty("symbol")]
        public AssetSymbolType Symbol { get; set; }


        #region IComplexArray

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var arr = serializer.Deserialize<JArray>(reader);
            Amount = arr[0].Value<long>();
            Symbol = new AssetSymbolType(arr[2].Value<string>(), arr[1].Value<byte>());
        }

        public void WriteJson(JsonWriter write, JsonSerializer serializer)
        {
            write.WriteRawValue($"[\"{Amount}\",{Symbol.Decimals()},\"{Symbol.ToNaiString()}\"]");
        }

        #endregion

    }
}
