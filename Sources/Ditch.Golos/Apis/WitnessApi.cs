using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Models;

namespace Ditch.Golos
{
    /// <summary>
    /// witness_api
    /// plugins\witness_api\include\golos\plugins\witness_api\plugin.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// API name: get_active_witnesses
        /// *Отображает список всех активных делегатов.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_name_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<string[]>> GetActiveWitnessesAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<string[]>(KnownApiNames.WitnessApi, "get_active_witnesses", token);
        }

        /// <summary>
        /// API name: get_current_median_history_price
        /// *Отображает текущую медианную цену конвертации
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: price_17</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<Price>> GetCurrentMedianHistoryPriceAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<Price>(KnownApiNames.WitnessApi, "get_current_median_history_price", token);
        }

        /// <summary>
        /// API name: get_feed_history
        /// *Отображает историю конверсий
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: feed_history_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<FeedHistoryApiObject>> GetFeedHistoryAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<FeedHistoryApiObject>(KnownApiNames.WitnessApi, "get_feed_history", token);
        }

        /// <summary>
        /// API name: get_miner_queue
        /// *Создает список майнеров, ожидающих попасть в DPOW цепочку, чтобы создать блок.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_name_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<string[]>> GetMinerQueueAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<string[]>(KnownApiNames.WitnessApi, "get_miner_queue", token);
        }

        /// <summary>
        /// API name: get_witness_by_account
        /// *Отображает данные о делегате (если он им является) в соответствии с данными из запроса
        /// 
        /// </summary>
        /// <param name="accountName">API type: std::string The name of the account whose witness should be retrieved</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_api_object The witness object, or null if the account does not have a witness</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<WitnessApiObject>> GetWitnessByAccountAsync(string accountName, CancellationToken token)
        {
            return CustomGetRequestAsync<WitnessApiObject>(KnownApiNames.WitnessApi, "get_witness_by_account", new object[] { accountName }, token);
        }

        /// <summary>
        /// API name: get_witness_count
        /// *Отображает количество делегатов.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: uint64_t</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<ulong>> GetWitnessCountAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<ulong>(KnownApiNames.WitnessApi, "get_witness_count", token);
        }

        /// <summary>
        /// API name: get_witness_schedule
        /// *Отображает текущее состояние делегирования.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_schedule_api_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<WitnessScheduleApiObject>> GetWitnessScheduleAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<WitnessScheduleApiObject>(KnownApiNames.WitnessApi, "get_witness_schedule", token);
        }

        /// <summary>
        /// API name: get_witnesses
        /// *Отображает данные о делегатах в соответствии с заданными ID
        /// 
        /// </summary>
        /// <param name="witnessIds">API type: std::vector&lt;witness_object::id_type> IDs of the witnesses to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_api_object The witnesses corresponding to the provided IDs
        /// 
        /// This function has semantics identical to @ref get_objects</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<WitnessApiObject[]>> GetWitnessesAsync(object[] witnessIds, CancellationToken token)
        {
            return CustomGetRequestAsync<WitnessApiObject[]>(KnownApiNames.WitnessApi, "get_witnesses", new object[] { witnessIds }, token);
        }

        /// <summary>
        /// API name: get_witnesses_by_vote
        /// *Отображает ограниченный список делегатов одобряющих голосование.
        /// 
        /// </summary>
        /// <param name="from">API type: std::string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: witness_api_object an array of `count` witnesses sorted by total votes after witness `from` with at most `limit' results.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<WitnessApiObject[]>> GetWitnessesByVoteAsync(string from, uint limit, CancellationToken token)
        {
            return CustomGetRequestAsync<WitnessApiObject[]>(KnownApiNames.WitnessApi, "get_witnesses_by_vote", new object[] { from, limit }, token);
        }

        /// <summary>
        /// API name: lookup_witness_accounts
        /// *Отображает ограниченный список пользователей, которые объявили о своем намерении работать в качестве делегата.
        /// 
        /// </summary>
        /// <param name="lowerBoundName">API type: std::string Lower bound of the first name to return</param>
        /// <param name="limit">API type: uint32_t Maximum number of results to return -- must not exceed 1000</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_name_type Map of witness names to corresponding IDs</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<string[]>> LookupWitnessAccountsAsync(string lowerBoundName, uint limit, CancellationToken token)
        {
            return CustomGetRequestAsync<string[]>(KnownApiNames.WitnessApi, "lookup_witness_accounts", new object[] { lowerBoundName, limit }, token);
        }
    }
}
