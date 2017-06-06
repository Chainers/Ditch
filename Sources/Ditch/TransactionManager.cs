using System;
using System.Collections.Generic;
//using Common.Logging;
using Cryptography.ECDSA;
using Ditch.JsonRpc;
using WebSocketSharp;

namespace Ditch
{
    public class TransactionManager
    {
        private readonly byte[] _key;
        private readonly List<BaseOperation> _operations;
        private readonly ChainInfo _chainInfo;

        //protected static readonly ILog Log = LogManager.GetLogger(typeof(TransactionManager));

        public TransactionManager(string wif, ChainManager.KnownChains chain)
        {
            _key = Base58.GetBytes(wif);
            _operations = new List<BaseOperation>();
            _chainInfo = ChainManager.GetChainInfo(chain);
        }

        public void AddOperation(BaseOperation operation)
        {
            lock (_operations)
            {
                _operations.Add(operation);
            }

            Broadcast();
        }

        private Transaction CreateTransaction(DynamicGlobalProperties properties)
        {
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
            var digest = Proxy.GetMessageHash(msg);
            var recoveryId = 0;
            var sig = Proxy.SignCompact(digest, _key, out recoveryId);
            recoveryId = recoveryId + 4 + 27;

            transaction.Signatures.Add(Hex.Join(new[] { (byte)recoveryId }, sig));
            return transaction;
        }

        private void Broadcast()
        {
            var msg = JsonRpcReques.GetDynamicGlobalProperties;

            using (var ws = new WebSocket(_chainInfo.Url))
            {
                ws.OnMessage += OnMessage;
                ws.OnError += (sender, e) =>
                {
                    var t = 0;
                    //Log.Error(e.Message, e.Exception);
                };

                ws.Connect();
                //Log.Info($"RESPONSE >>> {msg}");
                ws.Send(msg);

                while (ws.ReadyState != WebSocketState.Closed)
                {
                }
            }
        }

        private void OnMessage(object sender, MessageEventArgs e)
        {
            //Log.Info($"RESPONSE >>> {e.Data}");
            var ws = (WebSocket)sender;
            try
            {
                var prop = JsonRpcResponse.FromString(e.Data);
                if (prop.Error != null)
                {
                    //Log.Error(prop.Error.ToString());
                    ws.Close();
                    return;
                }

                if (prop.Id == 0)
                {
                    var paramResp = JsonRpcResponse<DynamicGlobalProperties>.FromString(e.Data);
                    var transaction = CreateTransaction(paramResp.Result);
                    var request = new JsonRpcReques("call", 1, 3, "broadcast_transaction", new[] { transaction });
                    var msg = request.ToString();

                    //Log.Info($"REQUEST >>> {msg}");
                    ws.Send(msg);
                }
                else
                {
                    ws.Close();
                }
            }
            catch (Exception ex)
            {
                //Log.Error(ex);
                if (ws != null && ws.ReadyState != WebSocketState.Closed)
                    ws.Close();
            }
        }
    }
}