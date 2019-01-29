using System.Threading;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Ethereum.JsonRpc
{
    public struct JsonRpcRequest : IJsonRpcRequest
    {
        private static int _id;

        public int Id { get; }

        public string Message { get; }


        public JsonRpcRequest(string method)
        {
            Id = Interlocked.Increment(ref _id);
            if (Id == int.MaxValue)
                Interlocked.Exchange(ref _id, 0);

            Message = $"{{\"method\":\"{method}\",\"params\":[],\"jsonrpc\":\"2.0\",\"id\":{Id}}}";
        }

        public JsonRpcRequest(string method, string paramData)
        {
            Id = Interlocked.Increment(ref _id);
            if (Id == int.MaxValue)
                Interlocked.Exchange(ref _id, 0);

            Message = string.IsNullOrEmpty(paramData)
                ? $"{{\"method\":\"{method}\",\"params\":[],\"jsonrpc\":\"2.0\",\"id\":{Id}}}"
                : $"{{\"method\":\"{method}\",\"params\":{paramData},\"jsonrpc\":\"2.0\",\"id\":{Id}}}";
        }

        public JsonRpcRequest(JsonSerializerSettings jsonSerializerSettings, string method, object[] data)
            : this(method, data == null ? "[]" : JsonConvert.SerializeObject(data, jsonSerializerSettings)) { }
    }
}
