using System.Threading;
using System.Threading.Tasks;
using Ditch.EOS.Models;

namespace Ditch.EOS
{

    public partial class OperationManager
    {
        public async Task<OperationResult<GetActionsResult>> GetActions(GetActionsParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/history/get_actions";
            return await CustomPostRequest<GetActionsResult>(endpoint, args, token);
        }

        public async Task<OperationResult<GetTransactionResult>> GetTransaction(GetTransactionParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/history/get_transaction";
            return await CustomPostRequest<GetTransactionResult>(endpoint, args, token);
        }

        public async Task<OperationResult<GetKeyAccountsResults>> GetKeyAccounts(GetKeyAccountsParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/history/get_key_accounts";
            return await CustomPostRequest<GetKeyAccountsResults>(endpoint, args, token);
        }

        public async Task<OperationResult<GetControlledAccountsResults>> GetControlledAccounts(GetControlledAccountsParams args, CancellationToken token)
        {
            var endpoint = $"{ChainUrl}/v1/history/get_controlled_accounts";
            return await CustomPostRequest<GetControlledAccountsResults>(endpoint, args, token);
        }
    }
}