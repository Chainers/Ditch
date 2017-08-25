using System.Collections.Generic;

namespace CppToCsharpConverter.Converters
{
    public class ParsedFunc : IParsedElement
    {
        public string MainComment { get; set; }

        public string Comment { get; set; }

        public string Name { get; set; }

        public object CppName { get; set; }

        public string Type { get; set; }

        public string CppType { get; set; }

        public List<ParsedParams> Params { get; set; }

        public string CppParams { get; set; }

        public override string ToString()
        {
            return $"{Type} {Name}({string.Join(", ", Params)});";
        }
    }
}