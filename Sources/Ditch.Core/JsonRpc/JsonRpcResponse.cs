using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.Core.JsonRpc
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonRpcResponse
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result")]
        public object Result { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "error")]
        public JObject ResponseError { get; set; }

        public Exception Exception { get; }

        public bool IsError => ResponseError != null || Exception != null;

        public string RawRequest { get; set; }

        public string RawResponse { get; set; }

        public JsonRpcResponse() { }

        public JsonRpcResponse(Exception exception)
        {
            Exception = exception;
        }

        public JsonRpcResponse(JsonRpcResponse response)
        {
            Exception = response.Exception;
            ResponseError = response.ResponseError;
            RawRequest = response.RawRequest;
            RawResponse = response.RawResponse;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class JsonRpcResponse<T> : JsonRpcResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result")]
        public new T Result
        {
            get => (T)base.Result;
            set => base.Result = value;
        }

        public JsonRpcResponse() { }

        public JsonRpcResponse(Exception exception) : base(exception) { }

        public JsonRpcResponse(JsonRpcResponse response) : base(response) { }

        public JsonRpcResponse(T result)
        {
            Result = result;
        }
    }
}