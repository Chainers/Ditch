using System.Threading;
using System.Threading.Tasks;
using Ditch.EOS.Models;

namespace Ditch.EOS
{
    /// <summary>
    /// https://eosio.github.io/eos/group__eosiorpc.html
    /// </summary>
    public partial class OperationManager
    {
        public string ChainUrl { get; set; }

        /// <summary>
        /// Get latest information related to a node
        /// 
        //  curl http://127.0.0.1:8888/v1/chain/get_info
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<GetInfoResults>> GetInfo(CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/get_info";
            return await CustomGetRequest<GetInfoResults>(endpoint, token);
        }

        /// <summary>
        /// Get information related to a block.
        /// 
        ///  curl http://127.0.0.1:8888/v1/chain/get_block -X POST -d '{"block_num_or_id":5}'
        ///  curl http://127.0.0.1:8888/v1/chain/get_block -X POST -d '{"block_num_or_id":0000000445a9f27898383fd7de32835d5d6a978cc14ce40d9f327b5329de796b}'
        /// </summary>
        /// <param name="args"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<GetBlockResults>> GetBlock(GetBlockParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/get_block";
            return await CustomPutRequest<GetBlockResults>(endpoint, args, token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<OperationResult<BlockHeaderState>> GetBlockHeaderState(GetBlockHeaderStateParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/get_block_header_state";
            return await CustomPutRequest<BlockHeaderState>(endpoint, args, token);
        }

        /// <summary>
        /// Get information related to an account.
        /// 
        ///  curl http://127.0.0.1:8888/v1/chain/get_account -X POST -d '{"account_name":"inita"}'
        /// </summary>
        /// <param name="args"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<GetAccountResults>> GetAccount(GetAccountParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/get_account";
            return await CustomPutRequest<GetAccountResults>(endpoint, args, token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">name of account to retrieve ABI for</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<OperationResult<GetAbiResults>> GetAbi(GetAbiParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/get_abi";
            return await CustomPutRequest<GetAbiResults>(endpoint, args, token);
        }

        /// <summary>
        /// Fetch smart contract code.
        /// 
        /// curl http://127.0.0.1:8888/v1/chain/get_code -X POST -d '{"account_name":"currency"}'
        /// </summary>
        /// <param name="args"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<GetCodeResults>> GetCode(GetCodeParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/get_code";
            return await CustomPutRequest<GetCodeResults>(endpoint, args, token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">Account name to get code and abi for</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<OperationResult<GetRawCodeAndAbiResults>> GetRawCodeAndAbi(GetRawCodeAndAbiParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/get_raw_code_and_abi";
            return await CustomPutRequest<GetRawCodeAndAbiResults>(endpoint, args, token);
        }

        /// <summary>
        /// Fetch smart contract data from an account.
        /// 
        /// curl  http://127.0.0.1:8888/v1/chain/get_table_rows -X POST -d '{"scope":"inita", "code":"currency", "table":"account", "json": true}'
        /// curl http://127.0.0.1:8888/v1/chain/get_table_rows -X POST -d '{"scope":"inita", "code":"currency", "table":"account", "json": true, "lower_bound":0, "upper_bound":-1, "limit":10}'
        /// </summary>
        /// <param name="args"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<GetTableRowsResult>> GetTableRows(GetTableRowsParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/get_table_rows";
            return await CustomPutRequest<GetTableRowsResult>(endpoint, args, token);
        }

        /// <summary>
        /// Serialize json to binary hex. The resulting binary hex is usually used for the data field in push_transaction.
        /// 
        /// curl http://127.0.0.1:8888/v1/chain/abi_json_to_bin -X POST -d '{"code":"currency", "action":"transfer", "args":{"from":"initb", "to":"initc", "quantity":1000}}'
        /// </summary>
        /// <param name="args"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<AbiJsonToBinResult>> AbiJsonToBin(AbiJsonToBinParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/abi_json_to_bin";
            return await CustomPutRequest<AbiJsonToBinResult>(endpoint, args, token);
        }

