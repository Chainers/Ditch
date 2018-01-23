//using System.Threading;
//using Ditch.Core.JsonRpc;
//using System;
//using Ditch.Golos.Objects;
//using Ditch.Golos.Enums;
//using Ditch.Core;
//using System.Collections.Generic;

//namespace Ditch.Golos
//{
//    /**
//     * This wallet assumes it is connected to the database server with a high-bandwidth, low-latency connection and
//     * performs minimal caching. This API could be provided locally to be used by a web interface.
//     */

//    /// <summary>
//    /// wallet_api
//    /// libraries\wallet\include\golos\wallet\wallet.hpp
//    /// </summary>
//    public partial class OperationManager
//    {

//        /// <summary>
//        /// API name: help
//        /// Returns a list of all commands supported by the wallet API.
//        /// 
//        /// This lists each command, along with its arguments and return types.
//        /// For more detailed help on a single command, use \c get_help()
//        /// 
//        /// @returns a multi-line string suitable for displaying on a terminal
//        ///
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: string</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string> Help(CancellationToken token)
//        {
//            return CallRequest<string>(KnownApiNames.WalletApi, "help", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: info
//        /// Returns info about the current state of the blockchain
//        ///
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: variant</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object> Info(CancellationToken token)
//        {
//            return CallRequest<object>(KnownApiNames.WalletApi, "info", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: about
//        /// Returns info such as client version, git version of graphene/fc, version of boost, openssl.
//        /// @returns compile time info and client and dependencies versions
//        ///
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: variant_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object> About(CancellationToken token)
//        {
//            return CallRequest<object>(KnownApiNames.WalletApi, "about", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: get_ops_in_block
//        /// Returns sequence of operations included/generated in a specified block
//        ///
//        /// 
//        /// </summary>
//        /// <param name="blockNum">API type: uint32_t Block height of specified block</param>
//        /// <param name="onlyVirtual">API type: bool Whether to only return virtual operations</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: applied_operation</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AppliedOperation[]> GetOpsInBlockWalletApi(UInt32 blockNum, bool onlyVirtual, CancellationToken token)
//        {
//            return CallRequest<AppliedOperation[]>(KnownApiNames.WalletApi, "get_ops_in_block", new object[] { blockNum, onlyVirtual }, token);
//        }

//        /// <summary>
//        /// API name: get_feed_history
//        /// Return the current price feed history
//        /// 
//        /// @returns Price feed history data on the blockchain
//        ///
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: feed_history_api_obj</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<FeedHistoryApiObj> GetFeedHistoryWalletApi(CancellationToken token)
//        {
//            return CallRequest<FeedHistoryApiObj>(KnownApiNames.WalletApi, "get_feed_history", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: get_active_witnesses
//        /// Returns the list of witnesses producing blocks in the current round (21 Blocks)
//        ///
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: account_name_type</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string[]> GetActiveWitnessesWalletApi(CancellationToken token)
//        {
//            return CallRequest<string[]>(KnownApiNames.WalletApi, "get_active_witnesses", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: get_miner_queue
//        /// Returns the queue of pow miners waiting to produce blocks.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: account_name_type</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string[]> GetMinerQueueWalletApi(CancellationToken token)
//        {
//            return CallRequest<string[]>(KnownApiNames.WalletApi, "get_miner_queue", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: get_withdraw_routes
//        /// Returns vesting withdraw routes for an account.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="account">API type: string Account to query routes</param>
//        /// <param name="type">API type: withdraw_route_type Withdraw type type [incoming, outgoing, all]</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: withdraw_route</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<WithdrawRoute[]> GetWithdrawRoutesWalletApi(string account, WithdrawRouteType type, CancellationToken token)
//        {
//            return CallRequest<WithdrawRoute[]>(KnownApiNames.WalletApi, "get_withdraw_routes", new object[] { account, type }, token);
//        }


//        /**
//        *  Gets the steem price per mvests
//        */

//        /// <summary>
//        /// API name: get_steem_per_mvests
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: string</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string> GetSteemPerMvests(CancellationToken token)
//        {
//            return CallRequest<string>(KnownApiNames.WalletApi, "get_steem_per_mvests", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: list_my_accounts
//        /// Gets the account information for all accounts for which this wallet has a private key
//        ///
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: account_api_obj</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AccountApiObj[]> ListMyAccounts(CancellationToken token)
//        {
//            return CallRequest<AccountApiObj[]>(KnownApiNames.WalletApi, "list_my_accounts", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: list_accounts
//        /// Lists all accounts registered in the blockchain.
//        /// This returns a list of all account names and their account ids, sorted by account name.
//        /// 
//        /// Use the \c lowerbound and limit parameters to page through the list.  To retrieve all accounts,
//        /// start by setting \c lowerbound to the empty string \c "", and then each iteration, pass
//        /// the last account name returned as the \c lowerbound for the next \c list_accounts() call.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="lowerbound">API type: string the name of the first account to return.  If the named account does not exist,
//        /// the list will start at the account that comes after \c lowerbound</param>
//        /// <param name="limit">API type: uint32_t the maximum number of accounts to return (max: 1000)
//        /// @returns a list of accounts mapping account names to account ids</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: string</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string[]> ListAccounts(string lowerbound, UInt32 limit, CancellationToken token)
//        {
//            return CallRequest<string[]>(KnownApiNames.WalletApi, "list_accounts", new object[] { lowerbound, limit }, token);
//        }

//        /// <summary>
//        /// API name: list_account_balances
//        /// List the balances of an account.
//        /// Each account can have multiple balances, one for each type of asset owned by that
//        /// account.  The returned list will only contain assets for which the account has a
//        /// nonzero balance
//        ///
//        /// 
//        /// </summary>
//        /// <param name="accountName">API type: account_name_type the name or id of the account whose balances you want
//        /// @returns a list of the given account's balances</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: asset</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<Asset[]> ListAccountBalances(string accountName, CancellationToken token)
//        {
//            return CallRequest<Asset[]>(KnownApiNames.WalletApi, "list_account_balances", new object[] { accountName }, token);
//        }

//        /// <summary>
//        /// API name: list_assets
//        /// Lists all assets registered on the blockchain.
//        /// 
//        /// To list all assets, pass the empty string \c "" for the lowerbound to start
//        /// at the beginning of the list, and iterate as necessary.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="lowerbound">API type: string  the symbol of the first asset to include in the list.</param>
//        /// <param name="limit">API type: uint32_t the maximum number of assets to return (max: 100)
//        /// @returns the list of asset objects, ordered by symbol</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: asset_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AssetObject[]> ListAssetsWalletApi(string lowerbound, UInt32 limit, CancellationToken token)
//        {
//            return CallRequest<AssetObject[]>(KnownApiNames.WalletApi, "list_assets", new object[] { lowerbound, limit }, token);
//        }

//        /// <summary>
//        /// API name: get_account
//        /// Returns information about the given account.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="accountName">API type: string the name of the account to provide information about
//        /// @returns the public account data stored in the blockchain</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: account_api_obj</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AccountApiObj> GetAccount(string accountName, CancellationToken token)
//        {
//            return CallRequest<AccountApiObj>(KnownApiNames.WalletApi, "get_account", new object[] { accountName }, token);
//        }

//        /// <summary>
//        /// API name: get_asset
//        /// Returns information about the given asset.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="assetSymbol">API type: string the symbol of the asset in the request
//        /// @returns the information about the asset stored in the block chain</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: asset_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AssetObject> GetAsset(string assetSymbol, CancellationToken token)
//        {
//            return CallRequest<AssetObject>(KnownApiNames.WalletApi, "get_asset", new object[] { assetSymbol }, token);
//        }

