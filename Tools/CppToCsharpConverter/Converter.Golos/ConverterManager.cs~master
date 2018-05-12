using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Converter.Core;
using Converter.Core.Helpers;
using Converter.Core.Models;
using Converter.Golos.Converters;

namespace Converter.Golos
{
    public class ConverterManager
    {
        private readonly StructConverter _structConverter;
        private readonly ApiConverter _apiConverter;

        public ConverterManager(Dictionary<string, string> knownTypes)
        {
            _structConverter = new StructConverter(knownTypes);
            _apiConverter = new ApiConverter(knownTypes);
        }


        public List<SearchTask> Execute(IList<SearchTask> tasks, string storeResultDir)
        {
            var allTasks = new List<SearchTask>(tasks);

            somethingChanged:
            BaseConverter.Founded.Clear();

            var classes = RecursiveSearch(tasks, storeResultDir, true, out var allTasksPart);

            GenerateTestFileForApi(classes, tasks);

            GenerateDocFile(classes, tasks);

            if (TaskHelper.AddTask(allTasks, allTasksPart))
            {
                tasks = allTasksPart;
                goto somethingChanged;
            }

            return allTasks;
        }

        private void GenerateDocFile(IList<ParsedClass> classes, IList<SearchTask> tasks)
        {
            var path = "md";
            var apiPath = $"{path}/api";
            var apiObj = $"{path}/obj";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (!Directory.Exists(apiPath))
                Directory.CreateDirectory(apiPath);
            if (!Directory.Exists(apiObj))
                Directory.CreateDirectory(apiObj);

            path = Path.Combine(path, BaseConverter.ProjName);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (var parsedClass in classes)
            {
                var sb = new StringBuilder();

                var task = tasks.FirstOrDefault(t => t.SearchLine.Equals(parsedClass.CppName));
                var pathToFile = task != null
                    ? "https://github.com/GolosChain/golos/tree/master/" + task.FullPath.Remove(0, task.SearchDir.Length).Replace("\\", "/")
                    : string.Empty;

                switch (parsedClass.ObjectType)
                {
                    case ObjectType.Class:
                        {
                            sb.AppendLine("# Описание классов/структур Golos | актуально для [hf 0.17.0](https://github.com/GolosChain/golos/releases/tag/v0.17.0)");
                            sb.AppendLine($"Текст собран на основе [исходного кода]({pathToFile})");
                            sb.AppendLine();
                            sb.AppendLine($"## {parsedClass.CppName}");

                            sb.AppendLine();
                            foreach (var pClass in parsedClass.Inherit)
                            {
                                var name = pClass.CppName;
                                if (classes.Any(c => c.CppName.Equals(name)))
                                    name = $"[{name}]({name}.md)";
                                sb.AppendLine($"Есть родительский класс: {name}");
                            }
                            sb.AppendLine();

                            if (parsedClass.Fields.Any())
                            {
                                sb.AppendLine("|Тип поля|Название поля|Описание|");
                                sb.AppendLine("|--------|-------------|--------|");

                                foreach (PreParsedElement funk in parsedClass.Fields)
                                {
                                    string returnType = funk?.Type?.CppName;
                                    if (classes.Any(c => c.CppName.Equals(returnType)))
                                        returnType = $"[{returnType}]({returnType}.md)";

                                    var com = GetCommentString(funk);
                                    sb.AppendLine($"|{returnType}|{funk.CppName}|{com}|");
                                }
                            }
                            else if (!parsedClass.Inherit.Any())
                            {
                                sb.AppendLine("Требуется дополнительное описание.");
                            }

                            sb.AppendLine();
                            sb.AppendLine("Подготовил: [@korzunav](https://golos.io/@korzunav).");
                            sb.AppendLine();

                            File.WriteAllText(Path.Combine(apiObj, parsedClass.CppName) + ".md", sb.ToString());
                            break;
                        }
                    case ObjectType.Enum:
                        {
                            sb.AppendLine("# Описание перечислений Golos | актуально для [hf 0.17.0](https://github.com/GolosChain/golos/releases/tag/v0.17.0)");
                            sb.AppendLine($"Текст собран на основе [исходного кода]({pathToFile})");
                            sb.AppendLine();
                            sb.AppendLine($"## {parsedClass.CppName}");

                            if (parsedClass.Fields.Any())
                            {
                                sb.AppendLine("|Название поля|Описание|");
                                sb.AppendLine("|-------------|--------|");

                                foreach (PreParsedElement funk in parsedClass.Fields)
                                {
                                    var com = GetCommentString(funk);
                                    sb.AppendLine($"|{funk.CppName}|{com}|");
                                }
                            }
                            else
                            {
                                sb.AppendLine("Требуется дополнительное описание.");
                            }

                            sb.AppendLine();
                            sb.AppendLine("Подготовил: [@korzunav](https://golos.io/@korzunav).");
                            sb.AppendLine();

                            File.WriteAllText(Path.Combine(apiObj, parsedClass.CppName) + ".md", sb.ToString());
                            break;
                        }
                    case ObjectType.Api:
                        {
                            sb.AppendLine("# Описание API Golos | актуально для [hf 0.17.0](https://github.com/GolosChain/golos/releases/tag/v0.17.0)");
                            sb.AppendLine($"Текст собран на основе [исходного кода]({pathToFile})");
                            sb.AppendLine();
                            sb.AppendLine($"## {parsedClass.CppName}");

                            if (parsedClass.Fields.Any())
                            {
                                foreach (ParsedFunc funk in parsedClass.Fields.Where(f => f is ParsedFunc))
                                {

                                    if (funk.CppName.StartsWith("_"))
                                        continue;

                                    var args = new string[funk.Params.Count];
                                    for (int i = 0; i < funk.Params.Count; i++)
                                    {
                                        var param = funk.Params[i];
                                        var type = param.CppType.Replace("<", "\\<").Replace(">", "\\>");
                                        if (classes.Any(c => c.CppName.Equals(param.CppName)))
                                            args[i] = $"[{type}](../objects/{type}.md)";
                                        else
                                            args[i] = type;
                                    }
                                    string returnType = funk?.Type?.CppName.Replace("<", "\\<").Replace(">", "\\>");
                                    returnType = returnType.Replace("std::", "");
                                    if (classes.Any(c => c.CppName.Equals(returnType)))
                                        returnType = $"[{returnType}](../objects/{returnType}.md)";

                                    if (funk?.Type?.IsArray == true)
                                        returnType += "[]";


                                    var com = GetCommentString(funk);
                                    if (com.Contains("//"))
                                        com = string.Empty; //some errore comment
                                    if (string.IsNullOrEmpty(com) && _apiConverter.MethodDescriptions.ContainsKey(funk.CppName))
                                        com = _apiConverter.MethodDescriptions[funk.CppName];

                                    sb.AppendLine($"### {funk.CppName}");
                                    sb.AppendLine();

                                    if (!string.IsNullOrEmpty(com))
                                    {
                                        sb.AppendLine($"> {com}");
                                        sb.AppendLine();
                                    }

                                    sb.AppendLine("|Входные параметры|Возвращаемый обьект|");
                                    sb.AppendLine("|-----------------|-------------------|");
                                    sb.AppendLine($"|{(args.Length > 0 ? $"<ul><li>{string.Join("</li><li>", args)}</li></ul>" : string.Empty)}|{returnType}|");
                                    sb.AppendLine();
                                }
                            }
                            else
                            {
                                sb.AppendLine("Требуется дополнительное описание.");
                            }

                            sb.AppendLine();
                            sb.AppendLine("Подготовил: [@korzunav](https://golos.io/@korzunav).");
                            sb.AppendLine();

                            File.WriteAllText(Path.Combine(apiPath, parsedClass.CppName) + ".md", sb.ToString());
                            break;
                        }
                }
            }

        }

