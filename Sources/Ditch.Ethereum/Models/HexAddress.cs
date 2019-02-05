using System;
using Cryptography.ECDSA;
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
        // AddressLength is the expected length of the address
        public const int AddressLength = 20;


        public HexAddress() { }

        public HexAddress(string value) : base(value)
        {
        }

        public HexAddress(byte[] value)
        {
            if (value == null)
            {
                IsNull = true;
            }
            else
            {
                if (value.Length != AddressLength)
                    throw new InvalidCastException($"32 bit expected but was {value.Length} {Hex.ToString(value)}");
                Bytes = value;
            }
        }

        public HexAddress(byte[] source, int start, int count)
        {
            if (source == null)
            {
                IsNull = true;
            }
            else
            {
                if (count != AddressLength)
                    throw new InvalidCastException($"32 bit expected but was {count}");

                Bytes = new byte[count];
                Array.Copy(source, start, Bytes, 0, count);
            }
        }


        #region ICustomJson

        protected override void SetValue(string str)
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

                Bytes = Hex.HexToBytes(str);
                if (Bytes.Length != AddressLength)
                    throw new InvalidCastException($"32 bit expected but was {Bytes} {str}");
            }
        }

        #endregion
    }
}
