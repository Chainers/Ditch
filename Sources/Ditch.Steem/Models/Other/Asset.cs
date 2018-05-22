using System;
using Ditch.Core.Attributes;
using Ditch.Core.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.Steem.Models.Other
{
    [JsonConverter(typeof(CustomConverter))]
    public partial class Asset : ICustomJson
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
        //  [JsonProperty("symbol")]
        [MessageOrder(20)]
        public AssetSymbolType Symbol { get; set; }


        public Asset(long amount, UInt32 assetNum)
        {
            Amount = amount;
            Symbol = new AssetSymbolType(assetNum);
        }

        public Asset() { }

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
