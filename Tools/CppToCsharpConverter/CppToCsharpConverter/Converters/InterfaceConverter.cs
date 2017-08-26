using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CppToCsharpConverter.Converters
{
    public class InterfaceConverter : BaseConverter
    {
        protected static readonly Regex FuncRegex = new Regex(@"^\s*[a-z<,_>0-9:]+\s+[a-z0-9_]+\s*\([a-z0-9:<(\s&\)>,_=]*\)\s*(const)*;", RegexOptions.IgnoreCase);
        protected static readonly Regex ParamsRegex = new Regex(@"(?<=^\s*[a-z<,_>0-9:]+\s+[a-z0-9_]+\s*\()[a-z0-9:<(\s&\)>,_=]*(?=\)\s*(const)*;)", RegexOptions.IgnoreCase);
        protected static readonly Regex FuncNameRegex = new Regex(@"(?<=^\s*[a-z<,_>0-9:]+\s+)[a-z0-9_]+\s*", RegexOptions.IgnoreCase);
        protected static readonly Regex FuncTypeRegex = new Regex(@"(?<=^\s*)[a-z<,_>0-9:]+", RegexOptions.IgnoreCase);
        protected static readonly Regex VoidFuncRegex = new Regex(@"^\s*void");
        protected static readonly Regex ParamTypeRegex = new Regex(@"(?<=^|,\s*)[a-z0-9:<_>]+", RegexOptions.IgnoreCase);
        protected static readonly Regex ParamNameRegex = new Regex(@"(?<=[\w_>:]+\s+)[a-z0-9_]+(\s*=\s*[a-z0-9]*)?(?=,|$)", RegexOptions.IgnoreCase);
        protected static readonly Regex ParamNormRegex = new Regex(@"(\bconst\b\s*)|(&*)", RegexOptions.IgnoreCase);

        public InterfaceConverter(Dictionary<string, string> knownTypes) : base(knownTypes)
        {
        }

        protected override bool IsCodeFile(string path)
        {
            return path.EndsWith(".hpp");
        }

        protected override IParsedElement TryParseElement(List<string> lines, int index, out int end)
        {
            end = index + 1;
            var text = lines[index].Trim();
            while (text.EndsWith(","))
                text = $"{text} {lines[end++].Trim()}";

            var test = NormalizeType.Replace(text, string.Empty);

            if (!FuncRegex.IsMatch(test) || VoidFuncRegex.IsMatch(test))
                return null;

            var cppTypeMatch = FuncTypeRegex.Match(test);
            if (!cppTypeMatch.Success)
                return null;

            var nameMatch = FuncNameRegex.Match(test);
            if (!nameMatch.Success)
                return null;

            var paramsMatch = ParamsRegex.Match(test);
            if (!paramsMatch.Success)
                return null;

            var netType = cppTypeMatch.Value;

            netType = GetKnownTypeOrDefault(netType);

            var field = new ParsedFunc
            {
                Type = netType,
                CppType = cppTypeMatch.Value,
                Name = ToTitleCase(nameMatch.Value),
                CppName = nameMatch.Value,
                Params = TryParseParams(paramsMatch.Value),
                CppParams = paramsMatch.Value,
                //Comment = coment
            };
            return field;
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
                    Name = ToTitleCase(name, false),
                    Default = defaultValue,
                    CppType = typeMatches[i].Value,
                    Type = GetKnownTypeOrDefault(typeMatches[i].Value)
                };
                rez.Add(param);
            }

            return rez;
        }

        protected override void PrintParsedElements(StringBuilder sb, IParsedElement parsedElement, int indentCount)
        {
            var parsedFunc = (ParsedFunc)parsedElement;
            var indent = new string(' ', indentCount);
            sb.AppendLine();

            var info = parsedFunc.Comment ?? string.Empty;
            var startComment = info.IndexOf("//", StringComparison.Ordinal);
            if (!string.IsNullOrEmpty(info) && (startComment > 0 || startComment < 0))
            {
                var addInfo = startComment > 0 ? info.Remove(startComment) : info;
                sb.Append($" | {addInfo}");
                sb.AppendLine();
            }

            if (startComment > -1)
            {
                info = info.Remove(0, startComment);
                info = info.Trim('/');
            }
            sb.AppendLine($"{indent}/// <summary>");
            sb.AppendLine($"{indent}/// API name: {parsedFunc.CppName}");
            sb.AppendLine($"{indent}/// {info}");
            sb.AppendLine($"{indent}/// </summary>");
            foreach (var itm in parsedFunc.Params)
                sb.AppendLine($"{indent}/// <param name=\"{itm.Name}\">API type: {TypeCorrection(itm.CppType)}</param>");
            sb.AppendLine($"{indent}/// <returns>API type: {TypeCorrection(parsedFunc.CppType)}</returns>");
            sb.AppendLine($"{indent}{parsedFunc.Type} {parsedFunc.Name}({string.Join(", ", parsedFunc.Params)});");
        }

        protected override ParsedClass InitParsedClass()
        {
            var pc = base.InitParsedClass();
            pc.ObjectType = ObjectType.Interface;
            return pc;
        }
    }
}