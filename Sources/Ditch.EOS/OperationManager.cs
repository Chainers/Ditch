using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cryptography.ECDSA;
using Ditch.Core;
using Ditch.EOS.Errors;
using Ditch.EOS.Models;
using Newtonsoft.Json;

namespace Ditch.EOS
{
    public partial class OperationManager
    {
        private readonly HttpClient _client;
        public MessageSerializer MessageSerializer { get; }

        #region Constructors

        public OperationManager(long maxResponseContentBufferSize = 256000)
        {
            _client = new HttpClient
            {
                MaxResponseContentBufferSize = maxResponseContentBufferSize
            };
            MessageSerializer = new MessageSerializer();
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
                param = JsonConvert.SerializeObject(data, Formatting.Indented);
                content = new StringContent(param, Encoding.UTF8, "application/json");
            }

            var response = await _client.PostAsync(url, content, token);
            var result = await CreateResult<T>(response, token);

            result.RawRequest = $"POST: {url}{Environment.NewLine}{param}";

            return result;
        }


        protected virtual async Task<OperationResult<T>> CreateResult<T>(HttpResponseMessage response, CancellationToken ct)
        {
            var result = new OperationResult<T>();

            var content = await response.Content.ReadAsStringAsync();

            result.RawResponse = content;

            // HTTP error
            if (response.StatusCode == HttpStatusCode.InternalServerError ||
                response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.Created &&
                response.StatusCode != HttpStatusCode.Accepted)
            {
                result.Error = new HttpError(content);
                return result;
            }

            if (response.Content == null)
                return result;

            var mediaType = response.Content.Headers?.ContentType?.MediaType.ToLower();

            if (mediaType != null)
            {
                if (mediaType.Equals("application/json"))
                {
                    result.Result = JsonConvert.DeserializeObject<T>(content);
                }
                else
                {
                    result.Error = new ClientError(LocalizationKeys.UnsupportedMime);
                }
            }

            return result;
        }

        public async Task<PackedTransaction> CreatePackedTransaction(CreateTransactionArgs args, CancellationToken token)
        {
            //1
            var infoResp = await GetInfo(token);
            if (infoResp.IsError)
                return null;

            var info = infoResp.Result;

            //2
            var blockArgs = new GetBlockParams
            {
                BlockNumOrId = info.HeadBlockId
            };
            var getBlock = await GetBlock(blockArgs, token);
            if (getBlock.IsError)
                return null;

            var block = getBlock.Result;

            //3
            var transaction = new SignedTransaction
            {
                RefBlockNum = (ushort)(block.BlockNum & 0xffff),
                RefBlockPrefix = block.RefBlockPrefix,
                Expiration = block.Timestamp.Value.AddSeconds(30),
                Actions = args.Actions
            };

            var packedTrx = MessageSerializer.Serialize<SignedTransaction>(transaction);

            var chainId = Hex.HexToBytes(info.ChainId);
            var msg = new byte[chainId.Length + packedTrx.Length + 32];
            Array.Copy(chainId, msg, chainId.Length);
            Array.Copy(packedTrx, 0, msg, chainId.Length, packedTrx.Length);
            var sha256 = Sha256Manager.GetHash(msg);

            transaction.Signatures = new string[args.PrivateKeys.Count];
            for (var i = 0; i < args.PrivateKeys.Count; i++)
            {
                var key = args.PrivateKeys[i];
                var sig = Secp256K1Manager.SignCompressedCompact(sha256, key);
                var sigHex = Base58.EncodeSig(sig);
                transaction.Signatures[i] = sigHex;
            }

            return new PackedTransaction
            {
                PackedTrx = Hex.ToString(packedTrx),
                Signatures = transaction.Signatures,
                PackedContextFreeData = "",
                Compression = "none"
            };
        }

        public async Task<SignedTransaction> CreateTransaction(CreateTransactionArgs args, CancellationToken token)
        {
            //1
            var infoResp = await GetInfo(token);
            if (infoResp.IsError)
                return null;

            var info = infoResp.Result;

            //2
            var blockArgs = new GetBlockParams
            {
                BlockNumOrId = info.HeadBlockId
            };
            var getBlock = await GetBlock(blockArgs, token);
            if (getBlock.IsError)
                return null;

            var block = getBlock.Result;

            //3
            var transaction = new SignedTransaction
            {
                RefBlockNum = (ushort)(block.BlockNum & 0xffff),
                RefBlockPrefix = block.RefBlockPrefix,
                Expiration = block.Timestamp.Value.AddSeconds(30),
                Actions = args.Actions
            };

            return transaction;
        }
    }
}
