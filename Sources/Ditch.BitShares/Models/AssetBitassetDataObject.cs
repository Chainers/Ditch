using System.Collections.Generic;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  @brief contains properties that only apply to bitassets (market issued assets)
     *
     *  @ingroup object
     *  @ingroup implementation
     */

    /// <summary>
    /// asset_bitasset_data_object
    /// libraries\chain\include\graphene\chain\asset_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AssetBitassetDataObject
    {

        /// <summary>
        /// API name: space_id
        /// = implementation_ids;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("space_id")]
        public byte SpaceId { get; set; }

        /// <summary>
        /// API name: type_id
        /// = impl_asset_bitasset_data_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }


        /// The tunable options for BitAssets are stored in this field.

        /// <summary>
        /// API name: options
        /// 
        /// </summary>
        /// <returns>API type: bitasset_options</returns>
        [JsonProperty("options")]
        public BitassetOptions Options { get; set; }


        /// Feeds published for this asset. If issuer is not committee, the keys in this map are the feed publishing
        /// accounts; otherwise, the feed publishers are the currently active committee_members and witnesses and this map
        /// should be treated as an implementation detail. The timestamp on each feed is the time it was published.

        /// <summary>
        /// API name: feeds
        /// 
        /// </summary>
        /// <returns>API type: flat_map&lt;account_id_type, pair&lt;time_point_sec,price_feed>> </returns>
        [JsonProperty("feeds")]
        public MapContainer<AccountIdType, KeyValuePair<TimePointSec, PriceFeed>> Feeds { get; set; }

        /// This is the currently active price feed, calculated as the median of values from the currently active
        /// feeds.

        /// <summary>
        /// API name: current_feed
        /// 
        /// </summary>
        /// <returns>API type: price_feed</returns>
        [JsonProperty("current_feed")]
        public PriceFeed CurrentFeed { get; set; }

        /// This is the publication time of the oldest feed which was factored into current_feed.

        /// <summary>
        /// API name: current_feed_publication_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("current_feed_publication_time")]
        public TimePointSec CurrentFeedPublicationTime { get; set; }


        /// True if this asset implements a @ref prediction_market

        /// <summary>
        /// API name: is_prediction_market
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("is_prediction_market")]
        public bool IsPredictionMarket { get; set; }


        /// This is the volume of this asset which has been force-settled this maintanence interval

        /// <summary>
        /// API name: force_settled_volume
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("force_settled_volume")]
        public object ForceSettledVolume { get; set; }


        /**
         *  In the event of a black swan, the swan price is saved in the settlement price, and all margin positions
         *  are settled at the same price with the siezed collateral being moved into the settlement fund. From this
         *  point on no further updates to the asset are permitted (no feeds, etc) and forced settlement occurs
         *  immediately when requested, using the settlement price and fund.
         */
        ///@{
        /// Price at which force settlements of a black swanned asset will occur

        /// <summary>
        /// API name: settlement_price
        /// 
        /// </summary>
        /// <returns>API type: price</returns>
        [JsonProperty("settlement_price")]
        public Price SettlementPrice { get; set; }

        /// Amount of collateral which is available for force settlement

        /// <summary>
        /// API name: settlement_fund
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("settlement_fund")]
        public object SettlementFund { get; set; }
    }
}
