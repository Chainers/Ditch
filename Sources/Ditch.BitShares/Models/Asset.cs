using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// asset
    /// libraries\chain\include\graphene\chain\protocol\asset.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Asset
    {

        /// <summary>
        /// API name: amount
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [MessageOrder(10)]
        [JsonProperty("amount")]
        public ulong Amount { get; set; }

        /// <summary>
        /// API name: asset_id
        /// 
        /// </summary>
        /// <returns>API type: asset_id_type</returns>
        [MessageOrder(20)]
        [JsonProperty("asset_id")]
        public AssetIdType AssetId { get; set; }
    }
}
