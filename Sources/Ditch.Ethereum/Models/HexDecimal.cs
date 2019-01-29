using System;
using System.Linq;
using Cryptography.ECDSA;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class HexDecimal : HexValue, IComparable<HexDecimal>
    {
        private decimal? _value;
        public decimal Value
        {
            get
            {
                if (!_value.HasValue)
                    _value = ToDecimal();

                return _value.Value;
            }
        }


        public HexDecimal() { }

        public HexDecimal(byte[] source, int start, int count)
        {
            if (source == null)
            {
                IsNull = true;
            }
            else
            {
                Bytes = new byte[count];
                Array.Copy(source, start, Bytes, 0, count);
            }
        }


        public HexDecimal(decimal value)
        {
            if (value < 0)
                throw new NotImplementedException();

            var buf = decimal.GetBits(value);
            var bufBytes = new byte[12];
            Buffer.BlockCopy(buf, 0, bufBytes, 0, bufBytes.Length);

            var zc = 0;
            for (int i = bufBytes.Length - 1; i >= 0; i--)
            {
                if (bufBytes[i] > 0)
                    break;
                zc++;
            }

            if (zc == bufBytes.Length)
                zc--;

            Bytes = bufBytes.Reverse().Skip(zc).ToArray();
        }




        private decimal ToDecimal()
        {
            if (IsNull)
                return 0;

            if (Bytes.Length > 12)
                throw new InvalidCastException($"Unexpected array length {Hex.ToString(Bytes)}");

            var buf = new int[4];
            var bufBytes = Bytes.Reverse().ToArray();
            Buffer.BlockCopy(bufBytes, 0, buf, 0, bufBytes.Length);

            return new decimal(buf);
        }


        public override string ToString()
        {
            return $"{Value} | 0x{Hex.ToString(Bytes)}";
        }

        public override void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            if (!IsNull)
            {
                var str = Hex.ToString(Bytes).TrimStart('0');
                writer.WriteValue(string.IsNullOrEmpty(str) ? "0x0" : $"0x{str}");
            }
        }

        public int CompareTo(HexDecimal other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;


            if (IsNull)
            {
                if (other.IsNull)
                    return 0;
                return -1;
            }

            if (other.IsNull)
                return 1;

            return Value.CompareTo(other.Value);
        }
    }
}