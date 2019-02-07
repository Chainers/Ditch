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

        public HexAddress()
        {
            MinBytes = AddressLength;
            MaxBytes = AddressLength;
        }

        public HexAddress(string value)
            : base(value, AddressLength, AddressLength) { }

        public HexAddress(byte[] value)
            : base(value, AddressLength, AddressLength) { }

        public HexAddress(byte[] value, int start, int count)
            : base(value, start, count, AddressLength, AddressLength, false) { }
    }
}
