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
            text = WordDelimiters.Replace(text, "-");
            text = Transliteration.ToEng(text);
            text = PermlinkNotSupportedCharacters.Replace(text, string.Empty);
            return $"{text}-{DateTime.UtcNow:yyyy-MM-dd-HH-mm-ss}";
        }


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
    }
}