using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @brief This class represents an account on the object graph
     * @ingroup object
     * @ingroup protocol
     *
     * Accounts are the primary unit of authority on the graphene system. Users must have an account in order to use
     * assets, trade in the markets, vote for committee_members, etc.
     */

    /// <summary>
    /// account_object
    /// libraries\chain\include\graphene\chain\account_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AccountObject : AbstractObject<AccountObject>
    {
        [JsonProperty("id")]
        public AccountIdType Id { get; set; }

        /// <summary>
        /// API name: space_id
        /// = protocol_ids;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("space_id")]
        public byte SpaceId { get; set; }

        /// <summary>
        /// API name: type_id
        /// = account_object_type;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }


        /**
         * The time at which this account's membership expires.
         * If set to any time in the past, the account is a basic account.
         * If set to time_point_sec::maximum(), the account is a lifetime member.
         * If set to any time not in the past less than time_point_sec::maximum(), the account is an annual member.
         *
         * See @ref is_lifetime_member, @ref is_basic_account, @ref is_annual_member, and @ref is_member
         */

        /// <summary>
        /// API name: membership_expiration_date
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("membership_expiration_date")]
        public TimePointSec MembershipExpirationDate { get; set; }


        ///The account that paid the fee to register this account. Receives a percentage of referral rewards.

        /// <summary>
        /// API name: registrar
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("registrar")]
        public AccountIdType Registrar { get; set; }

        /// The account credited as referring this account. Receives a percentage of referral rewards.

        /// <summary>
        /// API name: referrer
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("referrer")]
        public AccountIdType Referrer { get; set; }

        /// The lifetime member at the top of the referral tree. Receives a percentage of referral rewards.

        /// <summary>
        /// API name: lifetime_referrer
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("lifetime_referrer")]
        public AccountIdType LifetimeReferrer { get; set; }


        /// Percentage of fee which should go to network.

        /// <summary>
        /// API name: network_fee_percentage
        /// = GRAPHENE_DEFAULT_NETWORK_PERCENT_OF_FEE;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("network_fee_percentage")]
        public UInt16 NetworkFeePercentage { get; set; }

        /// Percentage of fee which should go to lifetime referrer.

        /// <summary>
        /// API name: lifetime_referrer_fee_percentage
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("lifetime_referrer_fee_percentage")]
        public UInt16 LifetimeReferrerFeePercentage { get; set; }

        /// Percentage of referral rewards (leftover fee after paying network and lifetime referrer) which should go
        /// to referrer. The remainder of referral rewards goes to the registrar.

        /// <summary>
        /// API name: referrer_rewards_percentage
        /// = 0;
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("referrer_rewards_percentage")]
        public UInt16 ReferrerRewardsPercentage { get; set; }


        /// The account's name. This name must be unique among all account names on the graph. May not be empty.

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("name")]
        public string Name { get; set; }


        /**
         * The owner authority represents absolute control over the account. Usually the keys in this authority will
         * be kept in cold storage, as they should not be needed very often and compromise of these keys constitutes
         * complete and irrevocable loss of the account. Generally the only time the owner authority is required is to
         * update the active authority.
         */

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [JsonProperty("owner")]
        public Authority Owner { get; set; }

        /// The owner authority contains the hot keys of the account. This authority has control over nearly all
        /// operations the account may perform.

        /// <summary>
        /// API name: active
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [JsonProperty("active")]
        public Authority Active { get; set; }

        /// <summary>
        /// API name: options
        /// 
        /// </summary>
        /// <returns>API type: account_options</returns>
        [JsonProperty("options")]
        public AccountOptions Options { get; set; }


        /// The reference implementation records the account's statistics in a separate object. This field contains the
        /// ID of that object.

        /// <summary>
        /// API name: statistics
        /// 
        /// </summary>
        /// <returns>API type: account_statistics_id_type</returns>
        [JsonProperty("statistics")]
        public object Statistics { get; set; }


        /**
         * This is a set of all accounts which have 'whitelisted' this account. Whitelisting is only used in core
         * validation for the purpose of authorizing accounts to hold and transact in whitelisted assets. This
         * account cannot update this set, except by transferring ownership of the account, which will clear it. Other
         * accounts may add or remove their IDs from this set.
         */

        /// <summary>
        /// API name: whitelisting_accounts
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("whitelisting_accounts")]
        public object[] WhitelistingAccounts { get; set; }


        /**
         * Optionally track all of the accounts this account has whitelisted or blacklisted, these should
         * be made Immutable so that when the account object is cloned no deep copy is required.  This state is
         * tracked for GUI display purposes.
         *
         * TODO: move white list tracking to its own multi-index container rather than having 4 fields on an
         * account.   This will scale better because under the current design if you whitelist 2000 accounts,
         * then every time someone fetches this account object they will get the full list of 2000 accounts.
         */
        ///@{

        /// <summary>
        /// API name: whitelisted_accounts
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("whitelisted_accounts")]
        public AccountIdType[] WhitelistedAccounts { get; set; }

        /// <summary>
        /// API name: blacklisted_accounts
        /// 
        /// </summary>
        /// <returns>API type: account_id_type</returns>
        [JsonProperty("blacklisted_accounts")]
        public AccountIdType[] BlacklistedAccounts { get; set; }

        ///@}


        /**
         * This is a set of all accounts which have 'blacklisted' this account. Blacklisting is only used in core
         * validation for the purpose of forbidding accounts from holding and transacting in whitelisted assets. This
         * account cannot update this set, and it will be preserved even if the account is transferred. Other accounts
         * may add or remove their IDs from this set.
         */

        /// <summary>
        /// API name: blacklisting_accounts
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("blacklisting_accounts")]
        public object[] BlacklistingAccounts { get; set; }


        /**
         * Vesting balance which receives cashback_reward deposits.
         */

        /// <summary>
        /// API name: cashback_vb
        /// 
        /// </summary>
        /// <returns>API type: vesting_balance_id_type</returns>
        [JsonProperty("cashback_vb", NullValueHandling = NullValueHandling.Ignore)]
        public object CashbackVb { get; set; }

        /// <summary>
        /// API name: owner_special_authority
        /// = no_special_authority();
        /// </summary>
        /// <returns>API type: special_authority</returns>
        [JsonProperty("owner_special_authority")]
        public object OwnerSpecialAuthority { get; set; }

        /// <summary>
        /// API name: active_special_authority
        /// = no_special_authority();
        /// </summary>
        /// <returns>API type: special_authority</returns>
        [JsonProperty("active_special_authority")]
        public object ActiveSpecialAuthority { get; set; }


        /**
         * This flag is set when the top_n logic sets both authorities,
         * and gets reset when authority or special_authority is set.
         */

        /// <summary>
        /// API name: top_n_control_flags
        /// = 0;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("top_n_control_flags")]
        public byte TopNControlFlags { get; set; }

        /// <summary>
        /// API name: top_n_control_owner
        /// = 1;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("top_n_control_owner")]
        public byte TopNControlOwner { get; set; }

        /// <summary>
        /// API name: top_n_control_active
        /// = 2;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [JsonProperty("top_n_control_active")]
        public byte TopNControlActive { get; set; }


        /**
         * This is a set of assets which the account is allowed to have.
         * This is utilized to restrict buyback accounts to the assets that trade in their markets.
         * In the future we may expand this to allow accounts to e.g. voluntarily restrict incoming transfers.
         */

        /// <summary>
        /// API name: allowed_assets
        /// 
        /// </summary>
        /// <returns>API type: flat_set</returns>
        [JsonProperty("allowed_assets", NullValueHandling = NullValueHandling.Ignore)]
        public object[] AllowedAssets { get; set; }
    }
}
