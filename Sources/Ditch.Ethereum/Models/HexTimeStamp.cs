using System;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class HexTimeStamp : HexValue
    {
        private const int MinCount = 0;
        private const int MaxCount = 8;
        private const bool IsTrimZero = true;

        protected override bool PrintZero => false;

        private DateTime? _value;

        public DateTime Value
        {
            get
            {
                if (!_value.HasValue)
                    _value = ToDateTime().UtcDateTime;

                return _value.Value;
            }
        }


        public HexTimeStamp()
        {
            MinBytes = MinCount;
            MaxBytes = MaxCount;
            TrimZero = IsTrimZero;
        }

        public HexTimeStamp(string value)
            : base(value, MinCount, MaxCount, IsTrimZero) { }

        public HexTimeStamp(byte[] value)
            : base(value, MinCount, MaxCount, IsTrimZero) { }

        public HexTimeStamp(byte[] source, int start, int count)
            : base(source, start, count, MinCount, MaxCount, IsTrimZero) { }


        public HexTimeStamp(DateTime dateTime)
        {
            _value = dateTime;
            var dto = new DateTimeOffset(dateTime);
            FromUnixTime(dto.ToUnixTimeSeconds());
        }

        public DateTimeOffset ToDateTime()
        {
            var ut = ToUnixTime();
            return DateTimeOffset.FromUnixTimeSeconds(ut);
        }

        private long ToUnixTime()
        {
            if (IsNull)
                return 0;

            long buf = Bytes[0];
            for (var i = 1; i < Bytes.Length; i++)
            {
                buf <<= 8;
                buf |= Bytes[i];
            }

            return buf;
        }

        private void FromUnixTime(long value)
        {
            var lbuf = (ulong)value;
            var i = 8;
            var buf = new byte[i];
            do
            {
                var bt = (byte)(lbuf & 0xFF);
                buf[--i] = bt;

                lbuf >>= 8;
            } while (lbuf > 0);

            Bytes = new byte[8 - i];
            Array.Copy(buf, i, Bytes, 0, Bytes.Length);
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}