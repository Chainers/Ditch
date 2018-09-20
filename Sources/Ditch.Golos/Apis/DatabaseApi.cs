using System.Threading;
using System.Threading.Tasks;
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
        public Task<JsonRpcResponse<AccountBandwidthApiObject>> GetAccountBandwidthAsync(string account, BandwidthType type, CancellationToken token)
        {
            return CustomGetRequestAsync<AccountBandwidthApiObject>(KnownApiNames.DatabaseApi, "get_account_bandwidth", new object[] { account, type }, token);
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
        public Task<JsonRpcResponse<ulong>> GetAccountCountAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<ulong>(KnownApiNames.DatabaseApi, "get_account_count", token);
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
        public Task<JsonRpcResponse<AccountApiObject[]>> GetAccountsAsync(string[] arg0, CancellationToken token)
        {
            return CustomGetRequestAsync<AccountApiObject[]>(KnownApiNames.DatabaseApi, "get_accounts", new object[] { arg0 }, token);
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
        public Task<JsonRpcResponse<SignedBlock>> GetBlockAsync(uint blockNum, CancellationToken token)
        {
            return CustomGetRequestAsync<SignedBlock>(KnownApiNames.DatabaseApi, "get_block", new object[] { blockNum }, token);
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
        public Task<JsonRpcResponse<BlockHeader>> GetBlockHeaderAsync(uint blockNum, CancellationToken token)
        {
            return CustomGetRequestAsync<BlockHeader>(KnownApiNames.DatabaseApi, "get_block_header", new object[] { blockNum }, token);
        }

        /// <summary>
        /// API name: get_chain_properties
        /// *Отображает комиссию за создание пользователя, максимальный размер блока и процентную ставку GBG.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: chain_api_properties</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<ChainApiProperties>> GetChainPropertiesAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<ChainApiProperties>(KnownApiNames.DatabaseApi, "get_chain_properties", token);
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
        public Task<JsonRpcResponse<T>> GetConfigAsync<T>(CancellationToken token)
        {
            return CustomGetRequestAsync<T>(KnownApiNames.DatabaseApi, "get_config", token);
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
        public Task<JsonRpcResponse<ConvertRequestApiObject[]>> GetConversionRequestsAsync(string accountName, CancellationToken token)
        {
            return CustomGetRequestAsync<ConvertRequestApiObject[]>(KnownApiNames.DatabaseApi, "get_conversion_requests", new object[] { accountName }, token);
        }

        /// <summary>
        /// API name: get_database_info
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: database_info</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<DatabaseInfo>> GetDatabaseInfoAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<DatabaseInfo>(KnownApiNames.DatabaseApi, "get_database_info", new object[] { }, token);
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
        public Task<JsonRpcResponse<DynamicGlobalPropertyApiObject>> GetDynamicGlobalPropertiesAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<DynamicGlobalPropertyApiObject>(KnownApiNames.DatabaseApi, "get_dynamic_global_properties", token);
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
        public Task<JsonRpcResponse<EscrowApiObject>> GetEscrowAsync(string from, uint escrowId, CancellationToken token)
        {
            return CustomGetRequestAsync<EscrowApiObject>(KnownApiNames.DatabaseApi, "get_escrow", new object[] { from, escrowId }, token);
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
        public Task<JsonRpcResponse<VestingDelegationExpirationApiObject[]>> GetExpiringVestingDelegationsAsync(string account, TimePointSec from, uint limit, CancellationToken token)
        {
            return CustomGetRequestAsync<VestingDelegationExpirationApiObject[]>(KnownApiNames.DatabaseApi, "get_expiring_vesting_delegations", new object[] { account, from, limit }, token);
        }

        /// <summary>
        /// API name: get_hardfork_version
        /// *Отображает текущую версию сети.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: hardfork_version</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<string>> GetHardforkVersionAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<string>(KnownApiNames.DatabaseApi, "get_hardfork_version", token);
        }

        /// <summary>
        /// API name: get_next_scheduled_hardfork
        /// *Отображает дату и версию HardFork
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: scheduled_hardfork</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<ScheduledHardfork>> GetNextScheduledHardforkAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<ScheduledHardfork>(KnownApiNames.DatabaseApi, "get_next_scheduled_hardfork", token);
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
        public Task<JsonRpcResponse<OwnerAuthorityHistoryApiObject[]>> GetOwnerHistoryAsync(string account, CancellationToken token)
        {
            return CustomGetRequestAsync<OwnerAuthorityHistoryApiObject[]>(KnownApiNames.DatabaseApi, "get_owner_history", new object[] { account }, token);
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
        public Task<JsonRpcResponse<PublicKeyType[]>> GetPotentialSignaturesAsync(SignedTransaction trx, CancellationToken token)
        {
            return CustomGetRequestAsync<PublicKeyType[]>(KnownApiNames.DatabaseApi, "get_potential_signatures", new object[] { trx }, token);
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
        public Task<JsonRpcResponse<ProposalApiObject[]>> GetProposedTransactionsAsync(string arg0, uint arg1, uint arg2, CancellationToken token)
        {
            return CustomGetRequestAsync<ProposalApiObject[]>(KnownApiNames.DatabaseApi, "get_proposed_transactions", new object[] { arg0, arg1, arg2 }, token);
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
        public Task<JsonRpcResponse<AccountRecoveryRequestApiObject>> GetRecoveryRequestAsync(string account, CancellationToken token)
        {
            return CustomGetRequestAsync<AccountRecoveryRequestApiObject>(KnownApiNames.DatabaseApi, "get_recovery_request", new object[] { account }, token);
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
        public Task<JsonRpcResponse<PublicKeyType[]>> GetRequiredSignaturesAsync(SignedTransaction trx, PublicKeyType[] availableKeys, CancellationToken token)
        {
            return CustomGetRequestAsync<PublicKeyType[]>(KnownApiNames.DatabaseApi, "get_required_signatures", new object[] { trx, availableKeys }, token);
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
        public Task<JsonRpcResponse<SavingsWithdrawApiObject[]>> GetSavingsWithdrawFromAsync(string account, CancellationToken token)
        {
            return CustomGetRequestAsync<SavingsWithdrawApiObject[]>(KnownApiNames.DatabaseApi, "get_savings_withdraw_from", new object[] { account }, token);
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
        public Task<JsonRpcResponse<SavingsWithdrawApiObject[]>> GetSavingsWithdrawToAsync(string account, CancellationToken token)
        {
            return CustomGetRequestAsync<SavingsWithdrawApiObject[]>(KnownApiNames.DatabaseApi, "get_savings_withdraw_to", new object[] { account }, token);
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
        public Task<JsonRpcResponse<string>> GetTransactionHexAsync(SignedTransaction trx, CancellationToken token)
        {
            return CustomGetRequestAsync<string>(KnownApiNames.DatabaseApi, "get_transaction_hex", new object[] { trx }, token);
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
        public Task<JsonRpcResponse<VestingDelegationApiObject[]>> GetVestingDelegationsAsync(string account, string from, uint limit, DelegationsType type, CancellationToken token)
        {
            return CustomGetRequestAsync<VestingDelegationApiObject[]>(KnownApiNames.DatabaseApi, "get_vesting_delegations", new object[] { account, from, limit, type }, token);
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
        public Task<JsonRpcResponse<WithdrawRoute[]>> GetWithdrawRoutesAsync(string account, WithdrawRouteType type, CancellationToken token)
        {
            return CustomGetRequestAsync<WithdrawRoute[]>(KnownApiNames.DatabaseApi, "get_withdraw_routes", new object[] { account, type }, token);
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
        public Task<JsonRpcResponse<AccountApiObject[]>> LookupAccountNamesAsync(string[] accountNames, CancellationToken token)
        {
            return CustomGetRequestAsync<AccountApiObject[]>(KnownApiNames.DatabaseApi, "lookup_account_names", new object[] { accountNames }, token);
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
        public Task<JsonRpcResponse<string[]>> LookupAccountsAsync(string lowerBoundName, uint limit, CancellationToken token)
        {
            return CustomGetRequestAsync<string[]>(KnownApiNames.DatabaseApi, "lookup_accounts", new object[] { lowerBoundName, limit }, token);
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
        public Task<JsonRpcResponse<VoidResponse>> SetBlockAppliedCallbackAsync(object args, CancellationToken token)
        {
            return CustomGetRequestAsync<VoidResponse>(KnownApiNames.DatabaseApi, "set_block_applied_callback", new[] { args }, token);
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
        public Task<JsonRpcResponse<bool>> VerifyAccountAuthorityAsync(string name, PublicKeyType[] signers, CancellationToken token)
        {
            return CustomGetRequestAsync<bool>(KnownApiNames.DatabaseApi, "verify_account_authority", new object[] { name, signers }, token);
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
        public Task<JsonRpcResponse<bool>> VerifyAuthorityAsync(SignedTransaction trx, CancellationToken token)
        {
            return CustomGetRequestAsync<bool>(KnownApiNames.DatabaseApi, "verify_authority", new object[] { trx }, token);
        }
    }
}
