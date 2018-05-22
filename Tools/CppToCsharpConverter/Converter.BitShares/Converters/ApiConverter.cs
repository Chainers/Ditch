using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Converter.Core;
using Converter.Core.Models;

namespace Converter.BitShares.Converters
{
    public class ApiConverter : BaseConverter
    {
        private static readonly Regex FuncRegex = new Regex(@"^\s*[a-z<,_>0-9:]+\s+[a-z0-9_]+\s*\([a-z0-9:<(\s&\)>,_=]*\)\s*(const)*;", RegexOptions.IgnoreCase);
        private static readonly Regex ParamsRegex = new Regex(@"(?<=^\s*[a-z<,_>0-9:]+\s+[a-z0-9_]+\s*\()[a-z0-9:<(\s&\)>,_=]*(?=\)\s*(const)*;)", RegexOptions.IgnoreCase);
        private static readonly Regex FuncNameRegex = new Regex(@"(?<=^\s*[a-z<,_>0-9:]+\s+)[a-z0-9_]+\s*", RegexOptions.IgnoreCase);
        private static readonly Regex FuncTypeRegex = new Regex(@"(?<=^\s*)[a-z<,_>0-9:]+", RegexOptions.IgnoreCase);
        private static readonly Regex VoidFuncRegex = new Regex(@"^\s*void");

        public ApiConverter(Dictionary<string, string> knownTypes)
            : base(knownTypes, new CashParser())
        {
        }

        public ParsedClass FindAndParse(SearchTask searchTask, string[] extensions, bool isApi)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTask.SearchLine))
                    return null;

                var classes = _cashParser.FindAndParse(searchTask, extensions, isApi);

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

        protected override PreParsedElement TryParseElement(PreParsedElement preParsedElement, string templateName, ObjectType objectType)
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
                field.Name = _cashParser.ToTitleCase(nameMatch.Value);
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