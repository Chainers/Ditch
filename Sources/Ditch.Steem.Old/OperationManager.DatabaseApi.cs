using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Old.Models.Objects;
using Ditch.Steem.Old.Models.Other;

namespace Ditch.Steem.Old
{
    /// <summary>
    /// database_api
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api.hpp
    /// </summary>
    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_dynamic_global_properties
        /// Retrieve the current @ref dynamic_global_property_object
        ///
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_dynamic_global_properties_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<DynamicGlobalPropertyObject> GetDynamicGlobalProperties(CancellationToken token)
        {
            return CustomGetRequest<DynamicGlobalPropertyObject>(KnownApiNames.DatabaseApi, "get_dynamic_global_properties", token);
        }

        /// <summary>
        /// API name: get_transaction_hex
        /// Get a hexdump of the serialized binary form of a transaction
        ///
        /// 
        /// </summary>
        /// <param name="args">API type: get_transaction_hex_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_transaction_hex_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<string> GetTransactionHex(SignedTransaction trx, CancellationToken token)
        {
            return CustomGetRequest<string>(KnownApiNames.DatabaseApi, "get_transaction_hex", new object[] { trx }, token);
        }

        /// <summary>
        /// API name: verify_authority
        /// *Returns TRUE if the transaction is signed correctly
        /// 
        /// </summary>
        /// <param name="trx">API type: signed_transaction</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bool true of the @ref trx has all of the required signatures, otherwise throws an exception</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<bool> VerifyAuthority(SignedTransaction trx, CancellationToken token)
        {
            return CustomGetRequest<bool>(KnownApiNames.DatabaseApi, "verify_authority", new object[] { trx }, token);
        }

        /// <summary>
        /// API name: lookup_account_names
        /// Get a list of accounts by name
        ///
        /// *Returns data for specified accounts
        /// 
        /// </summary>
        /// <param name="accountNames">API type: std::vector&lt;std::string> Names of the accounts to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_api_object The accounts holding the provided names
        /// 
        /// This function has semantics identical to @ref get_objects</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<AccountApiObject[]> LookupAccountNames(string[] accountNames, CancellationToken token)
        {
            return CustomGetRequest<AccountApiObject[]>(KnownApiNames.DatabaseApi, "lookup_account_names", new object[] { accountNames }, token);
        }
    }
}
