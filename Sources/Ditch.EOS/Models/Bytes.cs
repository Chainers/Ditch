using System.IO;
using Cryptography.ECDSA;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class Bytes : ICustomSerializer, ICustomJson
    {
        public byte[] Value { get; set; }

        public Bytes() { }

        public Bytes(string value)
        {
            Value = Hex.HexToBytes(value);
        }

        public Bytes(byte[] value)
        {
            Value = value;
        }

        public static implicit operator Bytes(byte[] bytes)
        {
            return new Bytes(bytes);
        }


        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            Value = Hex.HexToBytes(str);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            var str = string.Empty;
            if (Value != null)
                str = Hex.ToString(Value);
            writer.WriteValue(str);
        }

        #endregion

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            var len = new UnsignedInt((uint)Value.Length);
            len.Serializer(stream, serializeHelper);
            stream.Write(Value, 0, Value.Length);
        }

        #endregion
    }
}