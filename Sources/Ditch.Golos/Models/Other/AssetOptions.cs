using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Objects
{
    /**
     * @brief The asset_options struct contains options available on all assets in the network
     *
     * @note Changes to this struct will break protocol compatibility
     */

    /// <summary>
    /// asset_options
    /// libraries\protocol\include\golos\protocol\operations\asset_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AssetOptions
    {

        /// The maximum supply of this asset which may exist at any given time. This can be as large as
        /// STEEMIT_MAX_SHARE_SUPPLY

        /// <summary>
        /// API name: max_supply
        /// = STEEMIT_MAX_SHARE_SUPPLY;
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("max_supply")]
        public object MaxSupply { get; set; }

        /// When this asset is traded on the markets, this percentage of the total traded will be exacted and paid
        /// to the issuer. This is a fixed point value, representing hundredths of a percent, i.e. a value of 100
        /// in this field means a 1% fee is charged on market trades of this asset.

        /// <summary>
        /// API name: market_fee_percent
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("market_fee_percent")]
        public UInt16 MarketFeePercent { get; set; }

        /// Market fees calculated as @ref market_fee_percent of the traded volume are capped to this value

        /// <summary>
        /// API name: max_market_fee
        /// = STEEMIT_MAX_SHARE_SUPPLY;
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("max_market_fee")]
        public object MaxMarketFee { get; set; }


        /// The flags which the issuer has permission to update. See @ref asset_issuer_permission_flags

        /// <summary>
        /// API name: issuer_permissions
        /// = uia_asset_issuer_permission_mask;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("issuer_permissions")]
        public UInt16 IssuerPermissions { get; set; }

        /// The currently active flags on this permission. See @ref asset_issuer_permission_flags

        /// <summary>
        /// API name: flags
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("flags")]
        public UInt16 Flags { get; set; }


        /// When a non-core asset is used to pay a fee, the blockchain must convert that asset to core asset in
        /// order to accept the fee. If this asset's fee pool is funded, the chain will automatically deposite fees
        /// in this asset to its accumulated fees, and withdraw from the fee pool the same amount as converted at
        /// the core exchange rate.

        /// <summary>
        /// API name: core_exchange_rate
        /// 
        /// </summary>
        /// <returns>API type: price</returns>
        [JsonProperty("core_exchange_rate")]
        public Price CoreExchangeRate { get; set; }


        /// A set of accounts which maintain whitelists to consult for this asset. If whitelist_authorities
        /// is non-empty, then only accounts in whitelist_authorities are allowed to hold, use, or transfer the asset.

        /// <summary>
        /// API name: whitelist_authorities
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("whitelist_authorities")]
        public string[] WhitelistAuthorities { get; set; }

        /// A set of accounts which maintain blacklists to consult for this asset. If flags & white_list is set,
        /// an account may only send, receive, trade, etc. in this asset if none of these accounts appears in
        /// its account_object::blacklisting_accounts field. If the account is blacklisted, it may not transact in
        /// this asset even if it is also whitelisted.

        /// <summary>
        /// API name: blacklist_authorities
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("blacklist_authorities")]
        public string[] BlacklistAuthorities { get; set; }


        /** defines the assets that this asset may be traded against in the market */

        /// <summary>
        /// API name: whitelist_markets
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("whitelist_markets")]
        public string[] WhitelistMarkets { get; set; }

        /** defines the assets that this asset may not be traded against in the market, must not overlap whitelist */

        /// <summary>
        /// API name: blacklist_markets
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("blacklist_markets")]
        public string[] BlacklistMarkets { get; set; }


        /**
         * data that describes the meaning/purpose of this asset, fee will be charged proportional to
         * size of description.
         */

        /// <summary>
        /// API name: description
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// API name: extensions
        /// 
        /// </summary>
        /// <returns>API type: extensions_type</returns>
        [JsonProperty("extensions")]
        public object Extensions { get; set; }
    }
}
