using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Converter.Core;
using Converter.Core.Helpers;
using Converter.Core.Models;
using Newtonsoft.Json.Linq;

namespace Converter.Golos.Converters
{
    public abstract class BaseConverter
    {
        public const string ProjName = "Golos";

        private const string Url = "https://raw.githubusercontent.com/gropox/steemjsgui/master/src/steemjs/api/types.json";
        private static readonly Regex NamespacePref = new Regex(@"\b[a-z]+::", RegexOptions.IgnoreCase);
        private static readonly Regex ParamNormRegex = new Regex(@"(\bconst\b\s*)|(&*)", RegexOptions.IgnoreCase);
        private static readonly Regex ParamTypeRegex = new Regex(@"(?<=^|,\s*)[a-z0-9:_]+(<[a-z( ):_,0-9]*>)?", RegexOptions.IgnoreCase);
        private static readonly Regex ParamNameRegex = new Regex(@"(?<=[\w_>:]+\s+)[a-z0-9_]+(\s*=\s*[a-z0-9]+)?(?=,|$)", RegexOptions.IgnoreCase);
        protected static readonly Regex NotNameChar = new Regex("[^[a-z0-9_]]*", RegexOptions.IgnoreCase);

        protected readonly Dictionary<string, string> _knownTypes;
        public static readonly Dictionary<string, string> Founded = new Dictionary<string, string>();
        public static readonly Dictionary<string, ParsedClass> FoundedClass = new Dictionary<string, ParsedClass>();
        public static readonly List<SearchTask> UnknownTypes = new List<SearchTask>();
        private Dictionary<string, string> _methodDescriptions = new Dictionary<string, string>();

        public Dictionary<string, string> MethodDescriptions
        {
            get
            {
                if (_methodDescriptions == null || _methodDescriptions.Count == 0)
                {
                    _methodDescriptions = GetMethodDescriptions().Result;
                }
                return _methodDescriptions;
            }
        }

        protected readonly CashParser _cashParser;

        protected BaseConverter(Dictionary<string, string> knownTypes, CashParser cashParser)
        {
            _knownTypes = knownTypes;
            _cashParser = cashParser;
        }

        private async Task<Dictionary<string, string>> GetMethodDescriptions()
        {
            try
            {
                var result = new Dictionary<string, string>();
                var client = new HttpClient();
                var response = client.GetAsync(Url);
                var content = await response.Result.Content.ReadAsStringAsync();
                var types = JObject.Parse(content);
                var sections = types.Properties().ToList();
                foreach (var section in sections)
                {
                    var sectJObject = JObject.Parse(section.Value.ToString());
                    var methods = sectJObject.Properties().ToList();
                    foreach (var method in methods)
                    {
                        var methodJObject = JObject.Parse(method.Value.ToString());
                        var desc = JObject.Parse(methodJObject["desc"].ToString());
                        var enDesc = desc["ru"].ToString();
                        if (!result.ContainsKey(method.Name))
                        {
                            result.Add(method.Name, enDesc);
                        }
                    }
                }
                return result;
            }
            catch
            {
                //
            }
            return new Dictionary<string, string>();
        }

        public void PrintToFile(ParsedClass converted, string searchDir, string absPathToFile, string storeResultDir)
        {
            var outDir = $"{storeResultDir}\\{ProjName}\\";
            switch (converted.ObjectType)
            {
                case ObjectType.Class:
                case ObjectType.Enum:
                    {
                        outDir += "Models\\";
                        break;
                    }
                case ObjectType.Api:
                    {
                        outDir += "Apis\\";
                        break;
                    }
            }

            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            File.WriteAllText($"{outDir}{converted.Name}.cs", PrintParsedClass(converted, absPathToFile, searchDir), Encoding.UTF8);
            foreach (var itm in UnknownTypes)
            {
                if (string.IsNullOrEmpty(itm.SearchDir))
                    itm.SearchDir = searchDir;
            }
        }

        #region ParseText

