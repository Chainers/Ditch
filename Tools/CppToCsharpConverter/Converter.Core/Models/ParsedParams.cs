using Newtonsoft.Json;

namespace Converter.Core.Models
{
    public class ParsedParams
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CppName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ParsedType Type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CppType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Default { get; set; }

        public override string ToString()
        {
            return $"{Type} {Name}";
            //return $"{Type} {Name}{(string.IsNullOrEmpty(Default) ? string.Empty : " = " + Default)}";
        }
    }
}