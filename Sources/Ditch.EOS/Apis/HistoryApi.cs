using System.Threading;
using System.Threading.Tasks;
using Ditch.EOS.Models;

namespace Ditch.EOS
{

    public partial class OperationManager
    {
        public async Task<OperationResult<GetActionsResult>> GetActionsAsync(GetActionsParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/history/get_actions";
            return await CustomPutRequestAsync<GetActionsResult>(endpoint, args, token).ConfigureAwait(false);
        }

        public async Task<OperationResult<GetTransactionResult>> GetTransactionAsync(GetTransactionParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/history/get_transaction";
            return await CustomPutRequestAsync<GetTransactionResult>(endpoint, args, token).ConfigureAwait(false);
        }

        public async Task<OperationResult<GetKeyAccountsResults>> GetKeyAccountsAsync(GetKeyAccountsParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/history/get_key_accounts";
            return await CustomPutRequestAsync<GetKeyAccountsResults>(endpoint, args, token).ConfigureAwait(false);
        }

        public async Task<OperationResult<GetControlledAccountsResults>> GetControlledAccountsAsync(GetControlledAccountsParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/history/get_controlled_accounts";
            return await CustomPutRequestAsync<GetControlledAccountsResults>(endpoint, args, token).ConfigureAwait(false);
        }
    }
}