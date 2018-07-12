using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;

namespace Ditch.Core.Interfaces
{
    public interface IConnectionManager
    {
        bool IsConnected { get; }

        bool ConnectTo(string endpoin, CancellationToken token);

        void Disconnect();

        Task<JsonRpcResponse<T>> ExecuteAsync<T>(IJsonRpcRequest jsonRpc, JsonSerializerSettings jsonSerializerSettings, CancellationToken token);
    }
}