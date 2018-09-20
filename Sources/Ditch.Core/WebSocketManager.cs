using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.Interfaces;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperSocket.ClientEngine;
using WebSocket4Net;

namespace Ditch.Core
{
    public class WebSocketManager : IConnectionManager, IDisposable
    {
        private readonly Dictionary<int, string> _responseDictionary = new Dictionary<int, string>();
        private readonly Dictionary<int, ManualResetEvent> _manualResetEventDictionary = new Dictionary<int, ManualResetEvent>();
        private readonly ManualResetEvent _socketOpenEvent = new ManualResetEvent(false);
        private readonly ManualResetEvent _socketCloseEvent = new ManualResetEvent(false);
        public int MaxRequestRepeatCount { get; }

        private WebSocket _webSocket;

        public string UrlToConnect { get; private set; }

        /// <summary>
        /// Timeout in milliseconds waiting for WebSocket request to execute. Default is 30000.
        /// </summary>
        public int WaitResponceTimeout { get; set; } = 30000;

        /// <summary>
        /// Timeout in milliseconds waiting for WebSocket connect to chain. Default is 10000.
        /// </summary>
        public int WaitConnectTimeout { get; set; } = 10000;

        public bool IsConnected => _webSocket?.State == WebSocketState.Open;


        public WebSocketManager() : this(3) { }

        public WebSocketManager(int maxRequestRepeatCount)
        {
            MaxRequestRepeatCount = maxRequestRepeatCount;
        }

        /// <summary>
        /// Connects and checks socket status
        /// </summary>
        /// <param name="url">The Uri the request is sent to.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Url which will be used for data transfer (empty if none)</returns>
        public Task<bool> ConnectToAsync(string url, CancellationToken token)
        {
            return Task.Run(() =>
            {
                Disconnect();

                _webSocket = new WebSocket(url);
                _webSocket.Opened += WebSocketOpened;
                _webSocket.Closed += WebSocketClosed;
                _webSocket.MessageReceived += WebSocketMessageReceived;
                _webSocket.Error += WebSocketOnError;
                _webSocket.EnableAutoSendPing = true;
                _webSocket.Open();

                var t = WaitHandle.WaitAny(new[] { token.WaitHandle, _socketOpenEvent }, WaitConnectTimeout);

                if (t == 1)
                {
                    UrlToConnect = url;
                    return true;
                }

                return false;
            }, token);
        }


        /// <summary>
        /// Cleans all wait handlers
        /// </summary>
        public void Disconnect()
        {
            UrlToConnect = string.Empty;
            if (_webSocket != null &&
                (_webSocket.State == WebSocketState.Open || _webSocket.State == WebSocketState.Connecting))
            {
                _webSocket.Close();
                WaitHandle.WaitAny(new WaitHandle[] { _socketCloseEvent }, WaitResponceTimeout);
            }

            lock (_manualResetEventDictionary)
            {
                foreach (var resetEvent in _manualResetEventDictionary)
                {
                    resetEvent.Value.Set();
                }
            }
        }

        /// <summary>
        /// Sends request to specified url
        /// </summary>
        /// <typeparam name="T">Some type for response deserialization</typeparam>
        /// <param name="jsonRpc">Request body</param>
        /// <param name="jsonSerializerSettings">Specifies json settings</param>
        /// <param name="token"></param>
        /// <returns>Typed JsonRpcResponse</returns>
        public Task<JsonRpcResponse<T>> ExecuteAsync<T>(IJsonRpcRequest jsonRpc, JsonSerializerSettings jsonSerializerSettings, CancellationToken token)
        {
            return Task.Run(() =>
            {
                if (!OpenIfClosed(token))
                {
                    if (token.IsCancellationRequested)
                        return new JsonRpcResponse<T>(new OperationCanceledException()) { RawRequest = jsonRpc.Message };
                    return new JsonRpcResponse<T>(new TimeoutException()) { RawRequest = jsonRpc.Message };
                }

                var waiter = new ManualResetEvent(false);
                lock (_manualResetEventDictionary)
                {
                    _manualResetEventDictionary.Add(jsonRpc.Id, waiter);
                }

                _webSocket.Send(jsonRpc.Message);

                WaitHandle.WaitAny(new[] { token.WaitHandle, waiter }, WaitResponceTimeout);

                lock (_manualResetEventDictionary)
                {
                    if (_manualResetEventDictionary.ContainsKey(jsonRpc.Id))
                        _manualResetEventDictionary.Remove(jsonRpc.Id);
                    waiter.Dispose();
                }

                lock (_responseDictionary)
                {
                    if (_responseDictionary.ContainsKey(jsonRpc.Id))
                    {
                        var json = _responseDictionary[jsonRpc.Id];
                        _responseDictionary.Remove(jsonRpc.Id);
                        var response = JsonConvert.DeserializeObject<JsonRpcResponse<T>>(json, jsonSerializerSettings);
                        response.RawResponse = json;
                        response.RawRequest = jsonRpc.Message;
                        return response;
                    }
                }

                if (token.IsCancellationRequested)
                    return new JsonRpcResponse<T>(new OperationCanceledException()) { RawRequest = jsonRpc.Message };
                return new JsonRpcResponse<T>(new TimeoutException()) { RawRequest = jsonRpc.Message };
            }, token);
        }

