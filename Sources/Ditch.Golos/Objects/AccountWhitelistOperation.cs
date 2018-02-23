using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    /**
     * @brief This operation is used to whitelist and blacklist accounts, primarily for transacting in whitelisted ass     ets
     * @ingroup operations
     *
     * Accounts can freely specify opinions about other accounts, in the form of either whitelisting or blacklisting
     * them. This information is used in chain validation only to determine whether an account is authorized to tra     nsact
     * in an asset type which enforces a whitelist, but third parties can use this information for other uses as wel     l,
     * as long as it does not conflict with the use of whitelisted assets.
     *
     * An asset which enforces a whitelist specifies a list of accounts to maintain its whitelist, and a list of
     * accounts to maintain its blacklist. In order for a given account A to hold and transact in a whitelisted ass     et S,
     * A must be whitelisted by at least one of S's whitelist_authorities and blacklisted by none of S's
     * blacklist_authorities. If A receives a balance of S, and is later removed from the whitelist(s) which all     owed it
     * to hold S, or added to any blacklist S specifies as authoritative, A's balance of S will be frozen until A's
     * authorization is reinstated.
     *
     * This operation requires authorizing_account's signature, but not account_to_list's. The fee is paid by
     * authorizing_account.
     */

    /// <summary>
    /// account_whitelist_operation
    /// libraries\protocol\include\golos\protocol\operations\account_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AccountWhitelistOperation
    {


        /// Paid by authorizing_account

        /// <summary>
        /// API name: fee
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("fee")]
        public Asset Fee { get; set; }

        /// The account which is specifying an opinion of another account

        /// <summary>
        /// API name: authorizing_account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("authorizing_account")]
        public string AuthorizingAccount { get; set; }

        /// The account being opined about

        /// <summary>
        /// API name: account_to_list
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account_to_list")]
        public string AccountToList { get; set; }

        /// The new white and blacklist status of account_to_list, as determined by authorizing_account
        /// This is a bitfield using values defined in the account_listing enum

        /// <summary>
        /// API name: new_listing
        /// = no_listing;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("new_listing")]
        public byte NewListing { get; set; }

        /// <summary>
        /// API name: extensions
        /// 
        /// </summary>
        /// <returns>API type: extensions_type</returns>
        [JsonProperty("extensions")]
        public object Extensions { get; set; }
    }
}
