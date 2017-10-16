using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Ditch.Errors;
using Ditch.JsonRpc;
using Ditch.Operations;
using Newtonsoft.Json;
using SuperSocket.ClientEngine;
using WebSocket4Net;

namespace Ditch
{
    internal class WebSocketManager : IDisposable
    {
        private readonly Dictionary<int, JsonRpcResponse> _responseDictionary;
        private readonly Dictionary<int, ManualResetEvent> _manualResetEventDictionary;
        private readonly ManualResetEvent _socketOpenEvent;
        private readonly ManualResetEvent _socketCloseEvent;
        private WebSocket _webSocket;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        private readonly object _sync;
        private int _id;

        private int JsonRpsId
        {
            get
            {
                int reqId;
                lock (_sync)
                {
                    reqId = _id;
                    _id++;
                }
                return reqId;
            }
        }

        /// <summary>
        /// Timeout in milliseconds waiting for WebSocket request to execute. Default is 30000.
        /// </summary>
        public int Timeout { get; set; } = 30000;

        public WebSocketManager(string url, JsonSerializerSettings jsonSerializerSettings)
        {
            _sync = new object();
            _id = 0;
            _jsonSerializerSettings = jsonSerializerSettings;
            _responseDictionary = new Dictionary<int, JsonRpcResponse>();
            _manualResetEventDictionary = new Dictionary<int, ManualResetEvent>();
            _socketOpenEvent = new ManualResetEvent(false);
            _socketCloseEvent = new ManualResetEvent(false);

            _webSocket = new WebSocket(url);
            _webSocket.Opened += WebSocketOpened;
            _webSocket.Closed += WebSocketClosed;
            _webSocket.MessageReceived += WebSocketMessageReceived;
            _webSocket.Error += WebSocketOnError;
            _webSocket.EnableAutoSendPing = true;
            _webSocket.Open();
        }

        private string ToJsonRpc(int reqId, string method, params object[] data)
        {
            var paramData = (data == null) ? "[]" : JsonConvert.SerializeObject(data, _jsonSerializerSettings);
            return ToJsonRpc(reqId, method, paramData);
        }



        private string ToJsonRpc(int reqId, string method, string paramData)
        {
            return $"{{\"method\":\"{method}\",\"params\":{paramData},\"jsonrpc\":\"2.0\",\"id\":{reqId}}}";
        }

