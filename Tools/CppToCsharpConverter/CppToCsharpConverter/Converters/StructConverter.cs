using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CppToCsharpConverter.Converters
{
    public class StructConverter : BaseConverter
    {
        protected readonly Regex FieldRules = new Regex(@"^\s*[a-z0-9<,>_]*[ \t]{1,}[a-z0-9_]*\s*(=[a-z_0-9<,>\s]*)?;", RegexOptions.IgnoreCase);

        public StructConverter(Dictionary<string, string> knownTypes) : base(knownTypes) { }

        protected override IParsedElement TryParseElement(List<string> lines, int index, out int end)
        {
            end = index + 1;
            var text = lines[index];
            var test = NormalizeType.Replace(text, string.Empty);

            if (!FieldRules.IsMatch(test))
                return null;

            var parts = test.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
                return null;

            var cppType = parts[0];
            if (NotTypeChar.IsMatch(cppType))
                return null;

            var name = parts[1].Trim(' ', ';');
            if (NotNameChar.IsMatch(name))
                return null;

            var coment = string.Empty;
            if (parts.Length > 2)
                coment = string.Join(" ", parts.Skip(2)).TrimStart(' ', '/', '<');

            var netType = cppType;

            netType = GetKnownTypeOrDefault(netType);

            var field = new ParsedField
            {
                Type = netType,
                CppType = cppType,
                Name = ToTitleCase(name),
                CppName = name,
                Comment = coment
            };
            return field;
        }

        protected override void PrintParsedElements(StringBuilder sb, IParsedElement parsedElement, int indentCount)
        {
            var parsedField = (ParsedField)parsedElement;
            var indent = new string(' ', indentCount);
            sb.AppendLine();

            if (!string.IsNullOrEmpty(parsedField.MainComment))
                sb.AppendLine(parsedField.MainComment);

            sb.AppendLine($"{indent}/// <summary>");
            sb.AppendLine($"{indent}/// {parsedField.Comment}");
            sb.AppendLine($"{indent}/// </summary>");
            if (!string.IsNullOrEmpty(parsedField.CppType))
                sb.AppendLine($"{indent}/// <returns>API type: {parsedField.CppType}</returns>");
            sb.AppendLine($"{indent}[JsonProperty(\"{parsedField.CppName}\")]");
            if (!string.IsNullOrEmpty(parsedField.Type))
                sb.AppendLine($"{indent}public {parsedField.Type} {parsedField.Name} {{get; set;}}");
            else
                sb.AppendLine($"{indent}{parsedField.Name},");
        }
    }
}