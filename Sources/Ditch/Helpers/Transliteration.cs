using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ditch.Helpers
{
    public class Transliteration
    {
        //https://en.wikipedia.org/wiki/ISO_9
        private static readonly Dictionary<char, string> Rules = new Dictionary<char, string>
        {
            {'а', @"a"},
            {'б', @"b"},
            {'в', @"v"},
            {'г', @"g"},
            {'ѓ', @"g"},
            {'ґ', @"g"},
            {'д', @"d"},
            {'е', @"e"},
            {'ё', @"yo"},
            {'є', @"ye"},
            {'ж', @"zh"},
            {'з', @"z"},
            {'и', @"i"},
            {'й', @"j"},
            {'ї', @"yi"},
            {'к', @"k"},
            {'ќ', @"k"},
            {'л', @"l"},
            {'љ', @"l"},
            {'м', @"m"},
            {'н', @"n"},
            {'њ', @"n"},
            {'о', @"o"},
            {'п', @"p"},
            {'р', @"r"},
            {'с', @"s"},
            {'т', @"t"},
            {'у', @"u"},
            {'ў', @"u"},
            {'ф', @"f"},
            {'х', @"x"},
            {'ц', @"cz"},
            {'ч', @"ch"},
            {'џ', @"dh"},
            {'ш', @"sh"},
            {'щ', @"shh"},
            {'ы', @"y"},
            {'э', @"e"},
            {'ю', @"yu"},
            {'я', @"ya"},
            {'ѣ', @"ye"},
            {'ѳ', @"fh"},
            {'ѫ', @"о"},
        };

        public static string Convert(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if (!text.Any(t => Rules.ContainsKey(t)))
                return text;

            var sb = new StringBuilder();

            for (var i = 0; i < text.Length; i++)
            {
                string substitute;
                if (Rules.TryGetValue(text[i], out substitute))
                {
                    var nextChar = (text.Length > (i + 1)) ? text[i + 1] : ' ';
                    substitute = CheckSpecificRules(substitute, nextChar);
                    sb.Append(substitute);
                }
                else
                {
                    sb.Append(text[i]);
                }
            }
            return sb.ToString();
        }

        private static string CheckSpecificRules(string substitue, char nextCh)
        {
            if (substitue.Length != 2 || substitue[1] != 'z')
                return substitue;

            if (nextCh == 'е' || nextCh == 'ё' || nextCh == 'и' || nextCh == 'й' ||
                nextCh == 'i' || nextCh == 'ы' || nextCh == 'э' || nextCh == 'ю' ||
                nextCh == 'я' || nextCh == 'ѣ' || nextCh == 'Ѣ' || nextCh == 'ѵ')
                return substitue.Substring(0, 1);

            return substitue;
        }
    }
}