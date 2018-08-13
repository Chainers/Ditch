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
        private static readonly Random Random = new Random();

        public string UrlToConnect { get; private set; }

        public bool IsConnected => !string.IsNullOrEmpty(UrlToConnect);

        public int MaxRequestRepeatCount { get; }

        public long MaxResponseContentBufferSize { get; }


        public HttpManager()
        {
            MaxRequestRepeatCount = 3;
            MaxResponseContentBufferSize = 1024 * 1024;
        }

        public HttpManager(int maxRequestRepeatCount, long maxResponseContentBufferSize)
        {
            MaxRequestRepeatCount = maxRequestRepeatCount;
            MaxResponseContentBufferSize = maxResponseContentBufferSize;
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
        public async Task<bool> ConnectTo(string requestUrl, CancellationToken token)
        {
            UrlToConnect = string.Empty;

            if (string.IsNullOrEmpty(requestUrl))
                return false;

            HttpClient client = null;
            try
            {
                client = new HttpClient
                {
                    MaxResponseContentBufferSize = MaxResponseContentBufferSize
                };
                var response = await client.GetAsync(requestUrl, token);
                if (response.IsSuccessStatusCode)
                {
                    UrlToConnect = requestUrl;
                    return true;
                }
            }
            finally
            {
                client?.Dispose();
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
            return await RepeatExecuteAsync<T>(jsonRpc, jsonSerializerSettings, MaxRequestRepeatCount, token);
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
            return await RepeatExecuteAsync<T>(jsonRpc, jsonSerializerSettings, -1, token);
        }

        private async Task<JsonRpcResponse<T>> RepeatExecuteAsync<T>(IJsonRpcRequest jsonRpc, JsonSerializerSettings jsonSerializerSettings, int loop, CancellationToken token)
        {
            if (string.IsNullOrEmpty(UrlToConnect))
                return new JsonRpcResponse<T>(new ArgumentNullException(nameof(UrlToConnect))) { RawRequest = jsonRpc.Message };

            HttpResponseMessage response = null;
            HttpClient client = null;
            do
            {
                try
                {
                    loop++;
                    client = new HttpClient
                    {
                        MaxResponseContentBufferSize = MaxResponseContentBufferSize
                    };
                    var content = new StringContent(jsonRpc.Message);
                    response = await client.PostAsync(UrlToConnect, content, token);

                    response.EnsureSuccessStatusCode();

                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var prop = JsonConvert.DeserializeObject<JsonRpcResponse<T>>(stringResponse, jsonSerializerSettings);
                    prop.RawRequest = jsonRpc.Message;
                    prop.RawResponse = stringResponse;
                    return prop;
                }
                catch (Exception ex)
                {
                    if (loop > MaxRequestRepeatCount || token.IsCancellationRequested)
                    {
                        var stringResponse = string.Empty;
                        if (response?.Content != null)
                            stringResponse = await response.Content.ReadAsStringAsync();

                        return new JsonRpcResponse<T>(ex)
                        {
                            RawRequest = jsonRpc.Message,
                            RawResponse = stringResponse
                        };
                    }
                }
                finally
                {
                    client?.Dispose();
                }

                try
                {
                    await Task.Delay(1000 * loop + Random.Next(1, 5) * 100, token);
                }
                catch (Exception ex)
                {
                    return new JsonRpcResponse<T>(ex)
                    {
                        RawRequest = jsonRpc.Message,
                    };
                }
            } while (true);
        }
    }
}
