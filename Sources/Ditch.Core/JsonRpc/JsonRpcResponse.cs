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

        public JsonRpcResponse() { }

        public JsonRpcResponse(ErrorInfo systemError)
        {
            Error = systemError;
        }

        public static JsonRpcResponse FromString(string obj, JsonSerializerSettings jsonSerializerSettings)
        {
            return JsonConvert.DeserializeObject<JsonRpcResponse>(obj, jsonSerializerSettings);
        }

        public string GetErrorMessage()
        {
            return Error == null ? string.Empty : Error.ToString();
        }

        public JsonRpcResponse<T> ToTyped<T>(JsonSerializerSettings serializerSettings)
        {
            var rez = new JsonRpcResponse<T>
            {
                Id = Id,
                Error = Error
            };
            if (Result != null)
            {
                var t = typeof(T);
                switch (t.Name)
                {
                    case "Boolean":
                    case "Byte":
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Double":
                    case "String":
                        {
                            rez.Result = (T)Result;
                            break;
                        }
                    default:
                        {
                            rez.Result = JsonConvert.DeserializeObject<T>(Result.ToString(), serializerSettings);
                            break;
                        }
                }
            }
            return rez;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class JsonRpcResponse<T> : JsonRpcResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result")]
        public new T Result { get; set; }

        public new static JsonRpcResponse<T> FromString(string obj, JsonSerializerSettings serializerSettings)
        {
            return JsonConvert.DeserializeObject<JsonRpcResponse<T>>(obj, serializerSettings);
        }

        public JsonRpcResponse() { }

        public JsonRpcResponse(ErrorInfo systemError) : base(systemError) { }

        public JsonRpcResponse(T result)
        {
            Result = result;
        }
    }
}