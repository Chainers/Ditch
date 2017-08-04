using System;
using System.Text.RegularExpressions;

namespace Ditch.Helpers
{
    internal class ConvertHelper
    {
        /// <summary>
        /// Сonverts a number to a minimal byte array
        /// *peeped  https://github.com/xeroc/python-graphenelib/blob/master/graphenebase/types.py
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static byte[] VarInt(int n)
        {
            //get array len
            var i = 1;
            var k = n;
            while (k >= 0x80)
            {
                k >>= 7;
                i++;
            }

            var data = new byte[i];
            i = 0;

            while (n >= 0x80)
            {
                data[i++] = (byte)(0x80 | (n & 0x7f));
                n >>= 7;
            }

            data[i] += (byte)n;
            return data;
        }


        private static readonly Regex ConvertRegex = new Regex(@"[_\s\.*]");
        private static readonly Regex CleanRegex = new Regex(@"[^a-z0-9-*]");
        private static readonly Regex ReplyPostfixRegex = new Regex(@"-[0-9*]t[0-9*]z$");


        public static string StringToPermlink(string text)
        {
            text = text.ToLower();
            text = text.Trim();
            text = Transliteration.Convert(text);
            text = ConvertRegex.Replace(text, "-");
            text = CleanRegex.Replace(text, string.Empty);
            return $"{text}-{DateTime.UtcNow:yyyyMMddTHHmmss}";
        }

        public static string PermlinkToParentPermlink(string author, string permlink)
        {
            permlink = ReplyPostfixRegex.Replace(permlink, string.Empty);
            return $"re-{author}-{permlink}-{DateTime.UtcNow:yyyyMMddTHHmmssfffZ}";
        }

        public static void TagTransliteration(string[] tags)
        {
            for (var index = 0; index < tags.Length; index++)
            {
                var tag = tags[index];
                tag = tag.ToLower();
                tag = tag.Trim();
                var translit = Transliteration.Convert(tag);
                tag = translit.Equals(tag) ? translit : $"ru--{translit}";
                tag = ConvertRegex.Replace(tag, "-");
                tag = CleanRegex.Replace(tag, string.Empty);
                tags[index] = tag;
            }
        }


    }
}