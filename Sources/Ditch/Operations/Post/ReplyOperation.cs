using System;
using System.Text.RegularExpressions;
using Ditch.Helpers;
using Newtonsoft.Json;

namespace Ditch.Operations.Post
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ReplyOperation : CommentOperation
    {
        public static readonly Regex TimePostfix = new Regex(@"-[0-9]{8}t[0-9]{6,}z$", RegexOptions.IgnoreCase);


        public ReplyOperation(string parentAuthor, string parentPermlink, string author, string body, string jsonMetadata)
            : base(parentAuthor, parentPermlink, author, CreateReplyPermlink(author, parentAuthor, parentPermlink), string.Empty, body, jsonMetadata) { }


        /// <summary>
        /// Generate a permlink for replay by User, author and permlink
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="parentAuthor">Post author</param>
        /// <param name="permlink">Post permlink</param>
        /// <returns>A formatted string with a prefix (re-) and postfix (used current date and time)</returns>
        private static string CreateReplyPermlink(string user, string parentAuthor, string permlink)
        {
            var parentPermlink = $"re-{user}-re-{parentAuthor}-{permlink}";
            parentPermlink = Transliteration.ToEng(parentPermlink);
            parentPermlink = WordDelimiters.Replace(parentPermlink, "-");
            parentPermlink = PermlinkNotSupportedCharacters.Replace(parentPermlink, string.Empty);
            parentPermlink = TimePostfix.Replace(parentPermlink, string.Empty);
            parentPermlink = $"{parentPermlink}-{DateTime.UtcNow:yyyyMMddTHHmmssZ}".ToLower();
            return parentPermlink;
        }
    }
}