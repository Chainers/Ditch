using Newtonsoft.Json;

namespace Ditch.JsonRpc
{
    public class JsonRpcReques
    {
        private static readonly object _sync = new object();
        private static int _id = 0;

        [JsonProperty("jsonrpc")]
        public const string JsonRpc = "2.0";

        [JsonProperty("id")]
        public int Id { get; }


        public static string GetReques(string method)
        {
            int reqId = 0;
            lock (_sync)
            {
                reqId = _id;
                _id++;
            }
            return $"{{\"method\":\"{method}\",\"params\":[],\"jsonrpc\":\"{JsonRpc}\",\"id\":{reqId}}}";
        }

        public static string GetReques(string method, params object[] data)
        {
            int reqId = 0;
            lock (_sync)
            {
                reqId = _id;
                _id++;
            }

            var paramData = JsonConvert.SerializeObject(data);
            return $"{{\"method\":\"{method}\",\"params\":{paramData},\"jsonrpc\":\"{JsonRpc}\",\"id\":{reqId}}}";
        }

        public static void Clean()
        {
            _id = 0;
        }
    }
}