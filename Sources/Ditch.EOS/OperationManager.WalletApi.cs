using System.Threading;
using System.Threading.Tasks;

namespace Ditch.EOS
{
    /// <summary>
    /// https://eosio.github.io/eos/group__eosiorpc.html
    /// </summary>
    public partial class OperationManager
    {
        /// <summary>
        /// WalletCreate a new wallet with the given name
        /// 
        //  curl http://localhost:8889/v1/wallet/create -X POST -d '"default"'
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        public async Task<OperationResult<string>> WalletCreate(string name, CancellationToken token)
        {
            var endpoint = "v1/wallet/create";
            return await CustomPostRequest<string>(endpoint, name, token);
        }


        //    wallet_open
        //wallet_lock
        //    wallet_lock_all
        //wallet_import_key
        //    wallet_list
        //wallet_list_keys
        //    wallet_get_public_keys
        //wallet_set_timeout
        //    wallet_sign_trx

    }
}
