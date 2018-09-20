//using System;
//using System.Collections.Generic;
//using System.Threading;
//using Ditch.BitShares.Models;
//using Ditch.BitShares.Models.Operations;
//using Ditch.BitShares.Operations;
//using Ditch.Core.JsonRpc;
//using Ditch.Core.Models;

//namespace Ditch.BitShares
//{
//    /**
//     * This wallet assumes it is connected to the database server with a high-bandwidth, low-latency connection and
//     * performs minimal caching. This API could be provided locally to be used by a web interface.
//     */

//    /// <summary>
//    /// wallet_api
//    /// libraries\wallet\include\graphene\wallet\wallet.hpp
//    /// </summary>
//    public partial class OperationManager
//    {

//        /// <summary>
//        /// API name: info
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: variant</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object> Info(CancellationToken token)
//        {
//            return CustomGetRequestAsync<object>(KnownApiNames.WalletApi, "info", token);
//        }

//        /** Returns info such as client version, git version of graphene/fc, version of boost, openssl.
//         * @returns compile time info and client and dependencies versions
//         */

//        /// <summary>
//        /// API name: about
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: variant_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object> About(CancellationToken token)
//        {
//            return CustomGetRequestAsync<object>(KnownApiNames.WalletApi, "about", token);
//        }

//        ///// <summary>
//        ///// API name: get_block
//        ///// 
//        ///// </summary>
//        ///// <param name="num">API type: uint32_t</param>
//        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        ///// <returns>API type: signed_block_with_info</returns>
//        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        //public JsonRpcResponse<SignedBlockWithInfo>> GetBlock(UInt32 num, CancellationToken token)
//        //{
//        //    return CustomGetRequestAsync<SignedBlockWithInfo>(KnownApiNames.WalletApi, "get_block", new object[] { num, }, token);
//        //}

//        /** Returns the number of accounts registered on the blockchain
//         * @returns the number of registered accounts
//         */

//        ///// <summary>
//        ///// API name: get_account_count
//        ///// 
//        ///// </summary>
//        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        ///// <returns>API type: uint64_t</returns>
//        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        //public JsonRpcResponse<UInt64>> GetAccountCount(CancellationToken token)
//        //{
//        //    return CustomGetRequestAsync<UInt64>(KnownApiNames.WalletApi, "get_account_count", token);
//        //}

//        /** Lists all accounts controlled by this wallet.
//         * This returns a list of the full account objects for all accounts whose private keys 
//         * we possess.
//         * @returns a list of account objects
//         */

//        /// <summary>
//        /// API name: list_my_accounts
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: account_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AccountObject[]> ListMyAccounts(CancellationToken token)
//        {
//            return CustomGetRequestAsync<AccountObject[]>(KnownApiNames.WalletApi, "list_my_accounts", token);
//        }

//        /// <summary>
//        /// API name: list_accounts
//        /// 
//        /// </summary>
//        /// <param name="lowerbound">API type: string the name of the first account to return.  If the named account does not exist, 
//        /// the list will start at the account that comes after \c lowerbound</param>
//        /// <param name="limit">API type: uint32_t the maximum number of accounts to return (max: 1000)
//        /// @returns a list of accounts mapping account names to account ids</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: map&lt;string,account_id_type></returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<MapContainer<string, AccountIdType>> ListAccounts(string lowerbound, UInt32 limit, CancellationToken token)
//        {
//            return CustomGetRequestAsync<MapContainer<string, AccountIdType>>(KnownApiNames.WalletApi, "list_accounts", new object[] { lowerbound, limit, }, token);
//        }

//        /// <summary>
//        /// API name: list_account_balances
//        /// 
//        /// </summary>
//        /// <param name="id">API type: string the name or id of the account whose balances you want
//        /// @returns a list of the given account's balances</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: asset</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object[]> ListAccountBalances(string id, CancellationToken token)
//        {
//            return CustomGetRequestAsync<object[]>(KnownApiNames.WalletApi, "list_account_balances", new object[] { id, }, token);
//        }

//        ///// <summary>
//        ///// API name: list_assets
//        ///// 
//        ///// </summary>
//        ///// <param name="lowerbound">API type: string  the symbol of the first asset to include in the list.</param>
//        ///// <param name="limit">API type: uint32_t the maximum number of assets to return (max: 100)
//        ///// @returns the list of asset objects, ordered by symbol</param>
//        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        ///// <returns>API type: asset_object</returns>
//        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        //public JsonRpcResponse<AssetObject[]> ListAssets(string lowerbound, UInt32 limit, CancellationToken token)
//        //{
//        //    return CustomGetRequestAsync<AssetObject[]>(KnownApiNames.WalletApi, "list_assets", new object[] { lowerbound, limit, }, token);
//        //}

//        /// <summary>
//        /// API name: get_account_history
//        /// 
//        /// </summary>
//        /// <param name="name">API type: string the name or id of the account</param>
//        /// <param name="limit">API type: int the number of entries to return (starting from the most recent)
//        /// @returns a list of \c operation_history_objects</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: operation_detail</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<OperationDetail[]>> GetAccountHistory(string name, int limit, CancellationToken token)
//        {
//            return CustomGetRequestAsync<OperationDetail[]>(KnownApiNames.WalletApi, "get_account_history", new object[] { name, limit, }, token);
//        }

//        /// <summary>
//        /// API name: get_relative_account_history
//        /// 
//        /// </summary>
//        /// <param name="name">API type: string the name or id of the account</param>
//        /// <param name="stop">API type: uint32_t Sequence number of earliest operation.</param>
//        /// <param name="limit">API type: int the number of entries to return</param>
//        /// <param name="start">API type: uint32_t  the sequence number where to start looping back throw the history
//        /// @returns a list of \c operation_history_objects</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: operation_detail</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<OperationDetail[]>> GetRelativeAccountHistory(string name, UInt32 stop, int limit, UInt32 start, CancellationToken token)
//        {
//            return CustomGetRequestAsync<OperationDetail[]>(KnownApiNames.WalletApi, "get_relative_account_history", new object[] { name, stop, limit, start, }, token);
//        }

//        /// <summary>
//        /// API name: get_market_history
//        /// 
//        /// </summary>
//        /// <param name="symbol">API type: string</param>
//        /// <param name="symbol2">API type: string</param>
//        /// <param name="bucket">API type: uint32_t</param>
//        /// <param name="start">API type: fc::time_point_sec</param>
//        /// <param name="end">API type: fc::time_point_sec</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: bucket_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<BucketObject[]>> GetMarketHistory(string symbol, string symbol2, UInt32 bucket, TimePointSec start, TimePointSec end, CancellationToken token)
//        {
//            return CustomGetRequestAsync<BucketObject[]>(KnownApiNames.WalletApi, "get_market_history", new object[] { symbol, symbol2, bucket, start, end, }, token);
//        }

