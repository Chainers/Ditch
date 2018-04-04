using Converter.Core;
using Converter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Converter.Steem.Converters
{
    public class ApiConverter : BaseConverter
    {
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

            var field = new ParsedFunc();
            field.Type = GetKnownTypeOrDefault($"{test}_return");
            field.Name = _cashParser.ToTitleCase(test);
            field.CppName = test;
            field.Params = TryParseParams($"{test}_args args");
            field.Comment = preParsedElement.Comment;
            field.MainComment = preParsedElement.MainComment;
            return field;
        }
    }
}