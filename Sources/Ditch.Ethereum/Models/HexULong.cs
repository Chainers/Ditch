using System;
using Cryptography.ECDSA;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class HexULong : HexValue, IComparable<HexULong>
    {
        private const int MinCount = 0;
        private const int MaxCount = 8;
        private const bool IsTrimZero = true;

        protected override bool PrintZero => false;

        private ulong? _value;
        public ulong Value
        {
            get
            {
                if (!_value.HasValue)
                    _value = ToDecimal();

                return _value.Value;
            }
        }

        public HexULong()
        {
            MinBytes = MinCount;
            MaxBytes = MaxCount;
            TrimZero = IsTrimZero;
        }

        public HexULong(string value)
            : base(value, MinCount, MaxCount, IsTrimZero) { }

        public HexULong(byte[] value)
            : base(value, MinCount, MaxCount, IsTrimZero) { }

        public HexULong(byte[] source, int start, int count)
            : base(source, start, count, MinCount, MaxCount, IsTrimZero) { }

        public HexULong(ulong blockNum)
        {
            var i = MaxCount;
            var buf = new byte[MaxCount];
            do
            {
                var bt = (byte)(blockNum & 0xFF);
                buf[--i] = bt;

                blockNum >>= 8;
            } while (blockNum > 0);

            Bytes = new byte[MaxCount - i];
            Array.Copy(buf, i, Bytes, 0, Bytes.Length);
        }


        private ulong ToDecimal()
        {
            if (IsNull)
                return 0;

            ulong buf = Bytes[0];
            for (var i = 1; i < Bytes.Length; i++)
            {
                buf <<= 8;
                buf |= Bytes[i];
            }

            return buf;
        }

        public override string ToString()
        {
            return $"{Value} | 0x{Hex.ToString(Bytes)}";
        }

        public int CompareTo(HexULong other)
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