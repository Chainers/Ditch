using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CppToCsharpConverter.Helpers;

namespace CppToCsharpConverter.Converters
{
    public class ConverterManager
    {
        private static readonly Regex DirNameRegex = new Regex(@"(?<=\\)[a-z0-9_.-]+(?=\\*$)", RegexOptions.IgnoreCase);
        private readonly StructConverter _structConverter;
        private readonly ApiConverter _apiConverter;
        public ConverterManager(Dictionary<string, string> knownTypes)
        {
            _structConverter = new StructConverter(knownTypes);
            _apiConverter = new ApiConverter(knownTypes);
        }

        public List<SearchTask> Execute(IList<SearchTask> searchTask, string storeResultDir)
        {
            var allTasks = new List<SearchTask>(searchTask);
            var groups = searchTask.GroupBy(i => i.SearchDir);
            List<ParsedClass> steemClasses = null;
            List<ParsedClass> golosClasses = null;
            foreach (var group in groups)
            {
                var tasks = group.ToList();
                somethingChanged:
                BaseConverter.Founded.Clear();
                List<SearchTask> allTasksPart;

                var projName = DirNameRegex.Match(tasks.First().SearchDir).Value;
                projName = CashParser.ToTitleCase(projName);

                var classes = RecursiveSearch(tasks, storeResultDir, true, out allTasksPart, projName);

                GenerateTestFileForApi(classes, tasks, projName);
                if (group.Key.EndsWith("\\steem\\"))
                    steemClasses = classes;
                else if (group.Key.EndsWith("\\golos\\"))
                    golosClasses = classes;
                if (TaskHelper.AddTask(allTasks, allTasksPart))
                {
                    tasks = allTasksPart;
                    goto somethingChanged;
                }
            }

            if (steemClasses != null && golosClasses != null && steemClasses.Any() && golosClasses.Any())
                CreateSteemGolos(steemClasses, golosClasses, storeResultDir);
            return allTasks;
        }

        private void GenerateTestFileForApi(List<ParsedClass> classes, List<SearchTask> group, string projName)
        {
            foreach (var item in group.Where(i => i.Converter == KnownConverter.ApiConverter))
            {
                var clas = classes.FirstOrDefault(c => c.CppName.Equals(item.SearchLine, StringComparison.OrdinalIgnoreCase));
                if (clas == null)
                    continue;

                var sb = new StringBuilder();
                sb.AppendLine("using System;");
                sb.AppendLine("using Newtonsoft.Json;");
                sb.AppendLine("using Newtonsoft.Json.Linq;");
                sb.AppendLine("using NUnit.Framework;");
                sb.AppendLine($"namespace Ditch.{projName}.Tests");
                sb.AppendLine("{");

                var inden = new string(' ', 4);
                sb.AppendLine($"{inden}[TestFixture]");
                sb.AppendLine($"{inden}public class {clas.Name}Test : BaseTest");
                sb.AppendLine($"{inden}{{");

                inden = new string(' ', 8);
                foreach (ParsedFunc funk in clas.Fields.Where(f => f is ParsedFunc))
                {
                    sb.AppendLine();
                    sb.AppendLine($"{inden}[Test]");
                    sb.AppendLine($"{inden}public void {funk.CppName}()");
                    sb.AppendLine($"{inden}{{");
                    var inIntent = inden + "    ";
                    sb.AppendLine($"{inIntent}var resp = Manager.DatabaseApi.{funk.Name}();");
                    sb.AppendLine($"{inIntent}Assert.IsFalse(resp.IsError);");
                    sb.AppendLine($"{inIntent}Console.WriteLine(JsonConvert.SerializeObject(resp.Result));");
                    sb.AppendLine();
                    sb.AppendLine($"{inIntent}var obj = Manager.CustomGetRequest<JObject>(\"{funk.CppName}\");");
                    sb.AppendLine($"{inIntent}TestPropetries(resp.Result.GetType(), obj.Result);");
                    sb.AppendLine($"{inden}}}");
                }
                inden = new string(' ', 4);
                sb.AppendLine($"{inden}}}");
                sb.AppendLine("}");

                var path = "TestCash";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path = Path.Combine(path, projName);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                File.WriteAllText(Path.Combine(path, clas.Name), sb.ToString());
            }
        }


