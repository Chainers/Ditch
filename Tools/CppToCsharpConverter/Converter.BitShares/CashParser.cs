using Converter.Core.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Converter.BitShares
{
    public class CashParser : Core.CashParser
    {
        public CashParser()
            : base(new Grabber(), "BitShares") { }

        protected override PreParsedElement TryParseMethod(IList<string> lines, int index, out int end)
        {
            end = index + 1;

            var text = lines[index].Trim();

            while (text.EndsWith(","))
            {
                var line = lines[end].Trim();
                if (line.Length > 0 && (line[0] == '/' || line[0] == '*'))
                    break;
                end++;
                text = $"{text} {line}";
            }

            text = NormalizeType(text);
            //if (!isApi)
            //{
            if (IsBlockStart(lines, index, out index))
            {
                end = index;
                return null;
            }
            //}
            return new PreParsedElement
            {
                CppText = text.Trim()
            };
        }

        private static readonly Regex BlockStartPref = new Regex(@"^[a-z0-9<>:,_\s-&\*\(\),]*{", RegexOptions.IgnoreCase);
        public static bool IsBlockStart(IList<string> lines, int startIndex, out int endIndex)
        {
            endIndex = startIndex;
            var line = lines[startIndex];
            if (!BlockStartPref.IsMatch(line)) return false;

            var deep = 0;
            for (var index = startIndex; index < lines.Count; index++)
            {
                line = lines[index];
                for (var i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case '{':
                            deep++;
                            break;
                        case '}':
                            deep--;
                            break;
                        case '/':
                            break;
                    }
                }
                if (deep == 0)
                {
                    endIndex = index + 1;
                    return true;
                }
            }
            return false;
        }
    }
}