using Newtonsoft.Json;

namespace Ditch.BitShares.Models
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
    /// libraries\chain\include\graphene\chain\asset_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AssetObject
    {

        /// <summary>
        /// API name: space_id
        /// = protocol_ids;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("space_id")]
        public byte SpaceId { get; set; }

        /// <summary>
        /// API name: type_id
        /// = asset_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }


        /// Ticker symbol for this asset, i.e. "USD"

        /// <summary>
        /// API name: symbol
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// Maximum number of digits after the decimal point (must be &lt;= 12)

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
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("issuer")]
        public AccountIdType Issuer { get; set; }

        /// <summary>
        /// API name: options
        /// 
        /// </summary>
        /// <returns>API type: asset_options</returns>
        [JsonProperty("options")]
        public AssetOptions Options { get; set; }



        /// Current supply, fee pool, and collected fees are stored in a separate object as they change frequently.

        /// <summary>
        /// API name: dynamic_asset_data_id
        /// 
        /// </summary>
        /// <returns>API type: asset_dynamic_data_id_type</returns>
        [JsonProperty("dynamic_asset_data_id")]
        public object DynamicAssetDataId { get; set; }

        /// Extra data associated with BitAssets. This field is non-null if and only if is_market_issued() returns true

        /// <summary>
        /// API name: bitasset_data_id
        /// 
        /// </summary>
        /// <returns>API type: asset_bitasset_data_id_type</returns>
        [JsonProperty("bitasset_data_id", NullValueHandling = NullValueHandling.Ignore)]
        public object BitassetDataId { get; set; }

        /// <summary>
        /// API name: buyback_account
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("buyback_account", NullValueHandling = NullValueHandling.Ignore)]
        public AccountIdType BuybackAccount { get; set; }
    }
}
