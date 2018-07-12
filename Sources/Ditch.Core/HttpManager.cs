using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.Interfaces;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;

namespace Ditch.Core
{
    public class HttpManager : IConnectionManager
    {
        private readonly HttpClient _client;

        public string UrlToConnect { get; private set; }

        public bool IsConnected => !string.IsNullOrEmpty(UrlToConnect);


        /// <summary>
        /// Timeout in milliseconds waiting for WebSocket request to execute. Default is 30000.
        /// </summary>
        public int WaitResponceTimeout { get; set; } = 3000;

        /// <summary>
        /// Timeout in milliseconds waiting for WebSocket connect to chain. Default is 10000.
        /// </summary>
        public int WaitConnectTimeout { get; set; } = 3000;

        public int MaxRepeatRequest { get; set; } = 3;


        /// <summary>
        /// Manager for http connections
        /// </summary>
        /// <param name="maxResponseContentBufferSize">Sets the maximum numbr of bytes to buffer when reading the response content.</param>
        public HttpManager(long maxResponseContentBufferSize = 256000)
        {
            _client = new HttpClient
            {
                MaxResponseContentBufferSize = maxResponseContentBufferSize
            };
        }

        public HttpManager(HttpClient client)
        {
            _client = client;
        }


        /// <summary>
        /// Connects and checks http status
        /// </summary>  
        /// <param name="requestUrl">The Uri the request is sent to.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Url which will be used for data transfer (empty if none)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public bool ConnectTo(string requestUrl, CancellationToken token)
        {
            UrlToConnect = string.Empty;

            var cts = new CancellationTokenSource(WaitConnectTimeout);
            var lcts = CancellationTokenSource.CreateLinkedTokenSource(token, cts.Token);

            var rez = _client.GetAsync(requestUrl, lcts.Token).Result;
            if (rez.IsSuccessStatusCode)
            {
                UrlToConnect = requestUrl;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Clears connection url
        /// </summary>
        public void Disconnect()
        {
            UrlToConnect = string.Empty;
        }

        /// <summary>
        /// Sends request to specified url
        /// </summary>
        /// <typeparam name="T">Some type for response deserialization</typeparam>
        /// <param name="jsonRpc">Request body</param>
        /// <param name="jsonSerializerSettings">Specifies json settings</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Typed JsonRpcResponse</returns>
        public async Task<JsonRpcResponse<T>> ExecuteAsync<T>(IJsonRpcRequest jsonRpc, JsonSerializerSettings jsonSerializerSettings, CancellationToken token)
        {
            if (string.IsNullOrEmpty(UrlToConnect))
                return null;

            var stringResponse = string.Empty;
            try
            {
                var content = new StringContent(jsonRpc.Message);
                var response = await RepeatPost(content, token, MaxRepeatRequest);
                response.EnsureSuccessStatusCode();

                stringResponse = await response.Content.ReadAsStringAsync();
                var prop = JsonConvert.DeserializeObject<JsonRpcResponse<T>>(stringResponse, jsonSerializerSettings);
                prop.RawRequest = jsonRpc.Message;
                prop.RawResponse = stringResponse;
                return prop;

            }
            catch (Exception e)
            {
                var resp = new JsonRpcResponse<T>(e)
                {
                    RawRequest = jsonRpc.Message,
                    RawResponse = stringResponse
                };

                return resp;
            }
        }

        private async Task<HttpResponseMessage> RepeatPost(StringContent content, CancellationToken token, int loop)
        {
            try
            {
                var cts = new CancellationTokenSource(WaitResponceTimeout);
                var lcts = CancellationTokenSource.CreateLinkedTokenSource(token, cts.Token);
                return await _client.PostAsync(UrlToConnect, content, lcts.Token);
            }
            catch (TaskCanceledException)
            {
                if (token.IsCancellationRequested || loop < 1)
                    throw;
                return await RepeatPost(content, token, loop - 1);
            }
        }
    }
}
