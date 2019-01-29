using System;
using Cryptography.ECDSA;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class HexTransactionStatus : HexValue
    {
        private TransactionStatus? _value;
        public TransactionStatus Value
        {
            get
            {
                if (!_value.HasValue)
                    _value = ToTransactionStatus();

                return _value.Value;
            }
        }


        public HexTransactionStatus()
        {
        }

        public HexTransactionStatus(ulong blockNum)
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


        private TransactionStatus ToTransactionStatus()
        {
            if (IsNull)
                return TransactionStatus.Unknown;

            if (Bytes.Length > 1)
                throw new InvalidCastException($"Unexpected array length {Hex.ToString(Bytes)}");

            switch (Bytes[0])
            {
                case 0:
                    return TransactionStatus.Failed;
                case 1:
                    return TransactionStatus.Successful;
            }

            throw new NotImplementedException($"ToTransactionStatus = {Bytes[0]}");
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

        public enum TransactionStatus
        {
            Failed = 0,
            Successful = 1,
            Unknown = 2,
        }
    }
}