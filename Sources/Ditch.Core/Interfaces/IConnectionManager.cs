using System.Collections.Generic;
using System.Threading;
using Ditch.Core.JsonRpc;

namespace Ditch.Core.Interfaces
{
    public interface IConnectionManager
    {
        bool IsConnected { get; }

        bool TryConnectTo(string endpoin, CancellationToken token);

        bool TryConnectTo(IEnumerable<string> urls, CancellationToken token);

        void Disconnect();

        JsonRpcResponse Execute(IJsonRpcRequest jsonRpc, CancellationToken token);

        JsonRpcResponse<T> Execute<T>(IJsonRpcRequest jsonRpc, CancellationToken token);
    }
}