//        /// <summary>
//        /// API name: get_proposal
//        /// Returns information about the given proposed_transaction.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="accountName">API type: string the proposal author name</param>
//        /// <param name="id">API type: integral_id_type the proposal identification number unique for the account given
//        /// @returns the information about the asset stored in the block chain</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: proposal_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<ProposalObject> GetProposal(string accountName, UInt32 id, CancellationToken token)
//        {
//            return CallRequest<ProposalObject>(KnownApiNames.WalletApi, "get_proposal", new object[] { accountName, id }, token);
//        }

//        /// <summary>
//        /// API name: get_bitasset_data
//        /// Returns the BitAsset-specific data for a given asset.
//        /// Market-issued assets's behavior are determined both by their "BitAsset Data" and
//        /// their basic asset data, as returned by \c get_asset().
//        ///
//        /// 
//        /// </summary>
//        /// <param name="assetSymbol">API type: string the symbol of the BitAsset in the request
//        /// @returns the BitAsset-specific data for this asset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: asset_bitasset_data_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AssetBitassetDataObject> GetBitassetData(string assetSymbol, CancellationToken token)
//        {
//            return CallRequest<AssetBitassetDataObject>(KnownApiNames.WalletApi, "get_bitasset_data", new object[] { assetSymbol }, token);
//        }

//        /// <summary>
//        /// API name: get_private_key
//        /// Get the WIF private key corresponding to a public key.  The
//        /// private key must already be in the wallet.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="pubkey">API type: public_key_type</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: string</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string> GetPrivateKey(PublicKeyType pubkey, CancellationToken token)
//        {
//            return CallRequest<string>(KnownApiNames.WalletApi, "get_private_key", new object[] { pubkey }, token);
//        }

//        /// <summary>
//        /// API name: get_private_key_from_password
//        /// 
//        /// </summary>
//        /// <param name="account">API type: string</param>
//        /// <param name="role">API type: string - active | owner | posting | memo</param>
//        /// <param name="password">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<KeyValuePair<string, string>> GetPrivateKeyFromPassword(string account, string role, string password, CancellationToken token)
//        {
//            return CallRequest<KeyValuePair<string, string>>(KnownApiNames.WalletApi, "get_private_key_from_password", new object[] { account, role, password }, token);
//        }

//        /// <summary>
//        /// API name: get_transaction
//        /// Returns transaction by ID.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="trxId">API type: transaction_id_type</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> GetTransactionWalletApi(string trxId, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "get_transaction", new object[] { trxId }, token);
//        }

//        /// <summary>
//        /// API name: is_new
//        /// Checks whether the wallet has just been created and has not yet had a password set.
//        /// 
//        /// Calling \c set_password will transition the wallet to the locked state.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: bool true if the wallet is new
//        /// @ingroup Wallet Management</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<bool> IsNew(CancellationToken token)
//        {
//            return CallRequest<bool>(KnownApiNames.WalletApi, "is_new", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: is_locked
//        /// Checks whether the wallet is locked (is unable to use its private keys).
//        /// 
//        /// This state can be changed by calling \c lock() or \c unlock().
//        ///
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: bool true if the wallet is locked
//        /// @ingroup Wallet Management</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<bool> IsLocked(CancellationToken token)
//        {
//            return CallRequest<bool>(KnownApiNames.WalletApi, "is_locked", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: lock
//        /// Locks the wallet immediately.
//        /// @ingroup Wallet Management
//        ///
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse Lock(CancellationToken token)
//        {
//            return CallRequest(KnownApiNames.WalletApi, "lock", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: unlock
//        /// Unlocks the wallet.
//        /// 
//        /// The wallet remain unlocked until the \c lock is called
//        /// or the program exits.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="password">API type: string the password previously set with \c set_password()
//        /// @ingroup Wallet Management</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse Unlock(string password, CancellationToken token)
//        {
//            return CallRequest(KnownApiNames.WalletApi, "unlock", new object[] { password }, token);
//        }

//        /// <summary>
//        /// API name: set_password
//        /// Sets a new password on the wallet.
//        /// 
//        /// The wallet must be either 'new' or 'unlocked' to
//        /// execute this command.
//        /// @ingroup Wallet Management
//        ///
//        /// 
//        /// </summary>
//        /// <param name="password">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse SetPassword(string password, CancellationToken token)
//        {
//            return CallRequest(KnownApiNames.WalletApi, "set_password", new object[] { password }, token);
//        }

//        /// <summary>
//        /// API name: list_keys
//        /// Dumps all private keys owned by the wallet.
//        /// 
//        /// The keys are printed in WIF format.  You can import these keys into another wallet
//        /// using \c import_key()
//        /// @returns a map containing the private keys, indexed by their public key
//        ///
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: map&lt;public_key_type,string></returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object> ListKeys(CancellationToken token)
//        {
//            return CallRequest<object>(KnownApiNames.WalletApi, "list_keys", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: get_help
//        /// Returns detailed help on a single API command.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="method">API type: string the name of the API command you want help with
//        /// @returns a multi-line string suitable for displaying on a terminal</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: string</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string> GetHelp(string method, CancellationToken token)
//        {
//            return CallRequest<string>(KnownApiNames.WalletApi, "get_help", new object[] { method }, token);
//        }

//        /// <summary>
//        /// API name: suggest_brain_key
//        /// Suggests a safe brain key to use for creating your account.
//        /// \c create_account_with_brain_key() requires you to specify a 'brain key',
//        /// a long passphrase that provides enough entropy to generate cyrptographic
//        /// keys.  This function will suggest a suitably random string that should
//        /// be easy to write down (and, with effort, memorize).
//        /// @returns a suggested brain_key
//        ///
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: brain_key_info</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<BrainKeyInfo> SuggestBrainKey(CancellationToken token)
//        {
//            return CallRequest<BrainKeyInfo>(KnownApiNames.WalletApi, "suggest_brain_key", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: serialize_transaction
//        /// Converts a signed_transaction in JSON form to its binary representation.
//        /// 
//        /// TODO: I don't see a broadcast_transaction() function, do we need one?
//        ///
//        /// 
//        /// </summary>
//        /// <param name="tx">API type: signed_transaction the transaction to serialize
//        /// @returns the binary form of the transaction.  It will not be hex encoded,
//        /// this returns a raw string that may have null characters embedded
//        /// in it</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: string</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string> SerializeTransaction(SignedTransaction tx, CancellationToken token)
//        {
//            return CallRequest<string>(KnownApiNames.WalletApi, "serialize_transaction", new object[] { tx }, token);
//        }

//        /// <summary>
//        /// API name: import_key
//        /// Imports a WIF Private Key into the wallet to be used to sign transactions by an account.
//        /// 
//        /// example: import_key 5KQwrPbwdL6PhXujxW37FSSQZ1JiwsST4cqQzDeyXtP79zkvFD3
//        ///
//        /// 
//        /// </summary>
//        /// <param name="wifKey">API type: string the WIF Private Key to import</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: bool</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<bool> ImportKey(string wifKey, CancellationToken token)
//        {
//            return CallRequest<bool>(KnownApiNames.WalletApi, "import_key", new object[] { wifKey }, token);
//        }