        private void CreateSteemGolos(List<ParsedClass> steemClasses, List<ParsedClass> golosClasses, string storeResultDir)
        {
            if (steemClasses.Count > 0 && golosClasses.Count > 0)
            {
                foreach (var steemClass in steemClasses)
                {
                    var golosClass = golosClasses.FirstOrDefault(t => t.Name.Equals(steemClass.Name));
                    if (golosClass != null)
                    {
                        var steemGolos = MergeSame(steemClass, golosClass);

                        if (steemClass.ObjectType == ObjectType.Api)
                            _apiConverter.PrintToFile(steemGolos, "SteemGolos", string.Empty, steemClass.AbsPathToFile, storeResultDir);
                        else
                            _structConverter.PrintToFile(steemGolos, "SteemGolos", string.Empty, steemClass.AbsPathToFile, storeResultDir);
                    }
                }
            }
        }

        private ParsedClass MergeSame(ParsedClass steemClass, ParsedClass golosClass)
        {
            var steemGolosClass = new ParsedClass
            {
                Comment = steemClass.Comment,
                CppName = steemClass.CppName,
                MainComment = steemClass.MainComment,
                Name = steemClass.Name,
                ObjectType = steemClass.ObjectType,
            };

            if (!string.IsNullOrEmpty(steemClass.Template))
            {
                steemGolosClass.Template = steemClass.Template.EndsWith(golosClass.Template) ? steemClass.Template : $"??? {steemClass.Template} / {golosClass.Template}";
            }
            else if (!string.IsNullOrEmpty(golosClass.Template))
            {
                steemGolosClass.Template = $"??? --- / {golosClass.Template}";
            }

            foreach (var item in steemClass.Fields)
            {
                if (golosClass.Fields.Any(f => f.CppName == item.CppName))
                {
                    steemGolosClass.Fields.Add(item);
                }
            }

            foreach (var item in steemClass.Inherit)
            {
                if (golosClass.Inherit.Any(f => f.CppName == item.CppName))
                {
                    steemGolosClass.Inherit.Add(item);
                }
            }

            foreach (var item in steemClass.ConstructorParams)
            {
                if (golosClass.ConstructorParams.Any(f => f.Name == item.Name))
                {
                    steemGolosClass.ConstructorParams.Add(item);
                }
            }
            return steemGolosClass;
        }

        private ParsedClass FindAndParse(SearchTask task, string projName, string storeResultDir, bool enablePrint)
        {
            switch (task.Converter)
            {
                case KnownConverter.ApiConverter:
                    {
                        var converted = _apiConverter.FindAndParse(task, projName, new[] { ".hpp" }, true);
                        if (enablePrint && converted != null)
                        {
                            var absPathToFile = task.FullPath.Remove(0, task.SearchDir.Length);
                            _apiConverter.PrintToFile(converted, projName, task.SearchDir, absPathToFile, storeResultDir);
                        }
                        return converted;
                    }
                case KnownConverter.StructConverter:
                    {
                        var converted = _structConverter.FindAndParse(task, projName, new[] { ".cpp", ".hpp" }, false);
                        if (enablePrint && converted != null)
                        {
                            var absPathToFile = task.FullPath.Remove(0, task.SearchDir.Length);
                            _structConverter.PrintToFile(converted, projName, task.SearchDir, absPathToFile, storeResultDir);
                        }
                        return converted;
                    }
            }
            return null;
        }

        private List<ParsedClass> RecursiveSearch(IEnumerable<SearchTask> searchTasks, string storeResultDir, bool enablePrint, out List<SearchTask> allTasks, string projName)
        {
            allTasks = new List<SearchTask>(searchTasks);
            var parsedClasses = new List<ParsedClass>();
            foreach (var task in searchTasks)
            {
                if (string.IsNullOrWhiteSpace(task.SearchLine))
                    continue;

                var parsedClass = FindAndParse(task, projName, storeResultDir, enablePrint);
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
                    var parts = RecursiveSearch(buf, storeResultDir, enablePrint, out bReq, projName);
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
