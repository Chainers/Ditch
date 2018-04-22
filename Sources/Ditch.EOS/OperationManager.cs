using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ditch.EOS.Errors;

namespace Ditch.EOS
{
    public partial class OperationManager
    {
        private readonly JsonNetConverter _jsonNetConverter;

        private readonly HttpClient _client;
        private List<string> _urls;
        private string _url;


        #region Constructors

        public OperationManager(long maxResponseContentBufferSize = 256000)
        {
            _jsonNetConverter = new JsonNetConverter();
            _client = new HttpClient
            {
                MaxResponseContentBufferSize = maxResponseContentBufferSize
            };
        }

        #endregion Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public string TryConnectTo(List<string> urls, CancellationToken token)
        {
            _urls = urls;
            _url = string.Empty;

            foreach (var url in urls)
            {
                try
                {
                    var rez = _client.GetAsync(url, token).Result;
                    if (rez?.StatusCode != null)
                    {
                        _url = url;
                        break;
                    }
                }
                catch (Exception e)
                {
                    //todo nothing
                    var t = e.Message;
                }
            }
            return _url;
        }


        public async Task<OperationResult<T>> CustomGetRequest<T>(string endpoint, Dictionary<string, object> parameters, CancellationToken token)
        {
            var param = string.Empty;
            if (parameters != null && parameters.Count > 0)
                param = "?" + string.Join("&", parameters.Select(i => $"{i.Key}={i.Value}"));

            var url = $"{_url}/{endpoint}{param}";
            var response = await _client.GetAsync(url, token);
            return await CreateResult<T>(response, token);
        }

        public async Task<OperationResult<T>> CustomGetRequest<T>(string endpoint, CancellationToken token)
        {
            var url = $"{_url}/{endpoint}";
            var response = await _client.GetAsync(url, token);
            return await CreateResult<T>(response, token);
        }


        public async Task<OperationResult<T>> CustomPostRequest<T>(string endpoint, object data, CancellationToken token)
        {
            HttpContent content = null;
            if (data != null)
            {
                var param = _jsonNetConverter.Serialize(data);
                Debug.WriteLine(param);
                content = new StringContent(param, Encoding.UTF8, "application/json");
            }

            var url = $"{_url}/{endpoint}";
            var response = await _client.PostAsync(url, content, token);
            return await CreateResult<T>(response, token);
        }


        protected virtual async Task<OperationResult<T>> CreateResult<T>(HttpResponseMessage response, CancellationToken ct)
        {
            var result = new OperationResult<T>();

            // HTTP error
            if (response.StatusCode == HttpStatusCode.InternalServerError ||
                response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.Created)
            {
                var content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(content);
                result.Error = new HttpError(response.StatusCode, content);
                return result;
            }

            if (response.Content == null)
                return result;

            var mediaType = response.Content.Headers?.ContentType?.MediaType.ToLower();

            if (mediaType != null)
            {
                if (mediaType.Equals("application/json"))
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result.Result = _jsonNetConverter.Deserialize<T>(content);
                }
                else
                {
                    result.Error = new ClientError(LocalizationKeys.UnsupportedMime);
                }
            }

            return result;
        }
    }

}