//        /// <summary>
//        /// API name: create_account
//        /// This method will genrate new owner, active, and memo keys for the new account which
//        /// will be controlable by this wallet. There is a fee associated with account creation
//        /// that is paid by the creator. The current account creation fee can be found with the
//        /// 'info' wallet command.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="creator">API type: string The account creating the new account</param>
//        /// <param name="newAccountName">API type: string The name of the new account</param>
//        /// <param name="jsonMeta">API type: string JSON Metadata associated with the new account</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> CreateAccount(string creator, string newAccountName, string jsonMeta, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "create_account", new object[] { creator, newAccountName, jsonMeta, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: create_account_with_keys
//        /// This method is used by faucets to create new accounts for other users which must
//        /// provide their desired keys. The resulting account may not be controllable by this
//        /// wallet. There is a fee associated with account creation that is paid by the creator.
//        /// The current account creation fee can be found with the 'info' wallet command.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="creator">API type: string The account creating the new account</param>
//        /// <param name="newname">API type: string The name of the new account</param>
//        /// <param name="jsonMeta">API type: string JSON Metadata associated with the new account</param>
//        /// <param name="owner">API type: public_key_type public owner key of the new account</param>
//        /// <param name="active">API type: public_key_type public active key of the new account</param>
//        /// <param name="posting">API type: public_key_type public posting key of the new account</param>
//        /// <param name="memo">API type: public_key_type public memo key of the new account</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> CreateAccountWithKeys(string creator, string newname, string jsonMeta, PublicKeyType owner, PublicKeyType active, PublicKeyType posting, PublicKeyType memo, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "create_account_with_keys", new object[] { creator, newname, jsonMeta, owner, active, posting, memo, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: create_account_delegated
//        /// This method will genrate new owner, active, and memo keys for the new account which
//        /// will be controlable by this wallet. There is a fee associated with account creation
//        /// that is paid by the creator. The current account creation fee can be found with the
//        /// 'info' wallet command.
//        /// 
//        /// These accounts are created with combination of GOLOS and delegated GP
//        ///
//        /// 
//        /// </summary>
//        /// <param name="creator">API type: string The account creating the new account</param>
//        /// <param name="steemFee">API type: asset&lt;0,17,0> The amount of the fee to be paid with GOLOS</param>
//        /// <param name="delegatedVests">API type: asset&lt;0,17,0> The amount of the fee to be paid with delegation</param>
//        /// <param name="newAccountName">API type: string The name of the new account</param>
//        /// <param name="jsonMeta">API type: string JSON Metadata associated with the new account</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> CreateAccountDelegated(string creator, Asset steemFee, Asset delegatedVests, string newAccountName, string jsonMeta, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "create_account_delegated", new object[] { creator, steemFee, delegatedVests, newAccountName, jsonMeta, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: create_account_with_keys_delegated
//        /// This method is used by faucets to create new accounts for other users which must
//        /// provide their desired keys. The resulting account may not be controllable by this
//        /// wallet. There is a fee associated with account creation that is paid by the creator.
//        /// The current account creation fee can be found with the 'info' wallet command.
//        /// 
//        /// These accounts are created with combination of GOLOS and delegated GP
//        ///
//        /// 
//        /// </summary>
//        /// <param name="creator">API type: string The account creating the new account</param>
//        /// <param name="steemFee">API type: asset&lt;0,17,0> The amount of the fee to be paid with GOLOS</param>
//        /// <param name="delegatedVests">API type: asset&lt;0,17,0> The amount of the fee to be paid with delegation</param>
//        /// <param name="newname">API type: string The name of the new account</param>
//        /// <param name="jsonMeta">API type: string JSON Metadata associated with the new account</param>
//        /// <param name="owner">API type: public_key_type public owner key of the new account</param>
//        /// <param name="active">API type: public_key_type public active key of the new account</param>
//        /// <param name="posting">API type: public_key_type public posting key of the new account</param>
//        /// <param name="memo">API type: public_key_type public memo key of the new account</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> CreateAccountWithKeysDelegated(string creator, Asset steemFee, Asset delegatedVests, string newname, string jsonMeta, PublicKeyType owner, PublicKeyType active, PublicKeyType posting, PublicKeyType memo, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "create_account_with_keys_delegated", new object[] { creator, steemFee, delegatedVests, newname, jsonMeta, owner, active, posting, memo, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: update_account_auth_key
//        /// This method updates the key of an authority for an exisiting account.
//        /// Warning: You can create impossible authorities using this method. The method
//        /// will fail if you create an impossible owner authority, but will allow impossible
//        /// active and posting authorities.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="accountName">API type: string The name of the account whose authority you wish to update</param>
//        /// <param name="type">API type: authority_type The authority type. e.g. owner, active, or posting</param>
//        /// <param name="key">API type: public_key_type The public key to add to the authority</param>
//        /// <param name="weight">API type: weight_type The weight the key should have in the authority. A weight of 0 indicates the removal of the key.</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction.</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> UpdateAccountAuthKey(string accountName, AuthorityType type, PublicKeyType key, UInt16 weight, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "update_account_auth_key", new object[] { accountName, type, key, weight, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: update_account_auth_account
//        /// This method updates the account of an authority for an exisiting account.
//        /// Warning: You can create impossible authorities using this method. The method
//        /// will fail if you create an impossible owner authority, but will allow impossible
//        /// active and posting authorities.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="accountName">API type: string The name of the account whose authority you wish to update</param>
//        /// <param name="type">API type: authority_type The authority type. e.g. owner, active, or posting</param>
//        /// <param name="authAccount">API type: string The account to add the the authority</param>
//        /// <param name="weight">API type: weight_type The weight the account should have in the authority. A weight of 0 indicates the removal of the account.</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction.</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> UpdateAccountAuthAccount(string accountName, AuthorityType type, string authAccount, UInt16 weight, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "update_account_auth_account", new object[] { accountName, type, authAccount, weight, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: update_account_auth_threshold
//        /// This method updates the weight threshold of an authority for an account.
//        /// Warning: You can create impossible authorities using this method as well
//        /// as implicitly met authorities. The method will fail if you create an implicitly
//        /// true authority and if you create an impossible owner authoroty, but will allow
//        /// impossible active and posting authorities.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="accountName">API type: string The name of the account whose authority you wish to update</param>
//        /// <param name="type">API type: authority_type The authority type. e.g. owner, active, or posting</param>
//        /// <param name="threshold">API type: uint32_t The weight threshold required for the authority to be met</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> UpdateAccountAuthThreshold(string accountName, AuthorityType type, UInt32 threshold, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "update_account_auth_threshold", new object[] { accountName, type, threshold, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: update_account_memo_key
//        /// This method updates the memo key of an account
//        ///
//        /// 
//        /// </summary>
//        /// <param name="accountName">API type: string The name of the account you wish to update</param>
//        /// <param name="key">API type: public_key_type The new memo public key</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> UpdateAccountMemoKey(string accountName, PublicKeyType key, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "update_account_memo_key", new object[] { accountName, key, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: delegate_vesting_shares
//        /// This method delegates VESTS from one account to another.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="delegator">API type: string The name of the account delegating VESTS</param>
//        /// <param name="delegatee">API type: string The name of the account receiving VESTS</param>
//        /// <param name="vestingShares">API type: asset&lt;0,17,0> The amount of VESTS to delegate</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> DelegateVestingShares(string delegator, string delegatee, Asset vestingShares, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "delegate_vesting_shares", new object[] { delegator, delegatee, vestingShares, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: list_witnesses
//        /// Lists all witnesses registered in the blockchain.
//        /// This returns a list of all account names that own witnesses, and the associated witness id,
//        /// sorted by name.  This lists witnesses whether they are currently voted in or not.
//        /// 
//        /// Use the \c lowerbound and limit parameters to page through the list.  To retrieve all witnesss,
//        /// start by setting \c lowerbound to the empty string \c "", and then each iteration, pass
//        /// the last witness name returned as the \c lowerbound for the next \c list_witnesss() call.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="lowerbound">API type: string the name of the first witness to return.  If the named witness does not exist,
//        /// the list will start at the witness that comes after \c lowerbound</param>
//        /// <param name="limit">API type: uint32_t the maximum number of witnesss to return (max: 1000)
//        /// @returns a list of witnesss mapping witness names to witness ids</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: account_name_type</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string[]> ListWitnesses(string lowerbound, UInt32 limit, CancellationToken token)
//        {
//            return CallRequest<string[]>(KnownApiNames.WalletApi, "list_witnesses", new object[] { lowerbound, limit }, token);
//        }

