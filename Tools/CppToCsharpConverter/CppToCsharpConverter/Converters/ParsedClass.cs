using System.Collections.Generic;
using Newtonsoft.Json;

namespace CppToCsharpConverter.Converters
{
    [JsonObject]
    public class ParsedClass
    {
        public string MainComment { get; set; }

        public string Comment { get; set; }

        public string CppName { get; set; }

        public string Name { get; set; }

        public string CppInherit { get; internal set; }

        public List<ParsedType> Inherit { get; set; } = new List<ParsedType>();

        public List<PreParsedElement> Fields { get; set; } = new List<PreParsedElement>();

        public ObjectType ObjectType { get; set; } = ObjectType.Class;

        public string Template { get; set; }

        public bool IsTemplate => !string.IsNullOrEmpty(Template);

        public List<ParsedParams> ConstructorParams { get; set; } = new List<ParsedParams>();

        public List<string> CppConstructorParams { get; set; } = new List<string>();

        public string AbsPathToFile { get; set; }

        public override string ToString()
        {
            return $"{Name}{(IsTemplate ? Template : string.Empty)}";
        }
    }

    public enum ObjectType
    {
        Class,
        Enum,
        Api
    }
}