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

        public async Task<OperationResult<T>> CustomGetRequestAsync<T>(string url, Dictionary<string, object> parameters, CancellationToken token)
        {
            var param = string.Empty;
            if (parameters != null && parameters.Count > 0)
                param = "?" + string.Join("&", parameters.Select(i => $"{i.Key}={i.Value}"));
            return await RepeatGetRequestAsync<T>($"{url}{param}", token).ConfigureAwait(false);
        }

        public async Task<OperationResult<T>> CustomGetRequestAsync<T>(string url, CancellationToken token)
        {
            return await RepeatGetRequestAsync<T>(url, token).ConfigureAwait(false);
        }

        public async Task<OperationResult<T>> CustomPutRequestAsync<T>(string url, object data, CancellationToken token)
        {
            return await RepeatPostRequestAsync<T>(url, data, HttpClient.MaxRequestRepeatCount, token).ConfigureAwait(false);
        }

        public async Task<OperationResult<T>> CustomPostRequestAsync<T>(string url, object data, CancellationToken token)
        {
            return await RepeatPostRequestAsync<T>(url, data, 0, token).ConfigureAwait(false);
        }

        public async Task<OperationResult<PushTransactionResults>> BroadcastActionsAsync(BaseAction[] baseActions, List<byte[]> privateKeys, CancellationToken token)
        {
            var initOpRez = await AbiJsonToBinAsync(baseActions, token).ConfigureAwait(false);
            if (initOpRez.IsError)
                return new OperationResult<PushTransactionResults>(initOpRez);

            var infoResp = await GetInfoAsync(token).ConfigureAwait(false);
            if (infoResp.IsError)
                return new OperationResult<PushTransactionResults>(infoResp);

            var info = infoResp.Result;

            var blockArgs = new GetBlockParams
            {
                BlockNumOrId = info.HeadBlockId
            };
            var getBlock = await GetBlockAsync(blockArgs, token).ConfigureAwait(false);
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
                PackedTrx = packedTrx,
                Signatures = new string[privateKeys.Count],
                PackedContextFreeData = new Bytes(),
                Compression = CompressionType.None
            };

            for (var i = 0; i < privateKeys.Count; i++)
            {
                var key = privateKeys[i];
                var sig = Secp256K1Manager.SignCompressedCompact(sha256, key);
                var sigHex = Base58.EncodeSig(sig);
                pack.Signatures[i] = sigHex;
            }

            return await PushTransactionAsync(pack, token).ConfigureAwait(false);
        }

        public async Task<OperationResult<PushTransactionResults>> BroadcastActionsAsync(BaseAction[] baseActions, PublicKey[] publicKeys, Func<SignedTransaction, PublicKey[], string, CancellationToken, Task<OperationResult<SignedTransaction>>> signFunc, CancellationToken token)
        {
            var initOpRez = await AbiJsonToBinAsync(baseActions, token).ConfigureAwait(false);
            if (initOpRez.IsError)
                return new OperationResult<PushTransactionResults>(initOpRez);

            var infoResp = await GetInfoAsync(token).ConfigureAwait(false);
            if (infoResp.IsError)
                return new OperationResult<PushTransactionResults>(infoResp);

            var info = infoResp.Result;

            var blockArgs = new GetBlockParams
            {
                BlockNumOrId = info.HeadBlockId
            };
            var getBlock = await GetBlockAsync(blockArgs, token).ConfigureAwait(false);
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

            var strx = await signFunc.Invoke(trx, publicKeys, info.ChainId, token).ConfigureAwait(false);
            if (strx.IsError)
                return new OperationResult<PushTransactionResults>(strx);

            var packedTrx = MessageSerializer.Serialize<SignedTransaction>(trx);

            var chainId = Hex.HexToBytes(info.ChainId);
            var msg = new byte[chainId.Length + packedTrx.Length + 32];
            Array.Copy(chainId, msg, chainId.Length);
            Array.Copy(packedTrx, 0, msg, chainId.Length, packedTrx.Length);

            var pack = new PackedTransaction
            {
                PackedTrx = packedTrx,
                PackedContextFreeData = new Bytes(),
                Compression = CompressionType.None,
                Signatures = strx.Result.Signatures
            };

            return await PushTransactionAsync(pack, token).ConfigureAwait(false);
        }

        public async Task<OperationResult<PushTransactionResults>> BroadcastActionsWithWalletAsync(BaseAction[] baseActions, PublicKey[] publicKeys, CancellationToken token)
        {
            return await BroadcastActionsAsync(baseActions, publicKeys, WalletSignTransactionAsync, token).ConfigureAwait(false);
        }

        public async Task<OperationResult<VoidResponse>> AbiJsonToBinAsync(BaseAction[] baseActions, CancellationToken token)
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
                var abiJsonToBin = await AbiJsonToBinAsync(abiJsonToBinArgs, token).ConfigureAwait(false);

                if (abiJsonToBin.IsError)
                    return new OperationResult<VoidResponse>(abiJsonToBin);

                action.Data = abiJsonToBin.Result.BinArgs;
            }
            return new OperationResult<VoidResponse>();
        }

        public virtual async Task<OperationResult<T>> CreateResultAsync<T>(HttpResponseMessage response, CancellationToken ct)
        {
            var result = new OperationResult<T>();

            if (response.Content != null)
                result.RawResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

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


        private async Task<OperationResult<T>> RepeatPostRequestAsync<T>(string url, object data, byte loop, CancellationToken token)
        {
            var args = string.Empty;
            if (data != null)
                args = JsonConvert.SerializeObject(data, JsonSerializerSettings);

            if (string.IsNullOrEmpty(url))
                return new OperationResult<T>(new ArgumentNullException(nameof(url))) { RawRequest = $"POST(PUT): {url} {args}" };

            try
            {
                HttpContent content = args != null ? new StringContent(args, Encoding.UTF8, "application/json") : null;
                var response = await HttpClient.PostAsync(url, content, loop, token).ConfigureAwait(false);
                var result = await CreateResultAsync<T>(response, token).ConfigureAwait(false);
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

        private async Task<OperationResult<T>> RepeatGetRequestAsync<T>(string url, CancellationToken token)
        {
            if (string.IsNullOrEmpty(url))
                return new OperationResult<T>(new ArgumentNullException(nameof(url))) { RawRequest = $"GET: {url}" };

            try
            {
                var response = await HttpClient.GetAsync(url, token).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                var result = await CreateResultAsync<T>(response, token).ConfigureAwait(false);
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
