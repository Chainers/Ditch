using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.Interfaces;

namespace Ditch.Core
{
    public class RepeatHttpClient : HttpClient, IHttpClient
    {
        private static readonly Random Random = new Random();
        private readonly Dictionary<HttpClient, int> _httpClientSet;
        private HttpClient _current;

        public byte MaxRequestRepeatCount { get; }


        public RepeatHttpClient()
            : this(3, 1024 * 1024) { }

        public RepeatHttpClient(byte maxRequestRepeatCount, long maxResponseContentBufferSize)
        {
            MaxRequestRepeatCount = maxRequestRepeatCount;
            var client = new HttpClient
            {
                MaxResponseContentBufferSize = maxResponseContentBufferSize
            };
            _httpClientSet = new Dictionary<HttpClient, int> { { client, 0 } };
            _current = client;
        }


        public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, byte loopCount, CancellationToken token)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(requestUri),
                Content = content,
            };
            return await SendAsync(request, loopCount, token);
        }

        public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            var loopCount = request.Method == HttpMethod.Post ? (byte)0 : MaxRequestRepeatCount;
            return SendAsync(request, loopCount, token);
        }

        public virtual async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, byte loopCount, CancellationToken token)
        {
            var isfirst = true;
            var maxL = 0;
            do
            {
                //prevent "System.InvalidOperationException: Cannot send the same request message multiple times"
                var cloneRequest = await CloneHttpRequestMessageAsync(request);

                maxL++;
                HttpClient client = null;
                try
                {
                    if (isfirst)
                        isfirst = false;
                    else
                        await Task.Delay(1000 * maxL + Random.Next(1, 5) * 100, token);

                    lock (_httpClientSet)
                    {
                        client = _current;
                        _httpClientSet[client]++;
                    }

                    var msg = await client.SendAsync(cloneRequest, token);
                    if (msg.IsSuccessStatusCode || maxL >= loopCount)
                        return msg;

                    ResetClient(client);
                }
                catch (Exception)
                {
                    ResetClient(client);

                    if (token.IsCancellationRequested)
                        throw;

                    if (maxL >= loopCount)
                        throw;
                }
                finally
                {
                    if (client != null)
                    {
                        lock (_httpClientSet)
                        {
                            _httpClientSet[client]--;
                            if (client != _current && _httpClientSet[client] < 1)
                            {
                                _httpClientSet.Remove(client);
                                client.Dispose();
                            }
                        }
                    }
                }
            } while (true);
        }

        public static async Task<HttpRequestMessage> CloneHttpRequestMessageAsync(HttpRequestMessage req)
        {
            var clone = new HttpRequestMessage(req.Method, req.RequestUri)
            {
                Version = req.Version
            };

            // Copy the request's content (via a MemoryStream) into the cloned object
            var ms = new MemoryStream();
            if (req.Content != null)
            {
                await req.Content.CopyToAsync(ms).ConfigureAwait(false);
                ms.Position = 0;
                clone.Content = new StreamContent(ms);

                // Copy the content headers
                if (req.Content.Headers != null)
                    foreach (var h in req.Content.Headers)
                        clone.Content.Headers.Add(h.Key, h.Value);
            }

            foreach (var prop in req.Properties)
                clone.Properties.Add(prop);

            foreach (var header in req.Headers)
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);

            return clone;
        }


        private void ResetClient(HttpClient oldClient)
        {
            lock (_httpClientSet)
            {
                if (oldClient == _current)
                {
                    _current = new HttpClient
                    {
                        MaxResponseContentBufferSize = MaxResponseContentBufferSize
                    };
                    _httpClientSet.Add(_current, 0);
                }
            }
        }
    }
}
