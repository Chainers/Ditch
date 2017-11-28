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


        public HttpManager(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
            _client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        public bool IsConnected => !string.IsNullOrEmpty(_url);


        public string ConnectTo(string endpoin, CancellationToken tokent)
        {
            _url = string.Empty;
            var rez = _client.GetAsync(endpoin, tokent).Result;
            if (rez.StatusCode == HttpStatusCode.OK)
                _url = endpoin;

            return _url;
        }

        public string ConnectTo(IEnumerable<string> urls, CancellationToken token)
        {
            var rez = new List<KeyValuePair<string, long>>();
            var sw = new Stopwatch();
            long min = long.MaxValue;

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

        public void Disconnect()
        {
            _url = string.Empty;
        }

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

        public JsonRpcResponse<T> Execute<T>(JsonRpcRequest jsonRpc, CancellationToken token)
        {
            if (string.IsNullOrEmpty(_url))
                return null;

            var response = Execute(jsonRpc, token);
            return response.ToTyped<T>(_jsonSerializerSettings);
        }
    }
}
