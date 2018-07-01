using System;
using System.IO;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Core.Models
{
    [JsonConverter(typeof(CustomConverter))]
    public class SignedInt : ICustomSerializer, ICustomJson
    {
        public Int32 Value { get; set; }


        public SignedInt() { }

        public SignedInt(Int32 value)
        {
            Value = value;
        }


        public static implicit operator Int32(SignedInt d)
        {
            return d.Value;
        }

        public static implicit operator SignedInt(Int32 d)
        {
            return new SignedInt(d);
        }


        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            Value = serializer.Deserialize<Int32>(reader);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteValue(Value);
        }

        #endregion

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            var v = (Value << 1) ^ (Value >> 31);

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