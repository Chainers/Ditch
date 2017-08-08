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

namespace Ditch {
   internal class WebSocketManager: IDisposable {
      private readonly Dictionary<int, JsonRpcResponse> _responseDictionary;
      private readonly Dictionary<int, ManualResetEvent> _manualResetEventDictionary;
      private readonly ManualResetEvent _socketOpenEvent;
      private readonly ManualResetEvent _socketCloseEvent;
      private readonly WebSocket _webSocket;
      private readonly JsonSerializerSettings _jsonSerializerSettings;

      private readonly object _sync;
      private int _id;
      
      private int JsonRpsId {
         get {
            int reqId;
            lock (_sync) {
               reqId = _id;
               _id++;
            }
            return reqId;
         }
      }

      private int timeout = 30000;
      /// <summary>
      /// Timeout in milliseconds waiting for WebSocket request to execute. Default is 30000.
      /// </summary>
      public int Timeout { get { return timeout; } set { timeout = value; } }

      public WebSocketManager(string url, JsonSerializerSettings jsonSerializerSettings) {
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

      private string ToJsonRpc(int reqId, string method, params object[] data) {
         var paramData = (data == null) ? "[]" : JsonConvert.SerializeObject(data, _jsonSerializerSettings);
         return ToJsonRpc(reqId, method, paramData);
      }

      private string ToJsonRpc(int reqId, string method, string paramData) {
         return $"{{\"method\":\"{method}\",\"params\":{paramData},\"jsonrpc\":\"2.0\",\"id\":{reqId}}}";
      }

      public JsonRpcResponse Call(Api api, string operation, params object[] data) {
         var id = JsonRpsId;
         var msg = ToJsonRpc(id, "call", (int)api, operation, data);
         return Execute(id, msg);
      }

      public JsonRpcResponse Call(int api, string operation, params object[] data) {
         var id = JsonRpsId;
         var msg = ToJsonRpc(id, "call", api, operation, data);
         return Execute(id, msg);
      }

      public JsonRpcResponse<T> Call<T>(int api, string operation, params object[] data) {
         var id = JsonRpsId;
         var msg = ToJsonRpc(id, "call", api, operation, data);
         var resp = Execute(id, msg);
         return resp.ToTyped<T>(_jsonSerializerSettings);
      }

      public JsonRpcResponse<T> GetRequest<T>(string method, params object[] data) {
         var id = JsonRpsId;
         var msg = ToJsonRpc(id, method, data);
         var response = Execute(id, msg);
         return response.ToTyped<T>(_jsonSerializerSettings);
      }

      public JsonRpcResponse<T> GetRequest<T>(string method, string data) {
         var id = JsonRpsId;
         var msg = ToJsonRpc(id, method, data);
         var response = Execute(id, msg);
         return response.ToTyped<T>(_jsonSerializerSettings);
      }

      private JsonRpcResponse Execute(int id, string msg) {
         var waiter = new ManualResetEvent(false);
         lock (_manualResetEventDictionary) {
            _manualResetEventDictionary.Add(id, waiter);
         }
         if (!OpenIfClosed())
            return new JsonRpcResponse(new SystemError(ErrorCodes.ConnectionTimeoutError));

         _webSocket.Send(msg);

         waiter.WaitOne(Timeout);

         lock (_manualResetEventDictionary) {
            if (_manualResetEventDictionary.ContainsKey(id))
               _manualResetEventDictionary.Remove(id);
            waiter.Dispose();
         }

         JsonRpcResponse response = null;
         lock (_responseDictionary) {
            if (_responseDictionary.ContainsKey(id)) {
               response = _responseDictionary[id];
               _responseDictionary.Remove(id);
            }
         }

         if (response == null) {
            return new JsonRpcResponse(new SystemError(ErrorCodes.ResponseTimeoutError));
         }

         return response;
      }


      private bool OpenIfClosed() {
         switch (_webSocket.State) {
            case WebSocketState.Closing: {
                  if (_socketCloseEvent.WaitOne(1000)) {
                     _webSocket.Open();

                     if (_socketOpenEvent.WaitOne(Timeout)) {
                        return true;
                     }
                  }
                  return false;
               }
            case WebSocketState.Connecting: {
                  return _socketOpenEvent.WaitOne(Timeout);
               }
            case WebSocketState.None:
            case WebSocketState.Closed: {
                  _webSocket.Open();
                  return _socketOpenEvent.WaitOne(Timeout);
               }
            default:
               return true;
         }
      }

      private void WebSocketOpened(object sender, EventArgs e) {
         _socketOpenEvent.Set();
         _socketCloseEvent.Reset();
      }

      private void WebSocketClosed(object sender, EventArgs e) {
         _socketOpenEvent.Reset();
         _socketCloseEvent.Set();
      }

      private void WebSocketOnError(object sender, ErrorEventArgs errorEventArgs) {
         Debug.WriteLine($"{errorEventArgs.Exception.Message} | {errorEventArgs.Exception.StackTrace}");
      }

      private void WebSocketMessageReceived(object sender, MessageReceivedEventArgs e) {
         var prop = JsonRpcResponse.FromString(e.Message, _jsonSerializerSettings);
         lock (_responseDictionary) {
            if (_responseDictionary.ContainsKey(prop.Id))
               _responseDictionary[prop.Id] = prop;
            else
               _responseDictionary.Add(prop.Id, prop);
         }

         lock (_manualResetEventDictionary) {
            if (_manualResetEventDictionary.ContainsKey(prop.Id)) {
               _manualResetEventDictionary[prop.Id].Set();
            }
         }
      }

      #region IDisposable

      private bool _disposed;

      public void Dispose() {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      // Protected implementation of Dispose pattern.
      protected virtual void Dispose(bool disposing) {
         if (_disposed)
            return;

         if (disposing) {
            if (_webSocket != null && _webSocket.State == WebSocketState.Open) {
               _webSocket.Close();
               _socketCloseEvent.WaitOne();
            }

            lock (_manualResetEventDictionary) {
               foreach (var resetEvent in _manualResetEventDictionary) {
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