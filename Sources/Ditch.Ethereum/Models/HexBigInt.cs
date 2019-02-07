using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class HexBigInt : HexValue
    {
        private const int MinCount = 0;
        private const int MaxCount = 32;

        protected override bool PrintZero => false;

        public HexBigInt()
        {
            MinBytes = MinCount;
            MaxBytes = MaxCount;
        }

        public HexBigInt(string value)
            : base(value, MinCount, MaxCount) { }

        public HexBigInt(byte[] value)
            : base(value, MinCount, MaxCount) { }

        public HexBigInt(byte[] source, int start, int count, bool trimZero = false)
            : base(source, start, count, MinCount, MaxCount, trimZero) { }

    }
}