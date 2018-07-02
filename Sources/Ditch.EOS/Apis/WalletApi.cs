using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.EOS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        public async Task<OperationResult<string>> WalletCreate(string name, CancellationToken token)
        {
            var endpoint = $"{WalletUrl}/v1/wallet/create";
            return await CustomPostRequest<string>(endpoint, name, token);
        }

        /// <summary>
        /// Open an existing wallet of the given name
        /// 
        /// curl http://localhost:8889/v1/wallet/open -X POST -d '"default"'
        /// </summary>
        /// <param name="name"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<VoidResponse>> WalletOpen(string name, CancellationToken token)
        {
            string endpoint = $"{WalletUrl}/v1/wallet/open";
            return await CustomPostRequest<VoidResponse>(endpoint, name, token);
        }

        /// <summary>
        /// Lock a wallet of the given name
        /// 
        /// curl http://localhost:8889/v1/wallet/lock -X POST -d '"default"'
        /// </summary>
        /// <param name="name"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<VoidResponse>> WalletLock(string name, CancellationToken token)
        {
            string endpoint = $"{WalletUrl}/v1/wallet/lock";
            return await CustomPostRequest<VoidResponse>(endpoint, name, token);
        }

        /// <summary>
        /// Lock a wallets
        /// 
        /// curl http://localhost:8889/v1/wallet/lock_all
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<VoidResponse>> WalletLockAll(CancellationToken token)
        {
            string endpoint = $"{WalletUrl}/v1/wallet/lock_all";
            return await CustomGetRequest<VoidResponse>(endpoint, token);
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
        public async Task<OperationResult<VoidResponse>> WalletUnlock(string name, string password, CancellationToken token)
        {
            string endpoint = $"{WalletUrl}/v1/wallet/unlock";
            return await CustomPostRequest<VoidResponse>(endpoint, new[] { name, password }, token);
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
        public async Task<OperationResult<VoidResponse>> WalletImportKey(string name, string password, CancellationToken token)
        {
            string endpoint = $"{WalletUrl}/v1/wallet/import_key";
            return await CustomPostRequest<VoidResponse>(endpoint, new[] { name, password }, token);
        }

        /// <summary>
        /// List all wallets
        /// 
        /// curl http://localhost:8889/v1/wallet/list_wallets
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<string[]>> WalletList(CancellationToken token)
        {
            string endpoint = $"{WalletUrl}/v1/wallet/list_wallets";
            return await CustomGetRequest<string[]>(endpoint, token);
        }

        /// <summary>
        /// List all key pairs across all wallets
        /// 
        /// curl http://localhost:8889/v1/wallet/list_keys
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<string[][]>> WalletListKeys(CancellationToken token)
        {
            string endpoint = $"{WalletUrl}/v1/wallet/list_keys";
            return await CustomGetRequest<string[][]>(endpoint, token);
        }

        /// <summary>
        /// List all public keys across all wallets
        /// 
        /// curl http://localhost:8889/v1/wallet/get_public_keys
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<string[]>> WalletGetPublicKeys(CancellationToken token)
        {
            string endpoint = $"{WalletUrl}/v1/wallet/get_public_keys";
            return await CustomGetRequest<string[]>(endpoint, token);
        }

        /// <summary>
        /// Set wallet auto lock timeout(in seconds)
        /// 
        /// curl http://localhost:8889/v1/wallet/set_timeout -X POST -d '10'
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<VoidResponse>> WalletSetTimeout(long seconds, CancellationToken token)
        {
            string endpoint = $"{WalletUrl}/v1/wallet/set_timeout";
            return await CustomPostRequest<VoidResponse>(endpoint, seconds, token);
        }

        /// <summary>
        /// Sign transaction given an array of transaction, require public keys, and chain id
        /// 
        /// curl http://localhost:8889/v1/wallet/sign_transaction -X POST -d '[{"ref_block_num":21453,"ref_block_prefix":3165644999,"expiration":"2017-12-08T10:28:49","scope":["initb","initc"],"read_scope":[],"messages":[{"code":"currency","type":"transfer","authorization":[{"account":"initb","permission":"active"}],"data":"000000008093dd74000000000094dd74e803000000000000"}],"signatures":[]}, ["EOS6MRyAjQq8ud7hVNYcfnVPJqcVpscN5So8BhtHuGYqET5GDW5CV"], ""]'
        /// </summary>
        /// <param name="publicKeys"></param>
        /// <param name="trx"></param>
        /// <param name="chainId"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<SignedTransaction>> WalletSignTrx(SignedTransaction trx, PublicKey[] publicKeys, string chainId, CancellationToken token)
        {
            string endpoint = $"{WalletUrl}/v1/wallet/sign_transaction";
            var args = new object[] { trx, publicKeys, chainId };
            return await CustomPostRequest<SignedTransaction>(endpoint, args, token);
        }
    }
}
