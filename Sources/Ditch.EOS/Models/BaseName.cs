using System;
using System.IO;
using Cryptography.ECDSA;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    [JsonConverter(typeof(CustomConverter))]
    public class BaseName : ICustomSerializer, ICustomJson
    {
        public string Value { get; set; }

        public BaseName() { }

        public BaseName(string value)
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
            var pack = StringToName(Value);
            var buf = BitConverter.GetBytes(pack);
            stream.Write(buf, 0, buf.Length);
        }

        public static UInt64 StringToName(string str)
        {
            var len = str.Length;
            UInt64 value = 0;

            for (var i = 0; i <= 12; ++i)
            {
                UInt64 c = 0;
                if (i < len && i <= 12)
                    c = CharToSymbol(str[i]);

                if (i < 12)
                {
                    c &= 0x1f;
                    c <<= 64 - 5 * (i + 1);
                }
                else
                {
                    c &= 0x0f;
                }

                value |= c;
            }

            return value;
        }

        public static UInt64 CharToSymbol(char c)
        {
            if (c >= 'a' && c <= 'z')
                return (UInt64)(c - 'a') + 6;
            if (c >= '1' && c <= '5')
                return (UInt64)(c - '1') + 1;
            return 0;
        }

        #endregion
    }
}