﻿using System;
using System.Threading;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.BitShares.JsonRpc
{
    public struct JsonRpcRequest : IJsonRpcRequest
    {
        private static int _id = 0;

        public int Id { get; }

        public string Message { get; }


        public JsonRpcRequest(string api, string method)
        {
            Id = Interlocked.Increment(ref _id);
            if (Id == Int32.MaxValue)
                Interlocked.Exchange(ref _id, 0);

            Message = $"{{\"method\":\"call\",\"params\":[\"{api}\",\"{method}\",[]],\"jsonrpc\":\"2.0\",\"id\":{Id}}}";

            UnityEngine.Debug.Log(Message);
        }

        public JsonRpcRequest(string api, string method, string paramData)
        {
            Id = Interlocked.Increment(ref _id);
            if (Id == Int32.MaxValue)
                Interlocked.Exchange(ref _id, 0);

            if (string.IsNullOrEmpty(paramData))
                Message = $"{{\"method\":\"call\",\"params\":[\"{api}\",\"{method}\",[]],\"jsonrpc\":\"2.0\",\"id\":{Id}}}";
            else
                Message = $"{{\"method\":\"call\",\"params\":[\"{api}\",\"{method}\",{paramData}],\"jsonrpc\":\"2.0\",\"id\":{Id}}}";

            UnityEngine.Debug.Log(Message);
        }

        public JsonRpcRequest(JsonSerializerSettings jsonSerializerSettings, string api, string method, object[] data)
            : this(api, method, data == null ? "[]" : JsonConvert.SerializeObject(data, jsonSerializerSettings)) { }
    }
}
