using System.IO;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Core.Models
{
    [JsonConverter(typeof(CustomConverter))]
    public class UnsignedInt : ICustomSerializer, ICustomJson
    {
        public uint Value { get; set; }


        public UnsignedInt() { }

        public UnsignedInt(uint value)
        {
            Value = value;
        }


        public static implicit operator uint(UnsignedInt d)
        {
            return d.Value;
        }

        public static implicit operator UnsignedInt(uint d)
        {
            return new UnsignedInt(d);
        }

        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            Value = serializer.Deserialize<uint>(reader);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteValue(Value);
        }

        #endregion

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            var v = Value;

            while (v >= 0x80)
            {
                stream.WriteByte((byte)(0x80 | (v & 0x7f)));
                v >>= 7;
            }
            stream.WriteByte((byte)v);
        }

        #endregion
    }
}