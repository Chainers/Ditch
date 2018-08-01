﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Converter.Core.Helpers;
using Converter.Core.Models;
using Newtonsoft.Json;

namespace Converter.Core
{
    public class CashParser
    {
        protected const string SubDirName = "JsonCash";
        protected Regex TypeDefName;
        protected Regex TypeDefType;
        protected Regex CommentRegex;
        protected Regex TemplateRegexp;
        protected Regex StartBodyRegex;
        protected Regex ClassRegex;
        protected Regex EnumRegex;
        protected Regex InheritRegex;
        protected Regex StartPrivateRegex;
        protected Regex ApiMethod;

        private readonly Grabber _grabber;
        private readonly string _projName;

        public CashParser(Grabber grabber, string projName)
        {
            _grabber = grabber;
            _projName = projName;

            TypeDefName = new Regex(@"(?<=^\s*typedef\s+[a-z0-9<>:,_]+\s+)[a-z0-9_]+", RegexOptions.IgnoreCase);
            TypeDefType = new Regex(@"(?<=^\s*typedef\s+)[a-z0-9<>:,_]+", RegexOptions.IgnoreCase);
            CommentRegex = new Regex(@"^\s*(\*|/)+");
            TemplateRegexp = new Regex(@"^\s*template<", RegexOptions.IgnoreCase);
            StartBodyRegex = new Regex(@"(?<=^[^/]*){");
            ClassRegex = new Regex(@"(?<=^\s*(class|struct|enum)\s+)[a-z_0-9]+", RegexOptions.IgnoreCase);
            EnumRegex = new Regex(@"^\s*enum\s+", RegexOptions.IgnoreCase);
            InheritRegex = new Regex(@"(?<=^\s*(class|struct)\s+[a-z_0-9]+\s*:\s*public\s+)[a-z:_<>\s]*(?=\s*\{)", RegexOptions.IgnoreCase);
            StartPrivateRegex = new Regex(@"^\s*private\s*:");
            ApiMethod = new Regex(@"(?<=\()[a-z_]*(?=\))");
        }


        public IEnumerable<ParsedClass> FindAndParse(SearchTask searchTask, string[] extensions, bool isApi)
        {
            var cashFile = Path.Combine(SubDirName, _projName, $"{searchTask.SearchLine}.txt");

            if (!Directory.Exists(SubDirName))
                Directory.CreateDirectory(SubDirName);
            if (!Directory.Exists(Path.Combine(SubDirName, _projName)))
                Directory.CreateDirectory(Path.Combine(SubDirName, _projName));

            if (!string.IsNullOrEmpty(searchTask.FullPath) && File.Exists(searchTask.FullPath))
            {
                if (File.Exists(cashFile))
                {
                    var text = File.ReadAllText(cashFile);
                    yield return JsonConvert.DeserializeObject<ParsedClass>(text);
                }
            }

            var lines = _grabber.FindClass(searchTask, extensions, isApi);
            foreach (var text in lines)
            {
                var parcedClass = TryParseClass(searchTask, text, isApi);
                parcedClass.AbsPathToFile = searchTask.FullPath.Remove(0, searchTask.SearchDir.Length);
                var json = JsonConvert.SerializeObject(parcedClass);
                File.WriteAllText(cashFile, json, Encoding.UTF8);
                yield return parcedClass;
            }
        }

        public string Unpack(string line, int zIndex)
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

        public List<string> SplitParams(string text)
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
        
        public virtual ParsedClass TryParseClass(SearchTask searchTask, IList<string> text, bool isApi)
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
            result.Name = name.ToTitleCase();
            result.ObjectType = EnumRegex.IsMatch(header) ? ObjectType.Enum : result.ObjectType;

            var inherit = TryParseInherit(header).Trim();
            if (!string.IsNullOrEmpty(inherit))
                result.CppInherit = inherit;

            while (index < text.Count)
            {
                if (StartPrivateRegex.IsMatch(text[index]) || (index + 1 == text.Count && text[index].Trim().StartsWith("}")))
                    break;

                if (result.ObjectType == ObjectType.Api && GoToDeclareApiSection(text, index, out index))
                    continue;

                var comm = TryParseComment(text, index, out index);
                if (index == text.Count)
                    break;

                if (StartPrivateRegex.IsMatch(text[index]))
                    break;

                PreParsedElement field = null;
                switch (result.ObjectType)
                {
                    case ObjectType.Enum:
                        {
                            field = TryParseEnum(text, index, out index);
                            break;
                        }
                    case ObjectType.Class:
                        {
                            field = TryParseElement(text, index, out index, isApi);
                            break;
                        }
                    case ObjectType.Api:
                        {
                            field = TryParseMethod(text, index, out index);
                            break;
                        }
                }

                if (field != null)
                {
                    field.MainComment = comm;
                    result.Fields.Add(field);
                }
            }

            return result;
        }


        private ParsedClass TryParseTypedefClass(string text)
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

        private string TryParseComment(IList<string> text, int index, out int end)
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

        private void TryParseTemplate(ParsedClass result, IList<string> text, int index, out int end)
        {
            var line = text[index];
            end = index;

            if (TemplateRegexp.IsMatch(line))
            {
                line = Unpack(line, 1);
                var itms = SplitParams(line);
                end++;
                var names = itms.Where(i => i.StartsWith("typename")).Select(i => i.Remove(0, 8).Trim()).ToArray();

                result.Template = $"<{string.Join(", ", names.Select(i => i.ToTitleCase()))}> ";
                if (itms.Count > names.Length)
                {
                    foreach (var itm in itms.Where(i => !i.StartsWith("typename")))
                    {
                        result.CppConstructorParams.Add(itm);
                    }
                }
            }
        }

        private string TryParseClassName(string text)
        {
            var rez = ClassRegex.Match(text);
            if (rez.Success)
                return rez.Value;

            throw new InvalidCastException();
        }

        private string TryParseInherit(string text)
        {
            var rez = InheritRegex.Match(text);
            if (rez.Success)
            {
                return rez.Value;
            }
            return string.Empty;
        }

        private PreParsedElement TryParseEnum(IList<string> lines, int index, out int end)
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
                Name = name.ToTitleCase(),
                CppName = name,
                Comment = coment
            };
            return field;
        }

        private PreParsedElement TryParseElement(IList<string> lines, int index, out int end, bool isApi)
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
                if (_grabber.IsBlockStart(lines, index, out index))
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

        private static Regex DeclareApi = new Regex(@"^\s*DECLARE_API\s*\(\s*");

        private bool GoToDeclareApiSection(IList<string> lines, int index, out int end)
        {
            end = index;
            for (var i = index; i < lines.Count; i++)
            {
                var match = DeclareApi.Match(lines[i]);
                if (match.Success)
                {
                    lines[i] = lines[i].Remove(0, match.Length);
                    end = i;
                    return true;
                }
            }
            return false;
        }

        protected virtual PreParsedElement TryParseMethod(IList<string> lines, int index, out int end)
        {
            end = index + 1;
            if (index >= lines.Count)
                return null;

            var text = lines[index].Trim();

            var match = ApiMethod.Match(text);
            if (!match.Success || string.IsNullOrWhiteSpace(match.Value))
                return null;

            return new PreParsedElement
            {
                CppText = match.Value
            };
        }

        protected string NormalizeType(string text)
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

        private bool TestWord(StringBuilder sb, string word, int end)
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
