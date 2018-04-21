using System.Collections.Generic;

namespace Ditch.EOS.Models
{
    public class KeyContainer : List<object>
    {
        public KeyContainer(byte key, object value)
        {
            Add(key);
            Add(value);
        }
    }
}