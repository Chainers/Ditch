using Ditch.Core.Helpers;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Objects
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

        private object[] _items;

        public void InitFromArray(object[] value)
        {
            _items = value;
        }

        public object[] ToArray()
        {
            return _items;
        }
        
        #endregion

    }
}
