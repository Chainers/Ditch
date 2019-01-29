using System;
using Cryptography.ECDSA;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class HexULong : HexValue
    {
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
        }

        public HexULong(ulong blockNum)
        {
            var i = 8;
            var buf = new byte[i];
            do
            {
                var bt = (byte)(blockNum & 0xFF);
                buf[--i] = bt;

                blockNum >>= 8;
            } while (blockNum > 0);

            Bytes = new byte[8 - i];
            Array.Copy(buf, i, Bytes, 0, Bytes.Length);
        }


        private ulong ToDecimal()
        {
            if (IsNull)
                return 0;

            if (Bytes.Length > 8)
                throw new InvalidCastException($"Unexpected array length {Hex.ToString(Bytes)}");

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