        private Regex commClearRegex = new Regex(@"^\s*[\*/\]*\s*[\n\r]*", RegexOptions.Multiline);
        private string GetCommentString(PreParsedElement element)
        {
            var com = string.Empty;
            if (!string.IsNullOrWhiteSpace(element.MainComment))
            {
                com = commClearRegex.Replace(element.MainComment, string.Empty);

                if (!string.IsNullOrWhiteSpace(element.Comment))
                    com = $"{com} ({element.Comment})";
            }
            else if (!string.IsNullOrWhiteSpace(element.Comment))
                com = element.Comment;

            if (!string.IsNullOrWhiteSpace(com))
                com = com.Replace("\r\n", " ").Replace("  ", " ").Trim();

            return com;
        }

        private void GenerateTestFileForApi(IList<ParsedClass> classes, IList<SearchTask> group)
        {
            foreach (var item in group.Where(i => i.Converter == KnownConverter.ApiConverter))
            {
                var parsedClass = classes.FirstOrDefault(c => c.CppName.Equals(item.SearchLine, StringComparison.OrdinalIgnoreCase));
                if (parsedClass == null)
                    continue;

                var sb = new StringBuilder();
                sb.AppendLine("using System;");
                sb.AppendLine("using Newtonsoft.Json;");
                sb.AppendLine("using Newtonsoft.Json.Linq;");
                sb.AppendLine("using NUnit.Framework;");
                sb.AppendLine($"namespace Ditch.{BaseConverter.ProjName}.Tests");
                sb.AppendLine("{");

                var inden = new string(' ', 4);
                sb.AppendLine($"{inden}[TestFixture]");
                sb.AppendLine($"{inden}public class {parsedClass.Name}Test : BaseTest");
                sb.AppendLine($"{inden}{{");

                var doc = string.Empty;
                if (parsedClass.ObjectType == ObjectType.Api && !string.IsNullOrEmpty(item.FullPath))
                    doc = File.ReadAllText(item.FullPath);

                inden = new string(' ', 8);
                foreach (ParsedFunc funk in parsedClass.Fields.Where(f => f is ParsedFunc))
                {
                    if (parsedClass.ObjectType == ObjectType.Api && !string.IsNullOrEmpty(doc) && !doc.Contains($"({funk.CppName})"))
                        continue;

                    sb.AppendLine();
                    sb.AppendLine($"{inden}[Test]");
                    sb.AppendLine($"{inden}public void {funk.CppName}()");
                    sb.AppendLine($"{inden}{{");
                    var inIntent = inden + "    ";
                    sb.AppendLine($"{inIntent}var resp = Api.{funk.Name}(CancellationToken.None);");
                    sb.AppendLine($"{inIntent}Console.WriteLine(resp.Error);");
                    sb.AppendLine($"{inIntent}Assert.IsFalse(resp.IsError);");
                    sb.AppendLine($"{inIntent}Console.WriteLine(JsonConvert.SerializeObject(resp.Result));");
                    sb.AppendLine();
                    sb.AppendLine($"{inIntent}var obj = Api.CustomGetRequest<JObject>(KnownApiNames.{parsedClass.Name},\"{funk.CppName}\", new object[]{{}}, CancellationToken.None);");
                    sb.AppendLine($"{inIntent}TestPropetries(resp.Result.GetType(), obj.Result);");
                    sb.AppendLine($"{inIntent}Console.WriteLine(\"----------------------------------------------------------------------------\");");
                    sb.AppendLine($"{inIntent}Console.WriteLine(JsonConvert.SerializeObject(obj));");
                    sb.AppendLine($"{inden}}}");
                }
                inden = new string(' ', 4);
                sb.AppendLine($"{inden}}}");
                sb.AppendLine("}");

                var path = "TestCash";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path = Path.Combine(path, BaseConverter.ProjName);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                File.WriteAllText(Path.Combine(path, parsedClass.Name), sb.ToString());
            }
        }

