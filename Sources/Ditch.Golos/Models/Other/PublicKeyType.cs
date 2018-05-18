using Ditch.Core.Attributes;
using Ditch.Core.Converters;
using Ditch.Core.Helpers;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Other
{
    [JsonConverter(typeof(CustomConverter))]
    public partial class PublicKeyType : ICustomJson
    {
        public const string AddressPrefix = "GLS";

        private string _value;

        [MessageOrder(1)]
        public byte[] Data => ToBytes();


        public PublicKeyType() { }

        public PublicKeyType(string value)
        {
            _value = value;
        }

        private byte[] ToBytes()
        {
            if (!_value.StartsWith(AddressPrefix))
                return new byte[0];

            var buf = _value.Remove(0, 3);
            var s = Base58.Decode(buf);
            var dec = Base58.CutLastBytes(s, 4);
            return dec;
        }

        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            _value = reader.Value.ToString();
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteValue(_value);
        }

        #endregion
    }
}