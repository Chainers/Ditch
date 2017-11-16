using System;
using System.Collections.Generic;
using System.Linq;

namespace CppToCsharpConverter.Helpers
{
    public class TaskHelper
    {
        public static void ResetTasks(List<SearchTask> items, IEnumerable<SearchTask> tasks)
        {
            if (items != null)
            {
                items.Clear();
                foreach (var task in tasks)
                {
                    if (task.Converter == KnownConverter.None)
                    {
                        var ftasks = items.Where(i => i.SearchLine.Equals(task.SearchLine)).ToArray();
                        foreach (var item in ftasks)
                        {
                            items.Remove(item);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(task.SearchDir) && !items.Any(i => i.SearchLine.Equals(task.SearchLine) && i.Converter.Equals(task.Converter) && i.SearchDir.Equals(task.SearchDir)))
                            items.Add(task);
                    }
                }
            }
        }

        public static bool AddTask(List<SearchTask> items, IEnumerable<SearchTask> tasks)
        {
            var changed = false;
            if (items != null)
            {
                foreach (var task in tasks)
                {
                    if (task.Converter == KnownConverter.None)
                    {
                        var ftasks = items.Where(i => i.SearchLine.Equals(task.SearchLine)).ToArray();
                        foreach (var item in ftasks)
                        {
                            items.Remove(item);
                            changed = true;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(task.SearchDir) && !items.Any(i => i.SearchLine.Equals(task.SearchLine) && i.Converter.Equals(task.Converter) && i.SearchDir.Equals(task.SearchDir)))
                        {
                            items.Add(task);
                            changed = true;
                        }
                    }
                }
            }
            return changed;
        }

        public static void AddTask(IList<SearchTask> items, SearchTask task)
        {
            if (task.Converter == KnownConverter.None)
            {
                var ftasks = items.Where(i => i.SearchLine.Equals(task.SearchLine)).ToArray();
                foreach (var item in ftasks)
                {
                    items.Remove(item);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(task.SearchDir) && !items.Any(i => i.SearchLine.Equals(task.SearchLine) && i.Converter.Equals(task.Converter) && i.SearchDir.Equals(task.SearchDir)))
                    items.Add(task);
            }
        }

        public static void AddTask(IList<SearchTask> items, string searchLine, KnownConverter converter, string searchDir)
        {
            if (!string.IsNullOrEmpty(searchDir) && !items.Any(i => i.SearchLine.Equals(searchLine) && i.Converter.Equals(converter) && i.SearchDir.Equals(searchDir)))
            {
                var task = new SearchTask
                {
                    SearchDir = searchDir,
                    SearchLine = searchLine,
                    Converter = converter
                };
                items.Add(task);
            }
        }

        public static int Compare(SearchTask x, SearchTask y)
        {
            var rez = String.Compare(x.SearchDir, y.SearchDir, StringComparison.Ordinal);
            if (rez == 0)
                rez = x.Converter.CompareTo(y.Converter);
            if (rez == 0)
                rez = String.Compare(x.SearchLine, y.SearchLine, StringComparison.Ordinal);
            return rez;
        }

    }
}
