using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CppToCsharpConverter.Converters
{
    public class StructConverter : BaseConverter
    {
        private readonly Regex _fieldRules = new Regex(@"^[a-z0-9<,>_:]+\s+[a-z0-9_]+(\s*=\s*[a-z_0-9-<,>()\s]+)?;", RegexOptions.IgnoreCase);
        private readonly Regex _notTypeChar = new Regex("[^[a-z0-9_:<,>]]*", RegexOptions.IgnoreCase);

        public StructConverter(Dictionary<string, string> knownTypes) : base(knownTypes) { }

        protected override PreParsedElement TryParseElement(PreParsedElement preParsedElement, string templateName)
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