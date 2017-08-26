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

        public ObjectType ObjectType { get; set; } = ObjectType.Class;

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    public enum ObjectType
    {
        Class,
        Enum,
        Interface
    }
}