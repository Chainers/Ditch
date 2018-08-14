using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cryptography.ECDSA;
using Ditch.Core;
using Ditch.Core.Interfaces;
using Ditch.Core.JsonRpc;
using Ditch.EOS.Models;
using Newtonsoft.Json;

namespace Ditch.EOS
{
    public partial class OperationManager
    {
        public MessageSerializer MessageSerializer { get; set; }

        public JsonSerializerSettings JsonSerializerSettings { get; set; }

        public IHttpClient HttpClient { get; set; }

        #region Constructors

        public OperationManager(IHttpClient httpClient)
        {
            HttpClient = httpClient;
            MessageSerializer = new MessageSerializer();
            JsonSerializerSettings = new JsonSerializerSettings();
        }

        #endregion Constructors

        public async Task<OperationResult<T>> CustomGetRequest<T>(string url, Dictionary<string, object> parameters, CancellationToken token)
        {
            var param = string.Empty;
            if (parameters != null && parameters.Count > 0)
                param = "?" + string.Join("&", parameters.Select(i => $"{i.Key}={i.Value}"));
            return await RepeatGetRequest<T>($"{url}{param}", token);
        }

        public async Task<OperationResult<T>> CustomGetRequest<T>(string url, CancellationToken token)
        {
            return await RepeatGetRequest<T>(url, token);
        }

        public async Task<OperationResult<T>> CustomPutRequest<T>(string url, object data, CancellationToken token)
        {
            return await RepeatPostRequest<T>(url, data, HttpClient.MaxRequestRepeatCount, token);
        }

        public async Task<OperationResult<T>> CustomPostRequest<T>(string url, object data, CancellationToken token)
        {
            return await RepeatPostRequest<T>(url, data, 0, token);
        }

        public async Task<OperationResult<PushTransactionResults>> BroadcastActions(BaseAction[] baseActions, List<byte[]> privateKeys, CancellationToken token)
        {
            var initOpRez = await AbiJsonToBin(baseActions, token);
            if (initOpRez.IsError)
                return new OperationResult<PushTransactionResults>(initOpRez);

            var infoResp = await GetInfo(token);
            if (infoResp.IsError)
                return new OperationResult<PushTransactionResults>(infoResp);

            var info = infoResp.Result;

            var blockArgs = new GetBlockParams
            {
                BlockNumOrId = info.HeadBlockId
            };
            var getBlock = await GetBlock(blockArgs, token);
            if (getBlock.IsError)
                return new OperationResult<PushTransactionResults>(getBlock);

            var block = getBlock.Result;

            var trx = new SignedTransaction
            {
                Actions = baseActions,
                RefBlockNum = (ushort)(block.BlockNum & 0xffff),
                RefBlockPrefix = block.RefBlockPrefix,
                Expiration = block.Timestamp.Value.AddSeconds(30)
            };

            var packedTrx = MessageSerializer.Serialize<SignedTransaction>(trx);

            var chainId = Hex.HexToBytes(info.ChainId);
            var msg = new byte[chainId.Length + packedTrx.Length + 32];
            Array.Copy(chainId, msg, chainId.Length);
            Array.Copy(packedTrx, 0, msg, chainId.Length, packedTrx.Length);
            var sha256 = Sha256Manager.GetHash(msg);

            var pack = new PackedTransaction
            {
                PackedTrx = Hex.ToString(packedTrx),
                Signatures = new string[privateKeys.Count],
                PackedContextFreeData = "",
                Compression = "none"
            };

            for (var i = 0; i < privateKeys.Count; i++)
            {
                var key = privateKeys[i];
                var sig = Secp256K1Manager.SignCompressedCompact(sha256, key);
                var sigHex = Base58.EncodeSig(sig);
                pack.Signatures[i] = sigHex;
            }

            return await PushTransaction(pack, token);
        }