        public Task<JsonRpcResponse<T>> RepeatExecuteAsync<T>(IJsonRpcRequest jsonRpc, JsonSerializerSettings jsonSerializerSettings, CancellationToken token)
        {
            return Task.Run(() =>
            {
                var waiter = new ManualResetEvent(false);
                var rep = 0;
                int outId;
                do
                {
                    if (!OpenIfClosed(token))
                    {
                        if (token.IsCancellationRequested)
                            return new JsonRpcResponse<T>(new OperationCanceledException())
                            {
                                RawRequest = jsonRpc.Message
                            };
                        return new JsonRpcResponse<T>(new TimeoutException()) { RawRequest = jsonRpc.Message };
                    }

                    if (rep == 0)
                    {
                        lock (_manualResetEventDictionary)
                        {
                            _manualResetEventDictionary.Add(jsonRpc.Id, waiter);
                        }
                    }

                    _webSocket.Send(jsonRpc.Message);

                    outId = WaitHandle.WaitAny(new[] { token.WaitHandle, waiter }, WaitResponceTimeout);
                    rep++;
                } while (rep < MaxRequestRepeatCount && outId == WaitHandle.WaitTimeout);


                lock (_manualResetEventDictionary)
                {
                    if (_manualResetEventDictionary.ContainsKey(jsonRpc.Id))
                        _manualResetEventDictionary.Remove(jsonRpc.Id);
                    waiter.Dispose();
                }

                lock (_responseDictionary)
                {
                    if (_responseDictionary.ContainsKey(jsonRpc.Id))
                    {
                        var json = _responseDictionary[jsonRpc.Id];
                        _responseDictionary.Remove(jsonRpc.Id);
                        var response = JsonConvert.DeserializeObject<JsonRpcResponse<T>>(json, jsonSerializerSettings);
                        response.RawResponse = json;
                        response.RawRequest = jsonRpc.Message;
                        return response;
                    }
                }

                if (token.IsCancellationRequested)
                    return new JsonRpcResponse<T>(new OperationCanceledException()) { RawRequest = jsonRpc.Message };
                return new JsonRpcResponse<T>(new TimeoutException()) { RawRequest = jsonRpc.Message };
            }, token);
        }

        private bool OpenIfClosed(CancellationToken token)
        {
            switch (_webSocket.State)
            {
                case WebSocketState.Closing:
                    {
                        var t = WaitHandle.WaitAny(new[] { token.WaitHandle, _socketCloseEvent }, 1000);
                        if (t != 1)
                            return false;

                        _webSocket.Open();
                        t = WaitHandle.WaitAny(new[] { token.WaitHandle, _socketOpenEvent }, WaitResponceTimeout);
                        return t == 1;
                    }
                case WebSocketState.Connecting:
                    {
                        var t = WaitHandle.WaitAny(new[] { token.WaitHandle, _socketOpenEvent }, WaitResponceTimeout);
                        return t == 1;
                    }
                case WebSocketState.None:
                case WebSocketState.Closed:
                    {
                        _webSocket.Open();
                        var t = WaitHandle.WaitAny(new[] { token.WaitHandle, _socketOpenEvent }, WaitResponceTimeout);
                        return t == 1;
                    }
                case WebSocketState.Open:
                    return true;
                default:
                    return false;
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

        private static void WebSocketOnError(object sender, ErrorEventArgs errorEventArgs)
        {
            //Debug.WriteLine($"{errorEventArgs.Exception.Message} | {errorEventArgs.Exception.StackTrace}");
        }

        private void WebSocketMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            var prop = JsonConvert.DeserializeObject<JObject>(e.Message);
            var id = prop.Value<int>("id");

            lock (_manualResetEventDictionary)
            {
                if (!_manualResetEventDictionary.ContainsKey(id)) return;

                lock (_responseDictionary)
                {
                    if (_responseDictionary.ContainsKey(id))
                        _responseDictionary[id] = e.Message;
                    else
                        _responseDictionary.Add(id, e.Message);
                }
                _manualResetEventDictionary[id].Set();
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
                Disconnect();
                if (_webSocket != null)
                {
                    _webSocket.Dispose();
                    _webSocket = null;
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
