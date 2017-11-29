using System.Collections.Generic;
using System.Threading;
using Ditch.Core.JsonRpc;

namespace Ditch.Core
{
    public interface IConnectionManager
    {
        bool IsConnected { get; }

        string ConnectTo(string endpoin, CancellationToken tokent);
        string ConnectTo(IEnumerable<string> urls, CancellationToken token);
        void Disconnect();

        JsonRpcResponse Execute(JsonRpcRequest jsonRpc, CancellationToken token);
        JsonRpcResponse<T> Execute<T>(JsonRpcRequest jsonRpc, CancellationToken token);
    }
}