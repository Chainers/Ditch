using System;
using System.IO;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Core.Models
{
    [JsonConverter(typeof(CustomConverter))]
    public class UnsignedInt : ICustomSerializer, ICustomJson
    {
        public UInt32 Value { get; set; } = 0;


        public UnsignedInt() { }

        public UnsignedInt(UInt32 value)
        {
            Value = value;
        }


        public static implicit operator UInt32(UnsignedInt d)
        {
            return d.Value;
        }

        public static implicit operator UnsignedInt(UInt32 d)
        {
            return new UnsignedInt(d);
        }

        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            Value = serializer.Deserialize<UInt32>(reader);
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