        public async Task<OperationResult<PushTransactionResults>> BroadcastActions(BaseAction[] baseActions, PublicKey[] publicKeys, Func<SignedTransaction, PublicKey[], string, CancellationToken, Task<OperationResult<SignedTransaction>>> signFunc, CancellationToken token)
        {
            var initOpRez = await AbiJsonToBin(baseActions, token);
            if (initOpRez.IsError)
                return new OperationResult<PushTransactionResults>(initOpRez);

            var infoResp = await GetInfo(token);
            if (infoResp.IsError)
                return new OperationResult<PushTransactionResults>(infoResp);

            var info = infoResp.Result;

            var blockArgs = new GetBlockParams
            {
                BlockNumOrId = info.HeadBlockId
            };
            var getBlock = await GetBlock(blockArgs, token);
            if (getBlock.IsError)
                return new OperationResult<PushTransactionResults>(getBlock);

            var block = getBlock.Result;

            var trx = new SignedTransaction
            {
                Actions = baseActions,
                RefBlockNum = (ushort)(block.BlockNum & 0xffff),
                RefBlockPrefix = block.RefBlockPrefix,
                Expiration = block.Timestamp.Value.AddSeconds(30)
            };

            var strx = await signFunc.Invoke(trx, publicKeys, info.ChainId, token);
            if (strx.IsError)
                return new OperationResult<PushTransactionResults>(strx);

            var packedTrx = MessageSerializer.Serialize<SignedTransaction>(trx);

            var chainId = Hex.HexToBytes(info.ChainId);
            var msg = new byte[chainId.Length + packedTrx.Length + 32];
            Array.Copy(chainId, msg, chainId.Length);
            Array.Copy(packedTrx, 0, msg, chainId.Length, packedTrx.Length);

            var pack = new PackedTransaction
            {
                PackedTrx = Hex.ToString(packedTrx),
                PackedContextFreeData = "",
                Compression = "none",
                Signatures = strx.Result.Signatures
            };

            return await PushTransaction(pack, token);
        }

        public async Task<OperationResult<PushTransactionResults>> BroadcastActionsWithWallet(BaseAction[] baseActions, PublicKey[] publicKeys, CancellationToken token)
        {
            return await BroadcastActions(baseActions, publicKeys, WalletSignTransaction, token);
        }

        public async Task<OperationResult<VoidResponse>> AbiJsonToBin(BaseAction[] baseActions, CancellationToken token)
        {
            foreach (var action in baseActions)
            {
                if (action.Data != null)
                    continue;

                var abiJsonToBinArgs = new AbiJsonToBinParams
                {
                    Code = action.ContractName,
                    Action = action.Name,
                    Args = action.Args
                };
                var abiJsonToBin = await AbiJsonToBin(abiJsonToBinArgs, token);

                if (abiJsonToBin.IsError)
                    return new OperationResult<VoidResponse>(abiJsonToBin);

                action.Data = abiJsonToBin.Result.BinArgs;
            }
            return new OperationResult<VoidResponse>();
        }

        public virtual async Task<OperationResult<T>> CreateResult<T>(HttpResponseMessage response, CancellationToken ct)
        {
            var result = new OperationResult<T>();

            if (response.Content != null)
                result.RawResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                result.Exception = new HttpRequestException(result.RawResponse);
                return result;
            }

            if (response.Content == null)
            {
                result.Result = default(T);
                return result;
            }

            var mediaType = response.Content.Headers?.ContentType?.MediaType.ToLower();

            if (mediaType != null)
            {
                switch (mediaType)
                {
                    case "text/plain":
                    case "application/json":
                    case "text/html":
                        {
                            if (string.IsNullOrEmpty(result.RawResponse))
                                result.Result = default(T);
                            else
                                result.Result = JsonConvert.DeserializeObject<T>(result.RawResponse, JsonSerializerSettings);
                            break;
                        }
                    default:
                        {
                            result.Exception = new NotImplementedException(mediaType);
                            break;
                        }
                }
            }
            return result;
        }


        private async Task<OperationResult<T>> RepeatPostRequest<T>(string url, object data, byte loop, CancellationToken token)
        {
            var args = string.Empty;
            if (data != null)
                args = JsonConvert.SerializeObject(data, JsonSerializerSettings);

            if (string.IsNullOrEmpty(url))
                return new OperationResult<T>(new ArgumentNullException(nameof(url))) { RawRequest = $"POST(PUT): {url} {args}" };

            try
            {
                HttpContent content = args != null ? new StringContent(args, Encoding.UTF8, "application/json") : null;
                var response = await HttpClient.PostAsync(url, content, loop, token);

                response.EnsureSuccessStatusCode();

                var result = await CreateResult<T>(response, token);
                result.RawRequest = $"POST(PUT): {url} {args}";
                return result;

            }
            catch (Exception ex)
            {
                return new OperationResult<T>(ex)
                {
                    RawRequest = $"POST(PUT): {url} {args}",
                };
            }
        }

        private async Task<OperationResult<T>> RepeatGetRequest<T>(string url, CancellationToken token)
        {
            if (string.IsNullOrEmpty(url))
                return new OperationResult<T>(new ArgumentNullException(nameof(url))) { RawRequest = $"GET: {url}" };
            
            try
            {
                var response = await HttpClient.GetAsync(url, token);

                response.EnsureSuccessStatusCode();

                var result = await CreateResult<T>(response, token);
                result.RawRequest = $"GET: {url}";
                return result;
            }
            catch (Exception ex)
            {
                return new OperationResult<T>(ex)
                {
                    RawRequest = $"GET: {url}"
                };
            }
        }
    }
}