//        /// <summary>
//        /// API name: get_limit_orders
//        /// 
//        /// </summary>
//        /// <param name="a">API type: string</param>
//        /// <param name="b">API type: string</param>
//        /// <param name="limit">API type: uint32_t</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: limit_order_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<LimitOrderObject[]>> GetLimitOrders(string a, string b, UInt32 limit, CancellationToken token)
//        {
//            return CustomGetRequestAsync<LimitOrderObject[]>(KnownApiNames.WalletApi, "get_limit_orders", new object[] { a, b, limit, }, token);
//        }

//        /// <summary>
//        /// API name: get_call_orders
//        /// 
//        /// </summary>
//        /// <param name="a">API type: string</param>
//        /// <param name="limit">API type: uint32_t</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: call_order_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<CallOrderObject[]>> GetCallOrders(string a, UInt32 limit, CancellationToken token)
//        {
//            return CustomGetRequestAsync<CallOrderObject[]>(KnownApiNames.WalletApi, "get_call_orders", new object[] { a, limit, }, token);
//        }

//        /// <summary>
//        /// API name: get_settle_orders
//        /// 
//        /// </summary>
//        /// <param name="a">API type: string</param>
//        /// <param name="limit">API type: uint32_t</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: force_settlement_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<ForceSettlementObject[]>> GetSettleOrders(string a, UInt32 limit, CancellationToken token)
//        {
//            return CustomGetRequestAsync<ForceSettlementObject[]>(KnownApiNames.WalletApi, "get_settle_orders", new object[] { a, limit, }, token);
//        }

//        /// <summary>
//        /// API name: get_collateral_bids
//        /// 
//        /// </summary>
//        /// <param name="asset">API type: string the name or id of the asset</param>
//        /// <param name="limit">API type: uint32_t the number of entries to return</param>
//        /// <param name="start">API type: uint32_t the sequence number where to start looping back throw the history
//        /// @returns a list of \c collateral_bid_objects</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: collateral_bid_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<CollateralBidObject[]>> GetCollateralBids(string asset, UInt32 limit, UInt32 start, CancellationToken token)
//        {
//            return CustomGetRequestAsync<CollateralBidObject[]>(KnownApiNames.WalletApi, "get_collateral_bids", new object[] { asset, limit, start, }, token);
//        }


//        /** Returns the block chain's slowly-changing settings.
//         * This object contains all of the properties of the blockchain that are fixed
//         * or that change only once per maintenance interval (daily) such as the
//         * current list of witnesses, committee_members, block interval, etc.
//         * @see \c get_dynamic_global_properties() for frequently changing properties
//         * @returns the global properties
//         */

//        ///// <summary>
//        ///// API name: get_global_properties
//        ///// 
//        ///// </summary>
//        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        ///// <returns>API type: global_property_object</returns>
//        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        //public JsonRpcResponse<GlobalPropertyObject>> GetGlobalProperties(CancellationToken token)
//        //{
//        //    return CustomGetRequestAsync<GlobalPropertyObject>(KnownApiNames.WalletApi, "get_global_properties", token);
//        //}

//        /// <summary>
//        /// API name: get_account_history_by_operations
//        /// 
//        /// </summary>
//        /// <param name="name">API type: string the name or id of the account, whose history shoulde be queried</param>
//        /// <param name="operationTypes">API type: vector&lt;uint16_t> The IDs of the operation we want to get operations in the account( 0 = transfer , 1 = limit order create, ...)</param>
//        /// <param name="start">API type: uint32_t the sequence number where to start looping back throw the history</param>
//        /// <param name="limit">API type: int the max number of entries to return (from start number)
//        /// @returns account_history_operation_detail</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: account_history_operation_detail</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AccountHistoryOperationDetail>> GetAccountHistoryByOperations(string name, UInt16[] operationTypes, UInt32 start, int limit, CancellationToken token)
//        {
//            return CustomGetRequestAsync<AccountHistoryOperationDetail>(KnownApiNames.WalletApi, "get_account_history_by_operations", new object[] { name, operationTypes, start, limit, }, token);
//        }


//        /** Returns the block chain's rapidly-changing properties.
//         * The returned object contains information that changes every block interval
//         * such as the head block number, the next witness, etc.
//         * @see \c get_global_properties() for less-frequently changing properties
//         * @returns the dynamic global properties
//         */

//        ///// <summary>
//        ///// API name: get_dynamic_global_properties
//        ///// 
//        ///// </summary>
//        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        ///// <returns>API type: dynamic_global_property_object</returns>
//        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        //public JsonRpcResponse<DynamicGlobalPropertyObject>> GetDynamicGlobalProperties(CancellationToken token)
//        //{
//        //    return CustomGetRequestAsync<DynamicGlobalPropertyObject>(KnownApiNames.WalletApi, "get_dynamic_global_properties", token);
//        //}

//        /// <summary>
//        /// API name: get_account
//        /// 
//        /// </summary>
//        /// <param name="accountNameOrId">API type: string the name or id of the account to provide information about
//        /// @returns the public account data stored in the blockchain</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: account_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AccountObject>> GetAccount(string accountNameOrId, CancellationToken token)
//        {
//            return CustomGetRequestAsync<AccountObject>(KnownApiNames.WalletApi, "get_account", new object[] { accountNameOrId, }, token);
//        }

//        /// <summary>
//        /// API name: get_asset
//        /// 
//        /// </summary>
//        /// <param name="assetNameOrId">API type: string the symbol or id of the asset in question
//        /// @returns the information about the asset stored in the block chain</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: asset_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AssetObject>> GetAsset(string assetNameOrId, CancellationToken token)
//        {
//            return CustomGetRequestAsync<AssetObject>(KnownApiNames.WalletApi, "get_asset", new object[] { assetNameOrId, }, token);
//        }

//        /// <summary>
//        /// API name: get_bitasset_data
//        /// 
//        /// </summary>
//        /// <param name="assetNameOrId">API type: string the symbol or id of the BitAsset in question
//        /// @returns the BitAsset-specific data for this asset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: asset_bitasset_data_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AssetBitassetDataObject>> GetBitassetData(string assetNameOrId, CancellationToken token)
//        {
//            return CustomGetRequestAsync<AssetBitassetDataObject>(KnownApiNames.WalletApi, "get_bitasset_data", new object[] { assetNameOrId, }, token);
//        }

