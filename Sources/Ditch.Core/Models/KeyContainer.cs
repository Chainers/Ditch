using System.Collections.Generic;
using System.IO;
using Ditch.Core.Interfaces;

namespace Ditch.Core.Models
{
    public class KeyContainer : List<object>, ICustomSerializer
    {
        public KeyContainer(byte key, object value)
        {
            Add(key);
            Add(value);
        }

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            foreach (var value in this)
            {
                serializeHelper.AddToMessageStream(stream, value.GetType(), value);
            }
        }

        #endregion
    }
}