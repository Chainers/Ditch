using System.Threading;
using Ditch.BitShares.Models;
using Ditch.BitShares.Operations;
using Ditch.Core.JsonRpc;
using Ditch.Core.Models;

namespace Ditch.BitShares
{
    /**
     * @brief The database_api class implements the RPC API for the chain database.
     *
     * This API exposes accessors on the database which query state tracked by a blockchain validating node. This API is
     * read-only; all modifications to the database must be performed via transactions. Transactions are broadcast via
     * the @ref network_broadcast_api.
     */

    /// <summary>
    /// database_api
    /// libraries\app\include\graphene\app\database_api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /////////////
        // Objects //
        /////////////

        /// <summary>
        /// API name: get_objects
        /// Get the objects corresponding to the provided IDs
        ///
        /// 
        /// </summary>
        /// <param name="ids">API type: vector&lt;object_id_type> IDs of the objects to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: variants The objects retrieved, in the order they are mentioned in ids
        /// 
        /// If any of the provided IDs does not map to an object, a null variant is returned in its position.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> GetObjects<T>(object[] ids, CancellationToken token)
        {
            return CustomGetRequest<T>(KnownApiNames.DatabaseApi, "get_objects", new object[] { ids }, token);
        }

        /////////////////////////////
        // Blocks and transactions //
        /////////////////////////////

        /// <summary>
        /// API name: get_block_header
        /// Retrieve a block header
        ///
        /// 
        /// </summary>
        /// <param name="blockNum">API type: uint32_t Height of the block whose header should be returned</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: block_header header of the referenced block, or null if no matching block was found</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<BlockHeader> GetBlockHeader(uint blockNum, CancellationToken token)
        {
            return CustomGetRequest<BlockHeader>(KnownApiNames.DatabaseApi, "get_block_header", new object[] { blockNum }, token);
        }

        /// <summary>
        /// API name: get_block_header_batch
        /// Retrieve multiple block header by block numbers
        ///
        /// 
        /// </summary>
        /// <param name="blockNums">API type: vector&lt;uint32_t></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: map&lt;uint32_t,optional&lt;block_header>> array of headers of the referenced blocks, or null if no matching block was found</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object> GetBlockHeaderBatch(uint[] blockNums, CancellationToken token)
        {
            return CustomGetRequest<object>(KnownApiNames.DatabaseApi, "get_block_header_batch", new object[] { blockNums }, token);
        }

        /// <summary>
        /// API name: get_block
        /// Retrieve a full, signed block
        ///
        /// 
        /// </summary>
        /// <param name="blockNum">API type: uint32_t Height of the block to be returned</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: signed_block the referenced block, or null if no matching block was found</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SignedBlock> GetBlock(uint blockNum, CancellationToken token)
        {
            return CustomGetRequest<SignedBlock>(KnownApiNames.DatabaseApi, "get_block", new object[] { blockNum }, token);
        }

        /// <summary>
        /// API name: get_transaction
        /// used to fetch an individual transaction.
        ///
        /// 
        /// </summary>
        /// <param name="blockNum">API type: uint32_t</param>
        /// <param name="trxInBlock">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: processed_transaction</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ProcessedTransaction> GetTransaction(uint blockNum, uint trxInBlock, CancellationToken token)
        {
            return CustomGetRequest<ProcessedTransaction>(KnownApiNames.DatabaseApi, "get_transaction", new object[] { blockNum, trxInBlock }, token);
        }


        /**
         * If the transaction has not expired, this method will return the transaction for the given ID or
         * it will return NULL if it is not known.  Just because it is not known does not mean it wasn't
         * included in the blockchain.
         */

        /// <summary>
        /// API name: get_recent_transaction_by_id
        /// 
        /// </summary>
        /// <param name="id">API type: transaction_id_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: signed_transaction</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SignedTransaction> GetRecentTransactionById(string id, CancellationToken token)
        {
            return CustomGetRequest<SignedTransaction>(KnownApiNames.DatabaseApi, "get_recent_transaction_by_id", new object[] { id }, token);
        }

        /////////////
        // Globals //
        /////////////

        /// <summary>
        /// API name: get_chain_properties
        /// Retrieve the @ref chain_property_object associated with the chain
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: chain_property_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ChainPropertyObject> GetChainProperties(CancellationToken token)
        {
            return CustomGetRequest<ChainPropertyObject>(KnownApiNames.DatabaseApi, "get_chain_properties", token);
        }

