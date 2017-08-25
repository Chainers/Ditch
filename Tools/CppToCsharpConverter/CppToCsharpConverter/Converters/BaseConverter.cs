using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CppToCsharpConverter.Converters
{
    public abstract class BaseConverter
    {
        protected readonly Dictionary<string, string> KnownTypes;

        protected static readonly Regex CommentRegex = new Regex(@"^\s*(\*|/)+");
        protected static readonly Regex EnumRegex = new Regex(@"^\s*enum\s+", RegexOptions.IgnoreCase);
        protected static readonly Regex ClassRegex = new Regex(@"(?<=^\s*((class)|(struct)|(enum))\s+)[a-z_0-9]*", RegexOptions.IgnoreCase);
        protected static readonly Regex InheritRegex = new Regex(@"(?<=^\s*(class)|(struct)\s+[a-z_0-9]*\s*:\s*public\s+(object)*\s*<?\s*)[a-z_0-1,\s]*(?=>?)", RegexOptions.IgnoreCase);
        protected static readonly Regex StartBodyRegex = new Regex(@"(?<=^[^/]*){");
        protected static readonly Regex DirNameRegex = new Regex(@"(?<=\\)[\w-_.]*(?=\\*$)", RegexOptions.IgnoreCase);
        protected static readonly Regex StartPrivateRegex = new Regex(@"^\s*private\s*:");

        protected readonly Regex NotTypeChar = new Regex("[^[a-z0-9_:<,>]]*", RegexOptions.Compiled | RegexOptions.ExplicitCapture);
        protected readonly Regex NotNameChar = new Regex("[^[a-z0-9_]]*");
        protected readonly Regex NormalizeType = new Regex(@"((?<=<)\s*)|(\s*((?=>)))|((?<=[<][0-9_a-z\s]*[,])\s*)|(\b[a-z]*::\b)|");
        protected readonly Regex PairType = new Regex("(?<=^([a-z0-90_:]*){1,}),(?=([a-z0-90_:]*){1,}$)|(?<=^([a-z0-90_:]*[<][a-z0-90_,:]*[>]){1,}),(?=([a-z0-90_:]*[<][a-z0-90_,:]*[>]){1,}$)");
        protected readonly Regex TypeDefName = new Regex(@"(?<=^\s*typedef\s+[\w<>:]*\s)[\w]*");
        protected readonly Regex TypeDefType = new Regex(@"(?<=^\s*typedef\s+)[\w<>:]*");

        protected BaseConverter(Dictionary<string, string> knownTypes)
        {
            KnownTypes = knownTypes;
        }

        public List<SearchTask> UnknownTypes = new List<SearchTask>();

        public void FindAndExecute(SearchTask searchTask)
        {
            if (string.IsNullOrWhiteSpace(searchTask.SearchLine))
                return;

            if (File.Exists(searchTask.FullPath))
            {
                if (TryExecute(searchTask.FullPath, searchTask.SearchLine, searchTask.SearchDir))
                    return;
            }

            var files = Directory.GetFiles(searchTask.SearchDir, "*.*", SearchOption.AllDirectories).Where(IsCodeFile).ToArray();
            foreach (var file in files)
            {
                if (TryExecute(file, searchTask.SearchLine, searchTask.SearchDir))
                {
                    searchTask.FullPath = file;
                    return;
                }
            }
        }

        protected bool TryExecute(string filePath, string searchLine, string dir)
        {
            var text = TryGrabText(filePath, searchLine);
            if (text != null)
            {
                var converted = TryParseClass(text);
                PrintToFile(filePath, searchLine, dir, converted, text);
                return true;
            }
            return false;
        }

        protected void PrintToFile(string filePath, string searchLine, string dir, ParsedClass converted, List<string> text)
        {
            var outDir = $"{DirNameRegex.Match(dir).Value}\\{(converted.IsInterface ? "Api" : "Models")}";
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);
            File.WriteAllText($"{outDir}\\{converted.CppName}.txt", string.Join(Environment.NewLine, text));
            File.WriteAllText($"{outDir}\\{converted.Name}.cs", PrintParsedClass(converted, filePath, dir));
            foreach (var itm in UnknownTypes)
            {
                if (string.IsNullOrEmpty(itm.SearchDir))
                    itm.SearchDir = dir;
            }
        }

        #region GrabText

        protected virtual bool IsCodeFile(string path)
        {
            return path.EndsWith(".cpp") || path.EndsWith(".hpp");
        }

        protected virtual List<string> TryGrabText(string filePath, string searchLine)
        {
            if (!File.Exists(filePath))
                return null;

            var lines = File.ReadLines(filePath).ToArray();
            List<string> text = null;
            var deep = 0;
            var startWrite = false;
            var enterb = false;
            var typedefRegexp = new Regex($@"(?<=^\s*typedef\s+)[\w:]*(?=\s*{searchLine})");
            var classRegexp = new Regex($@"(?<=^\s*(class|struct|enum)\s){searchLine}\b");

            for (var index = 0; index < lines.Length; index++)
            {
                var line = lines[index];

                if (typedefRegexp.IsMatch(line))
                    return new List<string> { line };

                if (!startWrite && classRegexp.IsMatch(line))
                {
                    startWrite = true;
                    text = TryGetComent(lines, index - 1);
                }

                if (!startWrite) continue;

                for (var i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case '{':
                            enterb = true;
                            deep++;
                            break;
                        case '}':
                            deep--;
                            break;
                    }
                }
                text.Add(line);

                if (enterb && deep == 0)
                    break;
            }
            return text;
        }

        public List<string> TryGetComent(string[] lines, int endIndex)
        {
            var text = new List<string>();
            for (var i = endIndex; i >= 0; i--)
            {
                var line = lines[i].Trim();
                if (line.StartsWith("/") || line.StartsWith("*"))
                {
                    text.Add(lines[i]);
                }
                else if (string.IsNullOrWhiteSpace(line))
                {
                    if (line.Any())
                        text.Add(lines[i]);
                }
                else
                {
                    break;
                }
            }
            text.Reverse();
            return text;
        }

        #endregion GrabText

        #region ParseText

        protected virtual ParsedClass InitParsedClass()
        {
            return new ParsedClass();
        }

        protected virtual ParsedClass TryParseTypedefClass(string text)
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
                Name = ToTitleCase(nameMatch.Value),
                Inherit = new List<string> { GetKnownTypeOrDefault(typeMatch.Value) }
            };
        }

        protected virtual ParsedClass TryParseClass(List<string> text)
        {
            int index;
            if (text.Count == 1)
            {
                var typedef = TryParseTypedefClass(text[0]);
                if (typedef != null)
                    return typedef;
            }

            var result = InitParsedClass();
            result.MainComment = TryParseComment(text, 0, out index);

            var headerSb = new StringBuilder();
            do
            {
                headerSb.AppendLine(text[index]);
            } while (!StartBodyRegex.IsMatch(text[index++]));
            var header = headerSb.ToString();
            var name = TryParseClassName(header);
            result.CppName = name;
            result.Name = ToTitleCase(name);
            result.IsEnum = EnumRegex.IsMatch(header);
            var inherit = TryParseInherit(header).Trim();
            if (!string.IsNullOrEmpty(inherit))
            {
                var allInherit = inherit.Split(',');

                foreach (var itm in allInherit)
                {
                    if (!string.IsNullOrWhiteSpace(itm))
                    {
                        var bf = itm.Trim();
                        var nbf = ToTitleCase(bf);
                        if (!KnownTypes.ContainsKey(bf))
                            KnownTypes.Add(bf, nbf);
                        if (!result.CppName.Equals(bf))
                            result.Inherit.Add(nbf);
                    }
                }
            }

            while (index < text.Count)
            {
                if (StartPrivateRegex.IsMatch(text[index]))
                    break;
                var comm = TryParseComment(text, index, out index);
                if (StartPrivateRegex.IsMatch(text[index]))
                    break;
                var field = result.IsEnum ? TryParseEnum(text, index, out index) : TryParseElement(text, index, out index);
                if (field != null)
                {
                    field.MainComment = comm;
                    result.Fields.Add(field);
                }
            }

            return result;
        }

        protected abstract IParsedElement TryParseElement(List<string> lines, int index, out int end);


        protected IParsedElement TryParseEnum(List<string> lines, int index, out int end)
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

            var field = new ParsedField
            {
                Name = ToTitleCase(name),
                CppName = name,
                Comment = coment
            };
            return field;
        }

        protected string GetKnownTypeOrDefault(string type)
        {
            if (type.StartsWith("optional<"))
                type = Unpack(type, 1);

            if (type.StartsWith("const "))
                type = type.Remove(0, 6);

            if (type.IndexOf('<') > -1)
            {
                return GetKnownCompositType(type);
            }

            if (KnownTypes.ContainsKey(type))
                return KnownTypes[type];

            if (!NotNameChar.IsMatch(type))
            {
                if (!UnknownTypes.Any(i => i.SearchLine.Equals(type) && string.IsNullOrEmpty(i.SearchDir)))
                {
                    var task = new SearchTask
                    {
                        Converter = KnownConverter.StructConverter,
                        SearchLine = type,
                    };
                    UnknownTypes.Add(task);
                }
                if (!KnownTypes.ContainsKey(type))
                    KnownTypes.Add(type, ToTitleCase(type));

                return ToTitleCase(type);
            }

            return "object";
        }

        protected string ToTitleCase(string name, bool firstUpper = true)
        {
            var sb = new StringBuilder(name.ToLower());
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

        protected string GetKnownCompositType(string line)
        {
            if (line.StartsWith("map<") || line.StartsWith("array<"))
                return "object";

            if (IsArray(line))
            {
                line = Unpack(line, 1);
                return $"{GetKnownTypeOrDefault(line)}[]";
            }
            if (line.StartsWith("pair<"))
            {
                var buf = Unpack(line, 1);

                var m = PairType.Matches(buf);
                if (m.Count != 1)
                    return "KeyValuePair<object,object>";

                var index = m[0].Index;
                return $"KeyValuePair<{GetKnownTypeOrDefault(buf.Substring(0, index))},{GetKnownTypeOrDefault(buf.Substring(index + 1))}>";
            }

            return "object";
        }

        protected bool IsArray(string line)
        {
            return line.StartsWith("set<")
                   | line.StartsWith("vector<")
                   | line.StartsWith("deque<");
        }

        protected string Unpack(string line, int zIndex)
        {
            int startPos = 0;

            for (int i = 0; i < zIndex; i++)
            {
                startPos = line.IndexOf("<", startPos, StringComparison.Ordinal) + 1;
            }

            var buf = line.Remove(0, startPos);
            buf = buf.Remove(buf.Length - zIndex);
            return buf;
        }

        protected string TryParseClassName(string text)
        {
            var rez = ClassRegex.Match(text);
            if (rez.Success)
                return rez.Value;

            throw new InvalidCastException();
        }

        protected string TryParseComment(List<string> text, int index, out int end)
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

        protected string TryParseInherit(string text)
        {
            Match rez = InheritRegex.Match(text);
            if (rez.Success)
            {
                return rez.Value;
            }
            return string.Empty;
        }

        #endregion ParseText

        #region PrintClass

        protected virtual void PrinNamespace(StringBuilder sb, ParsedClass parsedClass, string rootDir)
        {
            sb.AppendLine("using System;");
            if (parsedClass.IsInterface)
                sb.AppendLine($"using Ditch.{rootDir}.Models;");
            sb.AppendLine();
            sb.AppendLine($"namespace Ditch.{rootDir}.{(parsedClass.IsInterface ? "Api" : "Models")}");
            sb.AppendLine("{");
        }

        protected virtual string PrintParsedClass(ParsedClass parsedClass, string pathToFile, string dir)
        {
            var sb = new StringBuilder();
            var rootDir = DirNameRegex.Match(dir).Value;
            rootDir = ToTitleCase(rootDir).Replace(".", "_").Replace("-", "_");
            PrinNamespace(sb, parsedClass, rootDir);
            AddClassName(sb, parsedClass, pathToFile, dir, 4);
            foreach (var t in parsedClass.Fields)
                PrintParsedElements(sb, t, 8);

            CloseClass(sb, 4);
            CloseClass(sb, 0);
            return sb.ToString();
        }

        protected virtual void AddClassName(StringBuilder sb, ParsedClass parsedClass, string pathToFile, string dir, int indentCount)
        {
            var indent = new string(' ', indentCount);
            if (!string.IsNullOrEmpty(parsedClass.MainComment))
                sb.AppendLine($"{indent}{parsedClass.MainComment.Replace("\r\n", "\r\n" + indent)}{Environment.NewLine}");
            sb.AppendLine($"{indent}/// <summary>");
            sb.AppendLine($"{indent}/// {parsedClass.CppName}");
            if (!string.IsNullOrEmpty(pathToFile))
                sb.AppendLine($@"{indent}/// {pathToFile.Remove(0, dir.Length)}");
            sb.AppendLine($"{indent}/// </summary>");
            if (!parsedClass.IsInterface)
                sb.AppendLine($"{indent}[JsonObject(MemberSerialization.OptIn)]");

            sb.AppendLine($"{indent}public {(parsedClass.IsInterface ? "interface" : parsedClass.IsEnum ? "enum" : "class")} {parsedClass.Name}{(parsedClass.Inherit.Any() ? $": {string.Join(", ", parsedClass.Inherit)}" : string.Empty)}");
            sb.AppendLine($"{indent}{{");
        }

        protected abstract void PrintParsedElements(StringBuilder sb, IParsedElement parsedElement, int indentCount);

        protected void CloseClass(StringBuilder sb, int indentCount)
        {
            var indent = new string(' ', indentCount);
            sb.AppendLine($"{indent}}}");
        }

        #endregion
    }
}