        /// <summary>
        /// Serialize back binary hex to json.
        /// 
        /// curl http://127.0.0.1:8888/v1/chain/abi_bin_to_json -X POST -d '{"code":"currency", "action":"transfer", "binargs":"000000008093dd74000000000094dd74e803000000000000"}'
        /// </summary>
        /// <param name="args"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<AbiBinToJsonResult>> AbiBinToJson(AbiBinToJsonParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/abi_bin_to_json";
            return await CustomPutRequest<AbiBinToJsonResult>(endpoint, args, token);
        }

        /// <summary>
        /// 
        /// /v1/chain/get_required_keys	{"transaction":{"expiration":"2018-04-10T12:26:15","region":0,"ref_block_num":44,"ref_block_prefix":104196284,"max_net_usage_words":0,"max_kcpu_usage":0,"delay_sec":0,"context_free_actions":[],"actions":[{"account":"currency","name":"transfer","authorization":[{"actor":"currency","permission":"active"}],"data":"0000001e4d75af46000000008090b1ca4015e73b000000000456494d00000000"}]},"available_keys":["EOS6MRyAjQq8ud7hVNYcfnVPJqcVpscN5So8BhtHuGYqET5GDW5CV","EOS7drQWvc7Mn7NK2PivjbAqLXMyBpvSNnZWnZC3CS61g1dhVK57o","EOS8KLWY5tcczw6tTkk4UhfeZJrES7ECiFZAkChcR2mwsFcArURn7"]}
        /// </summary>
        /// <param name="args"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<OperationResult<GetRequiredKeysResult>> GetRequiredKeys(GetRequiredKeysParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/get_required_keys";
            return await CustomPutRequest<GetRequiredKeysResult>(endpoint, args, token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<OperationResult<GetCurrencyStatsResult>> GetCurrencyStats(GetCurrencyStatsParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/get_currency_stats";
            return await CustomPutRequest<GetCurrencyStatsResult>(endpoint, args, token);
        }

        public async Task<OperationResult<GetProducersResult>> GetProducers(GetProducersParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/get_producers";
            return await CustomPutRequest<GetProducersResult>(endpoint, args, token);
        }

        /// <summary>
        /// This method expects a transaction in JSON format and will attempt to apply it to the blockchain
        /// 
        /// curl http://localhost:8888/v1/chain/push_transaction -X POST -d '{"ref_block_num":"100","ref_block_prefix":"137469861","expiration":"2017-09-25T06:28:49","scope":["initb","initc"],"actions":[{"code":"currency","type":"transfer","recipients":["initb","initc"],"authorization":[{"account":"initb","permission":"active"}],"data":"000000000041934b000000008041934be803000000000000"}],"signatures":[],"authorizations":[]}'
        /// </summary>
        /// <param name="args"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<OperationResult<PushTransactionResults>> PushTransaction(PackedTransaction args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/push_transaction";
            return await CustomPostRequest<PushTransactionResults>(endpoint, args, token);
        }

        /// <summary>
        /// This method push multiple transactions at once.
        /// 
        /// curl http://localhost:8888/v1/chain/push_transaction -X POST -d '[{"ref_block_num":"101","ref_block_prefix":"4159312339","expiration":"2017-09-25T06:28:49","scope":["initb","initc"],"actions":[{"code":"currency","type":"transfer","recipients":["initb","initc"],"authorization":[{"account":"initb","permission":"active"}],"data":"000000000041934b000000008041934be803000000000000"}],"signatures":[],"authorizations":[]}, 
        ///                                                                   {"ref_block_num":"101","ref_block_prefix":"4159312339","expiration":"2017-09-25T06:28:49","scope":["inita","initc"],"actions":[{"code":"currency","type":"transfer","recipients":["inita","initc"],"authorization":[{"account":"inita","permission":"active"}],"data":"000000008040934b000000008041934be803000000000000"}],"signatures":[],"authorizations":[]}]'
        /// </summary>
        /// <param name="args"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<OperationResult<PushTransactionResults[]>> PushTransactions(PackedTransaction[] args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/chain/push_transaction";
            return await CustomPostRequest<PushTransactionResults[]>(endpoint, args, token);
        }

    }
}