        /// <summary>
        /// API name: get_global_properties
        /// Retrieve the current @ref global_property_object
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: global_property_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GlobalPropertyObject> GetGlobalProperties(CancellationToken token)
        {
            return CustomGetRequest<GlobalPropertyObject>(KnownApiNames.DatabaseApi, "get_global_properties", token);
        }

        /// <summary>
        /// API name: get_config
        /// Retrieve compile-time constants
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: variant_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> GetConfig<T>(CancellationToken token)
        {
            return CustomGetRequest<T>(KnownApiNames.DatabaseApi, "get_config", token);
        }

        /// <summary>
        /// API name: get_chain_id
        /// Get the chain ID
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: chain_id_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string> GetChainId(CancellationToken token)
        {
            return CustomGetRequest<string>(KnownApiNames.DatabaseApi, "get_chain_id", token);
        }

        /// <summary>
        /// API name: get_dynamic_global_properties
        /// Retrieve the current @ref dynamic_global_property_object
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: dynamic_global_property_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<DynamicGlobalPropertyObject> GetDynamicGlobalProperties(CancellationToken token)
        {
            return CustomGetRequest<DynamicGlobalPropertyObject>(KnownApiNames.DatabaseApi, "get_dynamic_global_properties", token);
        }


        //////////
        // Keys //
        //////////


        /// <summary>
        /// API name: get_key_references
        /// 
        /// </summary>
        /// <param name="key">API type: vector&lt;public_key_type></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_id_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object[]> GetKeyReferences(PublicKeyType[] key, CancellationToken token)
        {
            return CustomGetRequest<object[]>(KnownApiNames.DatabaseApi, "get_key_references", new object[] { key }, token);
        }

        /// <summary>
        /// API name: is_public_key_registered
        /// 
        /// </summary>
        /// <param name="publicKey">API type: string Public key</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bool Whether a public key is known</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<bool> IsPublicKeyRegistered(string publicKey, CancellationToken token)
        {
            return CustomGetRequest<bool>(KnownApiNames.DatabaseApi, "is_public_key_registered", new object[] { publicKey }, token);
        }

        //////////////
        // Accounts //
        //////////////

        /// <summary>
        /// API name: get_accounts
        /// Get a list of accounts by ID
        ///
        /// 
        /// </summary>
        /// <param name="accountIds">API type: vector&lt;account_id_type> IDs of the accounts to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_object The accounts corresponding to the provided IDs
        /// 
        /// This function has semantics identical to @ref get_objects</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountObject[]> GetAccounts(AccountIdType[] accountIds, CancellationToken token)
        {
            return CustomGetRequest<AccountObject[]>(KnownApiNames.DatabaseApi, "get_accounts", new object[] { accountIds }, token);
        }

        /// <summary>
        /// API name: get_full_accounts
        /// Fetch all objects relevant to the specified accounts and subscribe to updates
        ///
        /// 
        /// </summary>
        /// <param name="namesOrIds">API type: vector&lt;string> Each item must be the name or ID of an account to retrieve</param>
        /// <param name="subscribe">API type: bool</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: map&lt;string,full_account> Map of string from @ref names_or_ids to the corresponding account
        /// 
        /// This function fetches all relevant objects for the given accounts, and subscribes to updates to the given
        /// accounts. If any of the strings in @ref names_or_ids cannot be tied to an account, that input will be
        /// ignored. All other accounts will be retrieved and subscribed.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object> GetFullAccounts(string[] namesOrIds, bool subscribe, CancellationToken token)
        {
            return CustomGetRequest<object>(KnownApiNames.DatabaseApi, "get_full_accounts", new object[] { namesOrIds, subscribe }, token);
        }

        /// <summary>
        /// API name: get_account_by_name
        /// 
        /// </summary>
        /// <param name="name">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountObject> GetAccountByName(string name, CancellationToken token)
        {
            return CustomGetRequest<AccountObject>(KnownApiNames.DatabaseApi, "get_account_by_name", new object[] { name }, token);
        }

        /// <summary>
        /// API name: get_account_references
        /// 
        /// </summary>
        /// <param name="accountId">API type: account_id_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_id_type all accounts that referr to the key or account id in their owner or active authorities.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountIdType[]> GetAccountReferences(AccountIdType accountId, CancellationToken token)
        {
            return CustomGetRequest<AccountIdType[]>(KnownApiNames.DatabaseApi, "get_account_references", new object[] { accountId }, token);
        }