        protected void ExtendPreParsedClass(ParsedClass parsedClass)
        {
            if (parsedClass == null)
                return;

            if (!string.IsNullOrEmpty(parsedClass.CppName))
                parsedClass.Name = parsedClass.CppName.ToTitleCase();
            if (!string.IsNullOrEmpty(parsedClass.CppInherit))
                parsedClass.Inherit = new List<ParsedType> { GetKnownTypeOrDefault(parsedClass.CppInherit) };

            if (parsedClass.CppConstructorParams != null && parsedClass.CppConstructorParams.Any())
            {
                foreach (var itm in parsedClass.CppConstructorParams)
                    parsedClass.ConstructorParams.Add(TryParseParam(itm));
            }

            if (parsedClass.ObjectType != ObjectType.Enum)
            {
                string templateName = null;
                if (parsedClass.IsTemplate)
                    templateName = _cashParser.Unpack(parsedClass.Template, 1);

                for (var i = 0; i < parsedClass.Fields.Count; i++)
                {
                    var preParsedElement = parsedClass.Fields[i];
                    parsedClass.Fields[i] = TryParseElement(preParsedElement, templateName, parsedClass.ObjectType);
                }
            }

            parsedClass.Fields.RemoveAll(i => i == null);
        }

        protected abstract PreParsedElement TryParseElement(PreParsedElement preParsedElement, string templateName, ObjectType objectType);

        protected ParsedType GetKnownTypeOrDefault(string type, string templateName = null)
        {
            var isOptional = false;
            type = type.Trim();
            if (NamespacePref.IsMatch(type))
                type = NamespacePref.Replace(type, string.Empty);

            if (type.StartsWith("optional<"))
            {
                type = _cashParser.Unpack(type, 1);
                isOptional = true;
            }

            if (type.StartsWith("static "))
                type = type.Remove(0, 7);
            if (type.StartsWith("const "))
                type = type.Remove(0, 6);

            if (type.EndsWith("<>"))
                type = type.Remove(type.Length - 2);

            if (type.IndexOf('<') > -1)
            {
                var ct = GetKnownCompositType(type);
                ct.IsOptional = isOptional;
                return ct;
            }

            if (_knownTypes.ContainsKey(type))
            {
                return new ParsedType { CppName = type, Name = _knownTypes[type], IsOptional = isOptional };
            }

            if (!string.IsNullOrEmpty(templateName) && type.Equals(templateName, StringComparison.OrdinalIgnoreCase))
            {
                return new ParsedType { CppName = type, Name = templateName, IsOptional = isOptional };
            }

            if (Founded.ContainsKey(type))
            {
                return new ParsedType { CppName = type, Name = Founded[type], IsOptional = isOptional };
            }

            if (!NotNameChar.IsMatch(type))
            {
                AddTypeToTask(type);
                return new ParsedType { CppName = type, Name = type.ToTitleCase(), IsOptional = isOptional };
            }

            return new ParsedType { CppName = type, Name = "object", IsOptional = isOptional };
        }

        private void AddTypeToTask(string type)
        {
            if (!Founded.ContainsKey(type))
            {
                Founded.Add(type, type.ToTitleCase());
                if (!UnknownTypes.Any(i => i.SearchLine.Equals(type) && string.IsNullOrEmpty(i.SearchDir)))
                {
                    var task = new SearchTask
                    {
                        Converter = KnownConverter.StructConverter,
                        SearchLine = type,
                    };
                    UnknownTypes.Add(task);
                }
            }
        }

        private ParsedType GetKnownCompositType(string type)
        {
            if (type.StartsWith("map<")) //TODO: research is needed
                return new ParsedType { CppName = type, Name = "object" };

            var unpacked = _cashParser.Unpack(type, 1);
            ParsedType parsedType;
            if (type.StartsWith("array<")) //TODO: research is needed
            {
                var countPart = unpacked.LastIndexOf(',');
                if (countPart > 0)
                {
                    unpacked = unpacked.Remove(countPart);
                    parsedType = GetKnownTypeOrDefault(unpacked);
                    parsedType.IsArray = true;
                    return parsedType;
                }
            }

            if (IsArray(type))
            {
                parsedType = GetKnownTypeOrDefault(unpacked);
                parsedType.IsArray = true;
                return parsedType;
            }

            var chArray = _cashParser.SplitParams(unpacked);
            var tmpl = type.Remove(type.IndexOf('<'));
            parsedType = tmpl.Equals("pair")
                ? new ParsedType { Name = "KeyValuePair" }
                : GetKnownTypeOrDefault(tmpl);
            parsedType.IsTemplate = true;

            foreach (var item in chArray)
            {
                var ch = GetKnownTypeOrDefault(item);
                parsedType.Container.Add(ch);
            }
            return parsedType;
        }

