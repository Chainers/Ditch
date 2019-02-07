using Ditch.Core.Converters;
using Newtonsoft.Json;

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
    }
}