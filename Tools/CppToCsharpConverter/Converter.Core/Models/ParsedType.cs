using Newtonsoft.Json;
using System.Collections.Generic;

namespace Converter.Core.Models
{
    public class ParsedType
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CppName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool IsArray { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool IsTemplate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ParsedType> Container { get; set; } = new List<ParsedType>();

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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