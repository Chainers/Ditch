namespace CppToCsharpConverter.Converters
{
    public class PreParsedElement
    {
        public string MainComment { get; set; }

        public string Comment { get; set; }

        public string Name { get; set; }

        public string CppName { get; set; }

        public ParsedType Type { get; set; }

        public string CppText { get; set; }

        public override string ToString()
        {
            return $"{Type} {Name} ({CppText})";
        }
    }
}
