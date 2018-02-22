using System.Collections.Generic;

namespace Converter.Steem
{
    public class ParsedFunc : PreParsedElement
    {
        public List<ParsedParams> Params { get; set; } = new List<ParsedParams>();

        public override string ToString()
        {
            return $"{Type} {Name}({string.Join(", ", Params)});";
        }
    }
}