//        /// <summary>
//        /// API name: get_witness
//        /// Returns information about the given witness.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="ownerAccount">API type: string the name or id of the witness account owner, or the id of the witness
//        /// @returns the information about the witness stored in the block chain</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: witness_api_obj</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<WitnessApiObj> GetWitness(string ownerAccount, CancellationToken token)
//        {
//            return CallRequest<WitnessApiObj>(KnownApiNames.WalletApi, "get_witness", new object[] { ownerAccount }, token);
//        }

//        /// <summary>
//        /// API name: get_conversion_requests
//        /// Returns conversion requests by an account
//        ///
//        /// 
//        /// </summary>
//        /// <param name="owner">API type: string Account name of the account owning the requests
//        /// 
//        /// @returns All pending conversion requests by account</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: convert_request_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<ConvertRequestObject[]> GetConversionRequestsWalletApi(string owner, CancellationToken token)
//        {
//            return CallRequest<ConvertRequestObject[]>(KnownApiNames.WalletApi, "get_conversion_requests", new object[] { owner }, token);
//        }

//        /// <summary>
//        /// API name: update_witness
//        /// Update a witness object owned by the given account.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="witnessName">API type: string The name of the witness account.</param>
//        /// <param name="url">API type: string A URL containing some information about the witness.  The empty string makes it remain the same.</param>
//        /// <param name="blockSigningKey">API type: public_key_type The new block signing public key.  The empty string disables block production.</param>
//        /// <param name="props">API type: chain_properties&lt;0,17,0> The chain properties the witness is voting on.</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction.</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> UpdateWitness(string witnessName, string url, PublicKeyType blockSigningKey, ChainProperties props, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "update_witness", new object[] { witnessName, url, blockSigningKey, props, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: set_voting_proxy
//        /// Set the voting proxy for an account.
//        /// 
//        /// If a user does not wish to take an active part in voting, they can choose
//        /// to allow another account to vote their stake.
//        /// 
//        /// Setting a vote proxy does not remove your previous votes from the blockchain,
//        /// they remain there but are ignored.  If you later null out your vote proxy,
//        /// your previous votes will take effect again.
//        /// 
//        /// This setting can be changed at any time.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="accountToModify">API type: string the name or id of the account to update</param>
//        /// <param name="proxy">API type: string the name of account that should proxy to, or empty string to have no proxy</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> SetVotingProxy(string accountToModify, string proxy, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "set_voting_proxy", new object[] { accountToModify, proxy, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: transfer
//        /// Transfer funds from one account to another. GOLOS and SBD can be transferred.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="from">API type: string The account the funds are coming from</param>
//        /// <param name="to">API type: string The account the funds are going to</param>
//        /// <param name="amount">API type: asset&lt;0,17,0> The funds being transferred. i.e. "100.000 GOLOS"</param>
//        /// <param name="memo">API type: string A memo for the transactionm, encrypted with the to account's public memo key</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> Transfer(string from, string to, Asset amount, string memo, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "transfer", new object[] { from, to, amount, memo, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: transfer_to_vesting
//        /// Transfer GOLOS into a vesting fund represented by vesting shares (VESTS). VESTS are required to vesting
//        /// for a minimum of one coin year and can be withdrawn once a week over a two year withdraw period.
//        /// VESTS are protected against dilution up until 90% of GOLOS is vesting.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="from">API type: string The account the GOLOS is coming from</param>
//        /// <param name="to">API type: string The account getting the VESTS</param>
//        /// <param name="amount">API type: asset&lt;0,17,0> The amount of GOLOS to vest i.e. "100.00 GOLOS"</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> TransferToVesting(string from, string to, Asset amount, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "transfer_to_vesting", new object[] { from, to, amount, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: transfer_to_savings
//        /// Transfers into savings happen immediately, transfers from savings take 72 hours
//        ///
//        /// 
//        /// </summary>
//        /// <param name="from">API type: string</param>
//        /// <param name="to">API type: string</param>
//        /// <param name="amount">API type: asset&lt;0,17,0></param>
//        /// <param name="memo">API type: string</param>
//        /// <param name="broadcast">API type: bool</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> TransferToSavings(string from, string to, Asset amount, string memo, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "transfer_to_savings", new object[] { from, to, amount, memo, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: transfer_from_savings
//        /// 
//        /// </summary>
//        /// <param name="from">API type: string The account the GOLOS is coming from</param>
//        /// <param name="requestId">API type: uint32_t - an unique ID assigned by from account, the id is used to cancel the operation and can be reused after the transfer completes</param>
//        /// <param name="to">API type: string The account getting the VESTS</param>
//        /// <param name="amount">API type: asset&lt;0,17,0> The amount of GOLOS to vest i.e. "100.00 GOLOS"</param>
//        /// <param name="memo">API type: string a memo to include in the transaction, readable by the recipient</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> TransferFromSavings(string from, UInt32 requestId, string to, Asset amount, string memo, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "transfer_from_savings", new object[] { from, requestId, to, amount, memo, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: withdraw_vesting
//        /// Set up a vesting withdraw request. The request is fulfilled once a week over the next two year (104 weeks).
//        ///
//        /// 
//        /// </summary>
//        /// <param name="from">API type: string The account the VESTS are withdrawn from</param>
//        /// <param name="vestingShares">API type: asset&lt;0,17,0> The amount of VESTS to withdraw over the next two years. Each week (amount/104) shares are
//        /// withdrawn and deposited back as GOLOS. i.e. "10.000000 VESTS"</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> WithdrawVesting(string from, Asset vestingShares, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "withdraw_vesting", new object[] { from, vestingShares, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: set_withdraw_vesting_route
//        /// Set up a vesting withdraw route. When vesting shares are withdrawn, they will be routed to these accounts
//        /// based on the specified weights.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="from">API type: string The account the VESTS are withdrawn from.</param>
//        /// <param name="to">API type: string   The account receiving either VESTS or GOLOS.</param>
//        /// <param name="percent">API type: uint16_t The percent of the withdraw to go to the 'to' account. This is denoted in hundreths of a percent.
//        /// i.e. 100 is 1% and 10000 is 100%. This value must be between 1 and 100000</param>
//        /// <param name="autoVest">API type: bool Set to true if the from account should receive the VESTS as VESTS, or false if it should receive
//        /// them as GOLOS.</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction.</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> SetWithdrawVestingRoute(string from, string to, UInt16 percent, bool autoVest, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "set_withdraw_vesting_route", new object[] { from, to, percent, autoVest, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: publish_feed
//        /// A witness can public a price feed for the GOLOS:SBD market. The median price feed is used
//        /// to process conversion requests from SBD to GOLOS.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="witness">API type: string The witness publishing the price feed</param>
//        /// <param name="exchangeRate">API type: price&lt;0,17,0> The desired exchange rate</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> PublishFeed(string witness, Price exchangeRate, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "publish_feed", new object[] { witness, exchangeRate, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: sign_transaction
//        /// Signs a transaction.
//        /// 
//        /// Given a fully-formed transaction that is only lacking signatures, this signs
//        /// the transaction with the necessary keys and optionally broadcasts the transaction
//        ///
//        /// 
//        /// </summary>
//        /// <param name="tx">API type: signed_transaction the unsigned transaction</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction the signed version of the transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> SignTransaction(SignedTransaction tx, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "sign_transaction", new object[] { tx, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: get_prototype_operation
//        /// Returns an uninitialized object representing a given blockchain operation.
//        /// 
//        /// This returns a default-initialized object of the given type; it can be used
//        /// during early development of the wallet when we don't yet have custom commands for
//        /// creating all of the operations the blockchain supports.
//        /// 
//        /// Any operation the blockchain supports can be created using the transaction builder's
//        /// \c add_operation_to_builder_transaction() , but to do that from the CLI you need to
//        /// know what the JSON form of the operation looks like.  This will give you a template
//        /// you can fill in.  It's better than nothing.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="operationType">API type: string the type of operation to return, must be one of the
//        /// operations defined in `steemit/chain/operations.hpp`
//        /// (e.g., "global_parameters_update_operation")</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: operation a default-constructed operation of the given type</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object> GetPrototypeOperation(string operationType, CancellationToken token)
//        {
//            return CallRequest<object>(KnownApiNames.WalletApi, "get_prototype_operation", new object[] { operationType }, token);
//        }

