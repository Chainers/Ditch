using System;
using System.Text.RegularExpressions;

namespace Ditch.Core.Helpers
{
    public class OperationHelper
    {
        protected const int PermlinkCropCount = 40;

        /// <summary>
        /// @"[_\s\.]+"
        /// </summary>
        public static readonly Regex WordDelimiters = new Regex(@"[_\s\.]+");

        /// <summary>
        /// @"[^a-z0-9-]+"
        /// </summary>
        public static readonly Regex PermlinkNotSupportedCharacters = new Regex(@"[^a-z0-9-]+", RegexOptions.IgnoreCase);


        public static readonly Regex TimePostfix = new Regex(@"-[0-9]{8}t[0-9]{6,}z$", RegexOptions.IgnoreCase);

        /// <summary>
        /// Generate a valid tags
        /// </summary>
        /// <param name="tags"></param>
        public static void PrepareTags(string[] tags)
        {
            for (var index = 0; index < tags.Length; index++)
            {
                var tag = tags[index];
                tag = tag.Trim();
                tag = tag.ToLower();
                var translit = Transliteration.ToEng(tag);
                tag = translit.Equals(tag) ? translit : $"ru--{translit}";
                tag = WordDelimiters.Replace(tag, "-");
                tag = PermlinkNotSupportedCharacters.Replace(tag, string.Empty);
                tags[index] = tag;
            }
        }


        /// <summary>
        /// Generate a permlink for replay by User, author and permlink
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="parentAuthor">Post author</param>
        /// <param name="permlink">Post permlink</param>
        /// <returns>A formatted string with a prefix (re-) and postfix (used current date and time)</returns>
        public static string CreateReplyPermlink(string user, string parentAuthor, string permlink)
        {
            var parentPermlink = $"re-{user}-re-{parentAuthor}-{permlink}";
            parentPermlink = Transliteration.ToEng(parentPermlink);
            parentPermlink = WordDelimiters.Replace(parentPermlink, "-");
            parentPermlink = PermlinkNotSupportedCharacters.Replace(parentPermlink, string.Empty);
            parentPermlink = TimePostfix.Replace(parentPermlink, string.Empty);
            if (parentPermlink.Length > PermlinkCropCount)
                parentPermlink = parentPermlink.Remove(PermlinkCropCount);
            parentPermlink = $"{parentPermlink}-{DateTime.UtcNow:yyyyMMddTHHmmssZ}".ToLower();
            return parentPermlink;
        }
        
        /// <summary>
        /// Uses input text to generate a valid Permlink
        /// </summary>
        /// <param name="text">Any text (usually a Title)</param>
        /// <returns>A formatted string with a postfix (used current date and time)</returns>
        public static string TitleToPermlink(string text)
        {
            text = text.Trim();
            text = text.ToLower();
            text = WordDelimiters.Replace(text, "-");
            text = Transliteration.ToEng(text);
            text = PermlinkNotSupportedCharacters.Replace(text, string.Empty);
            if (text.Length > PermlinkCropCount)
                text = text.Remove(PermlinkCropCount);
            return $"{text}-{DateTime.UtcNow:yyyy-MM-dd-HH-mm-ss}";
        }
    }
}
