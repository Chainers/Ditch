using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Models.Other;

namespace Ditch.Steem
{
    /**
    * @brief The login_api class implements the bottom layer of the RPC API
    *
    * All other APIs must be requested from this API.
    */

    /// <summary>
    /// login_api
    /// libraries\app\include\steemit\app\api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// API name: login
        /// Authenticate to the RPC server
        ///
        /// *Allows you to connect to the accounts on the network.
        /// 
        /// </summary>
        /// <param name="user">API type: string Username to login with</param>
        /// <param name="password">API type: string Password to login with</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bool True if logged in successfully; false otherwise
        /// 
        /// @note This must be called prior to requesting other APIs. Other APIs may not be accessible until the client
        /// has sucessfully authenticated.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<bool> Login(string user, string password, CancellationToken token)
        {
            return CallRequest<bool>(KnownApiNames.LoginApi, "login", new object[] { user, password }, token);
        }

        /// <summary>
        /// API name: get_api_by_name
        /// *Returns the unique API identifier by its name.
        /// 
        /// </summary>
        /// <param name="apiName">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: api_ptr</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<object> GetApiByName(string apiName, CancellationToken token)
        {
            return CallRequest<object>(KnownApiNames.LoginApi, "get_api_by_name", new object[] { apiName }, token);
        }

        /// <summary>
        /// API name: get_version
        /// *Returns the version information for the components of the blockchain.
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: steem_version_info</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<SteemVersionInfo> GetVersion(CancellationToken token)
        {
            return CallRequest<SteemVersionInfo>(KnownApiNames.LoginApi, "get_version", new object[] { }, token);
        }
    }
}