        /// <summary>
        /// API name: lookup_account_names
        /// Get a list of accounts by name
        ///
        /// 
        /// </summary>
        /// <param name="accountNames">API type: vector&lt;string> Names of the accounts to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_object The accounts holding the provided names
        /// 
        /// This function has semantics identical to @ref get_objects</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountObject[]> LookupAccountNames(string[] accountNames, CancellationToken token)
        {
            return CustomGetRequest<AccountObject[]>(KnownApiNames.DatabaseApi, "lookup_account_names", new object[] { accountNames }, token);
        }

        /// <summary>
        /// API name: lookup_accounts
        /// Get names and IDs for registered accounts
        ///
        /// 
        /// </summary>
        /// <param name="lowerBoundName">API type: string Lower bound of the first name to return</param>
        /// <param name="limit">API type: uint32_t Maximum number of results to return -- must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: map&lt;string,account_id_type> Map of account names to corresponding IDs</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MapContainer<string, AccountIdType>> LookupAccounts(string lowerBoundName, uint limit, CancellationToken token)
        {
            return CustomGetRequest<MapContainer<string, AccountIdType>>(KnownApiNames.DatabaseApi, "lookup_accounts", new object[] { lowerBoundName, limit }, token);
        }

        //////////////
        // Balances //
        //////////////

        /// <summary>
        /// API name: get_account_balances
        /// Get an account's balances in various assets
        ///
        /// 
        /// </summary>
        /// <param name="id">API type: account_id_type ID of the account to get balances for</param>
        /// <param name="assets">API type: flat_set&lt;asset_id_type> IDs of the assets to get balances of; if empty, get all assets account has a balance in</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: asset Balances of the account</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object[]> GetAccountBalances(AccountIdType id, AssetIdType[] assets, CancellationToken token)
        {
            return CustomGetRequest<object[]>(KnownApiNames.DatabaseApi, "get_account_balances", new object[] { id, assets }, token);
        }


        /// Semantically equivalent to @ref get_account_balances, but takes a name instead of an ID.

        /// <summary>
        /// API name: get_named_account_balances
        /// 
        /// </summary>
        /// <param name="name">API type: std::string</param>
        /// <param name="assets">API type: flat_set&lt;asset_id_type></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: asset</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object[]> GetNamedAccountBalances(string name, AssetIdType[] assets, CancellationToken token)
        {
            return CustomGetRequest<object[]>(KnownApiNames.DatabaseApi, "get_named_account_balances", new object[] { name, assets }, token);
        }

        /// <summary>
        /// API name: get_balance_objects
        /// 
        /// </summary>
        /// <param name="addrs">API type: vector&lt;address></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: balance_object all unclaimed balance objects for a set of addresses */</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<BalanceObject[]> GetBalanceObjects(object[] addrs, CancellationToken token)
        {
            return CustomGetRequest<BalanceObject[]>(KnownApiNames.DatabaseApi, "get_balance_objects", new object[] { addrs }, token);
        }

        /// <summary>
        /// API name: get_vested_balances
        /// 
        /// </summary>
        /// <param name="objs">API type: vector&lt;balance_id_type></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: asset</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object[]> GetVestedBalances(object[] objs, CancellationToken token)
        {
            return CustomGetRequest<object[]>(KnownApiNames.DatabaseApi, "get_vested_balances", new object[] { objs }, token);
        }

        /// <summary>
        /// API name: get_vesting_balances
        /// 
        /// </summary>
        /// <param name="accountId">API type: account_id_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: vesting_balance_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<VestingBalanceObject[]> GetVestingBalances(AccountIdType accountId, CancellationToken token)
        {
            return CustomGetRequest<VestingBalanceObject[]>(KnownApiNames.DatabaseApi, "get_vesting_balances", new object[] { accountId }, token);
        }

        /// <summary>
        /// API name: get_account_count
        /// Get the total number of accounts registered with the blockchain
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: uint64_t</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ulong> GetAccountCount(CancellationToken token)
        {
            return CustomGetRequest<ulong>(KnownApiNames.DatabaseApi, "get_account_count", token);
        }

        ////////////
        // Assets //
        ////////////

        /// <summary>
        /// API name: get_assets
        /// Get a list of assets by ID
        ///
        /// 
        /// </summary>
        /// <param name="assetIds">API type: vector&lt;asset_id_type> IDs of the assets to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: asset_object The assets corresponding to the provided IDs
        /// 
        /// This function has semantics identical to @ref get_objects</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AssetObject[]> GetAssets(AssetIdType[] assetIds, CancellationToken token)
        {
            return CustomGetRequest<AssetObject[]>(KnownApiNames.DatabaseApi, "get_assets", new object[] { assetIds }, token);
        }

