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
        /// <exception cref="T:System.ArgumentNullException">The requestUri was null.</exception>
        /// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
        public bool ConnectTo(string requestUrl, CancellationToken token)
        {
            UrlToConnect = string.Empty;

            var rez = _client.GetAsync(requestUrl, token).Result;
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
                return new JsonRpcResponse<T>(new ArgumentNullException(nameof(UrlToConnect))) { RawRequest = jsonRpc.Message };

            var stringResponse = string.Empty;
            try
            {
                var content = new StringContent(jsonRpc.Message);
                var response = await _client.PostAsync(UrlToConnect, content, token);
                response.EnsureSuccessStatusCode();

                stringResponse = await response.Content.ReadAsStringAsync();
                var prop = JsonConvert.DeserializeObject<JsonRpcResponse<T>>(stringResponse, jsonSerializerSettings);
                prop.RawRequest = jsonRpc.Message;
                prop.RawResponse = stringResponse;
                return prop;
            }
            catch (Exception e)
            {
                return new JsonRpcResponse<T>(e)
                {
                    RawRequest = jsonRpc.Message,
                    RawResponse = stringResponse
                };
            }
        }
    }
}
