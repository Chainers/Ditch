using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @brief The bitasset_options struct contains configurable options available only to BitAssets.
     *
     * @note Changes to this struct will break protocol compatibility
     */

    /// <summary>
    /// bitasset_options
    /// libraries\chain\include\graphene\chain\protocol\asset_ops.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class BitassetOptions
    {

        /// Time before a price feed expires

        /// <summary>
        /// API name: feed_lifetime_sec
        /// = GRAPHENE_DEFAULT_PRICE_FEED_LIFETIME;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("feed_lifetime_sec")]
        public UInt32 FeedLifetimeSec { get; set; }

        /// Minimum number of unexpired feeds required to extract a median feed from

        /// <summary>
        /// API name: minimum_feeds
        /// = 1;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("minimum_feeds")]
        public byte MinimumFeeds { get; set; }

        /// This is the delay between the time a long requests settlement and the chain evaluates the settlement

        /// <summary>
        /// API name: force_settlement_delay_sec
        /// = GRAPHENE_DEFAULT_FORCE_SETTLEMENT_DELAY;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("force_settlement_delay_sec")]
        public UInt32 ForceSettlementDelaySec { get; set; }

        /// This is the percent to adjust the feed price in the short's favor in the event of a forced settlement

        /// <summary>
        /// API name: force_settlement_offset_percent
        /// = GRAPHENE_DEFAULT_FORCE_SETTLEMENT_OFFSET;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("force_settlement_offset_percent")]
        public UInt16 ForceSettlementOffsetPercent { get; set; }

        /// Force settlement volume can be limited such that only a certain percentage of the total existing supply
        /// of the asset may be force-settled within any given chain maintenance interval. This field stores the
        /// percentage of the current supply which may be force settled within the current maintenance interval. If
        /// force settlements come due in an interval in which the maximum volume has already been settled, the new
        /// settlements will be enqueued and processed at the beginning of the next maintenance interval.

        /// <summary>
        /// API name: maximum_force_settlement_volume
        /// = GRAPHENE_DEFAULT_FORCE_SETTLEMENT_MAX_VOLUME;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("maximum_force_settlement_volume")]
        public UInt16 MaximumForceSettlementVolume { get; set; }

        /// This speicifies which asset type is used to collateralize short sales
        /// This field may only be updated if the current supply of the asset is zero.

        /// <summary>
        /// API name: short_backing_asset
        /// 
        /// </summary>
        /// <returns>API type: asset_id_type</returns>
        [JsonProperty("short_backing_asset")]
        public object ShortBackingAsset { get; set; }

        /// <summary>
        /// API name: extensions
        /// 
        /// </summary>
        /// <returns>API type: extensions_type</returns>
        [JsonProperty("extensions")]
        public object[] Extensions { get; set; }
    }
}
