using Ditch.Core.Attributes;
using Ditch.Core.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.Steem.Models.Other
{
    /// <summary>
    /// legacy_asset
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api_legacy_asset.hpp
    /// </summary>
    [JsonConverter(typeof(CustomConverter))]
    [JsonObject(MemberSerialization.OptIn)]
    public class LegacyAsset : ICustomJson
    {
        /// <summary>
        /// API name: amount
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [MessageOrder(10)]
        public long Amount { get; set; }

        /// <summary>
        /// API name: symbol
        /// = STEEM_SYMBOL;
        /// </summary>
        /// <returns>API type: asset_symbol_type</returns>
        [MessageOrder(20)]
        public AssetSymbolType Symbol { get; set; }

        public LegacyAsset(long amount, uint assetNum)
        {
            Amount = amount;
            Symbol = new AssetSymbolType(assetNum);
        }

        public LegacyAsset() { }

        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var arr = serializer.Deserialize<JArray>(reader);
            Amount = arr[0].Value<long>();
            Symbol = new AssetSymbolType(arr[2].Value<string>(), arr[1].Value<byte>());
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            writer.WriteValue(Amount.ToString());
            writer.WriteValue(Symbol.Decimals());
            writer.WriteValue(Symbol.ToNaiString());
            writer.WriteEndArray();
        }

        #endregion
    }
}
