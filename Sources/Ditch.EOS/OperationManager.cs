﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cryptography.ECDSA;
using Ditch.Core;
using Ditch.Core.JsonRpc;
using Ditch.EOS.Models;
using Newtonsoft.Json;

namespace Ditch.EOS
{
    public partial class OperationManager
    {
        private readonly HttpClient _client;
        public MessageSerializer MessageSerializer { get; set; }
        public JsonSerializerSettings JsonSerializerSettings { get; set; }

        #region Constructors

        public OperationManager()
            : this(new HttpClient()) { }

        public OperationManager(long maxResponseContentBufferSize)
            : this(new HttpClient { MaxResponseContentBufferSize = maxResponseContentBufferSize }) { }

        public OperationManager(HttpClient client)
        {
            _client = client;
            MessageSerializer = new MessageSerializer();
            JsonSerializerSettings = new JsonSerializerSettings();
        }

        #endregion Constructors

        public async Task<OperationResult<T>> CustomGetRequest<T>(string url, Dictionary<string, object> parameters, CancellationToken token)
        {
            var param = string.Empty;
            if (parameters != null && parameters.Count > 0)
                param = "?" + string.Join("&", parameters.Select(i => $"{i.Key}={i.Value}"));

            var response = await _client.GetAsync($"{url}{param}", token);
            var result = await CreateResult<T>(response, token);

            result.RawRequest = $"GET: {url}{param}";

            return result;
        }

        public async Task<OperationResult<T>> CustomGetRequest<T>(string url, CancellationToken token)
        {
            var response = await _client.GetAsync(url, token);
            var result = await CreateResult<T>(response, token);

            result.RawRequest = $"GET: {url}";

            return result;
        }

        public async Task<OperationResult<T>> CustomPostRequest<T>(string url, object data, CancellationToken token)
        {
            HttpContent content = null;
            var param = string.Empty;
            if (data != null)
            {
                param = JsonConvert.SerializeObject(data, JsonSerializerSettings);
                content = new StringContent(param, Encoding.UTF8, "application/json");
            }

            var response = await _client.PostAsync(url, content, token);
            var result = await CreateResult<T>(response, token);

            result.RawRequest = $"POST: {url} {param}";

            return result;
        }

        public async Task<OperationResult<PushTransactionResults>> BroadcastOperations(Operation[] operations, List<byte[]> privateKeys, CancellationToken token)
        {
            var initOpRez = await AbiJsonToBin(operations, token);
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
                Actions = operations,
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

        public async Task<OperationResult<VoidResponse>> AbiJsonToBin(Operation[] operations, CancellationToken token)
        {
            foreach (var operation in operations)
            {
                if (operation.Data != null)
                    continue;

                var abiJsonToBinArgs = new AbiJsonToBinParams
                {
                    Code = operation.ContractName,
                    Action = operation.Name,
                    Args = operation.Args
                };
                var abiJsonToBin = await AbiJsonToBin(abiJsonToBinArgs, token);

                if (abiJsonToBin.IsError)
                    return new OperationResult<VoidResponse>(abiJsonToBin);

                operation.Data = abiJsonToBin.Result.BinArgs;
            }
            return new OperationResult<VoidResponse>();
        }

        protected virtual async Task<OperationResult<T>> CreateResult<T>(HttpResponseMessage response, CancellationToken ct)
        {
            var result = new OperationResult<T>();

            if (response.Content != null)
                result.RawResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                result.Error = new HttpRequestException(result.RawResponse);
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
                            result.Error = new NotImplementedException(mediaType);
                            break;
                        }
                }
            }
            return result;
        }
    }
}