//        /// <summary>
//        /// API name: network_add_nodes
//        /// 
//        /// </summary>
//        /// <param name="nodes">API type: vector&lt;string></param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse NetworkAddNodes(string[] nodes, CancellationToken token)
//        {
//            return CallRequest(KnownApiNames.WalletApi, "network_add_nodes", new object[] { nodes }, token);
//        }

//        /// <summary>
//        /// API name: network_get_connected_peers
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: variant</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object[]> NetworkGetConnectedPeers(CancellationToken token)
//        {
//            return CallRequest<object[]>(KnownApiNames.WalletApi, "network_get_connected_peers", new object[] { }, token);
//        }

//        /// <summary>
//        /// API name: get_order_book
//        /// Gets the current order book for selected asset pair
//        ///
//        /// 
//        /// </summary>
//        /// <param name="base">API type: string Base symbol string</param>
//        /// <param name="quote">API type: string Quote symbol string</param>
//        /// <param name="limit">API type: unsigned Maximum number of orders to return for bids and asks. Max is 1000.</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: market_history::order_book</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object> GetOrderBook(string @base, string quote, UInt16 limit, CancellationToken token)
//        {
//            return CallRequest<object>(KnownApiNames.WalletApi, "get_order_book", new object[] { @base, quote, limit }, token);
//        }

//        /// <summary>
//        /// API name: get_limit_orders_by_owner
//        /// 
//        /// </summary>
//        /// <param name="accountName">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: extended_limit_order</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<ExtendedLimitOrder[]> GetLimitOrdersByOwnerWalletApi(string accountName, CancellationToken token)
//        {
//            return CallRequest<ExtendedLimitOrder[]>(KnownApiNames.WalletApi, "get_limit_orders_by_owner", new object[] { accountName }, token);
//        }

//        /// <summary>
//        /// API name: get_call_orders_by_owner
//        /// 
//        /// </summary>
//        /// <param name="accountName">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: call_order_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<CallOrderObject[]> GetCallOrdersByOwner(string accountName, CancellationToken token)
//        {
//            return CallRequest<CallOrderObject[]>(KnownApiNames.WalletApi, "get_call_orders_by_owner", new object[] { accountName }, token);
//        }

//        /// <summary>
//        /// API name: get_collateral_bids
//        /// Returns the collateral_bid object for the given MPA
//        ///
//        /// 
//        /// </summary>
//        /// <param name="asset">API type: string the name or id of the asset</param>
//        /// <param name="limit">API type: uint32_t the number of entries to return</param>
//        /// <param name="start">API type: uint32_t the sequence number where to start looping back throw the history
//        /// @returns a list of \c collateral_bid_objects</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: collateral_bid_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<CollateralBidObject[]> GetCollateralBids(string asset, UInt32 limit, UInt32 start, CancellationToken token)
//        {
//            return CallRequest<CollateralBidObject[]>(KnownApiNames.WalletApi, "get_collateral_bids", new object[] { asset, limit, start }, token);
//        }

