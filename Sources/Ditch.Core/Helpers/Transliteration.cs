namespace Ditch.Core.Helpers
{
    public static class Transliteration
    {
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
    }
}