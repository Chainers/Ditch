using System;
using System.IO;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class BaseName : ICustomSerializer, ICustomJson
    {
        public string Value { get; set; }

        public BaseName() { }

        public BaseName(string value)
        {
            Value = value;
        }

        public static implicit operator string(BaseName d)
        {
            return d.Value;
        }

        public static implicit operator BaseName(string d)
        {
            return new ActionName(d);
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

        public static ulong StringToName(string str)
        {
            var len = str.Length;
            ulong value = 0;

            for (var i = 0; i <= 12; ++i)
            {
                ulong c = 0;
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

        public static ulong CharToSymbol(char c)
        {
            if (c >= 'a' && c <= 'z')
                return (ulong)(c - 'a') + 6;
            if (c >= '1' && c <= '5')
                return (ulong)(c - '1') + 1;
            return 0;
        }

        public static string UlongToString(ulong value)
        {
            const string charmap = ".12345abcdefghijklmnopqrstuvwxyz";

            var str = new char[13];
            ulong tmp = value;
            var count = -1;
            for (var i = 0; i <= 12; ++i)
            {
                var id = i == 0 ? tmp & 0x0f : tmp & 0x1f;
                char c = charmap[(byte)id];
                str[12 - i] = c;
                tmp >>= (i == 0 ? 4 : 5);

                if (id == 0 && count + 1 == i)
                    count = i;
            }

            return new string(str, 0, 12 - count);
        }

        #endregion
    }
}