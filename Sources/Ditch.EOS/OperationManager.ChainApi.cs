using System.Collections.Generic;
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
        /// <summary>
        /// Get latest information related to a node
        /// 
        //  curl http://127.0.0.1:8888/v1/chain/get_info
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<GetInfoResult>> GetInfo(CancellationToken token)
        {
            var endpoint = "v1/chain/get_info";
            return await CustomGetRequest<GetInfoResult>(endpoint, token);
        }

        /// <summary>
        /// Get information related to a block.
        /// 
        ///  curl http://127.0.0.1:8888/v1/chain/get_block -X POST -d '{"block_num_or_id":5}'
        ///  curl http://127.0.0.1:8888/v1/chain/get_block -X POST -d '{"block_num_or_id":0000000445a9f27898383fd7de32835d5d6a978cc14ce40d9f327b5329de796b}'
        /// </summary>
        /// <param name="blockNumOrId"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<SignedBlock>> GetBlock(string blockNumOrId, CancellationToken token)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"block_num_or_id", blockNumOrId}
            };
            var endpoint = "v1/chain/get_block";
            return await CustomPostRequest<SignedBlock>(endpoint, parameters, token);
        }

        /// <summary>
        /// Get information related to an account.
        /// 
        ///  curl http://127.0.0.1:8888/v1/chain/get_account -X POST -d '{"account_name":"inita"}'
        /// </summary>
        /// <param name="accountParams"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<GetAccountResults>> GetAccount(GetAccountParams accountParams, CancellationToken token)
        {
            var endpoint = "v1/chain/get_account";
            return await CustomPostRequest<GetAccountResults>(endpoint, accountParams, token);
        }

        /// <summary>
        /// Fetch smart contract code.
        /// 
        /// curl http://127.0.0.1:8888/v1/chain/get_code -X POST -d '{"account_name":"currency"}'
        /// </summary>
        /// <param name="codeParams"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<GetCodeResults>> GetCode(GetCodeParams codeParams, CancellationToken token)
        {
            var endpoint = "v1/chain/get_code";
            return await CustomPostRequest<GetCodeResults>(endpoint, codeParams, token);
        }

        /// <summary>
        /// Fetch smart contract data from an account.
        /// 
        /// curl  http://127.0.0.1:8888/v1/chain/get_table_rows -X POST -d '{"scope":"inita", "code":"currency", "table":"account", "json": true}'
        /// curl http://127.0.0.1:8888/v1/chain/get_table_rows -X POST -d '{"scope":"inita", "code":"currency", "table":"account", "json": true, "lower_bound":0, "upper_bound":-1, "limit":10}'
        /// </summary>
        /// <param name="tableRowsParams"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<GetTableRowsResult>> GetTableRows(GetTableRowsParams tableRowsParams, CancellationToken token)
        {
            var endpoint = "v1/chain/get_table_rows";
            return await CustomPostRequest<GetTableRowsResult>(endpoint, tableRowsParams, token);
        }

        /// <summary>
        /// Serialize json to binary hex. The resulting binary hex is usually used for the data field in push_transaction.
        /// 
        /// curl http://127.0.0.1:8888/v1/chain/abi_json_to_bin -X POST -d '{"code":"currency", "action":"transfer", "args":{"from":"initb", "to":"initc", "quantity":1000}}'
        /// </summary>
        /// <param name="abiJsonToBinParams"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<AbiJsonToBinResult>> AbiJsonToBin(AbiJsonToBinParams abiJsonToBinParams, CancellationToken token)
        {
            var endpoint = "v1/chain/abi_json_to_bin";
            return await CustomPostRequest<AbiJsonToBinResult>(endpoint, abiJsonToBinParams, token);
        }


        //Serialize back binary hex to json.
        //$ curl http://127.0.0.1:8888/v1/chain/abi_bin_to_json -X POST -d '{"code":"currency", "action":"transfer", "binargs":"000000008093dd74000000000094dd74e803000000000000"}'

        //This method expects a transaction in JSON format and will attempt to apply it to the blockchain,


        // /v1/chain/abi_json_to_bin	{"code":"currency","action":"transfer","args":{"from":"currency","to":"test1","amount":"100500.0000 VIM"}}

        // /v1/wallet/get_public_keys	

        /// <summary>
        /// 
        /// /v1/chain/get_required_keys	{"transaction":{"expiration":"2018-04-10T12:26:15","region":0,"ref_block_num":44,"ref_block_prefix":104196284,"max_net_usage_words":0,"max_kcpu_usage":0,"delay_sec":0,"context_free_actions":[],"actions":[{"account":"currency","name":"transfer","authorization":[{"actor":"currency","permission":"active"}],"data":"0000001e4d75af46000000008090b1ca4015e73b000000000456494d00000000"}]},"available_keys":["EOS6MRyAjQq8ud7hVNYcfnVPJqcVpscN5So8BhtHuGYqET5GDW5CV","EOS7drQWvc7Mn7NK2PivjbAqLXMyBpvSNnZWnZC3CS61g1dhVK57o","EOS8KLWY5tcczw6tTkk4UhfeZJrES7ECiFZAkChcR2mwsFcArURn7"]}
        /// </summary>
        /// <param name="getRequiredKeysParams"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<OperationResult<GetRequiredKeysResult>> GetRequiredKeys(GetRequiredKeysParams getRequiredKeysParams, CancellationToken token)
        {
            var endpoint = "v1/chain/get_required_keys";
            return await CustomPostRequest<GetRequiredKeysResult>(endpoint, getRequiredKeysParams, token);
        }

        // /v1/wallet/sign_transaction[{"expiration":"2018-04-10T12:26:15","region":0,"ref_block_num":44,"ref_block_prefix":104196284,"max_net_usage_words":0,"max_kcpu_usage":0,"delay_sec":0,"context_free_actions":[],"actions":[{"account":"currency","name":"transfer","authorization":[{"actor":"currency","permission":"active"}],"data":"0000001e4d75af46000000008090b1ca4015e73b000000000456494d00000000"}],"signatures":[],"context_free_data":[]},["EOS8KLWY5tcczw6tTkk4UhfeZJrES7ECiFZAkChcR2mwsFcArURn7"],"0000000000000000000000000000000000000000000000000000000000000000"]
        // /v1/chain/push_transaction	{"signatures":["EOSK8C1tDRbfzAbV7cmRCBnj9FuKQNxac9UTH4NzzEA11ZQ3LALhpZwoWKH491d75TjBGvLMEzmTzCAoNMuneGrjTgMJaAeZK"],"compression":"none","packed_context_free_data":"","packed_trx":"67adcc5a00002c00bce8350600000000010000001e4d75af46000000572d3ccdcd010000001e4d75af4600000000a8ed3232200000001e4d75af46000000008090b1ca4015e73b000000000456494d00000000"}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getRequiredKeysParams"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<OperationResult<GetRequiredKeysResult>> PushTransaction(GetRequiredKeysParams getRequiredKeysParams, CancellationToken token)
        {
            var endpoint = "v1/chain/push_transaction";
            return await CustomPostRequest<GetRequiredKeysResult>(endpoint, getRequiredKeysParams, token);
        }
    }
}