        private ParsedClass FindAndParse(SearchTask task, string storeResultDir, bool enablePrint)
        {
            switch (task.Converter)
            {
                case KnownConverter.ApiConverter:
                    {
                        var converted = _apiConverter.FindAndParse(task, new[] { ".hpp" }, true);
                        if (enablePrint && converted != null)
                        {
                            var absPathToFile = task.FullPath.Remove(0, task.SearchDir.Length);
                            _apiConverter.PrintToFile(converted, task.SearchDir, absPathToFile, storeResultDir);
                        }
                        return converted;
                    }
                case KnownConverter.StructConverter:
                    {
                        var converted = _structConverter.FindAndParse(task, new[] { ".cpp", ".hpp" }, false);
                        if (enablePrint && converted != null)
                        {
                            var absPathToFile = task.FullPath.Remove(0, task.SearchDir.Length);
                            _structConverter.PrintToFile(converted, task.SearchDir, absPathToFile, storeResultDir);
                        }
                        return converted;
                    }
            }
            return null;
        }

        private List<ParsedClass> RecursiveSearch(IList<SearchTask> searchTasks, string storeResultDir, bool enablePrint, out List<SearchTask> allTasks)
        {
            allTasks = new List<SearchTask>(searchTasks);
            var parsedClasses = new List<ParsedClass>();
            foreach (var task in searchTasks)
            {
                if (string.IsNullOrWhiteSpace(task.SearchLine))
                    continue;

                var parsedClass = FindAndParse(task, storeResultDir, enablePrint);
                if (parsedClass != null)
                    parsedClasses.Add(parsedClass);
            }

            if (BaseConverter.UnknownTypes.Any())
            {
                var buf = BaseConverter.UnknownTypes.ToList();
                BaseConverter.UnknownTypes.Clear();
                var hasNew = TaskHelper.AddTask(allTasks, buf);
                if (hasNew)
                {
                    List<SearchTask> bReq;
                    var parts = RecursiveSearch(buf, storeResultDir, enablePrint, out bReq);
                    parsedClasses.AddRange(parts);
                    TaskHelper.AddTask(allTasks, bReq);
                }
            }

            return parsedClasses;
        }
    }
}