        private bool IsArray(string line)
        {
            return line.StartsWith("set<")
                   | line.StartsWith("vector<")
                   | line.StartsWith("deque<");
        }

        protected List<ParsedParams> TryParseParams(string parameters)
        {
            parameters = ParamNormRegex.Replace(parameters, string.Empty);
            parameters = parameters.Trim();
            if (string.IsNullOrEmpty(parameters))
                return new List<ParsedParams>();

            var typeMatches = ParamTypeRegex.Matches(parameters);
            var nameMatches = ParamNameRegex.Matches(parameters);

            if (typeMatches.Count != nameMatches.Count)
                throw new InvalidCastException();

            var rez = new List<ParsedParams>();
            for (var i = 0; i < typeMatches.Count; i++)
            {
                var defaultValue = string.Empty;
                var name = nameMatches[i].Value;
                var eqv = name.IndexOf("=", StringComparison.Ordinal);
                if (eqv > -1)
                {
                    defaultValue = name.Substring(eqv + 1).Trim();
                    name = name.Remove(eqv).Trim();
                }

                var param = new ParsedParams()
                {
                    CppName = name,
                    Name = name.ToTitleCase(false),
                    Default = defaultValue,
                    CppType = typeMatches[i].Value,
                    Type = GetKnownTypeOrDefault(typeMatches[i].Value)
                };
                rez.Add(param);
            }

            return rez;
        }

        private ParsedParams TryParseParam(string parameters)
        {
            parameters = ParamNormRegex.Replace(parameters, string.Empty);
            parameters = parameters.Trim();
            if (string.IsNullOrEmpty(parameters))
                return new ParsedParams();

            var typeMatche = ParamTypeRegex.Match(parameters);
            var nameMatche = ParamNameRegex.Match(parameters);

            if (!typeMatche.Success || !nameMatche.Success)
                throw new InvalidCastException();

            var defaultValue = string.Empty;
            var name = nameMatche.Value;
            var eqv = name.IndexOf("=", StringComparison.Ordinal);
            if (eqv > -1)
            {
                defaultValue = name.Substring(eqv + 1).Trim();
                name = name.Remove(eqv).Trim();
            }

            var rez = new ParsedParams()
            {
                CppName = name,
                Name = name.ToTitleCase(false),
                Default = defaultValue,
                CppType = typeMatche.Value,
                Type = GetKnownTypeOrDefault(typeMatche.Value)
            };
            return rez;
        }

        #endregion ParseText

        #region PrintClass

        private void PrinNamespace(StringBuilder sb, ParsedClass parsedClass)
        {
            switch (parsedClass.ObjectType)
            {
                case ObjectType.Class:
                    {
                        sb.AppendLine("using System;");
                        sb.AppendLine("using Newtonsoft.Json;");
                        sb.AppendLine();
                        sb.AppendLine($"namespace Ditch.{ProjName}.Models");
                        break;
                    }
                case ObjectType.Enum:
                    {
                        sb.AppendLine("using Ditch.Core.Converters;");
                        sb.AppendLine("using Newtonsoft.Json;");
                        sb.AppendLine();
                        sb.AppendLine($"namespace Ditch.{ProjName}.Models");
                        break;
                    }
                case ObjectType.Api:
                    {
                        sb.AppendLine("using Ditch.Core;");
                        sb.AppendLine("using System;");
                        sb.AppendLine("using System.Collections.Generic; ");
                        sb.AppendLine("using Ditch.Core.JsonRpc;");
                        sb.AppendLine($"using Ditch.{ProjName}.Models;");
                        sb.AppendLine();
                        sb.AppendLine($"namespace Ditch.{ProjName}.Api");
                        break;
                    }
            }

            sb.AppendLine("{");
        }

