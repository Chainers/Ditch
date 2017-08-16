using System;
using System.Text.RegularExpressions;

namespace Ditch.Helpers
{
    public class Transliteration
    {
        private static readonly Regex WordDelimiters = new Regex(@"[_\s\.]+");
        private static readonly Regex PermlinkNotSupportedCharacters = new Regex(@"[^a-z0-9-]+");

        //https://github.com/GolosChain/tolstoy/blob/master/app/utils/ParsersAndFormatters.js
        private static readonly string[,] Rules =
        {
            {"ые", "yie"},
            {"щ", "shch"},
            {"ш", "sh"},
            {"ч", "ch"},
            {"ц", "cz"},
            {"й", "ij"},
            {"ё", "yo"},
            {"э", "ye"},
            {"ю", "yu"},
            {"я", "ya"},
            {"х", "kh"},
            {"ж", "zh"},
            {"а", "a"},
            {"б", "b"},
            {"в", "v"},
            {"г", "g"},
            {"д", "d"},
            {"е", "e"},
            {"з", "z"},
            {"и", "i"},
            {"к", "k"},
            {"л", "l"},
            {"м", "m"},
            {"н", "n"},
            {"о", "o"},
            {"п", "p"},
            {"р", "r"},
            {"с", "s"},
            {"т", "t"},
            {"у", "u"},
            {"ф", "f"},
            {"ъ", "xx"},
            {"ы", "y"},
            {"ь", "x"},
            {"ґ", "g"},
            {"є", "e"},
            {"і", "i"},
            {"ї", "i"}
        };

        /// <summary>
        /// Transliteration of the Latin alphabet into Cyrillic (Only words with a prefix "ru--")
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToRus(string text)
        {
            if (string.IsNullOrEmpty(text) || !text.StartsWith("ru--"))
                return text;

            text = text.Remove(0, 4);

            for (var i = 0; i < Rules.GetLength(0); i++)
            {
                text = text.Replace(Rules[i, 1], Rules[i, 0]);
                text = text.Replace(Rules[i, 1].ToUpper(), Rules[i, 0].ToUpper());
            }

            return text;
        }

        /// <summary>
        /// Transliteration of the Cyrillic alphabet into Latin
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToEng(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            for (var i = 0; i < Rules.GetLength(0); i++)
            {
                text = text.Replace(Rules[i, 0], Rules[i, 1]);
                text = text.Replace(Rules[i, 0].ToUpper(), Rules[i, 1].ToUpper());
            }

            return text;
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
            text = ToEng(text);
            text = PermlinkNotSupportedCharacters.Replace(text, string.Empty);
            return $"{text}-{DateTime.UtcNow:yyyy_MM_dd-HH_mm_ss}";
        }

        /// <summary>
        /// Generate a ParentPermlink by author and permlink
        /// </summary>
        /// <param name="author">Post author</param>
        /// <param name="permlink">Post permlink</param>
        /// <returns>A formatted string with a prefix (re-) and postfix (used current date and time)</returns>
        public static string PermlinkToParentPermlink(string author, string permlink)
        {
            author = WordDelimiters.Replace(author, "-");
            author = PermlinkNotSupportedCharacters.Replace(author, string.Empty);
            return $"re-{author}-{permlink}";
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