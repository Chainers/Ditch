using System;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.EOS.Models;

namespace Ditch.EOS
{
    /// <summary>
    /// https://eosio.github.io/eos/group__eosiorpc.html
    /// </summary>
    public partial class OperationManager
    {
        public string WalletUrl { get; set; }

        /// <summary>
        /// WalletCreate a new wallet with the given name
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<string>> WalletCreateAsync(string name, CancellationToken token)
        {
            var endpoint = $"{WalletUrl}/v1/wallet/create";
            return await CustomPostRequestAsync<string>(endpoint, name, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Open an existing wallet of the given name
        /// 
        /// curl http://localhost:8889/v1/wallet/open -X POST -d '"default"'
        /// </summary>
        /// <param name="name"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<VoidResponse>> WalletOpenAsync(string name, CancellationToken token)
        {
            var endpoint = $"{WalletUrl}/v1/wallet/open";
            return await CustomPutRequestAsync<VoidResponse>(endpoint, name, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Lock a wallet of the given name
        /// 
        /// curl http://localhost:8889/v1/wallet/lock -X POST -d '"default"'
        /// </summary>
        /// <param name="name"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<VoidResponse>> WalletLockAsync(string name, CancellationToken token)
        {
            var endpoint = $"{WalletUrl}/v1/wallet/lock";
            return await CustomPutRequestAsync<VoidResponse>(endpoint, name, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Lock a wallets
        /// 
        /// curl http://localhost:8889/v1/wallet/lock_all
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<VoidResponse>> WalletLockAllAsync(CancellationToken token)
        {
            var endpoint = $"{WalletUrl}/v1/wallet/lock_all";
            return await CustomGetRequestAsync<VoidResponse>(endpoint, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Unlock a wallet with the given name and password
        /// 
        /// curl http://localhost:8889/v1/wallet/unlock -X POST -d '["default", "PW5KFWYKqvt63d4iNvedfDEPVZL227D3RQ1zpVFzuUwhMAJmRAYyX"]'
        /// </summary>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<VoidResponse>> WalletUnlockAsync(string name, string password, CancellationToken token)
        {
            var endpoint = $"{WalletUrl}/v1/wallet/unlock";
            return await CustomPutRequestAsync<VoidResponse>(endpoint, new[] { name, password }, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Import a private key to the wallet of the given name
        /// 
        /// curl http://localhost:8889/v1/wallet/import_key -X POST -d '["default","5KQwrPbwdL6PhXujxW37FSSQZ1JiwsST4cqQzDeyXtP79zkvFD3"]'
        /// </summary>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<VoidResponse>> WalletImportKeyAsync(string name, string password, CancellationToken token)
        {
            var endpoint = $"{WalletUrl}/v1/wallet/import_key";
            return await CustomPostRequestAsync<VoidResponse>(endpoint, new[] { name, password }, token).ConfigureAwait(false);
        }

        /// <summary>
        /// List all wallets
        /// 
        /// curl http://localhost:8889/v1/wallet/list_wallets
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<string[]>> WalletListAsync(CancellationToken token)
        {
            var endpoint = $"{WalletUrl}/v1/wallet/list_wallets";
            return await CustomGetRequestAsync<string[]>(endpoint, token).ConfigureAwait(false);
        }

        /// <summary>
        /// List all key pairs across all wallets
        /// 
        /// curl http://localhost:8889/v1/wallet/list_keys
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<string[][]>> WalletListKeysAsync(CancellationToken token)
        {
            var endpoint = $"{WalletUrl}/v1/wallet/list_keys";
            return await CustomGetRequestAsync<string[][]>(endpoint, token).ConfigureAwait(false);
        }

        /// <summary>
        /// List all public keys across all wallets
        /// 
        /// curl http://localhost:8889/v1/wallet/get_public_keys
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<string[]>> WalletGetPublicKeysAsync(CancellationToken token)
        {
            var endpoint = $"{WalletUrl}/v1/wallet/get_public_keys";
            return await CustomGetRequestAsync<string[]>(endpoint, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Set wallet auto lock timeout(in seconds)
        /// 
        /// curl http://localhost:8889/v1/wallet/set_timeout -X POST -d '10'
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<VoidResponse>> WalletSetTimeoutAsync(long seconds, CancellationToken token)
        {
            var endpoint = $"{WalletUrl}/v1/wallet/set_timeout";
            return await CustomPostRequestAsync<VoidResponse>(endpoint, seconds, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Signs a transaction
        /// </summary>
        /// <param name="trx"></param>
        /// <param name="keys"></param>
        /// <param name="chainId"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<SignedTransaction>> WalletSignTransactionAsync(SignedTransaction trx, PublicKey[] keys, string chainId, CancellationToken token)
        {
            var args = new object[] { trx, keys, chainId };
            var endpoint = $"{WalletUrl}/v1/wallet/sign_transaction";
            return await CustomPutRequestAsync<SignedTransaction>(endpoint, args, token).ConfigureAwait(false);
        }

       
        //set_dir
        //set_eosio_key
        //sign_digest
        //create_key

    }
}
