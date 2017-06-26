using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
//using Common.Logging;
using Cryptography.ECDSA;
using Ditch.Helpers;
using Ditch.JsonRpc;
using Ditch.Operations;
using SuperSocket.ClientEngine;
using WebSocket4Net;

namespace Ditch
{
    public class TransactionManager
    {
        private List<BaseOperation> _operations;
        private byte[] _key;
        private ChainInfo _chainInfo;
        public WebSocket websocket;
        public AutoResetEvent m_SendedEvent = new AutoResetEvent(false);
        private AutoResetEvent m_CloseEvent = new AutoResetEvent(false);

        //protected static readonly ILog Log = LogManager.GetLogger(typeof(TransactionManager));

        public void InitTransactionManager(string wif, ChainManager.KnownChains chain, EventHandler<ErrorEventArgs> websocket_Error = null)
        {
            _key = Base58.GetBytes(wif);
            _operations = new List<BaseOperation>();
            _chainInfo = ChainManager.GetChainInfo(chain);
            Close();
            websocket = new WebSocket(_chainInfo.Url);
            websocket.EnableAutoSendPing = true;
            websocket.Opened += websocket_Opened;
            if (websocket_Error != null)
                websocket.Error += websocket_Error;
            websocket.Closed += websocket_Closed;
            websocket.MessageReceived += OnMessage;
            websocket.Open();
        }

        public void AddOperation(BaseOperation operation)
        {
            lock (_operations)
            {
                _operations.Add(operation);
            }
        }

        public void Broadcast()
        {
            Debug.WriteLine($">>>>> Broadcast {websocket.State}");
            lock (_operations)
            {
                if (!_operations.Any())
                    return;
            }

            switch (websocket.State)
            {
                case WebSocketState.Open:
                    {
                        websocket.Send(JsonRpcReques.GetReques("get_dynamic_global_properties"));
                        break;
                    }
                case WebSocketState.Closing:
                    {
                        if (m_CloseEvent.WaitOne(1000))
                        {
                            websocket.Open();
                        }
                        break;
                    }
                case WebSocketState.None:
                case WebSocketState.Closed:
                    {
                        websocket.Open();
                        break;
                    }
            }

            Debug.WriteLine(">>>>>! Broadcast");
        }

        private void websocket_Opened(object sender, EventArgs e)
        {
            Debug.WriteLine(">>>>> websocket_Opened");
            //m_OpenedEvent.Set();
            websocket.Send(JsonRpcReques.GetReques("get_dynamic_global_properties"));
        }

        private void websocket_Closed(object sender, EventArgs e)
        {
            Debug.WriteLine(">>>>> websocket_Closed");
            m_CloseEvent.Set();
        }



        private Transaction CreateTransaction(DynamicGlobalProperties properties)
        {
            Debug.WriteLine(">>>>> CreateTransaction");

            var transaction = new Transaction
            {
                ChainId = _chainInfo.ChainId,
                RefBlockNum = (ushort)(properties.HeadBlockNumber & 0xffff),
                RefBlockPrefix = (uint)BitConverter.ToInt32(Hex.HexToBytes(properties.HeadBlockId), 4),
                Expiration = properties.Time.AddSeconds(30)
            };

            lock (_operations)
            {
                transaction.BaseOperations = _operations.ToArray();
                _operations.Clear();
            }

            var msg = SerializeHelper.TransactionToMessage(transaction);
            var data = Secp256k1Manager.GetMessageHash(msg);
            var sig = Secp256k1Manager.SignCompressedCompact(data, _key);
            transaction.Signatures.Add(sig);

            Debug.WriteLine(">>>>>! CreateTransaction");
            return transaction;
        }

        private void OnMessage(object sender, MessageReceivedEventArgs e)
        {
            //Log.Info($"RESPONSE >>> {e.Data}");
            Debug.WriteLine($">>>>> OnMessage {e.Message}");
            try
            {
                var ws = (WebSocket)sender;

                var prop = JsonRpcResponse.FromString(e.Message);
                if (prop.Error != null)
                {
                    Debug.WriteLine($">>>>>! OnMessage Error: {prop.Error}");
                    //Log.Error(prop.Error.ToString());
                    return;
                }

                if (e.Message.Contains("head_block_number"))
                {
                    var paramResp = JsonRpcResponse<DynamicGlobalProperties>.FromString(e.Message);
                    var transaction = CreateTransaction(paramResp.Result);
                    var msg = JsonRpcReques.GetReques("call", 3, "broadcast_transaction", new[] { transaction });
                    //Log.Info($"REQUEST >>> {msg}");
                    Debug.WriteLine($">>>>> OnMessage msg: {msg}");
                    ws.Send(msg);
                }
                else
                {
                    m_SendedEvent.Set();
                }
                Debug.WriteLine($">>>>>! OnMessage");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($">>>>>! OnMessage {ex.Message} {ex.StackTrace}");
                //Log.Error(ex);
            }
        }

        public void Close()
        {
            Debug.WriteLine(">>>>> Close");
            if (websocket != null && websocket.State == WebSocketState.Open)
            {
                websocket.Close();
                Debug.WriteLine(">>>>>  websocket.Close();");
            }
            JsonRpcReques.Clean();
        }
    }
}