using Newtonsoft.Json;

namespace Ditch.Core.Errors
{
    [JsonObject(MemberSerialization.OptIn)]
    public class HttpResponseError : ErrorInfo
    {
        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="message">ResponseError message</param>
        public HttpResponseError(string message) : base(message) { }

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="code">ResponseError code</param>
        /// <param name="message">ResponseError message</param>
        public HttpResponseError(long code, string message) : base(code, message) { }
    }
}