using Ditch.Golos.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Objects
{
    /**
     *  @brief tracks the parameters of an asset
     *  @ingroup object
     *
     *  All assets have a globally unique symbol name that controls how they are traded and an issuer who
     *  has authority over the parameters of the asset.
     */

    /// <summary>
    /// asset_object
    /// libraries\chain\include\golos\chain\objects\asset_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AssetObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }


        /// Ticker symbol for this asset, i.e. "USD"

        /// <summary>
        /// API name: asset_name
        /// 
        /// </summary>
        /// <returns>API type: asset_name_type</returns>
        [JsonProperty("asset_name")]
        public string AssetName { get; set; }

        /// Maximum number of digits after the decimal point (must be <= 12)

        /// <summary>
        /// API name: precision
        /// = 0;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("precision")]
        public byte Precision { get; set; }

        /// ID of the account which issued this asset.

        /// <summary>
        /// API name: issuer
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// API name: options
        /// 
        /// </summary>
        /// <returns>API type: asset_options</returns>
        [JsonProperty("options")]
        public AssetOptions Options { get; set; }


        /// Extra data associated with BitAssets. This field is non-null if and only if is_market_issued() returns true

        /// <summary>
        /// API name: market_issued
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("market_issued")]
        public bool MarketIssued { get; set; }

        /// <summary>
        /// API name: buyback_account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("buyback_account")]
        public string BuybackAccount { get; set; }
    }
}