        /// <summary>
        /// API name: list_assets
        /// Get assets alphabetically by symbol name
        ///
        /// 
        /// </summary>
        /// <param name="lowerBoundSymbol">API type: string Lower bound of symbol names to retrieve</param>
        /// <param name="limit">API type: uint32_t Maximum number of assets to fetch (must not exceed 100)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: asset_object The assets found</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AssetObject[]> ListAssets(string lowerBoundSymbol, uint limit, CancellationToken token)
        {
            return CustomGetRequest<AssetObject[]>(KnownApiNames.DatabaseApi, "list_assets", new object[] { lowerBoundSymbol, limit }, token);
        }

        /// <summary>
        /// API name: lookup_asset_symbols
        /// Get a list of assets by symbol
        ///
        /// 
        /// </summary>
        /// <param name="symbolsOrIds">API type: vector&lt;string></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: asset_object The assets corresponding to the provided symbols or IDs
        /// 
        /// This function has semantics identical to @ref get_objects</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AssetObject[]> LookupAssetSymbols(string[] symbolsOrIds, CancellationToken token)
        {
            return CustomGetRequest<AssetObject[]>(KnownApiNames.DatabaseApi, "lookup_asset_symbols", new object[] { symbolsOrIds }, token);
        }

        /////////////////////
        // Markets / feeds //
        /////////////////////

        /// <summary>
        /// API name: get_limit_orders
        /// Get limit orders in a given market
        ///
        /// 
        /// </summary>
        /// <param name="a">API type: asset_id_type ID of asset being sold</param>
        /// <param name="b">API type: asset_id_type ID of asset being purchased</param>
        /// <param name="limit">API type: uint32_t Maximum number of orders to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: limit_order_object The limit orders, ordered from least price to greatest</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<LimitOrderObject[]> GetLimitOrders(AssetIdType a, AssetIdType b, uint limit, CancellationToken token)
        {
            return CustomGetRequest<LimitOrderObject[]>(KnownApiNames.DatabaseApi, "get_limit_orders", new object[] { a, b, limit }, token);
        }

        /// <summary>
        /// API name: get_call_orders
        /// Get call orders in a given asset
        ///
        /// 
        /// </summary>
        /// <param name="a">API type: asset_id_type ID of asset being called</param>
        /// <param name="limit">API type: uint32_t Maximum number of orders to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: call_order_object The call orders, ordered from earliest to be called to latest</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CallOrderObject[]> GetCallOrders(AssetIdType a, uint limit, CancellationToken token)
        {
            return CustomGetRequest<CallOrderObject[]>(KnownApiNames.DatabaseApi, "get_call_orders", new object[] { a, limit }, token);
        }

        /// <summary>
        /// API name: get_settle_orders
        /// Get forced settlement orders in a given asset
        ///
        /// 
        /// </summary>
        /// <param name="a">API type: asset_id_type ID of asset being settled</param>
        /// <param name="limit">API type: uint32_t Maximum number of orders to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: force_settlement_object The settle orders, ordered from earliest settlement date to latest</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ForceSettlementObject[]> GetSettleOrders(AssetIdType a, uint limit, CancellationToken token)
        {
            return CustomGetRequest<ForceSettlementObject[]>(KnownApiNames.DatabaseApi, "get_settle_orders", new object[] { a, limit }, token);
        }

        /// <summary>
        /// API name: get_collateral_bids
        /// Get collateral_bid_objects for a given asset
        ///
        /// 
        /// </summary>
        /// <param name="asset">API type: asset_id_type</param>
        /// <param name="limit">API type: uint32_t Maximum number of objects to retrieve</param>
        /// <param name="start">API type: uint32_t skip that many results</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: collateral_bid_object The settle orders, ordered from earliest settlement date to latest</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CollateralBidObject[]> GetCollateralBids(AssetIdType asset, uint limit, uint start, CancellationToken token)
        {
            return CustomGetRequest<CollateralBidObject[]>(KnownApiNames.DatabaseApi, "get_collateral_bids", new object[] { asset, limit, start }, token);
        }

