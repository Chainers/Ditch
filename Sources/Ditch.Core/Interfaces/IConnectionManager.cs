using System.Collections.Generic;
using System.Threading;
using Ditch.Core.JsonRpc;

namespace Ditch.Core.Interfaces
{
    public interface IConnectionManager
    {
        bool IsConnected { get; }

        string ConnectTo(string endpoin, CancellationToken tokent);
        string ConnectTo(IEnumerable<string> urls, CancellationToken token);
        void Disconnect();

        JsonRpcResponse Execute(IJsonRpcRequest jsonRpc, CancellationToken token);
        JsonRpcResponse<T> Execute<T>(IJsonRpcRequest jsonRpc, CancellationToken token);
    }
}