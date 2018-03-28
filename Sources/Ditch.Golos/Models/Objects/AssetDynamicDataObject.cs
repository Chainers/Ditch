using Newtonsoft.Json;

namespace Ditch.Golos.Models.Objects
{
    /**
     *  @brief tracks the asset information that changes frequently
     *  @ingroup object
     *  @ingroup implementation
     *
     *  Because the asset_object is very large it doesn't make sense to save an undo state
     *  for all of the parameters that never change.   This object factors out the parameters
     *  of an asset that change in almost every transaction that involves the asset.
     *
     *  This object exists as an implementation detail and its ID should never be referenced by
     *  a blockchain operation.
     */

    /// <summary>
    /// asset_dynamic_data_object
    /// libraries\chain\include\golos\chain\objects\asset_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AssetDynamicDataObject
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


        /// The number of shares currently in existence

        /// <summary>
        /// API name: current_supply
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("current_supply")]
        public object CurrentSupply { get; set; }

        /// <summary>
        /// API name: confidential_supply
        /// total asset held in confidential balances
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("confidential_supply")]
        public object ConfidentialSupply { get; set; }

        /// <summary>
        /// API name: accumulated_fees
        /// fees accumulate to be paid out over time
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("accumulated_fees")]
        public object AccumulatedFees { get; set; }

        /// <summary>
        /// API name: fee_pool
        /// in core asset
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("fee_pool")]
        public object FeePool { get; set; }
    }
}
