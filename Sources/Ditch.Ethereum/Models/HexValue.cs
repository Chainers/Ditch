using System;
using Cryptography.ECDSA;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class HexValue : ICustomJson
    {
        protected int MinBytes;
        protected int MaxBytes;
        protected bool TrimZero;

        protected virtual bool PrintZero => true;

        public byte[] Bytes { get; protected set; }

        public bool IsNull { get; protected set; }


        public HexValue()
        {
            MinBytes = 0;
            MaxBytes = int.MaxValue;
            TrimZero = false;
        }

        public HexValue(string value, int minBytes = 0, int maxBytes = int.MaxValue, bool trimZero = false)
        {
            MinBytes = minBytes;
            MaxBytes = maxBytes;
            TrimZero = trimZero;

            SetValue(value);
        }

        public HexValue(byte[] value, int minBytes = 0, int maxBytes = int.MaxValue, bool trimZero = false)
            : this(value, 0, value.Length, minBytes, maxBytes, trimZero) { }

        public HexValue(byte[] source, int start, int count, int minBytes = 0, int maxBytes = int.MaxValue, bool trimZero = false)
        {
            MinBytes = minBytes;
            MaxBytes = maxBytes;
            TrimZero = trimZero;

            if (source == null || source.Length == 0 || count < 1)
            {
                IsNull = true;
            }
            else
            {
                if (trimZero)
                {
                    var skip = 0;
                    for (var i = start; i < start + count && i < source.Length; i++)
                    {
                        if (source[i] > 0)
                            break;
                        skip++;
                    }

                    var byteCount = count - skip;
                    if (MinBytes > byteCount)
                        throw new InvalidCastException($"expected min {MinBytes} byte but was {byteCount}");

                    if (MaxBytes < byteCount)
                        throw new InvalidCastException($"expected max {MaxBytes} byte but was {byteCount}");

                    if (byteCount == 0)
                    {
                        Bytes = new byte[1];
                    }
                    else
                    {
                        Bytes = new byte[byteCount];
                        Array.Copy(source, start + skip, Bytes, 0, byteCount);
                    }
                }
                else
                {
                    if (MinBytes > count)
                        throw new InvalidCastException($"expected min {MinBytes} byte but was {count}");

                    if (MaxBytes < count)
                        throw new InvalidCastException($"expected max {MaxBytes} byte but was {count}");


                    Bytes = new byte[count];
                    Array.Copy(source, start, Bytes, 0, count);
                }
            }
        }


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
                var str = Hex.ToString(Bytes);
                if (!PrintZero)
                {
                    str = str.TrimStart('0');
                    if (string.IsNullOrEmpty(str))
                        str = "0";
                }

                writer.WriteValue($"0x{str}");
            }
            else
            {
                writer.WriteNull();
            }
        }

        protected void SetValue(string str)
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

                if (TrimZero)
                {
                    str = str.TrimStart('0');
                    if (string.IsNullOrEmpty(str))
                        str = "00";
                }

                var lb = str.Length & 0x01;
                var byteLen = lb + str.Length >> 1;

                if (MinBytes > byteLen)
                    throw new InvalidCastException($"expected min {MinBytes} byte but was {byteLen} {str}");

                if (MaxBytes < byteLen)
                    throw new InvalidCastException($"expected max {MaxBytes} byte but was {byteLen} {str}");

                Bytes = Hex.HexToBytes(str);
            }
        }

        #endregion

        public override string ToString()
        {
            if (IsNull)
                return "NULL";
            var str = Hex.ToString(Bytes);

            if (!PrintZero)
                str = str.TrimStart('0');

            if (string.IsNullOrEmpty(str))
                str = "0";

            return "0x" + str;
        }
    }
}
