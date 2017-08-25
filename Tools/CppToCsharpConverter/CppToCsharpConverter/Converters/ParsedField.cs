namespace CppToCsharpConverter.Converters
{
    public class ParsedField : IParsedElement
    {
        public string MainComment { get; set; }

        public string Comment { get; set; }

        public string Name { get; set; }

        public string CppName { get; set; }

        public string Type { get; set; }
        
        public string CppType { get; set; }

        public override string ToString()
        {
            return $"{Type} {Name}";
        }
    }
}