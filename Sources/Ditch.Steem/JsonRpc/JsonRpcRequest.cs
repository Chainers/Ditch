using System;
using System.Threading;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Steem.JsonRpc
{
    public class JsonRpcRequest : IJsonRpcRequest
    {
        private static int _id;

        public int Id { get; }

        public string Message { get; }



        private JsonRpcRequest(int id, string message)
        {
            Id = id;
            Message = message;
        }

        private static int GetId()
        {
            var id = Interlocked.Increment(ref _id);
            if (id == int.MaxValue)
                Interlocked.Exchange(ref _id, 0);
            return id;
        }


        #region CondenserRequest

        public static JsonRpcRequest CondenserRequest(string api, string method)
        {
            var id = GetId();
            var message = $"{{\"method\":\"call\",\"params\":[\"{api}\",\"{method}\",[]],\"jsonrpc\":\"2.0\",\"id\":{id}}}";
            return new JsonRpcRequest(id, message);
        }

        public static JsonRpcRequest CondenserRequest(string api, string method, string data)
        {
            var id = GetId();
            var message = $"{{\"method\":\"call\",\"params\":[\"{api}\",\"{method}\",{data}],\"jsonrpc\":\"2.0\",\"id\":{id}}}";
            return new JsonRpcRequest(id, message);
        }

        public static JsonRpcRequest CondenserRequest(JsonSerializerSettings jsonSerializerSettings, string api, string method, object data)
        {
            var id = GetId();
            var jsonObj = data == null ? "[]" : JsonConvert.SerializeObject(data, jsonSerializerSettings);
            var message = $"{{\"method\":\"call\",\"params\":[\"{api}\",\"{method}\",{jsonObj}],\"jsonrpc\":\"2.0\",\"id\":{id}}}";
            return new JsonRpcRequest(id, message);
        }

        #endregion


        #region Request

        public static JsonRpcRequest Request(string api, string method)
        {
            var id = GetId();
            var message = $"{{\"jsonrpc\":\"2.0\",\"method\":\"{api}.{method}\",\"id\":{id}}}";
            return new JsonRpcRequest(id, message);
        }

        public static JsonRpcRequest Request(string api, string method, string data)
        {
            var id = GetId();
            var message = $"{{\"jsonrpc\":\"2.0\",\"method\":\"{api}.{method}\",\"params\":{data},\"id\":{id}}}";
            return new JsonRpcRequest(id, message);
        }

        public static JsonRpcRequest Request(JsonSerializerSettings jsonSerializerSettings, string api, string method, object data)
        {
            var id = GetId();
            var jsonObj = data == null ? "[]" : JsonConvert.SerializeObject(data, jsonSerializerSettings);
            var message = $"{{\"jsonrpc\":\"2.0\",\"method\":\"{api}.{method}\",\"params\":{jsonObj},\"id\":{id}}}";
            return new JsonRpcRequest(id, message);
        }

        #endregion
        
    }
}
