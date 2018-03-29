using System.Collections.Generic;

namespace Converter.Core.Models
{
    public class ParsedType
    {
        public string Name { get; set; }

        public string CppName { get; set; }

        public bool IsArray { get; set; }

        public bool IsTemplate { get; set; }

        public List<ParsedType> Container { get; set; } = new List<ParsedType>();

        public bool IsOptional { get; set; }

        public override string ToString()
        {
            if (IsTemplate)
                return $"{Name}<{string.Join(", ", Container)}>";
            if (IsArray)
                return $"{Name}[]";
            return Name;
        }
    }
}