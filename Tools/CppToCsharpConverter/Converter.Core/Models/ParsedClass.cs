using System.Collections.Generic;
using Newtonsoft.Json;

namespace Converter.Core.Models
{
    [JsonObject]
    public class ParsedClass
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MainComment { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Comment { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CppName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CppInherit { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ParsedType> Inherit { get; set; } = new List<ParsedType>();

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<PreParsedElement> Fields { get; set; } = new List<PreParsedElement>();

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ObjectType ObjectType { get; set; } = ObjectType.Class;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Template { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool IsTemplate => !string.IsNullOrEmpty(Template);

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ParsedParams> ConstructorParams { get; set; } = new List<ParsedParams>();

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> CppConstructorParams { get; set; } = new List<string>();

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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