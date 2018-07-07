namespace Ditch.Golos.Operations
{
    /// <inheritdoc />
    /// <summary>
    /// Unfollow some author
    /// </summary>
    public class UnfollowOperation : FollowOperation
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="login"></param>
        /// <param name="author"></param>
        /// <param name="requiredPostingAuths"></param>
        /// <returns></returns>
        public UnfollowOperation(string login, string author, params string[] requiredPostingAuths)
            : base(login, author, null, requiredPostingAuths)
        {
        }
    }
}
