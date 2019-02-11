using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Ethereum.Models;
using Newtonsoft.Json.Linq;

namespace Ditch.Ethereum
{

    public partial class OperationManager
    {

        //eth_accounts

        /// <summary>
        /// Returns the current "latest" block number. (eth_blockNumber)
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<HexLong>> BlockNumberAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<HexLong>("eth_blockNumber", token);
        }

        /// <summary>
        /// Executes a new message call immediately without creating a transaction on the block chain.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<T>> EthCallAsync<T>(EthCallArgs args, string blockParam, CancellationToken token)
        {
            return CustomGetRequestAsync<T>("eth_call", new object[] { args, blockParam }, token);
        }
        //    eth_estimateGas
        //eth_gasPrice
        //    eth_getBalance
        //eth_getBlockByHash

        /// <summary>
        /// Returns information about a block by number.
        /// </summary>
        /// <param name="number">an integer block number</param>
        /// <param name="details">(not supported => true bu default) if set to true, it returns the full transaction objects, if false only the hashes of the transactions.</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<GetBlockResult>> GetBlockByNumberAsync(long number, bool details, CancellationToken token)
        {
            return CustomGetRequestAsync<GetBlockResult>("eth_getBlockByNumber", new object[] { $"0x{number:X}", true }, token);
        }


        //eth_getBlockTransactionCountByHash
        //    eth_getBlockTransactionCountByNumber
        //eth_getCode

        /// <summary>
        /// Returns an array of all logs matching a given filter object.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<Log[]>> GetLogsAsync(GetLogsArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<Log[]>("eth_getLogs", new object[] { args }, token);
        }

        //eth_getStorageAt
        //    eth_getTransactionByBlockHashAndIndex
        //eth_getTransactionByBlockNumberAndIndex

        /// <summary>
        /// Returns information about a transaction for a given hash.
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<Transaction>> GetTransactionByHashAsync(HexValue hash, CancellationToken token)
        {
            return CustomGetRequestAsync<Transaction>("eth_getTransactionByHash", new object[] { hash }, token);
        }

        //eth_getTransactionCount

        /// <summary>
        /// Returns the receipt of a transaction by transaction hash. Note that the receipt is not available for pending transactions.
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="b"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<GetTransactionReceiptResult>> GetTransactionReceiptAsync(HexValue hash, CancellationToken token)
        {
            return CustomGetRequestAsync<GetTransactionReceiptResult>("eth_getTransactionReceipt", new object[] { hash }, token);
        }

        //eth_getUncleByBlockHashAndIndex
        //    eth_getUncleByBlockNumberAndIndex
        //eth_getUncleCountByBlockHash
        //    eth_getUncleCountByBlockNumber
        //eth_getWork
        //    eth_hashrate
        //eth_mining

        /// <summary>
        /// Returns the current ethereum protocol version.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<HexValue>> ProtocolVersionAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<HexValue>("eth_protocolVersion", token);
        }

        //eth_sendRawTransaction
        //    eth_submitWork

        /// <summary>
        /// Returns an object with data about the sync status or false.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<object>> SyncingAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<object>("eth_syncing", token);
        }


        //    net_listening
        //net_peerCount

        /// <summary>
        /// Returns the current network id.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<object>> NetVersionAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<object>("net_version", token);
        }

        //web3_clientVersion
        //    WSS
        //Introduction
        //    eth_newBlockFilter
        //eth_newFilter
        //    eth_newPendingTransactionFilter
        //eth_getFilterChanges
        //    eth_getFilterLogs
        //eth_uninstallFilter
        //    eth_subscribe
        //eth_unsubscribe
        //    parity_subscribe
        //parity_unsubscribe


    }
}