        private string ToJsonRpc(int reqId, string method)
        {
            return $"{{\"method\":\"{method}\",\"params\":[],\"jsonrpc\":\"2.0\",\"id\":{reqId}}}";
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request to "call" method.
        /// </summary>
        /// <param name="api">Api id key</param>
        /// <param name="command">Api command name</param>
        /// <param name="dataSet">The parameters of a method call.<remarks>Set "params" field in the JSON-RPC request. Uses JsonConvert to convert the object to a string.</remarks></param>
        /// <returns></returns>
        public JsonRpcResponse Call(Api api, string command, params object[] dataSet)
        {
            return Call(api, command, CancellationToken.None, dataSet);
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request to "call" method.
        /// </summary>
        /// <param name="api">Api id key</param>
        /// <param name="command">Api command name</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="dataSet">The parameters of a method call.<remarks>Set "params" field in the JSON-RPC request. Uses JsonConvert to convert the object to a string.</remarks></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse Call(Api api, string command, CancellationToken token, params object[] dataSet)
        {
            var id = JsonRpsId;
            var msg = ToJsonRpc(id, "call", (int)api, command, dataSet);
            return Execute(id, msg, token);
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request to "call" method.
        /// </summary>
        /// <param name="api">Api id key</param>
        /// <param name="command">Api command name</param>
        /// <param name="dataSet">The parameters of a method call.<remarks>Set "params" field in the JSON-RPC request. Uses JsonConvert to convert the object to a string.</remarks></param>
        /// <returns></returns>
        public JsonRpcResponse Call(int api, string command, params object[] dataSet)
        {
            return Call(api, command, CancellationToken.None, dataSet);
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request to "call" method.
        /// </summary>
        /// <param name="api">Api id key</param>
        /// <param name="command">Api command name</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="dataSet">The parameters of a method call.<remarks>Set "params" field in the JSON-RPC request. Uses JsonConvert to convert the object to a string.</remarks></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse Call(int api, string command, CancellationToken token, params object[] dataSet)
        {
            var id = JsonRpsId;
            var msg = ToJsonRpc(id, "call", api, command, dataSet);
            return Execute(id, msg, token);
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request to "call" method.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="api">Api id key</param>
        /// <param name="command">Api command name</param>
        /// <param name="dataSet">The parameters of a method call.<remarks>Set "params" field in the JSON-RPC request. Uses JsonConvert to convert the object to a string.</remarks></param>
        /// <returns></returns>
        public JsonRpcResponse<T> Call<T>(int api, string command, params object[] dataSet)
        {
            return Call<T>(api, command, CancellationToken.None, dataSet);
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request to "call" method.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="api">Api id key</param>
        /// <param name="command">Api command name</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="dataSet">The parameters of a method call.<remarks>Set "params" field in the JSON-RPC request. Uses JsonConvert to convert the object to a string.</remarks></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> Call<T>(int api, string command, CancellationToken token, params object[] dataSet)
        {
            var id = JsonRpsId;
            var msg = ToJsonRpc(id, "call", api, command, dataSet);
            var resp = Execute(id, msg, token);
            return resp.ToTyped<T>(_jsonSerializerSettings);
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="method">Set "method" field in the JSON-RPC request (as is)</param>
        /// <param name="dataSet">The parameters of a method call.<remarks>Set "params" field in the JSON-RPC request. Uses JsonConvert to convert the object to a string.</remarks></param>
        /// <returns></returns>
        public JsonRpcResponse<T> GetRequest<T>(string method, params object[] dataSet)
        {
            return GetRequest<T>(method, CancellationToken.None, dataSet);
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="method">Set "method" field in the JSON-RPC request (as is)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="dataSet">The parameters of a method call.<remarks>Set "params" field in the JSON-RPC request. Uses JsonConvert to convert the object to a string.</remarks></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> GetRequest<T>(string method, CancellationToken token, params object[] dataSet)
        {
            var id = JsonRpsId;
            var msg = ToJsonRpc(id, method, dataSet);
            var response = Execute(id, msg, token);
            return response.ToTyped<T>(_jsonSerializerSettings);
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="method">Set "method" field in the JSON-RPC request (as is)</param>
        /// <returns></returns>
        public JsonRpcResponse<T> GetRequest<T>(string method)
        {
            return GetRequest<T>(method, CancellationToken.None);
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="method">Set "method" field in the JSON-RPC request (as is)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> GetRequest<T>(string method, CancellationToken token)
        {
            var id = JsonRpsId;
            var msg = ToJsonRpc(id, method);
            var response = Execute(id, msg, token);
            return response.ToTyped<T>(_jsonSerializerSettings);
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="method">Set "method" field in the JSON-RPC request (as is)</param>
        /// <param name="data">The parameters of a method call.<remarks>Set "params" field in the JSON-RPC request. If the value is a simple string, then add quotes like \"someSimpleString\"</remarks></param>
        /// <returns></returns>
        public JsonRpcResponse<T> GetRequest<T>(string method, string data)
        {
            return GetRequest<T>(method, data, CancellationToken.None);
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="method">Set "method" field in the JSON-RPC request (as is)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="data">The parameters of a method call.<remarks>Set "params" field in the JSON-RPC request. If the value is a simple string, then add quotes like \"someSimpleString\"</remarks></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> GetRequest<T>(string method, string data, CancellationToken token)
        {
            var id = JsonRpsId;
            var msg = ToJsonRpc(id, method, data);
            var response = Execute(id, msg, token);
            return response.ToTyped<T>(_jsonSerializerSettings);
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="method">Set "method" field in the JSON-RPC request (as is)</param>
        /// <param name="dataSet">The parameters of a method call.<remarks>Set "params" field in the JSON-RPC request. Uses JsonConvert to convert the object to a string.</remarks></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> GetRequest<T>(string method, params string[] dataSet)
        {
            return GetRequest<T>(method, CancellationToken.None, dataSet);
        }

        /// <summary>
        /// Creates and executes a JSON-RPC request.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="method">Set "method" field in the JSON-RPC request (as is)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="dataSet">The parameters of a method call.<remarks>Set "params" field in the JSON-RPC request. Uses JsonConvert to convert the object to a string.</remarks></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> GetRequest<T>(string method, CancellationToken token, params string[] dataSet)
        {
            token.ThrowIfCancellationRequested();
            return GetRequest<T>(method, $"[\"{string.Join("\",\"", dataSet)}\"]", token);
        }


        private JsonRpcResponse Execute(int id, string msg, CancellationToken token)
        {
            var waiter = new ManualResetEvent(false);
            lock (_manualResetEventDictionary)
            {
                _manualResetEventDictionary.Add(id, waiter);
            }
            if (!OpenIfClosed(token))
                return new JsonRpcResponse(new SystemError(ErrorCodes.ConnectionTimeoutError));

            Debug.WriteLine($">>> {msg}");
            _webSocket.Send(msg);

            WaitHandle.WaitAny(new[] { token.WaitHandle, waiter }, Timeout);

            lock (_manualResetEventDictionary)
            {
                if (_manualResetEventDictionary.ContainsKey(id))
                    _manualResetEventDictionary.Remove(id);
                waiter.Dispose();
            }

            JsonRpcResponse response = null;
            lock (_responseDictionary)
            {
                if (_responseDictionary.ContainsKey(id))
                {
                    response = _responseDictionary[id];
                    _responseDictionary.Remove(id);
                }
            }

            token.ThrowIfCancellationRequested();

            if (response == null)
                return new JsonRpcResponse(new SystemError(ErrorCodes.ResponseTimeoutError));

            return response;
        }


        private bool OpenIfClosed(CancellationToken token)
        {
            switch (_webSocket.State)
            {
                case WebSocketState.Closing:
                    {
                        var t = WaitHandle.WaitAny(new[] { token.WaitHandle, _socketCloseEvent }, 1000);
                        token.ThrowIfCancellationRequested();
                        if (t == 1)
                        {
                            _webSocket.Open();
                            t = WaitHandle.WaitAny(new[] { token.WaitHandle, _socketOpenEvent }, Timeout);
                            token.ThrowIfCancellationRequested();
                            return t == 1;
                        }
                        return false;
                    }
                case WebSocketState.Connecting:
                    {
                        var t = WaitHandle.WaitAny(new[] { token.WaitHandle, _socketOpenEvent }, Timeout);
                        token.ThrowIfCancellationRequested();
                        return t == 1;
                    }
                case WebSocketState.None:
                case WebSocketState.Closed:
                    {
                        _webSocket.Open();
                        var t = WaitHandle.WaitAny(new[] { token.WaitHandle, _socketOpenEvent }, Timeout);
                        token.ThrowIfCancellationRequested();
                        return t == 1;
                    }
                default:
                    return true;
            }
        }

        private void WebSocketOpened(object sender, EventArgs e)
        {
            _socketOpenEvent.Set();
            _socketCloseEvent.Reset();
        }

        private void WebSocketClosed(object sender, EventArgs e)
        {
            _socketOpenEvent.Reset();
            _socketCloseEvent.Set();
        }

        private void WebSocketOnError(object sender, ErrorEventArgs errorEventArgs)
        {
            Debug.WriteLine($"{errorEventArgs.Exception.Message} | {errorEventArgs.Exception.StackTrace}");
        }

        private void WebSocketMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Debug.WriteLine($"<<< {e.Message}");
            var prop = JsonRpcResponse.FromString(e.Message, _jsonSerializerSettings);
            lock (_manualResetEventDictionary)
            {
                if (!_manualResetEventDictionary.ContainsKey(prop.Id)) return;

                lock (_responseDictionary)
                {
                    if (_responseDictionary.ContainsKey(prop.Id))
                        _responseDictionary[prop.Id] = prop;
                    else
                        _responseDictionary.Add(prop.Id, prop);
                }
                _manualResetEventDictionary[prop.Id].Set();
            }
        }

        #region IDisposable

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (_webSocket != null && _webSocket.State == WebSocketState.Open)
                {
                    _webSocket.Dispose();
                    _webSocket = null;
                }

                lock (_manualResetEventDictionary)
                {
                    foreach (var resetEvent in _manualResetEventDictionary)
                    {
                        resetEvent.Value.Set();
                    }
                }
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            _disposed = true;
        }

        #endregion IDisposable
    }
}