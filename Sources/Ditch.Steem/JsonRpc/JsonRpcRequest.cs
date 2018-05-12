using System;
using System.Threading;
using Newtonsoft.Json;
using Ditch.Core.JsonRpc;

namespace Ditch.Steem.JsonRpc
{
    public struct JsonRpcRequest : IJsonRpcRequest
    {
        private static int _id;

        public int Id { get; }

        public string Message { get; }


        public JsonRpcRequest(string api, string method)
        {
            Id = Interlocked.Increment(ref _id);
            if (Id == Int32.MaxValue)
                Interlocked.Exchange(ref _id, 0);

            Message = $"{{\"jsonrpc\":\"2.0\",\"method\":\"{api}.{method}\",\"id\":{Id}}}";
        }

        public JsonRpcRequest(string api, string method, string data = "[]")
        {
            Id = Interlocked.Increment(ref _id);
            if (Id == Int32.MaxValue)
                Interlocked.Exchange(ref _id, 0);

            Message = $"{{\"jsonrpc\":\"2.0\",\"method\":\"{api}.{method}\",\"params\":{data},\"id\":{Id}}}";
        }

        public JsonRpcRequest(JsonSerializerSettings jsonSerializerSettings, string api, string method, object data)
            : this(api, method, JsonConvert.SerializeObject(data, jsonSerializerSettings)) { }

    }
}
