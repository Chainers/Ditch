using System.Collections.Generic;

namespace CppToCsharpConverter.Converters
{
    public class ParsedClass
    {
        public string MainComment { get; set; }

        public string Comment { get; set; }

        public string Name { get; set; }

        public string CppName { get; set; }

        public List<string> Inherit { get; set; } = new List<string>();

        public List<IParsedElement> Fields { get; set; } = new List<IParsedElement>();

        public bool IsInterface { get; internal set; }

        public bool IsEnum { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}