using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Models.Args;
using Ditch.Steem.Models.Return;

namespace Ditch.Steem
{
    /// <summary>
    /// block_api
    /// libraries\plugins\apis\block_api\include\steem\plugins\block_api\block_api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /////////////////////////////
        // Blocks and transactions //
        /////////////////////////////

        /// <summary>
        /// API name: get_block_header
        /// Retrieve a block header
        ///
        /// 
        /// </summary>
        /// <param name="args">API type: get_block_header_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_block_header_return header of the referenced block, or null if no matching block was found</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetBlockHeaderReturn> GetBlockHeader(GetBlockHeaderArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetBlockHeaderReturn>(KnownApiNames.BlockApi, "get_block_header", args, token);
        }

        /// <summary>
        /// API name: get_block
        /// Retrieve a full, signed block
        ///
        /// 
        /// </summary>
        /// <param name="args">API type: get_block_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_block_return the referenced block, or null if no matching block was found</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<GetBlockReturn> GetBlock(GetBlockArgs args, CancellationToken token)
        {
            return CustomGetRequest<GetBlockReturn>(KnownApiNames.BlockApi, "get_block", args, token);
        }
    }
}
