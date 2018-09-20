using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Models;

namespace Ditch.Golos
{
    /**
    * @brief The database_api class implements the RPC API for the chain database.
    *
    * This API exposes accessors on the database which query state tracked by a blockchain validating node. This API is
    * read-only; all modifications to the database must be performed via transactions. Transactions are broadcast via
    * the @ref network_broadcast_api.
    */

    /// <summary>
    ///     database_api
    ///     libraries\application\include\golos\application\database_api.hpp
    /// </summary>
    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_active_votes
        /// *Displays the list of users who voted for the specified entry
        /// 
        /// </summary>
        /// <param name="author">API type: std::string</param>
        /// <param name="permlink">API type: std::string</param>
        /// <param name="voteLimit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: vote_state if permlink is "" then it will return all votes for author</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<VoteState[]>> GetActiveVotesAsync(string author, string permlink, ushort voteLimit, CancellationToken token)
        {
            return CustomGetRequestAsync<VoteState[]>(KnownApiNames.SocialNetworkApi, "get_active_votes", new object[] { author, permlink, voteLimit }, token);
        }

        /// <summary>
        /// API name: get_account_votes
        /// *Displays all the voices that are displayed by the specified user
        /// 
        /// </summary>
        /// <param name="voter">API type: std::string</param>
        /// <param name="voteLimit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_vote</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<AccountVote[]>> GetAccountVotesAsync(string voter, ushort voteLimit, CancellationToken token)
        {
            return CustomGetRequestAsync<AccountVote[]>(KnownApiNames.SocialNetworkApi, "get_account_votes", new object[] { voter, voteLimit }, token);
        }

        /// <summary>
        /// API name: get_content
        /// *Gets information about the publication, with the exception of comments
        /// 
        /// </summary>
        /// <param name="author">API type: std::string</param>
        /// <param name="permlink">API type: std::string</param>
        /// <param name="voteLimit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<Discussion>> GetContentAsync(string author, string permlink, ushort voteLimit, CancellationToken token)
        {
            return CustomGetRequestAsync<Discussion>(KnownApiNames.SocialNetworkApi, "get_content", new object[] { author, permlink, voteLimit }, token);
        }

        /// <summary>
        /// API name: get_content_replies
        /// *Displays a list of all comments for the selected publication
        /// 
        /// </summary>
        /// <param name="parent">API type: std::string</param>
        /// <param name="parentPermlink">API type: std::string</param>
        /// <param name="voteLimit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<Discussion[]>> GetContentRepliesAsync(string parent, string parentPermlink, ushort voteLimit, CancellationToken token)
        {
            return CustomGetRequestAsync<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_content_replies", new object[] { parent, parentPermlink, voteLimit }, token);
        }

        /// <summary>
        /// API name: get_replies_by_last_update
        /// *Return the active discussions with the highest cumulative pending payouts without respect to category, total  pending payout means the pending payout of all children as well.
        /// 
        /// </summary>
        /// <param name="startAuthor">API type: account_name_type</param>
        /// <param name="startPermlink">API type: std::string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="voteLimit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion Return the active discussions with the highest cumulative pending payouts without respect to category, total
        /// pending payout means the pending payout of all children as well.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<Discussion[]>> GetRepliesByLastUpdateAsync(string startAuthor, string startPermlink, uint limit, ushort voteLimit, CancellationToken token)
        {
            return CustomGetRequestAsync<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_replies_by_last_update", new object[] { startAuthor, startPermlink, limit, voteLimit }, token);
        }

        /// <summary>
        /// API name: get_all_content_replies
        /// 
        /// </summary>
        /// <param name="author">API type: std::string</param>
        /// <param name="permlink">API type: std::string</param>
        /// <param name="voteLimit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<Discussion[]>> GetAllContentRepliesAsync(string author, string permlink, ushort voteLimit, CancellationToken token)
        {
            return CustomGetRequestAsync<Discussion[]>(KnownApiNames.SocialNetworkApi, "get_all_content_replies", new object[] { author, permlink, voteLimit }, token);
        }
    }
}