//        /// <summary>
//        /// API name: get_account_id
//        /// 
//        /// </summary>
//        /// <param name="accountNameOrId">API type: string the name of the account to look up
//        /// @returns the id of the named account</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: account_id_type</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<AccountIdType>> GetAccountId(string accountNameOrId, CancellationToken token)
//        {
//            return CustomGetRequestAsync<object>(KnownApiNames.WalletApi, "get_account_id", new object[] { accountNameOrId, }, token);
//        }

//        /// <summary>
//        /// API name: get_object
//        /// 
//        /// </summary>
//        /// <param name="id">API type: object_id_type the id of the object to return
//        /// @returns the requested object</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: variant</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object>> GetObject(object id, CancellationToken token)
//        {
//            return CustomGetRequestAsync<object>(KnownApiNames.WalletApi, "get_object", new object[] { id, }, token);
//        }


//        /**
//         * Get the WIF private key corresponding to a public key.  The
//         * private key must already be in the wallet.
//         */

//        /// <summary>
//        /// API name: get_private_key
//        /// 
//        /// </summary>
//        /// <param name="pubkey">API type: public_key_type</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: string</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string>> GetPrivateKey(PublicKeyType pubkey, CancellationToken token)
//        {
//            return CustomGetRequestAsync<string>(KnownApiNames.WalletApi, "get_private_key", new object[] { pubkey, }, token);
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
//            return CustomGetRequestAsync<UInt16>(KnownApiNames.WalletApi, "begin_builder_transaction", token);
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
//        public JsonRpcResponse AddOperationToBuilderTransaction(UInt16 transactionHandle, BaseOperation op, CancellationToken token)
//        {
//            return CustomGetRequest(KnownApiNames.WalletApi, "add_operation_to_builder_transaction", new object[] { transactionHandle, op, }, token);
//        }

//        /**
//         * @ingroup Transaction Builder API
//         */

//        /// <summary>
//        /// API name: replace_operation_in_builder_transaction
//        /// 
//        /// </summary>
//        /// <param name="handle">API type: transaction_handle_type</param>
//        /// <param name="operationIndex">API type: unsigned</param>
//        /// <param name="newOp">API type: operation</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse ReplaceOperationInBuilderTransaction(UInt16 handle, UInt32 operationIndex, BaseOperation newOp, CancellationToken token)
//        {
//            return CustomGetRequest(KnownApiNames.WalletApi, "replace_operation_in_builder_transaction", new object[] { handle, operationIndex, newOp, }, token);
//        }

//        /// <summary>
//        /// API name: 
//        /// Parsing error: { preParsedElement.CppText}
//        /// </summary>
//        /// <param name="feeAsset"></param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <param name="handle"></param>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object> set_fees_on_builder_transaction(UInt16 handle, string feeAsset, CancellationToken token)
//        {
//            return CustomGetRequestAsync<object>(KnownApiNames.WalletApi, "set_fees_on_builder_transaction", new object[] { handle, feeAsset }, token);
//        }



//        /**
//        * @ingroup Transaction Builder API
//        */

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
//            return CustomGetRequestAsync<Transaction>(KnownApiNames.WalletApi, "preview_builder_transaction", new object[] { handle, }, token);
//        }

