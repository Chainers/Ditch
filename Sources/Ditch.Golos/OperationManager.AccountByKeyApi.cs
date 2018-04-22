using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Models.Other;

namespace Ditch.Golos
{
    /// <summary>
    /// account_by_key
    /// plugins\account_by_key\include\golos\plugins\account_by_key\account_by_key_plugin.hpp
    /// </summary>
    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_key_references
        /// 
        /// </summary>
        /// <param name="keys">API type: vector&lt;public_key_type></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_name_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string[][]> GetKeyReferences(PublicKeyType[] keys, CancellationToken token)
        {
            return CustomGetRequest<string[][]>(KnownApiNames.AccountByKey, "get_key_references", new object[] { keys }, token);
        }
    }
}
