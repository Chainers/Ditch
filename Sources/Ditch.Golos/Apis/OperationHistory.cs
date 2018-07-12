using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Models;

namespace Ditch.Golos
{
    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_ops_in_block
        /// Get sequence of operations included/generated within a particular block
        ///
        /// *Returns all operations in the block, if the parameter 'onlyVirtual' is true, then returns only the virtual operations
        /// 
        /// </summary>
        /// <param name="blockNum">API type: uint32_t Height of the block whose generated virtual operations should be returned</param>
        /// <param name="onlyVirtual">API type: bool Whether to only include virtual operations in returned results (default: true)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: applied_operation sequence of operations included/generated within the block</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<AppliedOperation[]>> GetOpsInBlock(uint blockNum, bool onlyVirtual, CancellationToken token)
        {
            return CustomGetRequest<AppliedOperation[]>(KnownApiNames.OperationHistory, "get_ops_in_block", new object[] { blockNum, onlyVirtual }, token);
        }

        /// <summary>
        /// API name: get_transaction
        /// *Displays transaction details for the specified transaction ID.
        /// 
        /// </summary>
        /// <param name="trxId">API type: transaction_id_type</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: annotated_signed_transaction</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<AnnotatedSignedTransaction>> GetTransaction(string trxId, CancellationToken token)
        {
            return CustomGetRequest<AnnotatedSignedTransaction>(KnownApiNames.OperationHistory, "get_transaction", new object[] { trxId }, token);
        }
    }
}