//        /// <summary>
//        /// API name: bid_collateral
//        /// Creates or updates a bid on an MPA after global settlement.
//        /// 
//        /// In order to revive a market-pegged asset after global settlement (aka
//        /// black swan), investors can bid collateral in order to take over part of
//        /// the debt and the settlement fund, see BSIP-0018. Updating an existing
//        /// bid to cover 0 debt will delete the bid.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="bidderName">API type: string the name or id of the account making the bid</param>
//        /// <param name="debtAmount">API type: string the amount of debt of the named asset to bid for</param>
//        /// <param name="debtSymbol">API type: string the name or id of the MPA to bid for</param>
//        /// <param name="additionalCollateral">API type: string the amount of additional collateral to bid
//        /// for taking over debt_amount. The asset type of this amount is
//        /// determined automatically from debt_symbol.</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction creating/updating the bid</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> BidCollateral(string bidderName, string debtAmount, string debtSymbol, string additionalCollateral, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "bid_collateral", new object[] { bidderName, debtAmount, debtSymbol, additionalCollateral, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: create_order
//        /// Creates a limit order at the price amount_to_sell / min_to_receive and will deduct amount_to_sell from account
//        ///
//        /// 
//        /// </summary>
//        /// <param name="owner">API type: string The name of the account creating the order</param>
//        /// <param name="orderId">API type: uint32_t is a unique identifier assigned by the creator of the order, it can be reused after the order has been filled</param>
//        /// <param name="amountToSell">API type: asset&lt;0,17,0> The amount of either SBD or GOLOS you wish to sell</param>
//        /// <param name="minToReceive">API type: asset&lt;0,17,0> The amount of the other asset you will receive at a minimum</param>
//        /// <param name="fillOrKill">API type: bool true if you want the order to be killed if it cannot immediately be filled</param>
//        /// <param name="expiration">API type: uint32_t the time the order should expire if it has not been filled</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> CreateOrder(string owner, UInt32 orderId, Asset amountToSell, Asset minToReceive, bool fillOrKill, UInt32 expiration, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "create_order", new object[] { owner, orderId, amountToSell, minToReceive, fillOrKill, expiration, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: cancel_order
//        /// Cancel an order created with create_order
//        ///
//        /// 
//        /// </summary>
//        /// <param name="owner">API type: string The name of the account owning the order to cancel_order</param>
//        /// <param name="orderId">API type: protocol::integral_id_type The unique identifier assigned to the order by its creator</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> CancelOrder(string owner, UInt32 orderId, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "cancel_order", new object[] { owner, orderId, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: sell_asset
//        /// Place a limit order attempting to sell one asset for another.
//        /// 
//        /// Buying and selling are the same operation on Graphene; if you want to buy GOLOS
//        /// with USD, you should sell USD for GOLOS.
//        /// 
//        /// The blockchain will attempt to sell the \c symbol_to_sell for as
//        /// much \c symbol_to_receive as possible, as long as the price is at
//        /// least \c min_to_receive / \c amount_to_sell.
//        /// 
//        /// In addition to the transaction fees, market fees will apply as specified
//        /// by the issuer of both the selling asset and the receiving asset as
//        /// a percentage of the amount exchanged.
//        /// 
//        /// If either the selling asset or the receiving asset is whitelist
//        /// restricted, the order will only be created if the seller is on
//        /// the whitelist of the restricted asset type.
//        /// 
//        /// Market orders are matched in the order they are included
//        /// in the block chain.
//        /// 
//        /// @todo Allow order expiration to be set here.  Document default/max expiration time
//        ///
//        /// 
//        /// </summary>
//        /// <param name="sellerAccount">API type: string the account providing the asset being sold, and which will
//        /// receive the proceeds of the sale.</param>
//        /// <param name="amountToSell">API type: asset&lt;0,17,0> the amount of the asset being sold to sell (in nominal units)</param>
//        /// <param name="amountToReceive">API type: asset&lt;0,17,0> the minimum amount you are willing to receive in return for
//        /// selling the entire amount_to_sell</param>
//        /// <param name="timeoutSec">API type: uint32_t if the order does not fill immediately, this is the length of
//        /// time the order will remain on the order books before it is
//        /// cancelled and the un-spent funds are returned to the seller's
//        /// account</param>
//        /// <param name="orderId">API type: protocol::integral_id_type</param>
//        /// <param name="fillOrKill">API type: bool if true, the order will only be included in the blockchain
//        /// if it is filled immediately; if false, an open order will be
//        /// left on the books to fill any amount that cannot be filled
//        /// immediately.</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction selling the funds</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> SellAsset(string sellerAccount, Asset amountToSell, Asset amountToReceive, UInt32 timeoutSec, UInt32 orderId, bool fillOrKill, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "sell_asset", new object[] { sellerAccount, amountToSell, amountToReceive, timeoutSec, orderId, fillOrKill, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: sell
//        /// Place a limit order attempting to sell one asset for another.
//        /// 
//        /// This API call abstracts away some of the details of the sell_asset call to be more
//        /// user friendly. All orders placed with sell never timeout and will not be killed if they
//        /// cannot be filled immediately. If you wish for one of these parameters to be different,
//        /// then sell_asset should be used instead.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="sellerAccount">API type: string the account providing the asset being sold, and which will
//        /// receive the processed of the sale.</param>
//        /// <param name="base">API type: string The name or id of the asset to sell.</param>
//        /// <param name="quote">API type: string The name or id of the asset to recieve.</param>
//        /// <param name="rate">API type: double The rate in base:quote at which you want to sell.</param>
//        /// <param name="amount">API type: double The amount of base you want to sell.</param>
//        /// <param name="orderId">API type: protocol::integral_id_type</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network.
//        /// @returns The signed transaction selling the funds.</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> Sell(string sellerAccount, string @base, string quote, double rate, double amount, UInt32 orderId, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "sell", new object[] { sellerAccount, @base, quote, rate, amount, orderId, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: buy
//        /// Place a limit order attempting to buy one asset with another.
//        /// 
//        /// This API call abstracts away some of the details of the sell_asset call to be more
//        /// user friendly. All orders placed with buy never timeout and will not be killed if they
//        /// cannot be filled immediately. If you wish for one of these parameters to be different,
//        /// then sell_asset should be used instead.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="buyerAccount">API type: string The account buying the asset for another asset.</param>
//        /// <param name="base">API type: string The name or id of the asset to buy.</param>
//        /// <param name="quote">API type: string The name or id of the assest being offered as payment.</param>
//        /// <param name="rate">API type: double The rate in base:quote at which you want to buy.</param>
//        /// <param name="amount">API type: double the amount of base you want to buy.</param>
//        /// <param name="orderId">API type: protocol::integral_id_type</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network.
//        /// @returns The signed transaction selling the funds.</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> Buy(string buyerAccount, string @base, string quote, double rate, double amount, UInt32 orderId, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "buy", new object[] { buyerAccount, @base, quote, rate, amount, orderId, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: borrow_asset
//        /// Borrow an asset or update the debt/collateral ratio for the loan.
//        /// 
//        /// This is the first step in shorting an asset.  Call \c sell_asset() to complete the short.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="borrowerName">API type: string the name or id of the account associated with the transaction.</param>
//        /// <param name="amountToBorrow">API type: asset&lt;0,17,0> the amount of the asset being borrowed.
//        /// Make this value negative to pay back debt.</param>
//        /// <param name="amountOfCollateral">API type: asset&lt;0,17,0> the amount of the backing asset to add to your collateral
//        /// position.  Make this negative to claim back some of your collateral.
//        /// The backing asset is defined in the \c bitasset_options for the asset being borrowed.</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction borrowing the asset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> BorrowAsset(string borrowerName, Asset amountToBorrow, Asset amountOfCollateral, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "borrow_asset", new object[] { borrowerName, amountToBorrow, amountOfCollateral, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: create_asset
//        /// Creates a new user-issued or market-issued asset.
//        /// 
//        /// Many options can be changed later using \c update_asset()
//        /// 
//        /// Right now this function is difficult to use because you must provide raw JSON data
//        /// structures for the options objects, and those include prices and asset ids.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="issuer">API type: string the name or id of the account who will pay the fee and become the
//        /// issuer of the new asset.  This can be updated later</param>
//        /// <param name="symbol">API type: string the ticker symbol of the new asset</param>
//        /// <param name="precision">API type: uint8_t the number of digits of precision to the right of the decimal point,
//        /// must be less than or equal to 12</param>
//        /// <param name="common">API type: asset_options&lt;0,17,0> asset options required for all new assets.
//        /// Note that core_exchange_rate technically needs to store the asset ID of
//        /// this new asset. Since this ID is not known at the time this operation is
//        /// created, create this price as though the new asset has instance ID 1, and
//        /// the chain will overwrite it with the new asset's ID.</param>
//        /// <param name="bitassetOpts">API type: fc::optional&lt;bitasset_options> options specific to BitAssets.  This may be null unless the
//        /// \c market_issued flag is set in common.flags</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction creating a new asset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> CreateAsset(string issuer, string symbol, byte precision, AssetOptions common, BitassetOptions bitassetOpts, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "create_asset", new object[] { issuer, symbol, precision, common, bitassetOpts, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: update_asset
//        /// Update the core options on an asset.
//        /// There are a number of options which all assets in the network use. These options are
//        /// enumerated in the asset_object::asset_options struct. This command is used to update
//        /// these options for an existing asset.
//        /// 
//        /// @note This operation cannot be used to update BitAsset-specific options. For these options,
//        /// \c update_bitasset() instead.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="symbol">API type: string the name or id of the asset to update</param>
//        /// <param name="newIssuer">API type: optional&lt;string> if changing the asset's issuer, the name or id of the new issuer.
//        /// null if you wish to remain the issuer of the asset</param>
//        /// <param name="newOptions">API type: asset_options&lt;0,17,0> the new asset_options object, which will entirely replace the existing
//        /// options.</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction updating the asset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> UpdateAsset(string symbol, string newIssuer, AssetOptions newOptions, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "update_asset", new object[] { symbol, newIssuer, newOptions, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: update_bitasset
//        /// Update the options specific to a BitAsset.
//        /// 
//        /// BitAssets have some options which are not relevant to other asset types. This operation is used to update those
//        /// options an an existing BitAsset.
//        /// 
//        /// @see update_asset()
//        ///
//        /// 
//        /// </summary>
//        /// <param name="symbol">API type: string the name or id of the asset to update, which must be a market-issued asset</param>
//        /// <param name="newOptions">API type: bitasset_options the new bitasset_options object, which will entirely replace the existing
//        /// options.</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction updating the bitasset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> UpdateBitasset(string symbol, BitassetOptions newOptions, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "update_bitasset", new object[] { symbol, newOptions, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: update_asset_feed_producers
//        /// Update the set of feed-producing accounts for a BitAsset.
//        /// 
//        /// BitAssets have price feeds selected by taking the median values of recommendations from a set of feed producers.
//        /// This command is used to specify which accounts may produce feeds for a given BitAsset.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="symbol">API type: string the name or id of the asset to update</param>
//        /// <param name="newFeedProducers">API type: flat_set&lt;string> a list of account names or ids which are authorized to produce feeds for the asset.
//        /// this list will completely replace the existing list</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction updating the bitasset's feed producers</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> UpdateAssetFeedProducers(string symbol, string[] newFeedProducers, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "update_asset_feed_producers", new object[] { symbol, newFeedProducers, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: publish_asset_feed
//        /// Publishes a price feed for the named asset.
//        /// 
//        /// Price feed providers use this command to publish their price feeds for market-issued assets. A price feed is
//        /// used to tune the market for a particular market-issued asset. For each value in the feed, the median across all
//        /// committee_member feeds for that asset is calculated and the market for the asset is configured with the median of that
//        /// value.
//        /// 
//        /// The feed object in this command contains three prices: a call price limit, a short price limit, and a settlement price.
//        /// The call limit price is structured as (collateral asset) / (debt asset) and the short limit price is structured
//        /// as (asset for sale) / (collateral asset). Note that the asset IDs are opposite to eachother, so if we're
//        /// publishing a feed for USD, the call limit price will be CORE/USD and the short limit price will be USD/CORE. The
//        /// settlement price may be flipped either direction, as long as it is a ratio between the market-issued asset and
//        /// its collateral.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="publishingAccount">API type: string the account publishing the price feed</param>
//        /// <param name="symbol">API type: string the name or id of the asset whose feed we're publishing</param>
//        /// <param name="feed">API type: price_feed&lt;0,17,0> the price_feed object containing the three prices making up the feed</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction updating the price feed for the given asset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> PublishAssetFeed(string publishingAccount, string symbol, PriceFeed feed, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "publish_asset_feed", new object[] { publishingAccount, symbol, feed, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: fund_asset_fee_pool
//        /// Pay into the fee pool for the given asset.
//        /// 
//        /// User-issued assets can optionally have a pool of the core asset which is
//        /// automatically used to pay transaction fees for any transaction using that
//        /// asset (using the asset's core exchange rate).
//        /// 
//        /// This command allows anyone to deposit the core asset into this fee pool.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="from">API type: string the name or id of the account sending the core asset</param>
//        /// <param name="symbol">API type: string the name or id of the asset whose fee pool you wish to fund</param>
//        /// <param name="amount">API type: string the amount of the core asset to deposit</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction funding the fee pool</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> FundAssetFeePool(string from, string symbol, string amount, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "fund_asset_fee_pool", new object[] { from, symbol, amount, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: reserve_asset
//        /// Burns the given user-issued asset.
//        /// 
//        /// This command burns the user-issued asset to reduce the amount in circulation.
//        /// @note you cannot burn market-issued assets.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="from">API type: string the account containing the asset you wish to burn</param>
//        /// <param name="amount">API type: string the amount to burn, in nominal units</param>
//        /// <param name="symbol">API type: string the name or id of the asset to burn</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction burning the asset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> ReserveAsset(string from, string amount, string symbol, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "reserve_asset", new object[] { from, amount, symbol, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: global_settle_asset
//        /// Forces a global settling of the given asset (black swan or prediction markets).
//        /// 
//        /// In order to use this operation, asset_to_settle must have the global_settle flag set
//        /// 
//        /// When this operation is executed all balances are converted into the backing asset at the
//        /// settle_price and all open margin positions are called at the settle price.  If this asset is
//        /// used as backing for other bitassets, those bitassets will be force settled at their current
//        /// feed price.
//        /// 
//        /// @note this operation is used only by the asset issuer, \c settle_asset() may be used by
//        /// any user owning the asset
//        ///
//        /// 
//        /// </summary>
//        /// <param name="symbol">API type: string the name or id of the asset to force settlement on</param>
//        /// <param name="settlePrice">API type: price&lt;0,17,0> the price at which to settle</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction settling the named asset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> GlobalSettleAsset(string symbol, Price settlePrice, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "global_settle_asset", new object[] { symbol, settlePrice, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: whitelist_account
//        /// Whitelist and blacklist accounts, primarily for transacting in whitelisted assets.
//        /// 
//        /// Accounts can freely specify opinions about other accounts, in the form of either whitelisting or blackl      isting
//        /// them. This information is used in chain validation only to determine whether an account is authorized to tra      nsact
//        /// in an asset type which enforces a whitelist, but third parties can use this information for other uses as wel      l,
//        /// as long as it does not conflict with the use of whitelisted assets.
//        /// 
//        /// An asset which enforces a whitelist specifies a list of accounts to maintain its whitelist, and a list of
//        /// accounts to maintain its blacklist. In order for a given account A to hold and transact in a whitel      isted asset S,
//        /// A must be whitelisted by at least one of S's whitelist_authorities and blacklisted by none of S's
//        /// blacklist_authorities. If A receives a balance of S, and is later removed from the whitelist(s) which allowe      d it
//        /// to hold S, or added to any blacklist S specifies as authoritative, A's balance of S will be frozen until       A's
//        /// authorization is reinstated.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="authorizingAccount">API type: string the account who is doing the whitelisting</param>
//        /// <param name="accountToList">API type: string the account being whitelisted</param>
//        /// <param name="newListingStatus">API type: account_whitelist_operation&lt;0,17,0> the new whitelisting status</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction changing the whitelisting status</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> WhitelistAccount(string authorizingAccount, string accountToList, AccountWhitelistOperation newListingStatus, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "whitelist_account", new object[] { authorizingAccount, accountToList, newListingStatus, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: post_comment
//        /// 
//        /// </summary>
//        /// <param name="author">API type: string the name of the account authoring the comment</param>
//        /// <param name="permlink">API type: string the accountwide unique permlink for the comment</param>
//        /// <param name="parentAuthor">API type: string can be null if this is a top level comment</param>
//        /// <param name="parentPermlink">API type: string becomes category if parent_author is ""</param>
//        /// <param name="title">API type: string the title of the comment</param>
//        /// <param name="body">API type: string the body of the comment</param>
//        /// <param name="json">API type: string the json metadata of the comment</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> PostComment(string author, string permlink, string parentAuthor, string parentPermlink, string title, string body, string json, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "post_comment", new object[] { author, permlink, parentAuthor, parentPermlink, title, body, json, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: extend_payout_by_cost
//        /// 
//        /// </summary>
//        /// <param name="payer">API type: string the name of the account paying for the transaction</param>
//        /// <param name="author">API type: string the name of the account authoring the comment</param>
//        /// <param name="permlink">API type: string comment permlink</param>
//        /// <param name="extensionCost">API type: asset&lt;0,17,0> SBD amount payer will spend on payout window extension</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> ExtendPayoutByCost(string payer, string author, string permlink, Asset extensionCost, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "extend_payout_by_cost", new object[] { payer, author, permlink, extensionCost, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: send_private_message
//        /// Send the encrypted private email-like message to user
//        ///
//        /// 
//        /// </summary>
//        /// <param name="from">API type: string message author name</param>
//        /// <param name="to">API type: string message recipient name</param>
//        /// <param name="subject">API type: string message subject</param>
//        /// <param name="body">API type: string message content</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> SendPrivateMessage(string from, string to, string subject, string body, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "send_private_message", new object[] { from, to, subject, body, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: get_inbox
//        /// Retrieves the private message inbox for the account mentioned
//        ///
//        /// 
//        /// </summary>
//        /// <param name="account">API type: string account to retrieve inbox for</param>
//        /// <param name="newest">API type: fc::time_point timestamp to start retrieve messages from</param>
//        /// <param name="limit">API type: uint32_t amount of messages to retrieve</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: extended_message_object message api objects vector</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<ExtendedMessageObject[]> GetInbox(string account, object newest, UInt32 limit, CancellationToken token)
//        {
//            return CallRequest<ExtendedMessageObject[]>(KnownApiNames.WalletApi, "get_inbox", new object[] { account, newest, limit }, token);
//        }

