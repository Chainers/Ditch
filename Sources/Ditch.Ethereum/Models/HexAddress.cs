using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    /// <summary>
    /// ~\go-ethereum\common\types.go Address
    /// </summary>
    [JsonConverter(typeof(CustomJsonConverter))]
    public class HexAddress : HexValue
    {
        public const int AddressLength = 20;
        private const bool IsTrimZero = false;

        public HexAddress()
        {
            MinBytes = AddressLength;
            MaxBytes = AddressLength;
            TrimZero = IsTrimZero;
        }

        public HexAddress(string value)
            : base(value, AddressLength, AddressLength, IsTrimZero) { }

        public HexAddress(byte[] value)
            : base(value, AddressLength, AddressLength, IsTrimZero) { }

        public HexAddress(byte[] value, int start, int count)
            : base(value, start, count, AddressLength, AddressLength, IsTrimZero) { }
    }
}
