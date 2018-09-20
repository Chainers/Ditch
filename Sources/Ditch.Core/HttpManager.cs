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
        public string UrlToConnect { get; private set; }

        public bool IsConnected => !string.IsNullOrEmpty(UrlToConnect);

        public IHttpClient HttpClient { get; set; }


        public HttpManager(IHttpClient httpClient)
        {
            HttpClient = httpClient;
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
        public async Task<bool> ConnectToAsync(string requestUrl, CancellationToken token)
        {
            UrlToConnect = string.Empty;

            if (string.IsNullOrEmpty(requestUrl))
                return false;

            var response = await HttpClient.GetAsync(requestUrl, token).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
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
            return await RepeatExecuteAsync<T>(jsonRpc, jsonSerializerSettings, 0, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends request to specified url.
        /// </summary>
        /// <typeparam name="T">Some type for response deserialization</typeparam>
        /// <param name="jsonRpc">Request body</param>
        /// <param name="jsonSerializerSettings">Specifies json settings</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Typed JsonRpcResponse</returns>
        public async Task<JsonRpcResponse<T>> RepeatExecuteAsync<T>(IJsonRpcRequest jsonRpc, JsonSerializerSettings jsonSerializerSettings, CancellationToken token)
        {
            return await RepeatExecuteAsync<T>(jsonRpc, jsonSerializerSettings, HttpClient.MaxRequestRepeatCount, token).ConfigureAwait(false);
        }

        private async Task<JsonRpcResponse<T>> RepeatExecuteAsync<T>(IJsonRpcRequest jsonRpc, JsonSerializerSettings jsonSerializerSettings, byte loop, CancellationToken token)
        {
            if (string.IsNullOrEmpty(UrlToConnect))
                return new JsonRpcResponse<T>(new ArgumentNullException(nameof(UrlToConnect))) { RawRequest = jsonRpc.Message };

            try
            {
                var content = new StringContent(jsonRpc.Message);
                var response = await HttpClient.PostAsync(UrlToConnect, content, loop, token).ConfigureAwait(false);
                
                var stringResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var prop = JsonConvert.DeserializeObject<JsonRpcResponse<T>>(stringResponse, jsonSerializerSettings);
                prop.RawRequest = jsonRpc.Message;
                prop.RawResponse = stringResponse;
                return prop;
            }
            catch (Exception ex)
            {
                return new JsonRpcResponse<T>(ex)
                {
                    RawRequest = jsonRpc.Message
                };
            }
        }
    }
}