        /// <summary>
        /// API name: get_margin_positions
        /// 
        /// </summary>
        /// <param name="id">API type: account_id_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: call_order_object all open margin positions for a given account id.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CallOrderObject[]> GetMarginPositions(AccountIdType id, CancellationToken token)
        {
            return CustomGetRequest<CallOrderObject[]>(KnownApiNames.DatabaseApi, "get_margin_positions", new object[] { id }, token);
        }

        /// <summary>
        /// API name: get_ticker
        /// Returns the ticker for the market assetA:assetB
        ///
        /// 
        /// </summary>
        /// <param name="base">API type: string</param>
        /// <param name="quote">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_ticker The market ticker for the past 24 hours.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketTicker> GetTicker(string @base, string quote, CancellationToken token)
        {
            return CustomGetRequest<MarketTicker>(KnownApiNames.DatabaseApi, "get_ticker", new object[] { @base, quote }, token);
        }

        /// <summary>
        /// API name: get_24_volume
        /// Returns the 24 hour volume for the market assetA:assetB
        ///
        /// 
        /// </summary>
        /// <param name="base">API type: string</param>
        /// <param name="quote">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_volume The market volume over the past 24 hours</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketVolume> Get24Volume(string @base, string quote, CancellationToken token)
        {
            return CustomGetRequest<MarketVolume>(KnownApiNames.DatabaseApi, "get_24_volume", new object[] { @base, quote }, token);
        }

        /// <summary>
        /// API name: get_order_book
        /// Returns the order book for the market base:quote
        ///
        /// 
        /// </summary>
        /// <param name="base">API type: string String name of the first asset</param>
        /// <param name="quote">API type: string String name of the second asset</param>
        /// <param name="limit">API type: unsigned</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: order_book Order book of the market</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OrderBook> GetOrderBook(string @base, string quote, uint limit, CancellationToken token)
        {
            return CustomGetRequest<OrderBook>(KnownApiNames.DatabaseApi, "get_order_book", new object[] { @base, quote, limit }, token);
        }

        /// <summary>
        /// API name: get_top_markets
        /// Returns vector of 24 hour volume markets sorted by reverse base_volume
        /// Note: this API is experimental and subject to change in next releases
        ///
        /// 
        /// </summary>
        /// <param name="limit">API type: uint32_t Max number of results</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_volume Desc Sorted volume vector</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketVolume[]> GetTopMarkets(uint limit, CancellationToken token)
        {
            return CustomGetRequest<MarketVolume[]>(KnownApiNames.DatabaseApi, "get_top_markets", new object[] { limit }, token);
        }

        /// <summary>
        /// API name: get_trade_history
        /// Returns recent trades for the market assetA:assetB, ordered by time, most recent first. The range is [stop, start)
        /// Note: Currently, timezone offsets are not supported. The time must be UTC.
        ///
        /// 
        /// </summary>
        /// <param name="base">API type: string</param>
        /// <param name="quote">API type: string</param>
        /// <param name="start">API type: fc::time_point_sec Start time as a UNIX timestamp, the latest trade to retrieve</param>
        /// <param name="stop">API type: fc::time_point_sec Stop time as a UNIX timestamp, the earliest trade to retrieve</param>
        /// <param name="limit">API type: unsigned Number of trasactions to retrieve, capped at 100</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_trade Recent transactions in the market</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketTrade[]> GetTradeHistory(string @base, string quote, TimePointSec start, TimePointSec stop, uint limit, CancellationToken token)
        {
            return CustomGetRequest<MarketTrade[]>(KnownApiNames.DatabaseApi, "get_trade_history", new object[] { @base, quote, start, stop, limit }, token);
        }

        /// <summary>
        /// API name: get_trade_history_by_sequence
        /// Returns trades for the market assetA:assetB, ordered by time, most recent first. The range is [stop, start)
        /// Note: Currently, timezone offsets are not supported. The time must be UTC.
        ///
        /// 
        /// </summary>
        /// <param name="base">API type: string</param>
        /// <param name="quote">API type: string</param>
        /// <param name="start">API type: int64_t Start sequence as an Integer, the latest trade to retrieve</param>
        /// <param name="stop">API type: fc::time_point_sec Stop time as a UNIX timestamp, the earliest trade to retrieve</param>
        /// <param name="limit">API type: unsigned Number of trasactions to retrieve, capped at 100</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: market_trade Transactions in the market</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MarketTrade[]> GetTradeHistoryBySequence(string @base, string quote, long start, TimePointSec stop, uint limit, CancellationToken token)
        {
            return CustomGetRequest<MarketTrade[]>(KnownApiNames.DatabaseApi, "get_trade_history_by_sequence", new object[] { @base, quote, start, stop, limit }, token);
        }