        public string PrintParsedClass(ParsedClass parsedClass, string absPathToFile, string searchDir)
        {
            var sb = new StringBuilder();
            PrinNamespace(sb, parsedClass);
            AddClassName(sb, parsedClass, absPathToFile, 4);
            string templateName = null;
            if (parsedClass.IsTemplate)
                templateName = _cashParser.Unpack(parsedClass.Template, 1);

            var doc = string.Empty;
            if (parsedClass.ObjectType == ObjectType.Api && !string.IsNullOrEmpty(searchDir))
                doc = File.ReadAllText(searchDir + absPathToFile);

            foreach (var t in parsedClass.Fields)
            {
                if (parsedClass.ObjectType == ObjectType.Api && !string.IsNullOrEmpty(doc) && !doc.Contains($"({t.CppName})"))
                    continue;

                PrintParsedElements(sb, parsedClass, t, 8, templateName);
            }

            CloseTag(sb, 4);
            CloseTag(sb, 0);
            return sb.ToString();
        }

        private void AddClassName(StringBuilder sb, ParsedClass parsedClass, string absPathToFile, int indentCount)
        {
            var indent = new string(' ', indentCount);

            if (!string.IsNullOrEmpty(parsedClass.MainComment))
                sb.AppendLine($"{indent}{parsedClass.MainComment.Replace("\r\n", "\r\n" + indent)}{Environment.NewLine}");
            sb.AppendLine($"{indent}/// <summary>");
            sb.AppendLine($"{indent}/// {parsedClass.CppName}");
            if (!string.IsNullOrEmpty(absPathToFile))
                sb.AppendLine($@"{indent}/// {absPathToFile}");
            sb.AppendLine($"{indent}/// </summary>");

            switch (parsedClass.ObjectType)
            {
                case ObjectType.Class:
                    {
                        sb.AppendLine($"{indent}[JsonObject(MemberSerialization.OptIn)]");
                        sb.AppendLine($"{indent}public class {parsedClass.Name}{(parsedClass.IsTemplate ? parsedClass.Template : string.Empty)}{(parsedClass.Inherit.Any() ? $" : {string.Join(", ", parsedClass.Inherit)}" : string.Empty)}");
                        break;
                    }
                case ObjectType.Enum:
                    {
                        sb.AppendLine($"{indent}[JsonConverter(typeof(EnumConverter))]");
                        sb.AppendLine($"{indent}public enum {parsedClass.Name}");
                        break;
                    }
                case ObjectType.Api:
                    {
                        sb.AppendLine($"{indent}public partial class OperationManager");
                        break;
                    }
            }
            sb.AppendLine($"{indent}{{");
        }

        private string TypeCorrection(string line)
        {
            if (string.IsNullOrEmpty(line))
                return line;
            return line.Replace("<", "&lt;");
        }

