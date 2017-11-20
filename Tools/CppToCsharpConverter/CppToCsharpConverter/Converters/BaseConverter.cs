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
        private static readonly Regex NamespacePref = new Regex(@"\b[a-z]+::", RegexOptions.IgnoreCase);
        private static readonly Regex ParamNormRegex = new Regex(@"(\bconst\b\s*)|(&*)", RegexOptions.IgnoreCase);
        private static readonly Regex ParamTypeRegex = new Regex(@"(?<=^|,\s*)[a-z0-9:<_,>]+", RegexOptions.IgnoreCase);
        private static readonly Regex ParamNameRegex = new Regex(@"(?<=[\w_>:]+\s+)[a-z0-9_]+(\s*=\s*[a-z0-9]+)?(?=,|$)", RegexOptions.IgnoreCase);
        protected static readonly Regex NotNameChar = new Regex("[^[a-z0-9_]]*", RegexOptions.IgnoreCase);

        private readonly Dictionary<string, string> _knownTypes;
        public static readonly Dictionary<string, string> Founded = new Dictionary<string, string>();
        public static readonly List<SearchTask> UnknownTypes = new List<SearchTask>();

        protected BaseConverter(Dictionary<string, string> knownTypes)
        {
            _knownTypes = knownTypes;
        }

        public ParsedClass FindAndParse(SearchTask searchTask, string projName, string[] extensions, bool isApi)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTask.SearchLine))
                    return null;

                var classes = CashParser.FindAndParse(searchTask, projName, extensions, isApi);

                foreach (var parsedClass in classes)
                {
                    ExtendPreParsedClass(parsedClass);

                    foreach (var newTask in UnknownTypes)
                    {
                        if (string.IsNullOrEmpty(newTask.SearchDir))
                            newTask.SearchDir = searchTask.SearchDir;
                    }

                    if (!parsedClass.Fields.Any() && parsedClass.Inherit.Count == 1 && (parsedClass.Inherit[0].IsArray || _knownTypes.ContainsKey(parsedClass.Inherit[0].CppName)))
                    {
                        if (Founded.ContainsKey(parsedClass.CppName))
                            Founded[parsedClass.CppName] = parsedClass.Inherit[0].Name;
                        else
                            Founded.Add(parsedClass.CppName, parsedClass.Inherit[0].Name);
                        UnknownTypes.Add(new SearchTask { SearchLine = parsedClass.CppName, Converter = KnownConverter.None });
                    }

                    return parsedClass;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"{searchTask.SearchDir} | {searchTask.SearchLine}", e);
            }
            return null;
        }

        public void PrintToFile(ParsedClass converted, string projName, string searchDir, string absPathToFile, string storeResultDir)
        {
            var outDir = $"{storeResultDir}\\{projName}\\";
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
                        outDir += "Api\\";
                        break;
                    }
            }

            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            File.WriteAllText($"{outDir}{converted.Name}.cs", PrintParsedClass(converted, projName, absPathToFile));
            foreach (var itm in UnknownTypes)
            {
                if (string.IsNullOrEmpty(itm.SearchDir))
                    itm.SearchDir = searchDir;
            }
        }

        public ParsedClass Parse(string text, bool isApi)
        {
            var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var preParseClass = CashParser.TryParseClass(lines, isApi);
            ExtendPreParsedClass(preParseClass);
            return preParseClass;
        }

        #region ParseText

        private void ExtendPreParsedClass(ParsedClass parsedClass)
        {
            if (parsedClass == null)
                return;

            if (!string.IsNullOrEmpty(parsedClass.CppName))
                parsedClass.Name = CashParser.ToTitleCase(parsedClass.CppName);
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
                    templateName = CashParser.Unpack(parsedClass.Template, 1);

                for (var i = 0; i < parsedClass.Fields.Count; i++)
                {
                    var preParsedElement = parsedClass.Fields[i];
                    parsedClass.Fields[i] = TryParseElement(preParsedElement, templateName);
                }
            }

            parsedClass.Fields.RemoveAll(i => i == null);
        }

        protected abstract PreParsedElement TryParseElement(PreParsedElement preParsedElement, string templateName);

        protected ParsedType GetKnownTypeOrDefault(string type, string templateName = null)
        {
            type = type.Trim();
            if (NamespacePref.IsMatch(type))
                type = NamespacePref.Replace(type, string.Empty);

            if (type.StartsWith("optional<"))
                type = CashParser.Unpack(type, 1);

            if (type.StartsWith("static "))
                type = type.Remove(0, 7);
            if (type.StartsWith("const "))
                type = type.Remove(0, 6);

            if (type.EndsWith("<>"))
                type = type.Remove(type.Length - 2);

            if (type.IndexOf('<') > -1)
                return GetKnownCompositType(type);

            if (_knownTypes.ContainsKey(type))
                return new ParsedType { CppName = type, Name = _knownTypes[type] };

            if (!string.IsNullOrEmpty(templateName) && type.Equals(templateName, StringComparison.OrdinalIgnoreCase))
                return new ParsedType { CppName = type, Name = templateName };

            if (Founded.ContainsKey(type))
            {
                return new ParsedType { CppName = type, Name = Founded[type] };
            }

            if (!NotNameChar.IsMatch(type))
            {
                AddTypeToTask(type);
                return new ParsedType { CppName = type, Name = CashParser.ToTitleCase(type) };
            }

            return new ParsedType { CppName = type, Name = "object" };
        }

        private void AddTypeToTask(string type)
        {
            if (!Founded.ContainsKey(type))
            {
                Founded.Add(type, CashParser.ToTitleCase(type));
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

            var unpacked = CashParser.Unpack(type, 1);
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

            var chArray = CashParser.SplitParams(unpacked);
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
                    Name = CashParser.ToTitleCase(name, false),
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
                Name = CashParser.ToTitleCase(name, false),
                Default = defaultValue,
                CppType = typeMatche.Value,
                Type = GetKnownTypeOrDefault(typeMatche.Value)
            };
            return rez;
        }

        #endregion ParseText

        #region PrintClass

        private void PrinNamespace(StringBuilder sb, ParsedClass parsedClass, string projName)
        {
            switch (parsedClass.ObjectType)
            {
                case ObjectType.Class:
                    {
                        sb.AppendLine("using Ditch.Core;");
                        sb.AppendLine("using System;");
                        sb.AppendLine("using System.Collections.Generic; ");
                        sb.AppendLine($"using Ditch.{projName}.Models;");
                        sb.AppendLine("using Newtonsoft.Json;");
                        sb.AppendLine();
                        sb.AppendLine($"namespace Ditch.{projName}.Models");
                        break;
                    }
                case ObjectType.Enum:
                    {
                        sb.AppendLine("using Ditch.Core.Helpers;");
                        sb.AppendLine("using Newtonsoft.Json;");
                        sb.AppendLine();
                        sb.AppendLine($"namespace Ditch.{projName}.Models");
                        break;
                    }
                case ObjectType.Api:
                    {
                        sb.AppendLine("using Ditch.Core;");
                        sb.AppendLine("using System;");
                        sb.AppendLine("using System.Collections.Generic; ");
                        sb.AppendLine("using Ditch.Core.JsonRpc;");
                        sb.AppendLine($"using Ditch.{projName}.Models;");
                        sb.AppendLine();
                        sb.AppendLine($"namespace Ditch.{projName}.Api");
                        break;
                    }
            }

            sb.AppendLine("{");
        }

        public string PrintParsedClass(ParsedClass parsedClass, string projName, string absPathToFile)
        {
            var sb = new StringBuilder();
            PrinNamespace(sb, parsedClass, projName);
            AddClassName(sb, parsedClass, absPathToFile, 4);
            string templateName = null;
            if (parsedClass.IsTemplate)
                templateName = CashParser.Unpack(parsedClass.Template, 1);
            foreach (var t in parsedClass.Fields)
                PrintParsedElements(sb, parsedClass, t, 8, templateName);

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
                        sb.AppendLine($"{indent}public partial class {parsedClass.Name}{(parsedClass.IsTemplate ? parsedClass.Template : string.Empty)}{(parsedClass.Inherit.Any() ? $" : {string.Join(", ", parsedClass.Inherit)}" : string.Empty)}");
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
                        sb.AppendLine($"{indent}public partial class {parsedClass.Name}{(parsedClass.Inherit.Any() ? $" : {string.Join(", ", parsedClass.Inherit)}" : string.Empty)}");
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

        private void PrintParsedElements(StringBuilder sb, ParsedClass parsedClass, PreParsedElement parsedElement, int indentCount, string templateName, bool printSecond = false)
        {
            var indent = new string(' ', indentCount);
            sb.AppendLine();

            if (!string.IsNullOrEmpty(parsedElement.MainComment) && !printSecond)
                sb.AppendLine(parsedElement.MainComment);

            var comment = parsedElement.Comment ?? string.Empty;
            //comment = comment.Replace("\\", $@"/// {Environment.NewLine}");

            sb.AppendLine($"{indent}/// <summary>");
            sb.AppendLine($"{indent}/// API name: {parsedElement.CppName}");
            sb.AppendLine($"{indent}/// {TypeCorrection(comment)}");
            sb.AppendLine($"{indent}/// </summary>");

            var parsedFunc = parsedElement as ParsedFunc;
            if (parsedFunc != null)
            {
                foreach (var itm in parsedFunc.Params)
                    sb.AppendLine($"{indent}/// <param name=\"{itm.Name}\">API type: {TypeCorrection(itm.CppType)}</param>");
                if (printSecond && parsedClass.ObjectType == ObjectType.Api)
                    sb.AppendLine($"{indent}/// <param name=\"token\">Throws a <see cref=\"T:System.OperationCanceledException\" /> if this token has had cancellation requested.</param>");
            }

            if (!string.IsNullOrEmpty(parsedElement.Type?.CppName))
                sb.AppendLine($"{indent}/// <returns>API type: {TypeCorrection(parsedElement.Type.CppName)}</returns>");

            if (printSecond && parsedClass.ObjectType == ObjectType.Api)
                sb.AppendLine($"{indent}/// <exception cref=\"T:System.OperationCanceledException\">The token has had cancellation requested.</exception>");

            var type = GetTypeForPrint(parsedElement.Type, templateName);
            if (parsedFunc != null)
            {
                sb.AppendLine($"{indent}public JsonRpcResponse{(type.Equals("void", StringComparison.OrdinalIgnoreCase) ? string.Empty : $"<{type}>")} {parsedElement.Name}({string.Join(", ", parsedFunc.Params)}{(printSecond && parsedClass.ObjectType == ObjectType.Api ? $"{(parsedFunc.Params.Any() ? ", " : string.Empty)}CancellationToken token" : string.Empty)})");
                sb.AppendLine($"{indent}{{");

                if (!printSecond && parsedClass.ObjectType == ObjectType.Api)
                {
                    sb.AppendLine($"{indent}    return {parsedElement.Name}({string.Join(", ", parsedFunc.Params.Select(i => i.Name))}{(parsedFunc.Params.Any() ? ", " : string.Empty)}CancellationToken.None);");
                }
                else
                {
                    sb.Append($"{indent}    return WebSocketManager.GetRequest{(type.Equals("void", StringComparison.OrdinalIgnoreCase) ? string.Empty : $"<{type}>")}(\"{parsedElement.CppName}\"");

                    if (printSecond && parsedClass.ObjectType == ObjectType.Api)
                        sb.Append(", token");

                    if (parsedFunc.Params.Any())
                    {
                        sb.Append(", ");
                        sb.Append(string.Join(", ", parsedFunc.Params.Select(i => i.Name)));
                    }
                    sb.AppendLine(");");
                }
                sb.AppendLine($"{indent}}}");
            }
            else
            {
                if (parsedClass.ObjectType != ObjectType.Enum)
                    sb.AppendLine($"{indent}[JsonProperty(\"{parsedElement.CppName}\")]");
                sb.AppendLine(parsedElement.Type != null
                    ? $"{indent}public {type} {parsedElement.Name} {{get; set;}}"
                    : $"{indent}{parsedElement.Name},");
            }

            if (parsedClass.ObjectType == ObjectType.Api && !printSecond)
                PrintParsedElements(sb, parsedClass, parsedElement, indentCount, templateName, true);
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