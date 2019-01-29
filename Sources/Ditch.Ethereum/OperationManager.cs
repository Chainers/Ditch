using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core;
using Ditch.Core.Interfaces;
using Ditch.Core.JsonRpc;
using Ditch.Ethereum.JsonRpc;
using Newtonsoft.Json;

namespace Ditch.Ethereum
{
    public partial class OperationManager
    {
        public JsonSerializerSettings JsonSerializerSettings { get; set; }

        public MessageSerializer MessageSerializer { get; }
        public IConnectionManager ConnectionManager { get; }
        //public byte[] ChainId { get; set; } = Config.ChainId;

        public bool IsConnected => ConnectionManager.IsConnected;

        #region Constructors

        public OperationManager(IConnectionManager connectionManage)
        {
            MessageSerializer = new MessageSerializer();
            ConnectionManager = connectionManage;
            JsonSerializerSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                Culture = CultureInfo.InvariantCulture
            };
        }

        #endregion Constructors

        public async Task<bool> ConnectToAsync(string endpoin, CancellationToken token)
        {
            return await ConnectionManager.ConnectToAsync(endpoin, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <typeparam name="T">Custom type. JsonConvert will try to convert json-response to you custom object</typeparam>
        /// <param name="api">api name</param>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<T>> CustomGetRequestAsync<T>(string method, CancellationToken token)
        {
            var jsonRpc = new JsonRpcRequest(method);
            return ConnectionManager.RepeatExecuteAsync<T>(jsonRpc, JsonSerializerSettings, token);
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <typeparam name="T">Custom type. JsonConvert will try to convert json-response to you custom object</typeparam>
        /// <param name="api">api name</param>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="data">Sets to json-rpc params field. JsonConvert use`s for convert array of data to string.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<T>> CustomGetRequestAsync<T>(string method, object[] data, CancellationToken token)
        {
            var jsonRpc = new JsonRpcRequest(JsonSerializerSettings, method, data);
            return ConnectionManager.RepeatExecuteAsync<T>(jsonRpc, JsonSerializerSettings, token);
        }
    }
}