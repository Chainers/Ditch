using System;
using System.Linq;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class HexDecimal : HexValue, IComparable<HexDecimal>
    {
        private const int MinCount = 0;
        private const int MaxCount = 12;
        private const bool IsTrimZero = true;

        protected override bool PrintZero => false;

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


        public HexDecimal()
        {
            MinBytes = MinCount;
            MaxBytes = MaxCount;
            TrimZero = IsTrimZero;
        }

        public HexDecimal(string value)
            : base(value, MinCount, MaxCount, IsTrimZero) { }

        public HexDecimal(byte[] value)
            : base(value, MinCount, MaxCount, IsTrimZero) { }

        public HexDecimal(byte[] source, int start, int count)
            : base(source, start, count, MinCount, MaxCount, IsTrimZero) { }

        public HexDecimal(decimal value)
        {
            var buf = decimal.GetBits(value);
            var bufBytes = new byte[MaxCount];
            Buffer.BlockCopy(buf, 0, bufBytes, 0, bufBytes.Length);

            var zc = 0;
            for (var i = MaxCount - 1; i >= 0; i--)
            {
                if (bufBytes[i] > 0)
                    break;
                zc++;
            }

            if (zc == MaxCount)
                zc--;

            Bytes = bufBytes
                .Reverse()
                .Skip(zc)
                .ToArray();
        }


        public decimal ToDecimal()
        {
            if (IsNull)
                return 0;

            var buf = new int[4];
            var bufBytes = Bytes.Reverse().ToArray();
            Buffer.BlockCopy(bufBytes, 0, buf, 0, bufBytes.Length);

            return new decimal(buf);
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