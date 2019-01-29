using System;
using Cryptography.ECDSA;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class HexTimeStamp : HexValue
    {
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

        public DateTimeOffset ToDateTime()
        {
            var ut = ToUnixTime();
            return DateTimeOffset.FromUnixTimeSeconds(ut);
        }

        private long ToUnixTime()
        {
            if (IsNull)
                return 0;

            if (Bytes.Length > 8)
                throw new InvalidCastException($"Unexpected array length {Hex.ToString(Bytes)}");

            if (Bytes.Length == 8)
                return BitConverter.ToInt64(Bytes, 0);

            long buf = Bytes[0];
            for (var i = 1; i < Bytes.Length; i++)
            {
                buf <<= 8;
                buf |= Bytes[i];
            }

            return buf;
        }


        public override string ToString()
        {
            return $"{Value}";
        }

        public override void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            if (!IsNull)
            {
                var str = Hex.ToString(Bytes).TrimStart('0');
                writer.WriteValue(string.IsNullOrEmpty(str) ? "0x0" : $"0x{str}");
            }
        }
    }
}