using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using Ditch.Core.Errors;
using Ditch.Core.Interfaces;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;

namespace Ditch.Core
{
    public class HttpManager : IConnectionManager
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly HttpClient _client;

        public string UrlToConnect { get; private set; }

        public bool IsConnected => !string.IsNullOrEmpty(UrlToConnect);

        /// <summary>
        /// Manager for http connections
        /// </summary>
        /// <param name="jsonSerializerSettings">Specifies json settings</param>
        /// <param name="maxResponseContentBufferSize">Sets the maximum numbr of bytes to buffer when reading the response content.</param>
        public HttpManager(JsonSerializerSettings jsonSerializerSettings, long maxResponseContentBufferSize = 256000)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
            _client = new HttpClient
            {
                MaxResponseContentBufferSize = maxResponseContentBufferSize
            };
        }

        public HttpManager(JsonSerializerSettings jsonSerializerSettings, HttpClient client)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
            _client = client;
        }


        /// <summary>
        /// Connects and checks http status
        /// </summary>  
        /// <param name="requestUrl">The Uri the request is sent to.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Url which will be used for data transfer (empty if none)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public bool TryConnectTo(string requestUrl, CancellationToken token)
        {
            UrlToConnect = string.Empty;
            try
            {
                var rez = _client.GetAsync(requestUrl, token).Result;
                if (rez.StatusCode == HttpStatusCode.OK)
                {
                    UrlToConnect = requestUrl;
                    return true;
                }
            }
            catch
            {
                //todo nothing
            }
            return false;
        }

        /// <summary>
        /// Connects and checks http status
        /// </summary>
        /// <param name="requestUrls">The Uri the request is sent to.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Url which will be used for data transfer (empty if none)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public bool TryConnectTo(IEnumerable<string> requestUrls, CancellationToken token)
        {
            foreach (var url in requestUrls)
            {
                if (TryConnectTo(url, CancellationToken.None))
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
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Typed JsonRpcResponse</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> Execute<T>(IJsonRpcRequest jsonRpc, CancellationToken token)
        {
            if (string.IsNullOrEmpty(UrlToConnect))
                return null;

            var content = new StringContent(jsonRpc.Message);
            var response = _client.PostAsync(UrlToConnect, content, token).Result;
            var stringResponse = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var prop = JsonConvert.DeserializeObject<JsonRpcResponse<T>>(stringResponse, _jsonSerializerSettings);
                prop.RawRequest = jsonRpc.Message;
                prop.RawResponse = stringResponse;
                return prop;
            }

            return new JsonRpcResponse<T>
            {
                Error = new HttpResponseError((int)response.StatusCode, "Http Error"),
                RawRequest = jsonRpc.Message,
                RawResponse = stringResponse
            };
        }
    }
}
