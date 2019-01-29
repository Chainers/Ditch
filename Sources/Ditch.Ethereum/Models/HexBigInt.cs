using Cryptography.ECDSA;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Ethereum.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class HexBigInt : HexValue
    {
        public override string ToString()
        {
            return $"0x{Hex.ToString(Bytes)}";
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