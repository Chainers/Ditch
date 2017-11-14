using System;
using Ditch.Core.Helpers;
using Newtonsoft.Json;

namespace Ditch.Steem.Operations.Post
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PostOperation : CommentOperation
    {
        public PostOperation(string parentPermlink, string author, string permlink, string title, string body, string jsonMetadata)
            : base(string.Empty, parentPermlink, author, permlink, title, body, jsonMetadata)
        {
        }

        public PostOperation(string parentPermlink, string author, string title, string body, string jsonMetadata)
            : base(string.Empty, parentPermlink, author, TitleToPermlink(title), title, body, jsonMetadata)
        {
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
            text = Transliteration.WordDelimiters.Replace(text, "-");
            text = Transliteration.ToEng(text);
            text = Transliteration.PermlinkNotSupportedCharacters.Replace(text, string.Empty);
            return $"{text}-{DateTime.UtcNow:yyyy-MM-dd-HH-mm-ss}";
        }
    }
}
