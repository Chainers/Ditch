using System;
using System.CodeDom;
using Converter.Core;
using Converter.Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Converter.Golos
{
    public class CashParser : Core.CashParser
    {
        public CashParser()
            : base(new Grabber(), "Golos")
        {
        }

        private static readonly Regex argsRegex = new Regex(@"args.args->at\([0-9]*\).as<[a-z_<>0-9:\s]*>\s*\(\)\s*", RegexOptions.Multiline);
        private static readonly Regex argsId = new Regex(@"(?<=args.args->at\()[0-9]*(?=\))", RegexOptions.Multiline);

        public override ParsedClass TryParseClass(SearchTask searchTask, IList<string> text, bool isApi)
        {
            var parsedClass = base.TryParseClass(searchTask, text, isApi);
            if (!isApi)
                return parsedClass;

            if (!parsedClass.Fields.Any())
                return parsedClass;

            var apiText = GetFile(searchTask, parsedClass, parsedClass.Fields.First().CppText);

            var fullText = File.ReadAllText(searchTask.FullPath);
            parsedClass.Fields = parsedClass.Fields.OrderBy(i => i.CppText).ToList();

            foreach (var field in parsedClass.Fields)
            {
                var returnObj = Regex.Match(fullText, $"(?<=^\\s*DEFINE_API_ARGS\\s*\\({field.CppText}\\s*,\\s*[a-z_:]*msg_pack*\\s*,\\s*)[a-z0-9:<>_\\s]*(?=\\))", RegexOptions.Multiline);
                var returnedType = returnObj.Value;
                if (string.IsNullOrEmpty(returnedType))
                    returnedType = "object";

                var mArgs = Regex.Match(apiText, $@"(?<=^\s*)DEFINE_API\s*\(\s*{parsedClass.CppName}\s*,\s*{field.CppText}\s*\)", RegexOptions.Multiline);
                var block = ReadBlock(apiText, mArgs.Index, mArgs.Length);
                var matches = argsRegex.Matches(block);
                if (matches.Count == 0)
                {
                    if (block.Contains("args"))
                    {
                        field.CppText = $"{returnedType} {field.CppText}(object args);";

                    }
                    else
                    {
                        field.CppText = $"{returnedType} {field.CppText}();";
                    }
                }
                else
                {
                    var args = new List<string>();

                    for (var i = 0; i < matches.Count; i++)
                    {
                        var arg = matches[i].Value;
                        var idMatch = argsId.Match(arg);
                        var id = int.Parse(idMatch.Value);
                        var start = idMatch.Length + 19;
                        var value = arg.Substring(start, arg.Length - start - 3);

                        args.Insert(id, $"{value.Replace(" ", "")} arg{id}");
                    }

                    field.CppText = $"{returnedType.Replace(" ", "")} {field.CppText}({string.Join(", ", args)});";
                }
            }

            parsedClass.CppName = searchTask.SearchLine;
            return parsedClass;
        }

        public string GetFile(SearchTask searchTask, ParsedClass parsedClass, string funcName)
        {
            var cppFiles = Directory.GetFiles(searchTask.SearchDir, "*.cpp", SearchOption.AllDirectories);
            var rgx = new Regex($@"^\s*DEFINE_API\s*\(\s*{parsedClass.CppName}\s*,\s*{funcName}\s*\)", RegexOptions.Multiline);

            foreach (var file in cppFiles)
            {
                var testext = File.ReadAllText(file);
                if (rgx.IsMatch(testext))
                    return testext;
            }
            return string.Empty;
        }

        private string ReadBlock(string text, int start, int len)
        {
            bool opened = false;
            var bracket = 0;
            for (int i = start + len; i < text.Length; i++)
            {
                var ch = text[i];
                if (ch == '{')
                {
                    opened = true;
                    bracket++;
                }
                else if (ch == '}')
                {
                    bracket--;
                }

                if (opened && bracket == 0)
                {
                    return text.Substring(start, i - start + 1);
                }
            }
            throw new InvalidCastException();
        }
    }
}
