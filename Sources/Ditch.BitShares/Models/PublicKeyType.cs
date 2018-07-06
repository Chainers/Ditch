using Ditch.Core;
using Ditch.Core.Attributes;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    [JsonConverter(typeof(CustomConverter))]
    public class PublicKeyType : ICustomJson
    {
        public string Prefix = "BTS";

        [MessageOrder(1)]
        public byte[] Data { get; set; }

        public PublicKeyType() { }

        public PublicKeyType(string value)
        {
            Data = Base58.DecodePublicWif(value, Prefix);
        }

        public PublicKeyType(string value, string prefix)
        {
            Prefix = prefix;
            Data = Base58.DecodePublicWif(value, prefix);
        }

        public PublicKeyType(byte[] data, string prefix)
        {
            Prefix = prefix;
            Data = data;
        }

        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var value = serializer.Deserialize<string>(reader);
            if (value.StartsWith("TEST"))
                Prefix = "TEST";

            Data = Base58.DecodePublicWif(value, Prefix);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            var wif = Base58.EncodePublicWif(Data, Prefix);
            writer.WriteValue(wif);
        }

        #endregion
    }
}