using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Converter.Core.Models
{
    public class SearchInFile
    {
        private static readonly Regex WhiteSpace = new Regex(@"(^\s*)|((?<=\s)\s*)|(\s*$)");
        public static string Search(string filePath, string searchLine)
        {
            if (!File.Exists(filePath))
                return string.Empty;

            var lines = File.ReadLines(filePath);
            var sb = new StringBuilder();
            var deep = 0;
            var startWrite = false;
            var enterb = false;
            foreach (var item in lines)
            {
                var line = WhiteSpace.Replace(item, string.Empty);
                if (!startWrite && Regex.IsMatch(line, $@"^{searchLine}\b(?!\s*;)"))
                    startWrite = true;

                if (startWrite)
                {
                    for (var i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '{')
                        {
                            enterb = true;
                            deep++;
                        }
                        else if (line[i] == '}')
                            deep--;
                    }
                    sb.AppendLine(line);

                    if (enterb && deep == 0)
                        break;
                }
            }
            return sb.ToString();
        }
    }
}