//        /// <summary>
//        /// API name: get_outbox
//        /// Retrieves the private message outbox for the account mentioned
//        ///
//        /// 
//        /// </summary>
//        /// <param name="account">API type: string account to retrieve outbox for</param>
//        /// <param name="newest">API type: fc::time_point timestamp to start retireve messages from</param>
//        /// <param name="limit">API type: uint32_t amount of messages to retrieve</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: extended_message_object message api objects vector</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<ExtendedMessageObject[]> GetOutbox(string account, object newest, UInt32 limit, CancellationToken token)
//        {
//            return CallRequest<ExtendedMessageObject[]>(KnownApiNames.WalletApi, "get_outbox", new object[] { account, newest, limit }, token);
//        }

//        /// <summary>
//        /// API name: vote
//        /// Vote on a comment to be paid GOLOS
//        ///
//        /// 
//        /// </summary>
//        /// <param name="voter">API type: string The account voting</param>
//        /// <param name="author">API type: string The author of the comment to be voted on</param>
//        /// <param name="permlink">API type: string The permlink of the comment to be voted on. (author, permlink) is a unique pair</param>
//        /// <param name="weight">API type: int16_t The weight [-100,100] of the vote</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> Vote(string voter, string author, string permlink, Int16 weight, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "vote", new object[] { voter, author, permlink, weight, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: set_transaction_expiration
//        /// Sets the amount of time in the future until a transaction expires.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="seconds">API type: uint32_t</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse SetTransactionExpiration(UInt32 seconds, CancellationToken token)
//        {
//            return CallRequest(KnownApiNames.WalletApi, "set_transaction_expiration", new object[] { seconds }, token);
//        }

