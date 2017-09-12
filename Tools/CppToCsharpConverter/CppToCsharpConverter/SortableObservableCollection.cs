using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CppToCsharpConverter
{
    public class SortableObservableCollection : ObservableCollection<SearchTask>
    {
        public void Sort()
        {
            var items = Items as List<SearchTask>;
            if (items != null)
            {
                items.Sort(Compare);
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        private static int Compare(SearchTask x, SearchTask y)
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