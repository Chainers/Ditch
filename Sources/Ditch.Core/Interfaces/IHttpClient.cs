using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ditch.Core.Interfaces
{
    public interface IHttpClient
    {
        byte MaxRequestRepeatCount { get; }

        Task<HttpResponseMessage> GetAsync(string requestUrl, CancellationToken token);

        Task<HttpResponseMessage> PostAsync(string urlToConnect, HttpContent content, byte loop, CancellationToken token);
    }
}