        ///////////////
        // Witnesses //
        ///////////////

        /// <summary>
        /// API name: get_witnesses
        /// Get a list of witnesses by ID
        ///
        /// 
        /// </summary>
        /// <param name="witnessIds">API type: vector&lt;witness_id_type> IDs of the witnesses to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_object The witnesses corresponding to the provided IDs
        /// 
        /// This function has semantics identical to @ref get_objects</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessObject[]> GetWitnesses(object[] witnessIds, CancellationToken token)
        {
            return CustomGetRequest<WitnessObject[]>(KnownApiNames.DatabaseApi, "get_witnesses", new object[] { witnessIds }, token);
        }

        /// <summary>
        /// API name: get_witness_by_account
        /// Get the witness owned by a given account
        ///
        /// 
        /// </summary>
        /// <param name="account">API type: account_id_type The ID of the account whose witness should be retrieved</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_object The witness object, or null if the account does not have a witness</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WitnessObject> GetWitnessByAccount(AccountIdType account, CancellationToken token)
        {
            return CustomGetRequest<WitnessObject>(KnownApiNames.DatabaseApi, "get_witness_by_account", new object[] { account }, token);
        }

        /// <summary>
        /// API name: lookup_witness_accounts
        /// Get names and IDs for registered witnesses
        ///
        /// 
        /// </summary>
        /// <param name="lowerBoundName">API type: string Lower bound of the first name to return</param>
        /// <param name="limit">API type: uint32_t Maximum number of results to return -- must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: map&lt;string,witness_id_type> Map of witness names to corresponding IDs</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object> LookupWitnessAccounts(string lowerBoundName, uint limit, CancellationToken token)
        {
            return CustomGetRequest<object>(KnownApiNames.DatabaseApi, "lookup_witness_accounts", new object[] { lowerBoundName, limit }, token);
        }

        /// <summary>
        /// API name: get_witness_count
        /// Get the total number of witnesses registered with the blockchain
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: uint64_t</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ulong> GetWitnessCount(CancellationToken token)
        {
            return CustomGetRequest<ulong>(KnownApiNames.DatabaseApi, "get_witness_count", token);
        }

        ///////////////////////
        // Committee members //
        ///////////////////////

        /// <summary>
        /// API name: get_committee_members
        /// Get a list of committee_members by ID
        ///
        /// 
        /// </summary>
        /// <param name="committeeMemberIds">API type: vector&lt;committee_member_id_type> IDs of the committee_members to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: committee_member_object The committee_members corresponding to the provided IDs
        /// 
        /// This function has semantics identical to @ref get_objects</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CommitteeMemberObject[]> GetCommitteeMembers(object[] committeeMemberIds, CancellationToken token)
        {
            return CustomGetRequest<CommitteeMemberObject[]>(KnownApiNames.DatabaseApi, "get_committee_members", new object[] { committeeMemberIds }, token);
        }

        /// <summary>
        /// API name: get_committee_member_by_account
        /// Get the committee_member owned by a given account
        ///
        /// 
        /// </summary>
        /// <param name="account">API type: account_id_type The ID of the account whose committee_member should be retrieved</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: committee_member_object The committee_member object, or null if the account does not have a committee_member</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<CommitteeMemberObject> GetCommitteeMemberByAccount(AccountIdType account, CancellationToken token)
        {
            return CustomGetRequest<CommitteeMemberObject>(KnownApiNames.DatabaseApi, "get_committee_member_by_account", new object[] { account }, token);
        }

        /// <summary>
        /// API name: lookup_committee_member_accounts
        /// Get names and IDs for registered committee_members
        ///
        /// 
        /// </summary>
        /// <param name="lowerBoundName">API type: string Lower bound of the first name to return</param>
        /// <param name="limit">API type: uint32_t Maximum number of results to return -- must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: map&lt;string,committee_member_id_type> Map of committee_member names to corresponding IDs</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object> LookupCommitteeMemberAccounts(string lowerBoundName, uint limit, CancellationToken token)
        {
            return CustomGetRequest<object>(KnownApiNames.DatabaseApi, "lookup_committee_member_accounts", new object[] { lowerBoundName, limit }, token);
        }

        /// <summary>
        /// API name: get_committee_count
        /// Get the total number of committee registered with the blockchain
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: uint64_t</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ulong> GetCommitteeCount(CancellationToken token)
        {
            return CustomGetRequest<ulong>(KnownApiNames.DatabaseApi, "get_committee_count", token);
        }