//        /// <summary>
//        /// API name: challenge
//        /// Challenge a user's authority. The challenger pays a fee to the challenged which is depositted as
//        /// Golos Power. Until the challenged proves their active key, all posting rights are revoked.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="challenger">API type: string The account issuing the challenge</param>
//        /// <param name="challenged">API type: string The account being challenged</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> Challenge(string challenger, string challenged, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "challenge", new object[] { challenger, challenged, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: request_account_recovery
//        /// Create an account recovery request as a recover account. The syntax for this command contains a serialized authority object
//        /// so there is an example below on how to pass in the authority.
//        /// 
//        /// request_account_recovery "your_account" "account_to_recover" {"weight_threshold": 1,"account_auths": [], "key_auths": [["new_public_key",1]]} true
//        ///
//        /// 
//        /// </summary>
//        /// <param name="recoveryAccount">API type: string The name of your account</param>
//        /// <param name="accountToRecover">API type: string The name of the account you are trying to recover</param>
//        /// <param name="newAuthority">API type: authority The new owner authority for the recovered account. This should be given to you by the holder of the compromised or lost account.</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> RequestAccountRecovery(string recoveryAccount, string accountToRecover, Authority newAuthority, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "request_account_recovery", new object[] { recoveryAccount, accountToRecover, newAuthority, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: change_recovery_account
//        /// Change your recovery account after a 30 day delay.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="owner">API type: string The name of your account</param>
//        /// <param name="newRecoveryAccount">API type: string The name of the recovery account you wish to have</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> ChangeRecoveryAccount(string owner, string newRecoveryAccount, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "change_recovery_account", new object[] { owner, newRecoveryAccount, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: get_owner_history
//        /// 
//        /// </summary>
//        /// <param name="account">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: owner_authority_history_api_obj</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<OwnerAuthorityHistoryApiObj[]> GetOwnerHistoryWalletApi(string account, CancellationToken token)
//        {
//            return CallRequest<OwnerAuthorityHistoryApiObj[]>(KnownApiNames.WalletApi, "get_owner_history", new object[] { account }, token);
//        }

//        /// <summary>
//        /// API name: prove
//        /// Prove an account's active authority, fulfilling a challenge, restoring posting rights, and making
//        /// the account immune to challenge for 24 hours.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="challenged">API type: string The account that was challenged and is proving its authority.</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> Prove(string challenged, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "prove", new object[] { challenged, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: follow
//        /// Marks one account as following another account.  Requires the posting authority of the follower.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="follower">API type: string account name to follow with</param>
//        /// <param name="following">API type: string account name to follow for</param>
//        /// <param name="what">API type: set&lt;string> - a set of things to follow: posts, comments, votes, ignore</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> Follow(string follower, string following, string[] what, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "follow", new object[] { follower, following, what, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: reblog
//        /// Reblog another account's post.  Requires the posting authority of the account doing the reblog.
//        ///
//        /// 
//        /// </summary>
//        /// <param name="account">API type: string account name of the user reblogging a post</param>
//        /// <param name="author">API type: string account name of the author of the post</param>
//        /// <param name="permlink">API type: string - permanent link of the post to reblog</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> Reblog(string account, string author, string permlink, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "reblog", new object[] { account, author, permlink, broadcast }, token);
//        }

//        /// <summary>
//        /// API name: get_encrypted_memo
//        /// Returns the encrypted memo if memo starts with '#' otherwise returns memo
//        ///
//        /// 
//        /// </summary>
//        /// <param name="from">API type: string</param>
//        /// <param name="to">API type: string</param>
//        /// <param name="memo">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: string</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string> GetEncryptedMemo(string from, string to, string memo, CancellationToken token)
//        {
//            return CallRequest<string>(KnownApiNames.WalletApi, "get_encrypted_memo", new object[] { from, to, memo }, token);
//        }

//        /// <summary>
//        /// API name: decrypt_memo
//        /// Returns the decrypted memo if possible given wallet's known private keys
//        ///
//        /// 
//        /// </summary>
//        /// <param name="memo">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: string</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string> DecryptMemo(string memo, CancellationToken token)
//        {
//            return CallRequest<string>(KnownApiNames.WalletApi, "decrypt_memo", new object[] { memo }, token);
//        }

//        /// <summary>
//        /// API name: decline_voting_rights
//        /// 
//        /// </summary>
//        /// <param name="account">API type: string</param>
//        /// <param name="decline">API type: bool</param>
//        /// <param name="broadcast">API type: bool</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: annotated_signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AnnotatedSignedTransaction> DeclineVotingRights(string account, bool decline, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<AnnotatedSignedTransaction>(KnownApiNames.WalletApi, "decline_voting_rights", new object[] { account, decline, broadcast }, token);
//        }


//        /**
//         * @ingroup Transaction Builder API
//         */

//        /// <summary>
//        /// API name: begin_builder_transaction
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: transaction_handle_type</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<UInt16> BeginBuilderTransaction(CancellationToken token)
//        {
//            return CallRequest<UInt16>(KnownApiNames.WalletApi, "begin_builder_transaction", new object[] { }, token);
//        }


//        /**
//         * @ingroup Transaction Builder API
//         */

//        /// <summary>
//        /// API name: add_operation_to_builder_transaction
//        /// 
//        /// </summary>
//        /// <param name="transactionHandle">API type: transaction_handle_type</param>
//        /// <param name="op">API type: operation</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse AddOperationToBuilderTransaction(UInt16 transactionHandle, object op, CancellationToken token)
//        {
//            return CallRequest(KnownApiNames.WalletApi, "add_operation_to_builder_transaction", new object[] { transactionHandle, op }, token);
//        }


//        /**
//         * @ingroup Transaction Builder API
//         */

//        /// <summary>
//        /// API name: preview_builder_transaction
//        /// 
//        /// </summary>
//        /// <param name="handle">API type: transaction_handle_type</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<Transaction> PreviewBuilderTransaction(UInt16 handle, CancellationToken token)
//        {
//            return CallRequest<Transaction>(KnownApiNames.WalletApi, "preview_builder_transaction", new object[] { handle }, token);
//        }


//        /**
//         * @ingroup Transaction Builder API
//         */

//        /// <summary>
//        /// API name: sign_builder_transaction
//        /// 
//        /// </summary>
//        /// <param name="transactionHandle">API type: transaction_handle_type</param>
//        /// <param name="broadcast">API type: bool</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> SignBuilderTransaction(UInt16 transactionHandle, bool broadcast, CancellationToken token)
//        {
//            return CallRequest<SignedTransaction>(KnownApiNames.WalletApi, "sign_builder_transaction", new object[] { transactionHandle, broadcast }, token);
//        }


//        /**
//         * @ingroup Transaction Builder API
//         */

//        /// <summary>
//        /// API name: remove_builder_transaction
//        /// 
//        /// </summary>
//        /// <param name="handle">API type: transaction_handle_type</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse RemoveBuilderTransaction(UInt16 handle, CancellationToken token)
//        {
//            return CallRequest(KnownApiNames.WalletApi, "remove_builder_transaction", new object[] { handle }, token);
//        }
//    }
//}
