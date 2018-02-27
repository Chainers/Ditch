using System;
using Ditch.Core.Helpers;
using Ditch.Steem.Helpers;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    [JsonConverter(typeof(ToArrayConverter))]
    public partial class Asset : IComplexArray
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
        
#region IComplexArray

public void InitFromArray(object[] value)
        {
            Amount = long.Parse((string)value[0]);
            Symbol = new AssetSymbolType((string)value[2], (byte)value[1]);
        }

        public object[] ToArray()
        {
            return new object[] { Amount.ToString(), Symbol.Decimals(), Symbol.ToNaiString() };
        }

        #endregion
    }
}
