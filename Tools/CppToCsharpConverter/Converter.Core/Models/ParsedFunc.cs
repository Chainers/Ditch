using Newtonsoft.Json;
using System.Collections.Generic;

namespace Converter.Core.Models
{
    public class ParsedFunc : PreParsedElement
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ParsedParams> Params { get; set; } = new List<ParsedParams>();

        public override string ToString()
        {
            return $"{Type} {Name}({string.Join(", ", Params)});";
        }
    }
}
