using System.Collections.Generic;

namespace CppToCsharpConverter
{
    public class CustomProperties
    {
        private Dictionary<string, string> _steemSearchItemsPath;
        private Dictionary<string, string> _golosSearchItemsPath;
        public string PathToSteem { get; set; }

        public string PathToGolos { get; set; }

        public string SearchItems { get; set; }

        public Dictionary<string, string> SteemSearchItemsPath
        {
            get { return _steemSearchItemsPath ?? (_steemSearchItemsPath = new Dictionary<string, string>()); }
            set { _steemSearchItemsPath = value; }
        }

        public Dictionary<string, string> GolosSearchItemsPath
        {
            get { return _golosSearchItemsPath ?? (_golosSearchItemsPath = new Dictionary<string, string>()); }
            set { _golosSearchItemsPath = value; }
        }
    }
}