using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Core.Models;
using Ditch.Golos.Models;

namespace Ditch.Golos
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
    /// plugins\database_api\include\golos\plugins\database_api\plugin.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// API name: get_account_bandwidth
        /// *Отображает действия пользователя в зависимости от типа
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="type">API type: bandwidth_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_bandwidth_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountBandwidthApiObject> GetAccountBandwidth(string account, BandwidthType type, CancellationToken token)
        {
            return CustomGetRequest<AccountBandwidthApiObject>(KnownApiNames.DatabaseApi, "get_account_bandwidth", new object[] { account, type }, token);
        }

        /// <summary>
        /// API name: get_account_count
        ///
        /// *Возвращает количество зарегестрированных пользователей.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: uint64_t</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<UInt64> GetAccountCount(CancellationToken token)
        {
            return CustomGetRequest<UInt64>(KnownApiNames.DatabaseApi, "get_account_count", token);
        }

        /// <summary>
        /// API name: get_accounts
        /// *Возращает данные по заданным аккаунтам
        /// 
        /// </summary>
        /// <param name="arg0">API type: vector&lt;std::string></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountApiObject[]> GetAccounts(string[] arg0, CancellationToken token)
        {
            return CustomGetRequest<AccountApiObject[]>(KnownApiNames.DatabaseApi, "get_accounts", new object[] { arg0 }, token);
        }

        /// <summary>
        /// API name: get_block
        /// Retrieve a full, signed block
        ///
        /// *Возвращает все данные о блоке включая транзакции
        /// 
        /// </summary>
        /// <param name="blockNum">API type: uint32_t Height of the block to be returned</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: signed_block the referenced block, or null if no matching block was found</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SignedBlock> GetBlock(UInt32 blockNum, CancellationToken token)
        {
            return CustomGetRequest<SignedBlock>(KnownApiNames.DatabaseApi, "get_block", new object[] { blockNum }, token);
        }

        /// <summary>
        /// API name: get_block_header
        /// Retrieve a block header
        /// 
        /// *Возвращает все данные о блоке
        /// 
        /// </summary>
        /// <param name="blockNum">API type: uint32_t Height of the block whose header should be returned</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: block_header header of the referenced block, or null if no matching block was found</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<BlockHeader> GetBlockHeader(UInt32 blockNum, CancellationToken token)
        {
            return CustomGetRequest<BlockHeader>(KnownApiNames.DatabaseApi, "get_block_header", new object[] { blockNum }, token);
        }

        /// <summary>
        /// API name: get_chain_properties
        /// *Отображает комиссию за создание пользователя, максимальный размер блока и процентную ставку GBG.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: chain_api_properties</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ChainApiProperties> GetChainProperties(CancellationToken token)
        {
            return CustomGetRequest<ChainApiProperties>(KnownApiNames.DatabaseApi, "get_chain_properties", token);
        }

        /// <summary>
        /// API name: get_config
        /// Retrieve compile-time constants
        ///
        /// *Отображает текущую конфигурацию узла.
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
        /// API name: get_conversion_requests
        /// *Возвращает текущие запросы на конвертацию указанным пользователем
        /// 
        /// </summary>
        /// <param name="accountName">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: convert_request_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ConvertRequestApiObject[]> GetConversionRequests(string accountName, CancellationToken token)
        {
            return CustomGetRequest<ConvertRequestApiObject[]>(KnownApiNames.DatabaseApi, "get_conversion_requests", new object[] { accountName }, token);
        }

        /// <summary>
        /// API name: get_database_info
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: database_info</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<DatabaseInfo> GetDatabaseInfo(CancellationToken token)
        {
            return CustomGetRequest<DatabaseInfo>(KnownApiNames.DatabaseApi, "get_database_info", new object[] { }, token);
        }

        /// <summary>
        /// API name: get_dynamic_global_properties
        /// Retrieve the current @ref dynamic_global_property_object
        ///
        /// *Отображает информацию о текущем состоянии сети
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: dynamic_global_property_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<DynamicGlobalPropertyApiObject> GetDynamicGlobalProperties(CancellationToken token)
        {
            return CustomGetRequest<DynamicGlobalPropertyApiObject>(KnownApiNames.DatabaseApi, "get_dynamic_global_properties", token);
        }

        /// <summary>
        /// API name: get_escrow
        /// *Возвращает операции реализованные с помощью посредничества.
        /// 
        /// </summary>
        /// <param name="from">API type: std::string</param>
        /// <param name="escrowId">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: escrow_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<EscrowApiObject> GetEscrow(string from, UInt32 escrowId, CancellationToken token)
        {
            return CustomGetRequest<EscrowApiObject>(KnownApiNames.DatabaseApi, "get_escrow", new object[] { from, escrowId }, token);
        }

        /// <summary>
        /// API name: get_expiring_vesting_delegations
        /// Получить список возвращаемых (отозванных и «замороженных») «делегирований» аккаунта
        /// 
        /// </summary>
        /// <param name="account">аккаунт, возвращающий «делегирования»</param>
        /// <param name="from"> начальное время возврата «делегирований» (для пагинации)</param>
        /// <param name="limit">количество возвращаемых элементов(для пагинации). необязательный аргумент.по умолчанию = 100.макс. 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: vesting_delegation_expiration_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<VestingDelegationExpirationApiObject[]> GetExpiringVestingDelegations(string account, TimePointSec from, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<VestingDelegationExpirationApiObject[]>(KnownApiNames.DatabaseApi, "get_expiring_vesting_delegations", new object[] { account, from, limit }, token);
        }

        /// <summary>
        /// API name: get_hardfork_version
        /// *Отображает текущую версию сети.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: hardfork_version</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string> GetHardforkVersion(CancellationToken token)
        {
            return CustomGetRequest<string>(KnownApiNames.DatabaseApi, "get_hardfork_version", token);
        }

        /// <summary>
        /// API name: get_next_scheduled_hardfork
        /// *Отображает дату и версию HardFork
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: scheduled_hardfork</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ScheduledHardfork> GetNextScheduledHardfork(CancellationToken token)
        {
            return CustomGetRequest<ScheduledHardfork>(KnownApiNames.DatabaseApi, "get_next_scheduled_hardfork", token);
        }

        /// <summary>
        /// API name: get_owner_history
        /// *Отображает имя пользователя если он изменил право собственности на блокчейн
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: owner_authority_history_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<OwnerAuthorityHistoryApiObject[]> GetOwnerHistory(string account, CancellationToken token)
        {
            return CustomGetRequest<OwnerAuthorityHistoryApiObject[]>(KnownApiNames.DatabaseApi, "get_owner_history", new object[] { account }, token);
        }

        /// <summary>
        /// API name: get_potential_signatures
        /// *Отображает потенциальный ключ для данной транзакции.
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
        /// API name: get_proposed_transactions
        /// 
        /// </summary>
        /// <param name="arg0">API type: string</param>
        /// <param name="arg1">API type: uint32_t</param>
        /// <param name="arg2">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: proposal_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<ProposalApiObject[]> GetProposedTransactions(string arg0, UInt32 arg1, UInt32 arg2, CancellationToken token)
        {
            return CustomGetRequest<ProposalApiObject[]>(KnownApiNames.DatabaseApi, "get_proposed_transactions", new object[] { arg0, arg1, arg2 }, token);
        }

        /// <summary>
        /// API name: get_recovery_request
        /// *Возвращает true если пользователь в статусе на восстановление.
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_recovery_request_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountRecoveryRequestApiObject> GetRecoveryRequest(string account, CancellationToken token)
        {
            return CustomGetRequest<AccountRecoveryRequestApiObject>(KnownApiNames.DatabaseApi, "get_recovery_request", new object[] { account }, token);
        }

        /// <summary>
        /// API name: get_required_signatures
        /// *Возвращает список ключей которыми может быть подписанна указанная транзакция, на основании списка предоставленных ключей(второй параметр)
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

        /// <summary>
        /// API name: get_savings_withdraw_from
        /// *Возвращает данные о выводах из 'СЕЙФА' для данного пользователя
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: savings_withdraw_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SavingsWithdrawApiObject[]> GetSavingsWithdrawFrom(string account, CancellationToken token)
        {
            return CustomGetRequest<SavingsWithdrawApiObject[]>(KnownApiNames.DatabaseApi, "get_savings_withdraw_from", new object[] { account }, token);
        }

        /// <summary>
        /// API name: get_savings_withdraw_to
        /// *Возвращает данные о выводах из 'СЕЙФА' для данного пользователя
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: savings_withdraw_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SavingsWithdrawApiObject[]> GetSavingsWithdrawTo(string account, CancellationToken token)
        {
            return CustomGetRequest<SavingsWithdrawApiObject[]>(KnownApiNames.DatabaseApi, "get_savings_withdraw_to", new object[] { account }, token);
        }

        /// <summary>
        /// API name: get_transaction_hex
        /// Get a hexdump of the serialized binary form of a transaction
        ///
        /// *Отображает HEX строку транзакции.
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

        /// <summary>
        /// API name: get_vesting_delegations
        /// Получить «делегирования» аккаунта (делегированные другим аккаунтам или же полученные от других аккаунтов)
        /// </summary>
        /// <param name="account">аккаунт, для которого получаем «делегирования». в зависимости от type (см. ниже) отправитель или получатель</param>
        /// <param name="from">начальный аккаунт, парный в операции делегирования. в зависимости от type (см. ниже) получатель или отправитель (для пагинации)</param>
        /// <param name="limit">количество возвращаемых элементов (для пагинации). необязательный аргумент. по умолчанию = 100, макс. 1000</param>
        /// <param name="type">какие «делегирования» требуется получить: "delegated" — делегированные, "received" — полученные. необязательный аргумент. по умолчанию = "delegated"</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: vesting_delegation_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<VestingDelegationApiObject[]> GetVestingDelegations(string account, string from, UInt32 limit, DelegationsType type, CancellationToken token)
        {
            return CustomGetRequest<VestingDelegationApiObject[]>(KnownApiNames.DatabaseApi, "get_vesting_delegations", new object[] { account, from, limit, type }, token);
        }

        /// <summary>
        /// API name: get_withdraw_routes
        /// *Возвращает все переводы на счету пользователя в зависимости от типа
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="type">API type: withdraw_route_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: withdraw_route</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<WithdrawRoute[]> GetWithdrawRoutes(string account, WithdrawRouteType type, CancellationToken token)
        {
            return CustomGetRequest<WithdrawRoute[]>(KnownApiNames.DatabaseApi, "get_withdraw_routes", new object[] { account, type }, token);
        }

        /// <summary>
        /// API name: lookup_account_names
        /// Get a list of accounts by name
        ///
        /// *Возращает данные по заданным аккаунтам
        /// 
        /// </summary>
        /// <param name="accountNames">API type: std::vector&lt;std::string> Names of the accounts to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_api_object The accounts holding the provided names
        /// 
        /// This function has semantics identical to @ref get_objects</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountApiObject[]> LookupAccountNames(string[] accountNames, CancellationToken token)
        {
            return CustomGetRequest<AccountApiObject[]>(KnownApiNames.DatabaseApi, "lookup_account_names", new object[] { accountNames }, token);
        }

        /// <summary>
        /// API name: lookup_accounts
        /// Get names and IDs for registered accounts
        ///
        /// *Возвращает имена пользователей близких к шаблону.
        /// 
        /// </summary>
        /// <param name="lowerBoundName">API type: std::string Lower bound of the first name to return</param>
        /// <param name="limit">API type: uint32_t Maximum number of results to return -- must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: string Map of account names to corresponding IDs</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[]> LookupAccounts(string lowerBoundName, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<string[]>(KnownApiNames.DatabaseApi, "lookup_accounts", new object[] { lowerBoundName, limit }, token);
        }

        /// <summary>
        /// API name: set_block_applied_callback
        /// Set callback which is triggered on each generated block
        ///
        /// 
        /// </summary>
        /// <param name="args">API type: object</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<VoidResponse> SetBlockAppliedCallback(object args, CancellationToken token)
        {
            return CustomGetRequest<VoidResponse>(KnownApiNames.DatabaseApi, "set_block_applied_callback", new[] { args }, token);
        }

        /// <summary>
        /// API name: verify_account_authority
        /// *Возвращает  true, если у пользователя есть достаточные полномочия для авторизации учетной записи
        /// 
        /// </summary>
        /// <param name="name">API type: std::string</param>
        /// <param name="signers">API type: flat_set&lt;public_key_type></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bool true if the signers have enough authority to authorize an account</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<bool> VerifyAccountAuthority(string name, PublicKeyType[] signers, CancellationToken token)
        {
            return CustomGetRequest<bool>(KnownApiNames.DatabaseApi, "verify_account_authority", new object[] { name, signers }, token);
        }

        /// <summary>
        /// API name: verify_authority
        /// *Возвращает TRUE если транзакция подписана правильно
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
    }
}
