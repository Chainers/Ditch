using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Models;

namespace Ditch.Golos
{
    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_account_history
        /// Account operations have sequence numbers from 0 to N where N is the most recent operation.
        ///
        /// *The history of all user actions on the network in the form of transactions. If from = -1, then are last {limit+1} history elements are shown. Parameter limit should be less or equals {from} (except from = -1). This is because elements preceding {from} are shown.
        /// 
        /// </summary>
        /// <param name="account">API type: std::string</param>
        /// <param name="from">API type: uint64_t - the absolute sequence number, -1 means most recent, limit is the number of operations before from.</param>
        /// <param name="limit">API type: uint32_t - the maximum number of items that can be queried (0 to 1000], must be less than from</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_account_history_return_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetAccountHistoryReturnType> GetAccountHistory(string account, UInt64 from, UInt32 limit, CancellationToken token)
        {
            return CustomGetRequest<GetAccountHistoryReturnType>(KnownApiNames.AccountHistory, "get_account_history", new object[] { account, from, limit }, token);
        }
    }
}
