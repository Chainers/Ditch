using System.Collections.Generic;
using System.Linq;

namespace CppToCsharpConverter
{
    public class SettingsViewModel
    {
        public HashSet<string> KnownDirectories { get; set; } = new HashSet<string>();

        public SortableObservableCollection SearchTasks { get; set; } = new SortableObservableCollection();

        public Dictionary<string, string> KnownTypes { get; set; } = new Dictionary<string, string>();
        
        public void AddTask(SearchTask task)
        {
            if (!string.IsNullOrEmpty(task.SearchDir) && !SearchTasks.Any(i => i.SearchLine.Equals(task.SearchLine) && i.Converter.Equals(task.Converter) && i.SearchDir.Equals(task.SearchDir)))
                SearchTasks.Add(task);
        }

        public void AddTask(string searchLine, KnownConverter converter, string searchDir)
        {
            if (!string.IsNullOrEmpty(searchDir) && !SearchTasks.Any(i => i.SearchLine.Equals(searchLine) && i.Converter.Equals(converter) && i.SearchDir.Equals(searchDir)))
            {
                var task = new SearchTask
                {
                    SearchDir = searchLine,
                    SearchLine = searchDir,
                    Converter = converter
                };
                SearchTasks.Add(task);
            }
        }
    }

    public class SearchTask
    {
        public string SearchDir { get; set; }

        public KnownConverter Converter { get; set; }

        public string FullPath { get; set; }

        public string SearchLine { get; set; }
    }

    public enum KnownConverter
    {
        InterfaceConverter,
        StructConverter
    }
}