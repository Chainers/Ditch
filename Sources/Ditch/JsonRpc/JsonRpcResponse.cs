using Newtonsoft.Json;

namespace Ditch.JsonRpc
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonRpcResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result")]
        public object Result { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "error")]
        public object Error { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        public static JsonRpcResponse FromString(string obj)
        {
            return JsonConvert.DeserializeObject<JsonRpcResponse>(obj);
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class JsonRpcResponse<T>
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result")]
        public T Result { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "error")]
        public object Error { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        public static JsonRpcResponse<T> FromString(string obj)
        {
            return JsonConvert.DeserializeObject<JsonRpcResponse<T>>(obj);
        }
    }
}