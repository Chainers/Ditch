using Newtonsoft.Json;

namespace Ditch.JsonRpc
{
    [JsonObject(MemberSerialization.OptIn)]
    public struct JsonRpcReques
    {
        public const string GetDynamicGlobalProperties = "{\"method\":\"get_dynamic_global_properties\",\"params\":[],\"jsonrpc\":\"2.0\",\"id\":0}";

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public object[] Params { get; set; }

        [JsonProperty("jsonrpc")]
        public string JsonRpc => "2.0";

        [JsonProperty("id")]
        public int Id { get; set; }

        
        public JsonRpcReques(string method, int id, params object[] data)
        {
            Method = method;
            Params = data;
            Id = id;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}