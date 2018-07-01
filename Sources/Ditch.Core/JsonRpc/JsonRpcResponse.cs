using Ditch.Core.Converters;
using Ditch.Core.Errors;
using Newtonsoft.Json;

namespace Ditch.Core.JsonRpc
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonRpcResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result")]
        public object Result { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<ResponseError>))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "error")]
        public ErrorInfo Error { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        public bool IsError => Error != null;


#if DEBUG
        public string RawRequest { get; set; }

        public string RawResponse { get; set; }
#endif


        public JsonRpcResponse() { }

        public JsonRpcResponse(ErrorInfo systemError)
        {
            Error = systemError;
        }

        public string GetErrorMessage()
        {
            return Error?.ToString() ?? string.Empty;
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

        public JsonRpcResponse(ErrorInfo systemError) : base(systemError) { }

        public JsonRpcResponse(T result)
        {
            Result = result;
        }
    }
}