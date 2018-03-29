using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Converter.Golos
{
    public class Grabber : Core.Grabber
    {
        public Grabber()
              : base("Golos") { }

        protected override List<string> TryGrabText(string filePath, string searchLine, bool isApi)
        {
            if (File.Exists(filePath) && !IsContainWord(filePath, searchLine, isApi))
                return null;

            if (isApi)
            {
                var text = File.ReadAllText(filePath);
                var isMatch = Regex.IsMatch(text, $"\\*plugin_name\\s*=\\s*\"{searchLine}\"");
                if (!isMatch)
                    return null;

                searchLine = GetContainerClassName(filePath, searchLine);
            }

            return base.TryGrabText(filePath, searchLine, isApi);
        }

        private static string GetContainerClassName(string filePath, string searchLine)
        {
            var text = File.ReadAllText(filePath);
            var index = Regex.Match(text, $"\\*plugin_name\\s*=\\s*\"{searchLine}\"").Index;

            var classMatches = Regex.Matches(text, @"(?<=^\s*class\s*)[a-z_]+\b(?!\s*;)", RegexOptions.Multiline);

            for (var i = classMatches.Count - 1; i >= 0; i--)
            {
                Match classMatche = classMatches[i];
                if (classMatche.Index < index)
                {
                    if (i == 0)
                    {
                        return classMatche.Value;
                    }
                }
            }

            throw new KeyNotFoundException(searchLine);
        }
    }
}
