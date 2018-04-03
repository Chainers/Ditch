using Newtonsoft.Json;

namespace Converter.Core.Models
{
    public class PreParsedElement
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MainComment { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Comment { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CppName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ParsedType Type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CppText { get; set; }

        public override string ToString()
        {
            return $"{Type} {Name} ({CppText})";
        }
    }
}
