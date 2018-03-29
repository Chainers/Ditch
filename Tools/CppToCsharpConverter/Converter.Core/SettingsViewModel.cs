using System.Collections.Generic;

namespace Converter.Core
{
    public class SettingsViewModel
    {
        public HashSet<string> KnownDirectories { get; set; } = new HashSet<string>();

        public SortableObservableCollection SearchTasks { get; set; } = new SortableObservableCollection();

        public Dictionary<string, string> KnownTypes { get; set; } = new Dictionary<string, string>();
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
        StructConverter,
        ApiConverter,
        None
    }
}