        ///////////////////////
        // Worker proposals  //
        ///////////////////////

        /// <summary>
        /// API name: get_all_workers
        /// Get all workers
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: worker_object All the workers</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WorkerObject[]> GetAllWorkers(CancellationToken token)
        {
            return CustomGetRequest<WorkerObject[]>(KnownApiNames.DatabaseApi, "get_all_workers", token);
        }

        /// <summary>
        /// API name: get_workers_by_account
        /// Get the workers owned by a given account
        ///
        /// 
        /// </summary>
        /// <param name="account">API type: account_id_type The ID of the account whose worker should be retrieved</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: worker_object The worker object, or null if the account does not have a worker</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WorkerObject[]> GetWorkersByAccount(AccountIdType account, CancellationToken token)
        {
            return CustomGetRequest<WorkerObject[]>(KnownApiNames.DatabaseApi, "get_workers_by_account", new object[] { account }, token);
        }

        /// <summary>
        /// API name: get_worker_count
        /// Get the total number of workers registered with the blockchain
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: uint64_t</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ulong> GetWorkerCount(CancellationToken token)
        {
            return CustomGetRequest<ulong>(KnownApiNames.DatabaseApi, "get_worker_count", token);
        }

        ///////////
        // Votes //
        ///////////

        /// <summary>
        /// API name: lookup_vote_ids
        /// Given a set of votes, return the objects they are voting for.
        /// 
        /// This will be a mixture of committee_member_object, witness_objects, and worker_objects
        /// 
        /// The results will be in the same order as the votes.  Null will be returned for
        /// any vote ids that are not found.
        ///
        /// 
        /// </summary>
        /// <param name="votes">API type: vector&lt;vote_id_type></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: variant</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object[]> LookupVoteIds(object[] votes, CancellationToken token)
        {
            return CustomGetRequest<object[]>(KnownApiNames.DatabaseApi, "lookup_vote_ids", new object[] { votes }, token);
        }


        ////////////////////////////
        // Authority / validation //
        ////////////////////////////

        /// @brief Get a hexdump of the serialized binary form of a transaction

        /// <summary>
        /// API name: get_transaction_hex
        /// Get a hexdump of the serialized binary form of a transaction
        ///
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: string</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string> GetTransactionHex(SignedTransaction trx, CancellationToken token)
        {
            return CustomGetRequest<string>(KnownApiNames.DatabaseApi, "get_transaction_hex", new object[] { trx }, token);
        }


        /**
         *  This API will take a partially signed transaction and a set of public keys that the owner has the ability to sign for
         *  and return the minimal subset of public keys that should add signatures to the transaction.
         */

        /// <summary>
        /// API name: get_required_signatures
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="availableKeys">API type: flat_set&lt;public_key_type></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: public_key_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<PublicKeyType[]> GetRequiredSignatures(SignedTransaction trx, PublicKeyType[] availableKeys, CancellationToken token)
        {
            return CustomGetRequest<PublicKeyType[]>(KnownApiNames.DatabaseApi, "get_required_signatures", new object[] { trx, availableKeys }, token);
        }


        /**
         *  This method will return the set of all public keys that could possibly sign for a given transaction.  This call can
         *  be used by wallets to filter their set of public keys to just the relevant subset prior to calling @ref get_required_signatures
         *  to get the minimum subset.
         */

        /// <summary>
        /// API name: get_potential_signatures
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: public_key_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<PublicKeyType[]> GetPotentialSignatures(SignedTransaction trx, CancellationToken token)
        {
            return CustomGetRequest<PublicKeyType[]>(KnownApiNames.DatabaseApi, "get_potential_signatures", new object[] { trx }, token);
        }

        /// <summary>
        /// API name: get_potential_address_signatures
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: address</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object[]> GetPotentialAddressSignatures(SignedTransaction trx, CancellationToken token)
        {
            return CustomGetRequest<object[]>(KnownApiNames.DatabaseApi, "get_potential_address_signatures", new object[] { trx }, token);
        }

        /// <summary>
        /// API name: verify_authority
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bool true of the @ref trx has all of the required signatures, otherwise throws an exception</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<bool> VerifyAuthority(SignedTransaction trx, CancellationToken token)
        {
            return CustomGetRequest<bool>(KnownApiNames.DatabaseApi, "verify_authority", new object[] { trx }, token);
        }

