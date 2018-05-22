using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Ditch.Core.Errors;
using Ditch.Core.Interfaces;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;
using SuperSocket.ClientEngine;
using WebSocket4Net;

namespace Ditch.Core
{
    public class WebSocketManager : IConnectionManager, IDisposable
    {
        private readonly Dictionary<int, JsonRpcResponse> _responseDictionary;
        private readonly Dictionary<int, ManualResetEvent> _manualResetEventDictionary;
        private readonly ManualResetEvent _socketOpenEvent;
        private readonly ManualResetEvent _socketCloseEvent;
        private WebSocket _webSocket;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        /// <summary>
        /// Timeout in milliseconds waiting for WebSocket request to execute. Default is 30000.
        /// </summary>
        public int WaitResponceTimeout { get; set; }

        /// <summary>
        /// Timeout in milliseconds waiting for WebSocket connect to chain. Default is 10000.
        /// </summary>
        public int WaitConnectTimeout { get; set; }

        public bool IsConnected => _webSocket.State == WebSocketState.Open;

        /// <summary>
        /// Manager for ws/wss connections
        /// </summary>
        /// <param name="jsonSerializerSettings">Specifies json settings</param>
        /// <param name="waitConnectTimeout"></param>
        /// <param name="waitResponceTimeout"></param>
        public WebSocketManager(JsonSerializerSettings jsonSerializerSettings, int waitConnectTimeout = 10000, int waitResponceTimeout = 30000)
        {
            WaitConnectTimeout = waitConnectTimeout;
            WaitResponceTimeout = waitResponceTimeout;
            _jsonSerializerSettings = jsonSerializerSettings;
            _responseDictionary = new Dictionary<int, JsonRpcResponse>();
            _manualResetEventDictionary = new Dictionary<int, ManualResetEvent>();
            _socketOpenEvent = new ManualResetEvent(false);
            _socketCloseEvent = new ManualResetEvent(false);
        }

        /// <summary>
        /// Connects and checks socket status
        /// </summary>
        /// <param name="url">The Uri the request is sent to.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Url which will be used for data transfer (empty if none)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public string ConnectTo(string url, CancellationToken token)
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
            token.ThrowIfCancellationRequested();
            return t == 1 ? url : string.Empty;
        }

        /// <summary>
        /// Connects and checks socket status
        /// </summary>
        /// <param name="urls">The Uri the request is sent to.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Url which will be used for data transfer (empty if none)</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public string ConnectTo(IEnumerable<string> urls, CancellationToken token)
        {
            foreach (var url in urls)
            {
                token.ThrowIfCancellationRequested();

                var connectedTo = ConnectTo(url, token);
                if (!string.IsNullOrWhiteSpace(connectedTo))
                    return connectedTo;
            }
            return string.Empty;
        }

        /// <summary>
        /// Cleans all wait handlers
        /// </summary>
        public void Disconnect()
        {
            if (_webSocket != null && (_webSocket.State == WebSocketState.Open || _webSocket.State == WebSocketState.Connecting))
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
        /// <param name="jsonRpc">Request body</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>JsonRpcResponse</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse Execute(IJsonRpcRequest jsonRpc, CancellationToken token)
        {
            var waiter = new ManualResetEvent(false);
            lock (_manualResetEventDictionary)
            {
                _manualResetEventDictionary.Add(jsonRpc.Id, waiter);
            }
            if (!OpenIfClosed(token))
                return new JsonRpcResponse(new SystemError(ErrorCodes.ConnectionTimeoutError));

            Debug.WriteLine($">>> {jsonRpc.Message}");
            _webSocket.Send(jsonRpc.Message);

            WaitHandle.WaitAny(new[] { token.WaitHandle, waiter }, WaitResponceTimeout);

            lock (_manualResetEventDictionary)
            {
                if (_manualResetEventDictionary.ContainsKey(jsonRpc.Id))
                    _manualResetEventDictionary.Remove(jsonRpc.Id);
                waiter.Dispose();
            }

            JsonRpcResponse response = null;
            lock (_responseDictionary)
            {
                if (_responseDictionary.ContainsKey(jsonRpc.Id))
                {
                    response = _responseDictionary[jsonRpc.Id];
                    _responseDictionary.Remove(jsonRpc.Id);
                }
            }

            token.ThrowIfCancellationRequested();

            if (response == null)
                return new JsonRpcResponse(new SystemError(ErrorCodes.ResponseTimeoutError));

            return response;
        }

        /// <summary>
        /// Sends request to specified url
        /// </summary>
        /// <typeparam name="T">Some type for response deserialization</typeparam>
        /// <param name="jsonRpc">Request body</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>Typed JsonRpcResponse</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<T> Execute<T>(IJsonRpcRequest jsonRpc, CancellationToken token)
        {
            var response = Execute(jsonRpc, token);
            return response.ToTyped<T>(_jsonSerializerSettings);
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
                            t = WaitHandle.WaitAny(new[] { token.WaitHandle, _socketOpenEvent }, WaitResponceTimeout);
                            token.ThrowIfCancellationRequested();
                            return t == 1;
                        }
                        return false;
                    }
                case WebSocketState.Connecting:
                    {
                        var t = WaitHandle.WaitAny(new[] { token.WaitHandle, _socketOpenEvent }, WaitResponceTimeout);
                        token.ThrowIfCancellationRequested();
                        return t == 1;
                    }
                case WebSocketState.None:
                case WebSocketState.Closed:
                    {
                        _webSocket.Open();
                        var t = WaitHandle.WaitAny(new[] { token.WaitHandle, _socketOpenEvent }, WaitResponceTimeout);
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