        private void PrintParsedElements(StringBuilder sb, ParsedClass parsedClass, PreParsedElement parsedElement, int indentCount, string templateName)
        {
            var indent = new string(' ', indentCount);
            sb.AppendLine();

            Comment briefComment = null;
            var parsedFunc = parsedElement as ParsedFunc;
            if (parsedFunc != null)
            {
                briefComment = Comment.TryParseMainComment(parsedFunc.MainComment);
                if (briefComment != null && !briefComment.IsEmpty())
                    parsedFunc.MainComment = Comment.RemoveBriefFromMainComment(parsedFunc.MainComment);
            }

            //if (!string.IsNullOrEmpty(parsedElement.MainComment))
            //{
            //    sb.Append(indent);
            //    sb.AppendLine(parsedElement.MainComment);
            //    sb.AppendLine();
            //}

            var comment = parsedElement.Comment ?? string.Empty;
            //comment = comment.Replace("\\", $@"/// {Environment.NewLine}");

            sb.AppendLine($"{indent}/// <summary>");
            sb.AppendLine($"{indent}/// API name: {parsedElement.CppName}");
            if (!string.IsNullOrWhiteSpace(briefComment?.Brief))
            {
                sb.AppendLine($"{indent}/// {briefComment.Brief.Replace(Environment.NewLine, $"{Environment.NewLine}{indent}/// ")}");
                sb.AppendLine($"{indent}///");
            }
            if (parsedClass.ObjectType == ObjectType.Api && !string.IsNullOrWhiteSpace(parsedElement.CppName) && MethodDescriptions.ContainsKey(parsedElement.CppName))
            {
                var text = MethodDescriptions[parsedElement.CppName];
                if (!string.IsNullOrWhiteSpace(text) && (briefComment == null || !briefComment.IsBriefContainText(text)))
                {
                    sb.AppendLine($"{indent}/// *{text.Trim()}");
                }
            }
            sb.AppendLine($"{indent}/// {TypeCorrection(comment)}");
            sb.AppendLine($"{indent}/// </summary>");

            if (parsedFunc != null)
            {
                foreach (var itm in parsedFunc.Params)
                {
                    sb.Append($"{indent}/// <param name=\"{itm.Name}\">API type: {TypeCorrection(itm.CppType)}");

                    if (briefComment != null && briefComment.Params.ContainsKey(itm.CppName))
                        sb.Append(briefComment.Params[itm.CppName].Replace(Environment.NewLine, $"{Environment.NewLine}{indent}/// "));

                    sb.AppendLine("</param>");
                }

                if (parsedClass.ObjectType == ObjectType.Api)
                    sb.AppendLine($"{indent}/// <param name=\"token\">Throws a <see cref=\"T:System.OperationCanceledException\" /> if this token has had cancellation requested.</param>");
            }

            if (!string.IsNullOrWhiteSpace(briefComment?.Return) || !string.IsNullOrEmpty(parsedElement.Type?.CppName))
            {
                sb.Append($"{indent}/// <returns>");
                if (!string.IsNullOrEmpty(parsedElement.Type?.CppName))
                {
                    sb.Append($"API type: {TypeCorrection(parsedElement.Type.CppName)}");
                    if (!string.IsNullOrWhiteSpace(briefComment?.Return))
                        sb.Append(" ");
                }

                if (!string.IsNullOrWhiteSpace(briefComment?.Return))
                    sb.Append($"{briefComment.Return.Replace(Environment.NewLine, $"{Environment.NewLine}{indent}/// ")}");
                sb.AppendLine("</returns>");
            }


            if (parsedClass.ObjectType == ObjectType.Api)
                sb.AppendLine($"{indent}/// <exception cref=\"T:System.OperationCanceledException\">The token has had cancellation requested.</exception>");

            var type = GetTypeForPrint(parsedElement.Type, templateName);
            if (parsedFunc != null)
            {
                sb.AppendLine($"{indent}public JsonRpcResponse{(type.Equals("void", StringComparison.OrdinalIgnoreCase) ? string.Empty : $"<{type}>")} {parsedElement.Name}({string.Join(", ", parsedFunc.Params)}{(parsedClass.ObjectType == ObjectType.Api ? $"{(parsedFunc.Params.Any() ? ", " : string.Empty)}CancellationToken token" : string.Empty)})");
                sb.AppendLine($"{indent}{{");

                sb.Append($"{indent}    return CustomGetRequest{(type.Equals("void", StringComparison.OrdinalIgnoreCase) ? string.Empty : $"<{type}>")}(");
                if (parsedClass.ObjectType == ObjectType.Api)
                    sb.Append($"KnownApiNames.{parsedClass.Name}, ");

                sb.Append($"\"{parsedElement.CppName}\"");


                sb.Append(", new object[] {");
                if (parsedFunc.Params.Any())
                    sb.Append(string.Join(", ", parsedFunc.Params.Select(i => i.Name)));
                sb.Append("}");

                if (parsedClass.ObjectType == ObjectType.Api)
                    sb.Append(", token");
                sb.AppendLine(");");
                sb.AppendLine($"{indent}}}");
            }
            else
            {
                if (parsedClass.ObjectType != ObjectType.Enum)
                    sb.AppendLine($"{indent}[JsonProperty(\"{parsedElement.CppName}\"{(parsedElement.Type != null && parsedElement.Type.IsOptional ? ", NullValueHandling = NullValueHandling.Ignore" : string.Empty)})]");
                sb.AppendLine(parsedElement.Type != null
                    ? $"{indent}public {type} {parsedElement.Name} {{get; set;}}"
                    : $"{indent}{parsedElement.Name},");
            }
        }

        private class Comment
        {
            public string Brief { get; set; }

            public Dictionary<string, string> Params { get; set; } = new Dictionary<string, string>();

            public string Return { get; set; }


            public bool IsEmpty()
            {
                return string.IsNullOrEmpty(Brief) && Params.Count == 0 && string.IsNullOrEmpty(Return);
            }

            public static string RemoveBriefFromMainComment(string mainComment)
            {
                if (!string.IsNullOrWhiteSpace(mainComment) && mainComment.Contains("//"))
                {
                    var start = mainComment.IndexOf("/**", StringComparison.Ordinal);
                    if (start > -1)
                    {
                        mainComment = mainComment.Remove(start).Trim(new[] { ' ', '\r', '\n' });
                    }
                    return mainComment;
                }
                return string.Empty;
            }

            public static Comment TryParseMainComment(string mainComment)
            {
                if (!string.IsNullOrWhiteSpace(mainComment))
                {
                    var tag = "@brief ";
                    var start = mainComment.IndexOf(tag, StringComparison.Ordinal);
                    if (start == -1)
                    {
                        tag = "@param ";
                        start = mainComment.IndexOf(tag, StringComparison.Ordinal);
                        if (start == -1)
                        {
                            tag = "@return ";
                            start = mainComment.IndexOf(tag, StringComparison.Ordinal);

                            if (start == -1)
                                return null;
                        }
                    }

                    start += tag.Length;
                    int end = mainComment.Length;
                    var rez = new Comment();

                    while (start < end)
                    {
                        var newTag = GetBlockEnd(mainComment, start, out end);
                        var line = mainComment.Substring(start, end - start);
                        line = TrimLine(line);
                        switch (tag)
                        {
                            case "@brief ":
                                rez.Brief = line;
                                break;
                            case "@param ":
                                var nameEnd = line.IndexOf(' ');
                                rez.Params.Add(line.Remove(nameEnd), line.Substring(nameEnd));
                                break;
                            case "@return ":
                                rez.Return = line;
                                break;
                        }
                        tag = newTag;
                        start = end + tag.Length;
                        end = mainComment.Length;
                    }
                    return rez;
                }
                return null;
            }

            private static string GetBlockEnd(string text, int start, out int end)
            {
                end = text.IndexOf("@param ", start, StringComparison.Ordinal);
                if (end > -1)
                    return "@param ";

                end = text.IndexOf("@return ", start, StringComparison.Ordinal);
                if (end > -1)
                    return "@return ";
                end = text.Length;

                return string.Empty;
            }

            private static string TrimLine(string line)
            {
                var nl = new[] { '\r', '\n' };
                var rem = new[] { '\t', ' ', '*', '/' };
                var lines = line.Split(nl, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(Environment.NewLine, lines.Select(i => i.TrimStart(rem))).TrimEnd(nl);
            }

            public bool IsBriefContainText(string text)
            {
                if (string.IsNullOrEmpty(Brief))
                    return string.IsNullOrEmpty(text);

                var t1 = Brief.Replace('\r', ' ')
                .Replace('\n', ' ')
                .Replace('\t', ' ')
                .Replace("  ", " ");

                var t2 = text.Replace('\r', ' ')
                .Replace('\n', ' ')
                .Replace('\t', ' ')
                .Replace("  ", " ");

                return t1.Equals(t2, StringComparison.CurrentCulture);
            }
        }


        private string GetTypeForPrint(ParsedType parsedType, string templateName)
        {
            if (parsedType == null)
                return string.Empty;
            var type = parsedType.Name;
            //if (!(!string.IsNullOrEmpty(templateName) && type.Equals(templateName, StringComparison.OrdinalIgnoreCase) || _knownTypes.ContainsValue(parsedType.Name)))
            //    type = $"I{type}";
            if (parsedType.IsTemplate)
                type += $"<{string.Join(", ", parsedType.Container.Select(pt => GetTypeForPrint(pt, templateName)))}>";
            if (parsedType.IsArray)
                type += "[]";
            return type;
        }

        private void CloseTag(StringBuilder sb, int indentCount)
        {
            var indent = new string(' ', indentCount);
            sb.AppendLine($"{indent}}}");
        }

        #endregion
    }
}