        /// <summary>
        /// API name: verify_account_authority
        /// 
        /// </summary>
        /// <param name="nameOrId">API type: string</param>
        /// <param name="signers">API type: flat_set&lt;public_key_type></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bool true if the signers have enough authority to authorize an account</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<bool> VerifyAccountAuthority(string nameOrId, PublicKeyType[] signers, CancellationToken token)
        {
            return CustomGetRequest<bool>(KnownApiNames.DatabaseApi, "verify_account_authority", new object[] { nameOrId, signers }, token);
        }


        /**
         *  Validates a transaction against the current state without broadcasting it on the network.
         */

        /// <summary>
        /// API name: validate_transaction
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: processed_transaction</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ProcessedTransaction> ValidateTransaction(SignedTransaction trx, CancellationToken token)
        {
            return CustomGetRequest<ProcessedTransaction>(KnownApiNames.DatabaseApi, "validate_transaction", new object[] { trx }, token);
        }


        /**
         *  For each operation calculate the required fee in the specified asset type.  If the asset type does
         *  not have a valid core_exchange_rate
         */

        /// <summary>
        /// API name: get_required_fees
        /// 
        /// </summary>
        /// <param name="ops">API type: vector&lt;operation></param>
        /// <param name="id">API type: asset_id_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: variant</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object[]> GetRequiredFees(BaseOperation[] ops, AssetIdType id, CancellationToken token)
        {
            return CustomGetRequest<object[]>(KnownApiNames.DatabaseApi, "get_required_fees", new object[] { new[] { ops }, id }, token);
        }

        ///////////////////////////
        // Proposed transactions //
        ///////////////////////////

        /// <summary>
        /// API name: get_proposed_transactions
        /// 
        /// </summary>
        /// <param name="id">API type: account_id_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: proposal_object the set of proposed transactions relevant to the specified account id.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ProposalObject[]> GetProposedTransactions(AccountIdType id, CancellationToken token)
        {
            return CustomGetRequest<ProposalObject[]>(KnownApiNames.DatabaseApi, "get_proposed_transactions", new object[] { id }, token);
        }

        //////////////////////
        // Blinded balances //
        //////////////////////

        /// <summary>
        /// API name: get_blinded_balances
        /// 
        /// </summary>
        /// <param name="commitments">API type: flat_set&lt;commitment_type></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: blinded_balance_object the set of blinded balance objects by commitment ID</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<BlindedBalanceObject[]> GetBlindedBalances(object commitments, CancellationToken token)
        {
            return CustomGetRequest<BlindedBalanceObject[]>(KnownApiNames.DatabaseApi, "get_blinded_balances", new[] { commitments }, token);
        }

        /////////////////
        // Withdrawals //
        /////////////////

        /// <summary>
        /// API name: get_withdraw_permissions_by_giver
        /// Get non expired withdraw permission objects for a giver(ex:recurring customer)
        ///
        /// 
        /// </summary>
        /// <param name="account">API type: account_id_type Account to get objects from</param>
        /// <param name="start">API type: withdraw_permission_id_type Withdraw permission objects(1.12.X) before this ID will be skipped in results. Pagination purposes.</param>
        /// <param name="limit">API type: uint32_t Maximum number of objects to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: withdraw_permission_object Withdraw permission objects for the account</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WithdrawPermissionObject[]> GetWithdrawPermissionsByGiver(AccountIdType account, object start, uint limit, CancellationToken token)
        {
            return CustomGetRequest<WithdrawPermissionObject[]>(KnownApiNames.DatabaseApi, "get_withdraw_permissions_by_giver", new[] { account, start, limit }, token);
        }

        /// <summary>
        /// API name: get_withdraw_permissions_by_recipient
        /// Get non expired withdraw permission objects for a recipient(ex:service provider)
        ///
        /// 
        /// </summary>
        /// <param name="account">API type: account_id_type Account to get objects from</param>
        /// <param name="start">API type: withdraw_permission_id_type Withdraw permission objects(1.12.X) before this ID will be skipped in results. Pagination purposes.</param>
        /// <param name="limit">API type: uint32_t Maximum number of objects to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: withdraw_permission_object Withdraw permission objects for the account</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WithdrawPermissionObject[]> GetWithdrawPermissionsByRecipient(AccountIdType account, object start, uint limit, CancellationToken token)
        {
            return CustomGetRequest<WithdrawPermissionObject[]>(KnownApiNames.DatabaseApi, "get_withdraw_permissions_by_recipient", new[] { account, start, limit }, token);
        }
    }
}
