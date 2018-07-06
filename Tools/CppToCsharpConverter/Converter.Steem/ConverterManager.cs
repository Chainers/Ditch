using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Converter.Core;
using Converter.Core.Helpers;
using Converter.Steem.Converters;
using Converter.Core.Models;

namespace Converter.Steem
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

            if (TaskHelper.AddTask(allTasks, allTasksPart))
            {
                tasks = allTasksPart;
                goto somethingChanged;
            }

            return allTasks;
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

                    if (funk.Params.Any())
                    {
                        sb.AppendLine($"{inIntent}var args = new {funk.Params[0].Type.Name}();");
                        sb.AppendLine($"{inIntent}var resp = Api.{funk.Name}(args, CancellationToken.None);");
                    }
                    else
                    {
                        sb.AppendLine($"{inIntent}var resp = Api.{funk.Name}(CancellationToken.None);");
                    }
                    sb.AppendLine($"{inIntent}Console.WriteLine(resp.Error);");
                    sb.AppendLine($"{inIntent}Assert.IsFalse(resp.IsError);");
                    sb.AppendLine($"{inIntent}Console.WriteLine(JsonConvert.SerializeObject(resp.Result));");
                    sb.AppendLine();
                    if (funk.Params.Any())
                        sb.AppendLine($"{inIntent}var obj = Api.CustomGetRequest<JObject>(KnownApiNames.{parsedClass.Name},\"{funk.CppName}\", args, CancellationToken.None);");
                    else
                        sb.AppendLine($"{inIntent}var obj = Api.CustomGetRequest<JObject>(KnownApiNames.{parsedClass.Name},\"{funk.CppName}\", CancellationToken.None);");
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

                File.WriteAllText(Path.Combine(path, parsedClass.Name), sb.ToString(), Encoding.UTF8);
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

        //private List<SearchTask> AddTasks()
        //{
        //}
    }
}
