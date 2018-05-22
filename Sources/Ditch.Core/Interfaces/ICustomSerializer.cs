using System.IO;

namespace Ditch.Core.Interfaces
{
    public interface ICustomSerializer
    {
        void Serializer(Stream stream, IMessageSerializer serializeHelper);
    }
}