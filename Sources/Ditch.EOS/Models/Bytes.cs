using System;
using System.IO;
using Cryptography.ECDSA;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    [JsonConverter(typeof(CustomConverter))]
    public class Bytes : ICustomSerializer, ICustomJson
    {
        public string Value { get; set; } = string.Empty;

        public Bytes() { }

        public Bytes(string value)
        {
            Value = value;
        }


        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            Value = serializer.Deserialize<string>(reader);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteValue(Value);
        }

        #endregion

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            var buf = Hex.HexToBytes(Value);
            var len = new UnsignedInt((UInt32)buf.Length);
            len.Serializer(stream, serializeHelper);
            stream.Write(buf, 0, buf.Length);
        }

        #endregion
    }
}