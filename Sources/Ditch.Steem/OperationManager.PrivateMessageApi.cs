using System.Threading;
using Ditch.Core.JsonRpc;
using System;
using Ditch.Steem.Models.ApiObj;

namespace Ditch.Steem
{
    /// <summary>
    /// private_message_api
    /// libraries\plugins\private_message\include\steemit\private_message\private_message_plugin.hpp
    /// </summary>
    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_inbox
        /// 
        /// </summary>
        /// <param name="to">API type: string</param>
        /// <param name="newest">API type: time_point</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: message_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MessageApiObj[]> GetInbox(string to, object newest, UInt16 limit, CancellationToken token)
        {
            return CallRequest<MessageApiObj[]>(KnownApiNames.PrivateMessageApi, "get_inbox", new object[] { to, newest, limit }, token);
        }

        /// <summary>
        /// API name: get_outbox
        /// 
        /// </summary>
        /// <param name="from">API type: string</param>
        /// <param name="newest">API type: time_point</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: message_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MessageApiObj[]> GetOutbox(string from, object newest, UInt16 limit, CancellationToken token)
        {
            return CallRequest<MessageApiObj[]>(KnownApiNames.PrivateMessageApi, "get_outbox", new object[] { from, newest, limit }, token);
        }
    }
}
