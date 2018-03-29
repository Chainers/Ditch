using Converter.Core.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Converter.Core
{
    public class SortableObservableCollection : ObservableCollection<SearchTask>
    {
        public void ResetTasks(IEnumerable<SearchTask> tasks)
        {
            var items = Items as List<SearchTask>;
            TaskHelper.ResetTasks(items, tasks);
            Sort();
        }

       
        public void AddTask(string searchLine, KnownConverter converter, string searchDir)
        {
            TaskHelper.AddTask(Items, searchLine, converter, searchDir);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void Sort()
        {
            var items = Items as List<SearchTask>;
            if (items != null)
            {
                items.Sort(TaskHelper.Compare);
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }
    }
}