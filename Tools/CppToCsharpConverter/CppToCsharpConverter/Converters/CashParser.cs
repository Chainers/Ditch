using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace CppToCsharpConverter.Converters
{
    public static class CashParser
    {
        private const string SubDirName = "JsonCash";
        private static readonly Regex TypeDefName = new Regex(@"(?<=^\s*typedef\s+[a-z0-9<>:,_]+\s+)[a-z0-9_]+", RegexOptions.IgnoreCase);
        private static readonly Regex TypeDefType = new Regex(@"(?<=^\s*typedef\s+)[a-z0-9<>:,_]+", RegexOptions.IgnoreCase);
        private static readonly Regex CommentRegex = new Regex(@"^\s*(\*|/)+");
        private static readonly Regex TemplateRegexp = new Regex(@"^\s*template<", RegexOptions.IgnoreCase);
        private static readonly Regex StartBodyRegex = new Regex(@"(?<=^[^/]*){");
        private static readonly Regex ClassRegex = new Regex(@"(?<=^\s*(class|struct|enum)\s+)[a-z_0-9]+", RegexOptions.IgnoreCase);
        private static readonly Regex EnumRegex = new Regex(@"^\s*enum\s+", RegexOptions.IgnoreCase);
        private static readonly Regex InheritRegex = new Regex(@"(?<=^\s*(class|struct)\s+[a-z_0-9]+\s*:\s*public\s+)[a-z:_<>\s]*(?=\s*\{)", RegexOptions.IgnoreCase);
        private static readonly Regex StartPrivateRegex = new Regex(@"^\s*private\s*:");


        public static IEnumerable<ParsedClass> FindAndParse(SearchTask searchTask, string projName, string[] extensions, bool isApi)
        {
            var cashFile = Path.Combine(SubDirName, projName, $"{searchTask.SearchLine}.txt");

            if (!Directory.Exists(SubDirName))
                Directory.CreateDirectory(SubDirName);
            if (!Directory.Exists(Path.Combine(SubDirName, projName)))
                Directory.CreateDirectory(Path.Combine(SubDirName, projName));

            if (!string.IsNullOrEmpty(searchTask.FullPath) && File.Exists(searchTask.FullPath))
            {
                if (File.Exists(cashFile))
                {
                    var text = File.ReadAllText(cashFile);
                    yield return JsonConvert.DeserializeObject<ParsedClass>(text);
                }
            }

            var lines = Grabber.FindClass(searchTask, projName, extensions);
            foreach (var text in lines)
            {
                var parcedClass = TryParseClass(text, isApi);
                parcedClass.AbsPathToFile = searchTask.FullPath.Remove(0, searchTask.SearchDir.Length);
                var json = JsonConvert.SerializeObject(parcedClass);
                File.WriteAllText(cashFile, json);
                yield return parcedClass;
            }
        }

        public static string Unpack(string line, int zIndex)
        {
            line = line.Trim();
            var startPos = 0;

            for (var i = 0; i < zIndex; i++)
            {
                startPos = line.IndexOf("<", startPos, StringComparison.Ordinal) + 1;
            }

            var buf = line.Remove(0, startPos);
            buf = buf.Remove(buf.Length - zIndex);
            return buf;
        }

        public static List<string> SplitParams(string text)
        {
            var rez = new List<string>();
            if (text.Contains(","))
            {
                var sb = new StringBuilder();
                var inner = 0;
                for (var i = 0; i < text.Length; i++)
                {
                    var ch = text[i];
                    switch (ch)
                    {
                        case '\t':
                        case ' ':
                            {
                                if (sb.Length > 0)
                                    sb.Append(ch);
                                break;
                            }
                        case ',':
                            {
                                if (inner == 0)
                                {
                                    rez.Add(sb.ToString());
                                    sb.Clear();
                                }
                                break;
                            }
                        case '<':
                            {
                                inner++;
                                sb.Append(ch);
                                break;
                            }
                        case '>':
                            {
                                inner--;
                                sb.Append(ch);
                                break;
                            }
                        default:
                            {
                                sb.Append(ch);
                                break;
                            }
                    }
                }
                rez.Add(sb.ToString());
            }
            else
            {
                rez.Add(text);
            }
            return rez;
        }

        public static string ToTitleCase(string name, bool firstUpper = true)
        {
            var sb = new StringBuilder(name);
            for (var i = 0; i < sb.Length; i++)
            {
                if (i == 0 && firstUpper)
                    sb[i] = char.ToUpper(sb[i]);

                if (sb[i] == '_' && i + 1 < sb.Length)
                    sb[i + 1] = char.ToUpper(sb[i + 1]);
            }
            sb.Replace("_", string.Empty);
            var rez = sb.ToString();
            if (rez.Equals("params"))
                rez = "parameters";

            return rez;
        }

        public static ParsedClass TryParseClass(IList<string> text, bool isApi)
        {
            if (!text.Any())
                return null;

            int index;
            if (text.Count == 1)
            {
                var typedef = TryParseTypedefClass(text[0]);
                if (typedef != null)
                    return typedef;
            }

            var result = new ParsedClass();
            if (isApi)
                result.ObjectType = ObjectType.Api;

            result.MainComment = TryParseComment(text, 0, out index);
            TryParseTemplate(result, text, index, out index);

            var headerSb = new StringBuilder();
            do
            {
                headerSb.Append(" " + text[index]);
            } while (!StartBodyRegex.IsMatch(text[index++]));

            var header = headerSb.ToString();
            var name = TryParseClassName(header);
            result.CppName = name;
            result.Name = ToTitleCase(name);
            result.ObjectType = EnumRegex.IsMatch(header) ? ObjectType.Enum : result.ObjectType;

            var inherit = TryParseInherit(header).Trim();
            if (!string.IsNullOrEmpty(inherit))
                result.CppInherit = inherit;

            while (index < text.Count)
            {
                if (StartPrivateRegex.IsMatch(text[index]) || (index + 1 == text.Count && text[index].Trim().StartsWith("}")))
                    break;

                var comm = TryParseComment(text, index, out index);
                if (index == text.Count)
                    break;
                if (StartPrivateRegex.IsMatch(text[index]))
                    break;

                var field = result.ObjectType == ObjectType.Enum
                    ? TryParseEnum(text, index, out index)
                    : TryParseElement(text, index, out index, isApi);

                if (field != null)
                {
                    field.MainComment = comm;
                    result.Fields.Add(field);
                }
            }

            return result;
        }


        private static ParsedClass TryParseTypedefClass(string text)
        {
            var nameMatch = TypeDefName.Match(text);
            if (!nameMatch.Success)
                return null;
            var typeMatch = TypeDefType.Match(text);
            if (!typeMatch.Success)
                return null;

            return new ParsedClass
            {
                CppName = nameMatch.Value,
                CppInherit = typeMatch.Value
            };
        }

        private static string TryParseComment(IList<string> text, int index, out int end)
        {
            end = text.Count;
            for (var i = index; i < text.Count; i++)
            {
                var line = text[i];
                if (string.IsNullOrWhiteSpace(line) || CommentRegex.IsMatch(line))
                    continue;
                end = i;
                break;
            }

            var comm = string.Join(Environment.NewLine, text.Skip(index).Take(end - index));
            return comm.Contains("/") ? comm : string.Empty;
        }

        private static void TryParseTemplate(ParsedClass result, IList<string> text, int index, out int end)
        {
            var line = text[index];
            end = index;

            if (TemplateRegexp.IsMatch(line))
            {
                line = Unpack(line, 1);
                var itms = SplitParams(line);
                end++;
                var names = itms.Where(i => i.StartsWith("typename")).Select(i => i.Remove(0, 8).Trim()).ToArray();

                result.Template = $"<{string.Join(", ", names.Select(i => ToTitleCase(i)))}> ";
                if (itms.Count > names.Length)
                {
                    foreach (var itm in itms.Where(i => !i.StartsWith("typename")))
                    {
                        result.CppConstructorParams.Add(itm);
                    }
                }
            }
        }

        private static string TryParseClassName(string text)
        {
            var rez = ClassRegex.Match(text);
            if (rez.Success)
                return rez.Value;

            throw new InvalidCastException();
        }

        private static string TryParseInherit(string text)
        {
            var rez = InheritRegex.Match(text);
            if (rez.Success)
            {
                return rez.Value;
            }
            return string.Empty;
        }

        private static PreParsedElement TryParseEnum(IList<string> lines, int index, out int end)
        {
            end = index + 1;
            var text = lines[index].Trim();
            var parts = text.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
                return null;

            var name = parts[0];
            var coment = string.Empty;
            if (parts.Length > 1)
                coment = string.Join(" ", parts.Skip(2)).TrimStart(' ', '/', '<');

            var field = new PreParsedElement
            {
                Name = ToTitleCase(name),
                CppName = name,
                Comment = coment
            };
            return field;
        }

        private static PreParsedElement TryParseElement(IList<string> lines, int index, out int end, bool isApi)
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
            if (!isApi)
            {
                if (Grabber.IsBlockStart(lines, index, out index))
                {
                    end = index;
                    return null;
                }
            }
            return new PreParsedElement
            {
                CppText = text.Trim()
            };
        }

        private static string NormalizeType(string text)
        {
            if (text.Length < 3)
                return text;

            var sb = new StringBuilder();
            int open = 0;
            for (int i = 0; i < text.Length; i++)
            {
                var ch = text[i];

                switch (ch)
                {
                    case '<':
                        if (i == 0)
                            break;

                        var chPrev = text[i - 1];
                        if (chPrev >= 'a' && chPrev <= 'z')
                            open++;
                        else if (chPrev == ' ' && i > 5 && TestWord(sb, "asset", sb.Length - 2))
                        {
                            open++;
                        }
                        else
                        {
                            //debug
                        }
                        break;
                    case '>':
                        if (open > 0)
                            open--;
                        else
                        {
                            //debug
                        }
                        break;
                    case ' ':
                        {
                            if (open > 0)
                            {
                                var privCh = text[i - 1];
                                if (privCh == ' ' || privCh == '<' || privCh == ',' || (i + 1 < text.Length && (text[i + 1] == '>' || text[i + 1] == ' ')))  // < int, int, int > to  <int,int,int> 
                                    continue;
                            }
                            else if (i + 1 < text.Length && text[i + 1] == '<')
                            {
                                continue;
                            }
                            break;
                        }
                }

                sb.Append(ch);
            }

            var text2 = sb.ToString();
            if (text2 != text)
            {
                //debug
            }

            return text2;
            //private static readonly Regex NormalizeType = new Regex(@"((?<=<)\s+)|(\s+((?=>)))|((?<=<[0-9_a-z\s]+,)\s+)", RegexOptions.IgnoreCase);
            //text = NormalizeType.Replace(text, string.Empty);
        }

        private static bool TestWord(StringBuilder sb, string word, int end)
        {
            var j = word.Length - 1;
            for (int i = end; i > end - j; i--)
            {
                if (sb[i] != word[j--])
                    return false;
            }
            if (end + 1 < sb.Length && sb[end + 1] == ' ')
                sb.Remove(end + 1, 1);
            return true;
        }
    }
}
