using System;
using Cryptography.ECDSA;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class HexValue : ICustomJson
    {
        public HexValue() { }

        public HexValue(string value)
        {
            SetValue(value);
        }

        public HexValue(byte[] value)
        {
            if (value == null)
                IsNull = true;
            else
                Bytes = value;
        }

        public HexValue(byte[] source, int start, int count, bool trimZero = false)
        {
            if (source == null)
            {
                IsNull = true;
            }
            else
            {
                if (trimZero)
                {
                    var skip = 0;
                    for (int i = start; i < start + count && i < source.Length; i++)
                    {
                        if (source[i] > 0)
                            break;
                        skip++;
                    }

                    if (skip == source.Length)
                    {
                        Bytes = new byte[1];
                    }
                    else
                    {
                        Bytes = new byte[count - skip];
                        Array.Copy(source, start + skip, Bytes, 0, count - skip);
                    }
                }
                else
                {
                    Bytes = new byte[count];
                    Array.Copy(source, start, Bytes, 0, count);
                }
            }
        }

        public byte[] Bytes { get; protected set; }

        public bool IsNull { get; protected set; }


        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            SetValue(str);
        }

        public virtual void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            if (!IsNull)
            {
                writer.WriteValue($"0x{Hex.ToString(Bytes)}");
            }
            else
            {
                writer.WriteNull();
            }
        }


        private void SetValue(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                IsNull = true;
            }
            else
            {
                if (str.StartsWith("0x"))
                {
                    str = str.Remove(0, 2);
                }

                Bytes = Hex.HexToBytes(str);
            }
        }

        #endregion

        public override string ToString()
        {
            if (IsNull)
                return "NULL";
            return "0x" + Hex.ToString(Bytes);
        }
    }
}
