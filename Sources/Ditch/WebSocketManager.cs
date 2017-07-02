using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
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
            GlobalSettings.SettingsChanged += SettingsChanged;
            SettingsChanged();
        }



        public static void SettingsChanged()
        {
            Close();
            _websocket?.Dispose();
            _websocket = new WebSocket(GlobalSettings.ChainInfo.Url);
            _websocket.Opened += websocket_Opened;
            _websocket.Closed += websocket_Closed;
            _websocket.MessageReceived += websocket_MessageReceived;
            _websocket.Error += WebsocketOnError;
            _websocket.EnableAutoSendPing = true;
            _websocket.Open();
        }

        public JsonRpcResponse Call(int api, string operation, params object[] data)
        {
            var msg = JsonRpcReques.GetReques("call", api, operation, data);
            return Execute(msg);
        }

        public JsonRpcResponse<T> Call<T>(int api, string operation, params object[] data)
        {
            var msg = JsonRpcReques.GetReques("call", api, operation, data);
            var resp = Execute(msg);
            return resp.ToTyped<T>();
        }

        public JsonRpcResponse<T> GetRequest<T>(string request)
        {
            var msg = JsonRpcReques.GetReques(request);
            var responce = Execute(msg);
            return responce.ToTyped<T>();
        }

        public JsonRpcResponse<T> GetRequest<T>(string request, params object[] data)
        {
            var msg = JsonRpcReques.GetReques(request, data);
            var responce = Execute(msg);
            return responce.ToTyped<T>();
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
                return new JsonRpcResponse { Error = new ErrorResponce("execution has timed-out") };
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


        private static void websocket_Opened(object sender, EventArgs e)
        {
            SocketOpenEvent.Set();
            SocketCloseEvent.Reset();
        }

        private static void websocket_Closed(object sender, EventArgs e)
        {
            SocketOpenEvent.Reset();
            SocketCloseEvent.Set();
        }

        private static void WebsocketOnError(object sender, ErrorEventArgs errorEventArgs)
        {
            Debug.WriteLine($"{errorEventArgs.Exception.Message} | {errorEventArgs.Exception.StackTrace}");
        }

        private static void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
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


        public static void Close()
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