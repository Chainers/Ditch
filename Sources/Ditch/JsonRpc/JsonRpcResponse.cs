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

        public bool IsError => Error != null;

        public static JsonRpcResponse FromString(string obj)
        {
            return JsonConvert.DeserializeObject<JsonRpcResponse>(obj, GlobalSettings.ChainInfo.JsonSerializerSettings);
        }

        public string GetErrorMessage()
        {
            return Error == null ? string.Empty : Error.ToString();
        }

        public JsonRpcResponse<T> ToTyped<T>()
        {
            var rez = new JsonRpcResponse<T>
            {
                Id = Id,
                Error = Error
            };
            if (Result != null)
                rez.Result = JsonConvert.DeserializeObject<T>(Result.ToString(), GlobalSettings.ChainInfo.JsonSerializerSettings);
            return rez;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class JsonRpcResponse<T> : JsonRpcResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result")]
        public new T Result { get; set; }

        public new static JsonRpcResponse<T> FromString(string obj)
        {
            return JsonConvert.DeserializeObject<JsonRpcResponse<T>>(obj, GlobalSettings.ChainInfo.JsonSerializerSettings);
        }
    }
}