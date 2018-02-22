using Converter.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Converter.Steem.Converters;

namespace Converter.Steem
{
    public static class Grabber
    {
        private const string SubDirName = "Cash";
        private static readonly Regex TemplateRegexp = new Regex(@"^\s*template<", RegexOptions.IgnoreCase);
        private static readonly Regex BlockStartPref = new Regex(@"^[a-z0-9<>:,_\s-&\*\(\),]*{", RegexOptions.IgnoreCase);


        public static IEnumerable<IList<string>> FindClass(SearchTask searchTask, string[] extensions)
        {
            IList<string> text;
            var cashFile = Path.Combine(SubDirName, BaseConverter.ProjName, $"{searchTask.SearchLine}.txt");

            if (!Directory.Exists(SubDirName))
                Directory.CreateDirectory(SubDirName);
            if (!Directory.Exists(Path.Combine(SubDirName, BaseConverter.ProjName)))
                Directory.CreateDirectory(Path.Combine(SubDirName, BaseConverter.ProjName));

            if (!string.IsNullOrEmpty(searchTask.FullPath) && File.Exists(searchTask.FullPath))
            {
                if (File.Exists(cashFile))
                {
                    text = File.ReadAllLines(cashFile);
                    if (text.Count > 0)
                        yield return text;
                }
                text = TryGrabText(searchTask.FullPath, searchTask.SearchLine);
                if (text != null && text.Count > 0)
                {
                    File.WriteAllLines(cashFile, text);
                    yield return text;
                }
            }

            var files = Directory.GetFiles(searchTask.SearchDir, "*.*", SearchOption.AllDirectories).Where(path => extensions.Any(path.EndsWith)).ToArray();
            foreach (var file in files)
            {
                text = TryGrabText(file, searchTask.SearchLine);

                if (text != null && text.Count > 0)
                {
                    searchTask.FullPath = file;
                    File.WriteAllLines(cashFile, text);
                    yield return text;
                }
            }
        }


        private static List<string> TryGrabText(string filePath, string searchLine)
        {
            if (!File.Exists(filePath) && IsContainWord(filePath, searchLine))
                return null;

            var lines = File.ReadAllLines(filePath);
            List<string> text = null;
            var deep = 0;
            var startWrite = false;
            var enterb = false;
            var typedefRegexp = new Regex($@"^\s*typedef\s+[a-z0-9<>:,_]+\s+{searchLine}\s*;");
            var classRegexp = new Regex($@"^\s*(class|struct|enum)\s+{searchLine}\b\s*(?!;)");

            for (var index = 0; index < lines.Length; index++)
            {
                var line = lines[index];

                if (typedefRegexp.IsMatch(line))
                    return new List<string> { line };

                if (!startWrite && classRegexp.IsMatch(line))
                {
                    startWrite = true;
                    text = new List<string>();
                    TryGetTemplate(lines, index - 1, text);
                    TryGetComent(lines, index - 1 - text.Count, text);
                    text.Reverse();
                }

                if (!startWrite) continue;

                for (var i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case '{':
                            enterb = true;
                            deep++;
                            break;
                        case '}':
                            deep--;
                            break;
                    }
                }
                text.Add(line);

                if (enterb && deep == 0)
                    break;
            }
            return text;
        }

        private static bool IsContainWord(string filePath, string searchLine)
        {
            var lines = File.ReadLines(filePath);
            return lines.Any(line => line.IndexOf(searchLine, StringComparison.OrdinalIgnoreCase) > -1);
        }

        private static void TryGetTemplate(string[] lines, int endIndex, List<string> text)
        {
            var line = lines[endIndex];
            if (TemplateRegexp.IsMatch(line))
                text.Add(line);
        }

        private static void TryGetComent(string[] lines, int endIndex, List<string> text)
        {
            for (var i = endIndex; i >= 0; i--)
            {
                var line = lines[i].Trim();
                if (line.StartsWith("/") || line.StartsWith("*"))
                {
                    text.Add(lines[i]);
                }
                else if (string.IsNullOrWhiteSpace(line))
                {
                    if (line.Any())
                        text.Add(lines[i]);
                }
                else
                {
                    break;
                }
            }
        }




        public static bool IsBlockStart(IList<string> lines, int startIndex, out int endIndex)
        {
            endIndex = startIndex;
            var line = lines[startIndex];
            if (!BlockStartPref.IsMatch(line)) return false;

            var deep = 0;
            for (var index = startIndex; index < lines.Count; index++)
            {
                line = lines[index];
                for (var i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case '{':
                            deep++;
                            break;
                        case '}':
                            deep--;
                            break;
                        case '/':
                            break;
                    }
                }
                if (deep == 0)
                {
                    endIndex = index + 1;
                    return true;
                }
            }
            return false;
        }


    }
}
