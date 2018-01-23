using Ditch.Core.JsonRpc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using Ditch.Core.Errors;

namespace Ditch.Core
{
    public class HttpManager : IConnectionManager
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly HttpClient _client;
        private string _url;


        public bool IsConnected => !string.IsNullOrEmpty(_url);

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


        /// <summary>
        /// Connects and checks http status
        /// </summary>  
        /// <param name="endpoin">The Uri the request is sent to.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Url which will be used for data transfer (empty if none)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public string ConnectTo(string endpoin, CancellationToken token)
        {
            _url = string.Empty;
            var rez = _client.GetAsync(endpoin, token).Result;
            if (rez.StatusCode == HttpStatusCode.OK)
                _url = endpoin;

            return _url;
        }

        /// <summary>
        /// Connects and checks http status
        /// </summary>
        /// <param name="urls">The Uri the request is sent to.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Url which will be used for data transfer (empty if none)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public string ConnectTo(IEnumerable<string> urls, CancellationToken token)
        {
            var rez = new List<KeyValuePair<string, long>>();
            var sw = new Stopwatch();
            var min = long.MaxValue;

            foreach (var url in urls)
            {
                sw.Restart();
                var buf = _client.GetAsync(url, token).Result;
                sw.Stop();
                if (buf.StatusCode == HttpStatusCode.OK)
                {
                    min = Math.Min(min, sw.ElapsedMilliseconds);
                    rez.Add(new KeyValuePair<string, long>(url, sw.ElapsedMilliseconds));
                }
            }

            if (min != long.MaxValue)
            {
                _url = rez.First(i => i.Value == min).Key;
                return _url;
            }

            return string.Empty;
        }

        /// <summary>
        /// Clears connection url
        /// </summary>
        public void Disconnect()
        {
            _url = string.Empty;
        }

        /// <summary>
        /// Sends request to specified url
        /// </summary>
        /// <param name="jsonRpc">Request body</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>JsonRpcResponse</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse Execute(JsonRpcRequest jsonRpc, CancellationToken token)
        {
            if (string.IsNullOrEmpty(_url))
                return null;

            var content = new StringContent(jsonRpc.Message);
            var response = _client.PostAsync(_url, content, token).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringResponse = response.Content.ReadAsStringAsync().Result;
                var prop = JsonRpcResponse.FromString(stringResponse, _jsonSerializerSettings);
                return prop;
            }

            return new JsonRpcResponse { Error = new HttpResponseError((int)response.StatusCode, "Http Error") };
        }

        /// <summary>
        /// Sends request to specified url
        /// </summary>
        /// <typeparam name="T">Some type for response deserialization</typeparam>
        /// <param name="jsonRpc">Request body</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Typed JsonRpcResponse</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> Execute<T>(JsonRpcRequest jsonRpc, CancellationToken token)
        {
            if (string.IsNullOrEmpty(_url))
                return null;

            var response = Execute(jsonRpc, token);
            return response.ToTyped<T>(_jsonSerializerSettings);
        }
    }
}
