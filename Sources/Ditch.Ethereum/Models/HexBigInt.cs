using System;
using System.Linq;
using Ditch.Core.Converters;
using Newtonsoft.Json;
using System.Numerics;

namespace Ditch.Ethereum.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class HexBigInt : HexValue
    {
        private const int MinCount = 0;
        private const int MaxCount = 32;
        private const bool IsTrimZero = true;

        protected override bool PrintZero => false;

        public bool IsZero => Bytes.Length == 1 && Bytes[0] == 0;

        private BigInteger? _value;
        public BigInteger Value
        {
            get
            {
                if (!_value.HasValue)
                    _value = ToValue();

                return _value.Value;
            }
        }

        public HexBigInt()
        {
            MinBytes = MinCount;
            MaxBytes = MaxCount;
            TrimZero = IsTrimZero;
        }

        public HexBigInt(string value)
            : base(value, MinCount, MaxCount, IsTrimZero) { }

        public HexBigInt(byte[] value)
            : base(value, MinCount, MaxCount, IsTrimZero) { }

        public HexBigInt(byte[] source, int start, int count)
            : base(source, start, count, MinCount, MaxCount, IsTrimZero) { }



        private BigInteger ToValue()
        {
            if (IsNull)
                return BigInteger.Zero;

            var buf = new byte[Bytes.Length + 1]; //prevent sign in BigInteger
            Array.Copy(Bytes, 0, buf, 1, Bytes.Length);
            Array.Reverse(buf);
            return new BigInteger(buf);
        }
    }
}