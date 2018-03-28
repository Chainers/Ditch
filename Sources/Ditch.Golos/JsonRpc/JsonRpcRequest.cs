using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;

namespace Ditch.Golos.JsonRpc
{
    public struct JsonRpcRequest : IJsonRpcRequest
    {
        private static int _id = 0;

        public int Id { get; }

        public string Message { get; }


        public JsonRpcRequest(string method, string paramData = "[]")
        {
            Id = Interlocked.Increment(ref _id);
            if (Id == Int32.MaxValue)
                Interlocked.Exchange(ref _id, 0);

            Message = $"{{\"method\":\"{method}\",\"params\":{paramData},\"jsonrpc\":\"2.0\",\"id\":{Id}}}";
        }

        public JsonRpcRequest(JsonSerializerSettings jsonSerializerSettings, string method, object[] data)
            : this(method, data == null ? "[]" : JsonConvert.SerializeObject(data, jsonSerializerSettings)) { }
    }
}
