using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ditch.JsonRpc;
using SuperSocket.ClientEngine;
using WebSocket4Net;

namespace Ditch
{
    internal class WebSocketManager
    {
        private static readonly Dictionary<int, JsonRpcResponse> ResponceDictionary;
        private static readonly Dictionary<int, ManualResetEvent> ManualResetEventDictionary;
        private static readonly ManualResetEvent SocketOpenEvent;
        private static readonly ManualResetEvent SocketCloseEvent;

        private static WebSocket _websocket;

        static WebSocketManager()
        {
            ResponceDictionary = new Dictionary<int, JsonRpcResponse>();
            ManualResetEventDictionary = new Dictionary<int, ManualResetEvent>();
            SocketOpenEvent = new ManualResetEvent(false);
            SocketCloseEvent = new ManualResetEvent(false);
        }

        public void InitTransactionManager(string url, EventHandler<ErrorEventArgs> websocketError = null)
        {
            Close();
            _websocket?.Dispose();
            _websocket = new WebSocket(url);
            _websocket.EnableAutoSendPing = true;
            _websocket.Opened += websocket_Opened;
            _websocket.Closed += websocket_Closed;
            _websocket.MessageReceived += websocket_MessageReceived;

            if (websocketError != null)
                _websocket.Error += websocketError;

            _websocket.Open();
        }


        public Task<JsonRpcResponse> BroadcastTransaction(Transaction transaction)
        {
            return new Task<JsonRpcResponse>(() =>
            {
                //{'follow': 5, 'account_by_key': 2, 'network_broadcast': 3, 'database': 0}
                var msg = JsonRpcReques.GetReques("call", 3, "broadcast_transaction", new[] { transaction });
                return Execute(msg);
            });
        }

        public Task<JsonRpcResponse> Call(int api, string operation, params object[] data)
        {
            return new Task<JsonRpcResponse>(() =>
            {
                var msg = JsonRpcReques.GetReques("call", api, operation, data);
                return Execute(msg);
            });
        }

        public Task<JsonRpcResponse<T>> Call<T>(int api, string operation, params object[] data)
        {
            return new Task<JsonRpcResponse<T>>(() =>
            {
                var msg = JsonRpcReques.GetReques("call", api, operation, data);
                var resp = Execute(msg);
                return resp.ToTyped<T>();
            });
        }

        public Task<JsonRpcResponse<T>> GetRequest<T>(string request)
        {
            return new Task<JsonRpcResponse<T>>(() =>
            {
                var msg = JsonRpcReques.GetReques(request);
                var responce = Execute(msg);

                return responce.ToTyped<T>();
            });
        }


        private JsonRpcResponse Execute(Tuple<int, string> msg)
        {
            var vaiter = new ManualResetEvent(false);
            lock (ManualResetEventDictionary)
            {
                ManualResetEventDictionary.Add(msg.Item1, vaiter);
            }
            OpenIfClosed();
            _websocket.Send(msg.Item2);

            vaiter.WaitOne(30000);

            lock (ManualResetEventDictionary)
            {
                if (ManualResetEventDictionary.ContainsKey(msg.Item1))
                    ManualResetEventDictionary.Remove(msg.Item1);
                vaiter.Dispose();
            }

            JsonRpcResponse responce = null;
            lock (ResponceDictionary)
            {
                if (ResponceDictionary.ContainsKey(msg.Item1))
                {
                    responce = ResponceDictionary[msg.Item1];
                    ResponceDictionary.Remove(msg.Item1);
                }
            }

            if (responce == null)
            {
                return new JsonRpcResponse { Error = "execution has timed-out" };
            }

            return responce;
        }


        private void OpenIfClosed()
        {
            switch (_websocket.State)
            {
                case WebSocketState.Closing:
                    {
                        if (SocketCloseEvent.WaitOne(1000))
                        {
                            _websocket.Open();
                            SocketOpenEvent.WaitOne();
                        }
                        break;
                    }
                case WebSocketState.Connecting:
                    {
                        SocketOpenEvent.WaitOne();
                        break;
                    }
                case WebSocketState.None:
                case WebSocketState.Closed:
                    {
                        _websocket.Open();
                        SocketOpenEvent.WaitOne();
                        break;
                    }
            }
        }


        private void websocket_Opened(object sender, EventArgs e)
        {
            SocketOpenEvent.Set();
            SocketCloseEvent.Reset();
        }

        private void websocket_Closed(object sender, EventArgs e)
        {
            SocketOpenEvent.Reset();
            SocketCloseEvent.Set();
        }

        private void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            var prop = JsonRpcResponse.FromString(e.Message);
            lock (ResponceDictionary)
            {
                if (ResponceDictionary.ContainsKey(prop.Id))
                    ResponceDictionary[prop.Id] = prop;
                else
                    ResponceDictionary.Add(prop.Id, prop);
            }

            lock (ManualResetEventDictionary)
            {
                if (ManualResetEventDictionary.ContainsKey(prop.Id))
                {
                    ManualResetEventDictionary[prop.Id].Set();
                }
            }
        }


        public void Close()
        {
            if (_websocket != null && _websocket.State == WebSocketState.Open)
            {
                _websocket.Close();
                SocketCloseEvent.WaitOne();
            }
            JsonRpcReques.Init();

            lock (ManualResetEventDictionary)
            {
                foreach (var resetEvent in ManualResetEventDictionary)
                {
                    resetEvent.Value.Set();
                }
            }
        }
    }
}