using System;
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

        public static Tuple<int, string> GetReques(string method)
        {
            int reqId = 0;
            lock (_sync)
            {
                reqId = _id;
                _id++;
            }

            return new Tuple<int, string>(reqId, $"{{\"method\":\"{method}\",\"params\":[],\"jsonrpc\":\"{JsonRpc}\",\"id\":{reqId}}}");
        }

        public static Tuple<int, string> GetReques(string method, params object[] data)
        {
            int reqId = 0;
            lock (_sync)
            {
                reqId = _id;
                _id++;
            }

            var paramData = JsonConvert.SerializeObject(data, GlobalSettings.ChainInfo.JsonSerializerSettings);
            return new Tuple<int, string>(reqId, $"{{\"method\":\"{method}\",\"params\":{paramData},\"jsonrpc\":\"{JsonRpc}\",\"id\":{reqId}}}");
        }

        public static void Init()
        {
            _id = 0;
        }
    }
}