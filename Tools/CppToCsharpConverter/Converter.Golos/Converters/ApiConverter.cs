using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Converter.Golos.Converters
{
    public class ApiConverter : BaseConverter
    {
        private static readonly Regex FuncRegex = new Regex(@"^\s*[a-z<,_>0-9:]+\s+[a-z0-9_]+\s*\([a-z0-9:<(\s&\)>,_=]*\)\s*(const)*;", RegexOptions.IgnoreCase);
        private static readonly Regex ParamsRegex = new Regex(@"(?<=^\s*[a-z<,_>0-9:]+\s+[a-z0-9_]+\s*\()[a-z0-9:<(\s&\)>,_=]*(?=\)\s*(const)*;)", RegexOptions.IgnoreCase);
        private static readonly Regex FuncNameRegex = new Regex(@"(?<=^\s*[a-z<,_>0-9:]+\s+)[a-z0-9_]+\s*", RegexOptions.IgnoreCase);
        private static readonly Regex FuncTypeRegex = new Regex(@"(?<=^\s*)[a-z<,_>0-9:]+", RegexOptions.IgnoreCase);
        private static readonly Regex VoidFuncRegex = new Regex(@"^\s*void");

        public ApiConverter(Dictionary<string, string> knownTypes) : base(knownTypes)
        {
        }

        protected override PreParsedElement TryParseElement(PreParsedElement preParsedElement, string templateName)
        {
            var test = preParsedElement.CppText;

            if (!FuncRegex.IsMatch(test))// || VoidFuncRegex.IsMatch(test))
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

            
            try
            {
                var field = new ParsedFunc();
                field.Type = GetKnownTypeOrDefault(cppTypeMatch.Value, templateName);
                field.Name = CashParser.ToTitleCase(nameMatch.Value);
                field.CppName = nameMatch.Value;
                field.Params = TryParseParams(paramsMatch.Value);
                field.Comment = preParsedElement.Comment;
                field.MainComment = preParsedElement.MainComment;
                return field;
            }
            catch (Exception e)
            {
            }

            var error = new ParsedFunc();
            error.Comment = "Parsing error: { preParsedElement.CppText}";
            return error;
        }
    }
}