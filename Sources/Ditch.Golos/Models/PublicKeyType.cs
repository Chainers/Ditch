using Ditch.Core;
using Ditch.Core.Attributes;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    [JsonConverter(typeof(CustomConverter))]
    public class PublicKeyType : ICustomJson
    {
        public const string Prefix = "GLS";

        [MessageOrder(1)]
        public byte[] Data { get; set; }


        public PublicKeyType() { }

        public PublicKeyType(string value)
        {
            Data = Base58.DecodePublicWif(value, Prefix);
        }

        public PublicKeyType(byte[] data)
        {
            Data = data;
        }


        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
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