//        /**
//        * @ingroup Transaction Builder API
//        */

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
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "sign_builder_transaction", new object[] { transactionHandle, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: broadcast_transaction
//        /// 
//        /// </summary>
//        /// <param name="tx">API type: signed_transaction signed transaction
//        /// @returns the transaction ID along with the signed transaction.</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<KeyValuePair<string, SignedTransaction>> BroadcastTransaction(SignedTransaction tx, CancellationToken token)
//        {
//            return CustomGetRequestAsync<KeyValuePair<string, SignedTransaction>>(KnownApiNames.WalletApi, "broadcast_transaction", new object[] { tx, }, token);
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
//            return CustomGetRequest(KnownApiNames.WalletApi, "remove_builder_transaction", new object[] { handle, }, token);
//        }

//        /// <summary>
//        /// API name: is_new
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: bool true if the wallet is new
//        /// @ingroup Wallet Management</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<bool> IsNew(CancellationToken token)
//        {
//            return CustomGetRequestAsync<bool>(KnownApiNames.WalletApi, "is_new", token);
//        }

//        /// <summary>
//        /// API name: is_locked
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: bool true if the wallet is locked
//        /// @ingroup Wallet Management</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<bool> IsLocked(CancellationToken token)
//        {
//            return CustomGetRequestAsync<bool>(KnownApiNames.WalletApi, "is_locked", token);
//        }


//        /** Locks the wallet immediately.
//         * @ingroup Wallet Management
//         */

//        /// <summary>
//        /// API name: lock
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse Lock(CancellationToken token)
//        {
//            return CustomGetRequest(KnownApiNames.WalletApi, "lock", token);
//        }

//        /// <summary>
//        /// API name: unlock
//        /// 
//        /// </summary>
//        /// <param name="password">API type: string the password previously set with \c set_password()
//        /// @ingroup Wallet Management</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse Unlock(string password, CancellationToken token)
//        {
//            return CustomGetRequest(KnownApiNames.WalletApi, "unlock", new object[] { password, }, token);
//        }


//        /** Sets a new password on the wallet.
//         *
//         * The wallet must be either 'new' or 'unlocked' to
//         * execute this command.
//         * @ingroup Wallet Management
//         */

//        /// <summary>
//        /// API name: set_password
//        /// 
//        /// </summary>
//        /// <param name="password">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse SetPassword(string password, CancellationToken token)
//        {
//            return CustomGetRequest(KnownApiNames.WalletApi, "set_password", new object[] { password, }, token);
//        }


//        /** Dumps all private keys owned by the wallet.
//         *
//         * The keys are printed in WIF format.  You can import these keys into another wallet
//         * using \c import_key()
//         * @returns a map containing the private keys, indexed by their public key 
//         */

//        /// <summary>
//        /// API name: dump_private_keys
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: map&lt;public_key_type,string></returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<MapContainer<PublicKeyType, string>> DumpPrivateKeys(CancellationToken token)
//        {
//            return CustomGetRequestAsync<MapContainer<PublicKeyType, string>>(KnownApiNames.WalletApi, "dump_private_keys", token);
//        }


//        /** Returns a list of all commands supported by the wallet API.
//         *
//         * This lists each command, along with its arguments and return types.
//         * For more detailed help on a single command, use \c get_help()
//         *
//         * @returns a multi-line string suitable for displaying on a terminal
//         */

//        /// <summary>
//        /// API name: help
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: string</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string> Help(CancellationToken token)
//        {
//            return CustomGetRequestAsync<string>(KnownApiNames.WalletApi, "help", token);
//        }

//        /// <summary>
//        /// API name: gethelp
//        /// 
//        /// </summary>
//        /// <param name="method">API type: string the name of the API command you want help with
//        /// @returns a multi-line string suitable for displaying on a terminal</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: string</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string>> Gethelp(string method, CancellationToken token)
//        {
//            return CustomGetRequestAsync<string>(KnownApiNames.WalletApi, "gethelp", new object[] { method, }, token);
//        }


//        /** Suggests a safe brain key to use for creating your account.
//         * \c create_account_with_brain_key() requires you to specify a 'brain key',
//         * a long passphrase that provides enough entropy to generate cyrptographic
//         * keys.  This function will suggest a suitably random string that should
//         * be easy to write down (and, with effort, memorize).
//         * @returns a suggested brain_key
//         */

//        /// <summary>
//        /// API name: suggest_brain_key
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: brain_key_info</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<BrainKeyInfo> SuggestBrainKey(CancellationToken token)
//        {
//            return CustomGetRequestAsync<BrainKeyInfo>(KnownApiNames.WalletApi, "suggest_brain_key", token);
//        }

//        /// <summary>
//        /// API name: derive_owner_keys_from_brain_key
//        /// 
//        /// </summary>
//        /// <param name="brainKey">API type: string    Brain key</param>
//        /// <param name="numberOfDesiredKeys">API type: int</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: brain_key_info A list of keys that are deterministically derived from the brainkey</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<BrainKeyInfo[]> DeriveOwnerKeysFromBrainKey(string brainKey, int numberOfDesiredKeys, CancellationToken token)
//        {
//            return CustomGetRequestAsync<BrainKeyInfo[]>(KnownApiNames.WalletApi, "derive_owner_keys_from_brain_key", new object[] { brainKey, numberOfDesiredKeys, }, token);
//        }

//        ///// <summary>
//        ///// API name: is_public_key_registered
//        ///// 
//        ///// </summary>
//        ///// <param name="publicKey">API type: string Public key</param>
//        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        ///// <returns>API type: bool Whether a public key is known</returns>
//        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        //public JsonRpcResponse<bool> IsPublicKeyRegistered(string publicKey, CancellationToken token)
//        //{
//        //    return CustomGetRequestAsync<bool>(KnownApiNames.WalletApi, "is_public_key_registered", new object[] { publicKey, }, token);
//        //}

//        /// <summary>
//        /// API name: serialize_transaction
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
//            return CustomGetRequestAsync<string>(KnownApiNames.WalletApi, "serialize_transaction", new object[] { tx, }, token);
//        }

//        /// <summary>
//        /// API name: import_key
//        /// 
//        /// </summary>
//        /// <param name="accountNameOrId">API type: string the account owning the key</param>
//        /// <param name="wifKey">API type: string the private key in WIF format
//        /// @returns true if the key was imported</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: bool</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<bool> ImportKey(string accountNameOrId, string wifKey, CancellationToken token)
//        {
//            return CustomGetRequestAsync<bool>(KnownApiNames.WalletApi, "import_key", new object[] { accountNameOrId, wifKey, }, token);
//        }

//        /// <summary>
//        /// API name: import_accounts
//        /// 
//        /// </summary>
//        /// <param name="filename">API type: string</param>
//        /// <param name="password">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: map&lt;string,bool></returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object> ImportAccounts(string filename, string password, CancellationToken token)
//        {
//            return CustomGetRequestAsync<object>(KnownApiNames.WalletApi, "import_accounts", new object[] { filename, password, }, token);
//        }

//        /// <summary>
//        /// API name: import_account_keys
//        /// 
//        /// </summary>
//        /// <param name="filename">API type: string</param>
//        /// <param name="password">API type: string</param>
//        /// <param name="srcAccountName">API type: string</param>
//        /// <param name="destAccountName">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: bool</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<bool> ImportAccountKeys(string filename, string password, string srcAccountName, string destAccountName, CancellationToken token)
//        {
//            return CustomGetRequestAsync<bool>(KnownApiNames.WalletApi, "import_account_keys", new object[] { filename, password, srcAccountName, destAccountName, }, token);
//        }


//        /**
//         * This call will construct transaction(s) that will claim all balances controled
//         * by wif_keys and deposit them into the given account.
//         */

//        /// <summary>
//        /// API name: import_balance
//        /// 
//        /// </summary>
//        /// <param name="accountNameOrId">API type: string</param>
//        /// <param name="wifKeys">API type: vector&lt;string></param>
//        /// <param name="broadcast">API type: bool</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction[]> ImportBalance(string accountNameOrId, string[] wifKeys, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction[]>(KnownApiNames.WalletApi, "import_balance", new object[] { accountNameOrId, wifKeys, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: normalize_brain_key
//        /// 
//        /// </summary>
//        /// <param name="s">API type: string the brain key as supplied by the user
//        /// @returns the brain key in its normalized form</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: string</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string> NormalizeBrainKey(string s, CancellationToken token)
//        {
//            return CustomGetRequestAsync<string>(KnownApiNames.WalletApi, "normalize_brain_key", new object[] { s, }, token);
//        }

//        /// <summary>
//        /// API name: register_account
//        /// 
//        /// </summary>
//        /// <param name="name">API type: string the name of the account, must be unique on the blockchain.  Shorter names
//        /// are more expensive to register; the rules are still in flux, but in general
//        /// names of more than 8 characters with at least one digit will be cheap.</param>
//        /// <param name="owner">API type: public_key_type the owner key for the new account</param>
//        /// <param name="active">API type: public_key_type the active key for the new account</param>
//        /// <param name="registrarAccount">API type: string the account which will pay the fee to register the user</param>
//        /// <param name="referrerAccount">API type: string the account who is acting as a referrer, and may receive a
//        /// portion of the user's transaction fees.  This can be the
//        /// same as the registrar_account if there is no referrer.</param>
//        /// <param name="referrerPercent">API type: uint32_t the percentage (0 - 100) of the new user's transaction fees
//        /// not claimed by the blockchain that will be distributed to the
//        /// referrer; the rest will be sent to the registrar.  Will be
//        /// multiplied by GRAPHENE_1_PERCENT when constructing the transaction.</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction registering the account</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> RegisterAccount(string name, PublicKeyType owner, PublicKeyType active, string registrarAccount, string referrerAccount, UInt32 referrerPercent, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "register_account", new object[] { name, owner, active, registrarAccount, referrerAccount, referrerPercent, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: upgrade_account
//        /// 
//        /// </summary>
//        /// <param name="name">API type: string the name or id of the account to upgrade</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction upgrading the account</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> UpgradeAccount(string name, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "upgrade_account", new object[] { name, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: create_account_with_brain_key
//        /// 
//        /// </summary>
//        /// <param name="brainKey">API type: string the brain key used for generating the account's private keys</param>
//        /// <param name="accountName">API type: string the name of the account, must be unique on the blockchain.  Shorter names
//        /// are more expensive to register; the rules are still in flux, but in general
//        /// names of more than 8 characters with at least one digit will be cheap.</param>
//        /// <param name="registrarAccount">API type: string the account which will pay the fee to register the user</param>
//        /// <param name="referrerAccount">API type: string the account who is acting as a referrer, and may receive a
//        /// portion of the user's transaction fees.  This can be the
//        /// same as the registrar_account if there is no referrer.</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction registering the account</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> CreateAccountWithBrainKey(string brainKey, string accountName, string registrarAccount, string referrerAccount, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "create_account_with_brain_key", new object[] { brainKey, accountName, registrarAccount, referrerAccount, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: transfer
//        /// 
//        /// </summary>
//        /// <param name="from">API type: string the name or id of the account sending the funds</param>
//        /// <param name="to">API type: string the name or id of the account receiving the funds</param>
//        /// <param name="amount">API type: string the amount to send (in nominal units -- to send half of a BTS, specify 0.5)</param>
//        /// <param name="assetSymbol">API type: string the symbol or id of the asset to send</param>
//        /// <param name="memo">API type: string a memo to attach to the transaction.  The memo will be encrypted in the 
//        /// transaction and readable for the receiver.  There is no length limit
//        /// other than the limit imposed by maximum transaction size, but transaction
//        /// increase with transaction size</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction transferring funds</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> Transfer(string from, string to, string amount, string assetSymbol, string memo, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "transfer", new object[] { from, to, amount, assetSymbol, memo, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: sign_memo
//        /// 
//        /// </summary>
//        /// <param name="from">API type: string the name or id of signing account; or a public key.</param>
//        /// <param name="to">API type: string the name or id of receiving account; or a public key.</param>
//        /// <param name="memo">API type: string text to sign.</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: memo_data</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<MemoData> SignMemo(string from, string to, string memo, CancellationToken token)
//        {
//            return CustomGetRequestAsync<MemoData>(KnownApiNames.WalletApi, "sign_memo", new object[] { from, to, memo, }, token);
//        }

//        /// <summary>
//        /// API name: read_memo
//        /// 
//        /// </summary>
//        /// <param name="memo">API type: memo_data JSON-enconded memo.
//        /// @returns string with decrypted message..</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: string</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<string> ReadMemo(MemoData memo, CancellationToken token)
//        {
//            return CustomGetRequestAsync<string>(KnownApiNames.WalletApi, "read_memo", new object[] { memo, }, token);
//        }

//        /**
//         *  Generates a new blind account for the given brain key and assigns it the given label.
//         */

//        /// <summary>
//        /// API name: create_blind_account
//        /// 
//        /// </summary>
//        /// <param name="label">API type: string</param>
//        /// <param name="brainKey">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: public_key_type</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<PublicKeyType> CreateBlindAccount(string label, string brainKey, CancellationToken token)
//        {
//            return CustomGetRequestAsync<PublicKeyType>(KnownApiNames.WalletApi, "create_blind_account", new object[] { label, brainKey, }, token);
//        }

//        /// <summary>
//        /// API name: get_blind_balances
//        /// 
//        /// </summary>
//        /// <param name="keyOrLabel">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: asset the total balance of all blinded commitments that can be claimed by the
//        /// given account key or label</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object[]>> GetBlindBalances(string keyOrLabel, CancellationToken token)
//        {
//            return CustomGetRequestAsync<object[]>(KnownApiNames.WalletApi, "get_blind_balances", new object[] { keyOrLabel, }, token);
//        }

//        /// <summary>
//        /// API name: get_blind_accounts
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: map&lt;string,public_key_type> all blind accounts */</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<MapContainer<string, PublicKeyType>>> GetBlindAccounts(CancellationToken token)
//        {
//            return CustomGetRequestAsync<MapContainer<string, PublicKeyType>>(KnownApiNames.WalletApi, "get_blind_accounts", token);
//        }

//        /// <summary>
//        /// API name: get_my_blind_accounts
//        /// 
//        /// </summary>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: map&lt;string,public_key_type> all blind accounts for which this wallet has the private key */</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<MapContainer<string, PublicKeyType>>> GetMyBlindAccounts(CancellationToken token)
//        {
//            return CustomGetRequestAsync<MapContainer<string, PublicKeyType>>(KnownApiNames.WalletApi, "get_my_blind_accounts", token);
//        }

//        /// <summary>
//        /// API name: get_public_key
//        /// 
//        /// </summary>
//        /// <param name="label">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: public_key_type the public key associated with the given label */</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<PublicKeyType>> GetPublicKey(string label, CancellationToken token)
//        {
//            return CustomGetRequestAsync<PublicKeyType>(KnownApiNames.WalletApi, "get_public_key", new object[] { label, }, token);
//        }


//        /// <summary>
//        /// API name: blind_history
//        /// 
//        /// </summary>
//        /// <param name="keyOrAccount">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: blind_receipt all blind receipts to/form a particular account</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<BlindReceipt[]> BlindHistory(string keyOrAccount, CancellationToken token)
//        {
//            return CustomGetRequestAsync<BlindReceipt[]>(KnownApiNames.WalletApi, "blind_history", new object[] { keyOrAccount, }, token);
//        }

//        /// <summary>
//        /// API name: receive_blind_transfer
//        /// 
//        /// </summary>
//        /// <param name="confirmationReceipt">API type: string - a base58 encoded stealth confirmation </param>
//        /// <param name="optFrom">API type: string - if not empty and the sender is a unknown public key, then the unknown public key will be given the label opt_from</param>
//        /// <param name="optMemo">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: blind_receipt</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<BlindReceipt> ReceiveBlindTransfer(string confirmationReceipt, string optFrom, string optMemo, CancellationToken token)
//        {
//            return CustomGetRequestAsync<BlindReceipt>(KnownApiNames.WalletApi, "receive_blind_transfer", new object[] { confirmationReceipt, optFrom, optMemo, }, token);
//        }


//        /**
//         *  Used to transfer from one set of blinded balances to another
//         */

//        /// <summary>
//        /// API name: blind_transfer
//        /// 
//        /// </summary>
//        /// <param name="fromKeyOrLabel">API type: string</param>
//        /// <param name="toKeyOrLabel">API type: string</param>
//        /// <param name="amount">API type: string</param>
//        /// <param name="symbol">API type: string</param>
//        /// <param name="broadcast">API type: bool</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: blind_confirmation</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<BlindConfirmation> BlindTransfer(string fromKeyOrLabel, string toKeyOrLabel, string amount, string symbol, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<BlindConfirmation>(KnownApiNames.WalletApi, "blind_transfer", new object[] { fromKeyOrLabel, toKeyOrLabel, amount, symbol, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: sell_asset
//        /// 
//        /// </summary>
//        /// <param name="sellerAccount">API type: string the account providing the asset being sold, and which will 
//        /// receive the proceeds of the sale.</param>
//        /// <param name="amountToSell">API type: string the amount of the asset being sold to sell (in nominal units)</param>
//        /// <param name="symbolToSell">API type: string the name or id of the asset to sell</param>
//        /// <param name="minToReceive">API type: string the minimum amount you are willing to receive in return for
//        /// selling the entire amount_to_sell</param>
//        /// <param name="symbolToReceive">API type: string the name or id of the asset you wish to receive</param>
//        /// <param name="timeoutSec">API type: uint32_t if the order does not fill immediately, this is the length of 
//        /// time the order will remain on the order books before it is 
//        /// cancelled and the un-spent funds are returned to the seller's 
//        /// account</param>
//        /// <param name="fillOrKill">API type: bool if true, the order will only be included in the blockchain
//        /// if it is filled immediately; if false, an open order will be
//        /// left on the books to fill any amount that cannot be filled
//        /// immediately.</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction selling the funds</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> SellAsset(string sellerAccount, string amountToSell, string symbolToSell, string minToReceive, string symbolToReceive, UInt32 timeoutSec, bool fillOrKill, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "sell_asset", new object[] { sellerAccount, amountToSell, symbolToSell, minToReceive, symbolToReceive, timeoutSec, fillOrKill, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: borrow_asset
//        /// 
//        /// </summary>
//        /// <param name="borrowerName">API type: string the name or id of the account associated with the transaction.</param>
//        /// <param name="amountToBorrow">API type: string the amount of the asset being borrowed.  Make this value
//        /// negative to pay back debt.</param>
//        /// <param name="assetSymbol">API type: string the symbol or id of the asset being borrowed.</param>
//        /// <param name="amountOfCollateral">API type: string the amount of the backing asset to add to your collateral
//        /// position.  Make this negative to claim back some of your collateral.
//        /// The backing asset is defined in the \c bitasset_options for the asset being borrowed.</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction borrowing the asset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> BorrowAsset(string borrowerName, string amountToBorrow, string assetSymbol, string amountOfCollateral, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "borrow_asset", new object[] { borrowerName, amountToBorrow, assetSymbol, amountOfCollateral, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: cancel_order
//        /// 
//        /// </summary>
//        /// <param name="orderId">API type: object_id_type the id of order to be cancelled</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction canceling the order</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> CancelOrder(object orderId, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "cancel_order", new object[] { orderId, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: create_asset
//        /// 
//        /// </summary>
//        /// <param name="issuer">API type: string the name or id of the account who will pay the fee and become the 
//        /// issuer of the new asset.  This can be updated later</param>
//        /// <param name="symbol">API type: string the ticker symbol of the new asset</param>
//        /// <param name="precision">API type: uint8_t the number of digits of precision to the right of the decimal point,
//        /// must be less than or equal to 12</param>
//        /// <param name="common">API type: asset_options asset options required for all new assets.
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
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "create_asset", new object[] { issuer, symbol, precision, common, bitassetOpts, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: issue_asset
//        /// 
//        /// </summary>
//        /// <param name="toAccount">API type: string the name or id of the account to receive the new shares</param>
//        /// <param name="amount">API type: string the amount to issue, in nominal units</param>
//        /// <param name="symbol">API type: string the ticker symbol of the asset to issue</param>
//        /// <param name="memo">API type: string a memo to include in the transaction, readable by the recipient</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction issuing the new shares</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> IssueAsset(string toAccount, string amount, string symbol, string memo, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "issue_asset", new object[] { toAccount, amount, symbol, memo, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: update_asset
//        /// 
//        /// </summary>
//        /// <param name="symbol">API type: string the name or id of the asset to update</param>
//        /// <param name="newIssuer">API type: optional&lt;string> if changing the asset's issuer, the name or id of the new issuer.
//        /// null if you wish to remain the issuer of the asset</param>
//        /// <param name="newOptions">API type: asset_options the new asset_options object, which will entirely replace the existing
//        /// options.</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction updating the asset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> UpdateAsset(string symbol, string newIssuer, AssetOptions newOptions, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "update_asset", new object[] { symbol, newIssuer, newOptions, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: update_bitasset
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
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "update_bitasset", new object[] { symbol, newOptions, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: update_asset_feed_producers
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
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "update_asset_feed_producers", new object[] { symbol, newFeedProducers, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: publish_asset_feed
//        /// 
//        /// </summary>
//        /// <param name="publishingAccount">API type: string the account publishing the price feed</param>
//        /// <param name="symbol">API type: string the name or id of the asset whose feed we're publishing</param>
//        /// <param name="feed">API type: price_feed the price_feed object containing the three prices making up the feed</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction updating the price feed for the given asset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> PublishAssetFeed(string publishingAccount, string symbol, PriceFeed feed, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "publish_asset_feed", new object[] { publishingAccount, symbol, feed, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: fund_asset_fee_pool
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
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "fund_asset_fee_pool", new object[] { from, symbol, amount, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: reserve_asset
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
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "reserve_asset", new object[] { from, amount, symbol, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: global_settle_asset
//        /// 
//        /// </summary>
//        /// <param name="symbol">API type: string the name or id of the asset to force settlement on</param>
//        /// <param name="settlePrice">API type: price the price at which to settle</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction settling the named asset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> GlobalSettleAsset(string symbol, Price settlePrice, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "global_settle_asset", new object[] { symbol, settlePrice, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: settle_asset
//        /// 
//        /// </summary>
//        /// <param name="accountToSettle">API type: string the name or id of the account owning the asset</param>
//        /// <param name="amountToSettle">API type: string the amount of the named asset to schedule for settlement</param>
//        /// <param name="symbol">API type: string the name or id of the asset to settlement on</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction settling the named asset</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> SettleAsset(string accountToSettle, string amountToSettle, string symbol, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "settle_asset", new object[] { accountToSettle, amountToSettle, symbol, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: bid_collateral
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
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "bid_collateral", new object[] { bidderName, debtAmount, debtSymbol, additionalCollateral, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: whitelist_account
//        /// 
//        /// </summary>
//        /// <param name="authorizingAccount">API type: string the account who is doing the whitelisting</param>
//        /// <param name="accountToList">API type: string the account being whitelisted</param>
//        /// <param name="newListingStatus">API type: account_whitelist_operation::account_listing the new whitelisting status</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction changing the whitelisting status</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> WhitelistAccount(string authorizingAccount, string accountToList, object newListingStatus, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "whitelist_account", new object[] { authorizingAccount, accountToList, newListingStatus, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: create_committee_member
//        /// 
//        /// </summary>
//        /// <param name="ownerAccount">API type: string the name or id of the account which is creating the committee_member</param>
//        /// <param name="url">API type: string a URL to include in the committee_member record in the blockchain.  Clients may
//        /// display this when showing a list of committee_members.  May be blank.</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction registering a committee_member</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> CreateCommitteeMember(string ownerAccount, string url, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "create_committee_member", new object[] { ownerAccount, url, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: list_witnesses
//        /// 
//        /// </summary>
//        /// <param name="lowerbound">API type: string the name of the first witness to return.  If the named witness does not exist, 
//        /// the list will start at the witness that comes after \c lowerbound</param>
//        /// <param name="limit">API type: uint32_t the maximum number of witnesss to return (max: 1000)
//        /// @returns a list of witnesss mapping witness names to witness ids</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: map&lt;string,witness_id_type></returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object> ListWitnesses(string lowerbound, UInt32 limit, CancellationToken token)
//        {
//            return CustomGetRequestAsync<object>(KnownApiNames.WalletApi, "list_witnesses", new object[] { lowerbound, limit, }, token);
//        }

//        /// <summary>
//        /// API name: list_committee_members
//        /// 
//        /// </summary>
//        /// <param name="lowerbound">API type: string the name of the first committee_member to return.  If the named committee_member does not exist, 
//        /// the list will start at the committee_member that comes after \c lowerbound</param>
//        /// <param name="limit">API type: uint32_t the maximum number of committee_members to return (max: 1000)
//        /// @returns a list of committee_members mapping committee_member names to committee_member ids</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: map&lt;string,committee_member_id_type></returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<object> ListCommitteeMembers(string lowerbound, UInt32 limit, CancellationToken token)
//        {
//            return CustomGetRequestAsync<object>(KnownApiNames.WalletApi, "list_committee_members", new object[] { lowerbound, limit, }, token);
//        }

//        /// <summary>
//        /// API name: get_witness
//        /// 
//        /// </summary>
//        /// <param name="ownerAccount">API type: string the name or id of the witness account owner, or the id of the witness
//        /// @returns the information about the witness stored in the block chain</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: witness_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<WitnessObject>> GetWitness(string ownerAccount, CancellationToken token)
//        {
//            return CustomGetRequestAsync<WitnessObject>(KnownApiNames.WalletApi, "get_witness", new object[] { ownerAccount, }, token);
//        }

//        /// <summary>
//        /// API name: get_committee_member
//        /// 
//        /// </summary>
//        /// <param name="ownerAccount">API type: string the name or id of the committee_member account owner, or the id of the committee_member
//        /// @returns the information about the committee_member stored in the block chain</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: committee_member_object</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<CommitteeMemberObject>> GetCommitteeMember(string ownerAccount, CancellationToken token)
//        {
//            return CustomGetRequestAsync<CommitteeMemberObject>(KnownApiNames.WalletApi, "get_committee_member", new object[] { ownerAccount, }, token);
//        }

//        /// <summary>
//        /// API name: create_witness
//        /// 
//        /// </summary>
//        /// <param name="ownerAccount">API type: string the name or id of the account which is creating the witness</param>
//        /// <param name="url">API type: string a URL to include in the witness record in the blockchain.  Clients may
//        /// display this when showing a list of witnesses.  May be blank.</param>
//        /// <param name="broadcast">API type: bool true to broadcast the transaction on the network
//        /// @returns the signed transaction registering a witness</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> CreateWitness(string ownerAccount, string url, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "create_witness", new object[] { ownerAccount, url, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: update_witness
//        /// 
//        /// </summary>
//        /// <param name="witnessName">API type: string</param>
//        /// <param name="url">API type: string Same as for create_witness.  The empty string makes it remain the same.</param>
//        /// <param name="blockSigningKey">API type: string The new block signing public key.  The empty string makes it remain the same.</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction.</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> UpdateWitness(string witnessName, string url, string blockSigningKey, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "update_witness", new object[] { witnessName, url, blockSigningKey, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: get_vesting_balances
//        /// 
//        /// </summary>
//        /// <param name="accountName">API type: string An account name, account ID, or vesting balance object ID.</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: vesting_balance_object_with_info</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<VestingBalanceObjectWithInfo[]>> GetVestingBalances(string accountName, CancellationToken token)
//        {
//            return CustomGetRequestAsync<VestingBalanceObjectWithInfo[]>(KnownApiNames.WalletApi, "get_vesting_balances", new object[] { accountName, }, token);
//        }

//        /// <summary>
//        /// API name: vote_for_committee_member
//        /// 
//        /// </summary>
//        /// <param name="votingAccount">API type: string the name or id of the account who is voting with their shares</param>
//        /// <param name="committeeMember">API type: string the name or id of the committee_member' owner account</param>
//        /// <param name="approve">API type: bool true if you wish to vote in favor of that committee_member, false to 
//        /// remove your vote in favor of that committee_member</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction the signed transaction changing your vote for the given committee_member</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> VoteForCommitteeMember(string votingAccount, string committeeMember, bool approve, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "vote_for_committee_member", new object[] { votingAccount, committeeMember, approve, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: vote_for_witness
//        /// 
//        /// </summary>
//        /// <param name="votingAccount">API type: string the name or id of the account who is voting with their shares</param>
//        /// <param name="witness">API type: string the name or id of the witness' owner account</param>
//        /// <param name="approve">API type: bool true if you wish to vote in favor of that witness, false to 
//        /// remove your vote in favor of that witness</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction the signed transaction changing your vote for the given witness</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> VoteForWitness(string votingAccount, string witness, bool approve, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "vote_for_witness", new object[] { votingAccount, witness, approve, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: set_voting_proxy
//        /// 
//        /// </summary>
//        /// <param name="accountToModify">API type: string the name or id of the account to update</param>
//        /// <param name="votingAccount">API type: optional&lt;string> the name or id of an account authorized to vote account_to_modify's shares,
//        /// or null to vote your own shares</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction the signed transaction changing your vote proxy settings</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> SetVotingProxy(string accountToModify, string votingAccount, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "set_voting_proxy", new object[] { accountToModify, votingAccount, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: set_desired_witness_and_committee_member_count
//        /// 
//        /// </summary>
//        /// <param name="accountToModify">API type: string the name or id of the account to update</param>
//        /// <param name="desiredNumberOfWitnesses">API type: uint16_t</param>
//        /// <param name="desiredNumberOfCommitteeMembers">API type: uint16_t</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction the signed transaction changing your vote proxy settings</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> SetDesiredWitnessAndCommitteeMemberCount(string accountToModify, UInt16 desiredNumberOfWitnesses, UInt16 desiredNumberOfCommitteeMembers, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "set_desired_witness_and_committee_member_count", new object[] { accountToModify, desiredNumberOfWitnesses, desiredNumberOfCommitteeMembers, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: sign_transaction
//        /// 
//        /// </summary>
//        /// <param name="tx">API type: signed_transaction the unsigned transaction</param>
//        /// <param name="broadcast">API type: bool true if you wish to broadcast the transaction</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: signed_transaction the signed version of the transaction</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<SignedTransaction> SignTransaction(SignedTransaction tx, bool broadcast, CancellationToken token)
//        {
//            return CustomGetRequestAsync<SignedTransaction>(KnownApiNames.WalletApi, "sign_transaction", new object[] { tx, broadcast, }, token);
//        }

//        /// <summary>
//        /// API name: get_prototype_operation
//        /// 
//        /// </summary>
//        /// <param name="operationType">API type: string the type of operation to return, must be one of the 
//        /// operations defined in `graphene/chain/operations.hpp`
//        /// (e.g., "global_parameters_update_operation")</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: operation a default-constructed operation of the given type</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse<BaseOperation>> GetPrototypeOperation(string operationType, CancellationToken token)
//        {
//            return CustomGetRequestAsync<BaseOperation>(KnownApiNames.WalletApi, "get_prototype_operation", new object[] { operationType, }, token);
//        }

//        ///// <summary>
//        ///// API name: get_order_book
//        ///// 
//        ///// </summary>
//        ///// <param name="base">API type: string</param>
//        ///// <param name="quote">API type: string</param>
//        ///// <param name="limit">API type: unsigned</param>
//        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        ///// <returns>API type: order_book</returns>
//        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        //public JsonRpcResponse<OrderBook>> GetOrderBook(string @base, string quote, UInt32 limit, CancellationToken token)
//        //{
//        //    return CustomGetRequestAsync<OrderBook>(KnownApiNames.WalletApi, "get_order_book", new object[] { @base, quote, limit, }, token);
//        //}

//        /// <summary>
//        /// API name: dbg_make_uia
//        /// 
//        /// </summary>
//        /// <param name="creator">API type: string</param>
//        /// <param name="symbol">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse DbgMakeUia(string creator, string symbol, CancellationToken token)
//        {
//            return CustomGetRequest(KnownApiNames.WalletApi, "dbg_make_uia", new object[] { creator, symbol, }, token);
//        }

//        /// <summary>
//        /// API name: dbg_make_mia
//        /// 
//        /// </summary>
//        /// <param name="creator">API type: string</param>
//        /// <param name="symbol">API type: string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse DbgMakeMia(string creator, string symbol, CancellationToken token)
//        {
//            return CustomGetRequest(KnownApiNames.WalletApi, "dbg_make_mia", new object[] { creator, symbol, }, token);
//        }

//        /// <summary>
//        /// API name: dbg_push_blocks
//        /// 
//        /// </summary>
//        /// <param name="srcFilename">API type: std::string</param>
//        /// <param name="count">API type: uint32_t</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse DbgPushBlocks(string srcFilename, UInt32 count, CancellationToken token)
//        {
//            return CustomGetRequest(KnownApiNames.WalletApi, "dbg_push_blocks", new object[] { srcFilename, count, }, token);
//        }

//        /// <summary>
//        /// API name: dbg_generate_blocks
//        /// 
//        /// </summary>
//        /// <param name="debugWifKey">API type: std::string</param>
//        /// <param name="count">API type: uint32_t</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse DbgGenerateBlocks(string debugWifKey, UInt32 count, CancellationToken token)
//        {
//            return CustomGetRequest(KnownApiNames.WalletApi, "dbg_generate_blocks", new object[] { debugWifKey, count, }, token);
//        }

//        /// <summary>
//        /// API name: dbg_stream_json_objects
//        /// 
//        /// </summary>
//        /// <param name="filename">API type: std::string</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse DbgStreamJsonObjects(string filename, CancellationToken token)
//        {
//            return CustomGetRequest(KnownApiNames.WalletApi, "dbg_stream_json_objects", new object[] { filename, }, token);
//        }

//        /// <summary>
//        /// API name: dbg_update_object
//        /// 
//        /// </summary>
//        /// <param name="update">API type: fc::variant_object</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse DbgUpdateObject(object update, CancellationToken token)
//        {
//            return CustomGetRequest(KnownApiNames.WalletApi, "dbg_update_object", new object[] { update, }, token);
//        }

//        /// <summary>
//        /// API name: flood_network
//        /// 
//        /// </summary>
//        /// <param name="prefix">API type: string</param>
//        /// <param name="numberOfTransactions">API type: uint32_t</param>
//        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
//        /// <returns>API type: void</returns>
//        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
//        public JsonRpcResponse FloodNetwork(string prefix, UInt32 numberOfTransactions, CancellationToken token)
//        {
//            return CustomGetRequest(KnownApiNames.WalletApi, "flood_network", new object[] { prefix, numberOfTransactions, }, token);
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
//            return CustomGetRequest(KnownApiNames.WalletApi, "network_add_nodes", new object[] { nodes, }, token);
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
//            return CustomGetRequestAsync<object[]>(KnownApiNames.WalletApi, "network_get_connected_peers", token);
//        }
//    }
//}
