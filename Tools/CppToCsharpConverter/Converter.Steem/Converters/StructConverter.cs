using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Converter.Steem.Converters;
using Converter.Core;

namespace Converter.Steem
{
    public class StructConverter : BaseConverter
    {
        private readonly Regex _fieldRules = new Regex(@"^[a-z0-9<,>_:]+\s+[a-z0-9_]+(\s*=\s*[a-z_0-9-<,>()\s]+)?;", RegexOptions.IgnoreCase);
        private readonly Regex _notTypeChar = new Regex("[^[a-z0-9_:<,>]]*", RegexOptions.IgnoreCase);

        public StructConverter(Dictionary<string, string> knownTypes) : base(knownTypes) { }

        public ParsedClass FindAndParse(SearchTask searchTask, string[] extensions, bool isApi)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTask.SearchLine))
                    return null;

                var classes = CashParser.FindAndParse(searchTask, extensions, isApi);

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

                    if (FoundedClass.ContainsKey(parsedClass.Name))
                        FoundedClass[parsedClass.Name] = parsedClass;
                    else
                        FoundedClass.Add(parsedClass.Name, parsedClass);

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

            if (string.IsNullOrEmpty(test))
                return null;

            if (test.StartsWith("static "))
                test = test.Remove(0, 7);
            if (test.StartsWith("const "))
                test = test.Remove(0, 6);

            if (!_fieldRules.IsMatch(test))
                return null;

            var parts = test.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
                return null;

            var cppType = parts[0];
            if (_notTypeChar.IsMatch(cppType))
                return null;

            var name = parts[1].Trim(' ', ';');
            if (NotNameChar.IsMatch(name))
                return null;

            var coment = string.Empty;
            if (parts.Length > 2)
                coment = string.Join(" ", parts.Skip(2)).TrimStart(' ', '/', '<');

            var field = new PreParsedElement
            {
                Type = GetKnownTypeOrDefault(cppType, templateName),
                Name = CashParser.ToTitleCase(name),
                CppName = name,
                Comment = coment,
                MainComment = preParsedElement.MainComment
            };
            return field;
        }
    }
}