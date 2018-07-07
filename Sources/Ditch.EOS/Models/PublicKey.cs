using Ditch.Core.Attributes;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// public_key
    /// contracts\eosiolib\public_key.hpp
    /// </summary>
    [JsonConverter(typeof(CustomConverter))]
    public class PublicKey : ICustomJson
    {
        public string Prefix = "EOS";

        [MessageOrder(1)]
        public byte[] Data { get; set; }


        public PublicKey() { }

        public PublicKey(string value)
        {
            Data = Core.Base58.DecodePublicWif(value, Prefix);
        }

        public PublicKey(byte[] data)
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
